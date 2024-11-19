/**
 * Calculates the next mowing date based on the executed date and client's maintenance preference.
 */
async function calculateNextMowingDate() {
    var executedDateValue = document.getElementById("ExecutedDate").value;
    var clientID = document.getElementById("ID").value;

    if (!executedDateValue) {
        return;
    }

    var executedDate = new Date(executedDateValue + "T00:00:00");
    var currentDate = new Date();
    try {
        var response = await fetch(`http://localhost:5141/api/Client/GetbyID/${clientID}`)
        var client = await response.json();
        var month = currentDate.getMonth();
        var preference;

        if (month < 2 || month === 11) {
            preference = client ? client.summerMowingPreferenceName : null;
        } else {
            preference = client ? client.winterMowingPrecerenceName : null;
        }

        var nextMowingDate;

        if (preference == "Quincenal") {
            nextMowingDate = new Date(executedDate);
            nextMowingDate.setDate(executedDate.getDate() + 15);
        } else if (preference == "Mensual") {
            nextMowingDate = new Date(executedDate);
            nextMowingDate.setMonth(executedDate.getMonth() + 1);
        }

        if (nextMowingDate) {
            document.getElementById("NextMowingDate").value = nextMowingDate.toISOString().split('T')[0];
            document.getElementById("MowingPreference").value = preference;
            document.getElementById("MowingPreferenceHidden").value = preference == "Quincenal" ? 1 : 2;

        }
    } catch (ex) {
        console.error("An error occurred:", ex);
    }
}

/**
 * Calculates the number of days without mowing based on the executed date.
 */
function calculateDaysWithoutMowing() {
    var executedDateValue = document.getElementById("ExecutedDate").value;

    if (!executedDateValue) {
        return;
    }

    var executedDate = new Date(executedDateValue + "T00:00:00");

    var currentDate = new Date();
    var timeDiff = currentDate - executedDate;

    var daysDiff = Math.floor(timeDiff / (1000 * 60 * 60 * 24));
    if (daysDiff < 0) {
        daysDiff = 0;
    }

    document.getElementById("DaysWithoutMowing").value = daysDiff;
}

/**
 * Calculates the total cost of the maintenance service based on the property area, hedge area, mowing cost per square meter, and product application cost per square meter.
 */
function calculateTotalCost() {
    const propertyArea = parseFloat(document.getElementById("PropertyArea").value) || 0;
    const hedgeArea = parseFloat(document.getElementById("HedgeArea").value) || 0;
    const mowingCostPerSquareMeter = parseFloat(document.getElementById("MowingCostPerSquareMeter").value) || 0;
    const productApplicationCostPerSquareMeter = parseFloat(document.getElementById("ProductApplicationCostPerSquareMeter").value) || 0;

    // Validación simple
    if (propertyArea < 0 || hedgeArea < 0 || mowingCostPerSquareMeter < 0 || productApplicationCostPerSquareMeter < 0) {
        alert("Por favor, ingrese valores no negativos.");
        return;
    }
    var discount = 0;
    if (propertyArea >= 400 && propertyArea <= 900) {
        discount = 0.02;
    }
    else if (propertyArea > 900 && propertyArea <= 1500) {
        discount = 0.03;
    }
    else if (propertyArea > 1500 && propertyArea <= 2000) {
        discount = 0.04;
    }
    else if(propertyArea>2000){
        discount = 0.05;
    }
    var totalDiscount = (propertyArea * mowingCostPerSquareMeter) * discount;

    const totalCostWithoutVAT = ((propertyArea + hedgeArea) * mowingCostPerSquareMeter) +
        ((propertyArea + hedgeArea) * productApplicationCostPerSquareMeter) - totalDiscount;
    const VAT_RATE = 0.13; // Tasa de IVA
    const vat = totalCostWithoutVAT * VAT_RATE;
    const totalCostWithVAT = totalCostWithoutVAT + vat;

   
    document.getElementById("TotalCost").value = totalCostWithVAT.toFixed(2);
}

document.getElementById("PropertyArea").addEventListener("input", calculateTotalCost);
document.getElementById("HedgeArea").addEventListener("input", calculateTotalCost);
document.getElementById("MowingCostPerSquareMeter").addEventListener("input", calculateTotalCost);
document.getElementById("ProductApplicationCostPerSquareMeter").addEventListener("input", calculateTotalCost);

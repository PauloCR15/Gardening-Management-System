document.addEventListener('DOMContentLoaded', function () {
    const savedProvince = "@Model.Province";  // Valor guardado del modelo
    const savedCanton = "@Model.Canton";      // Valor guardado del modelo
    const savedDistrict = "@Model.District";  // Valor guardado del modelo

    // Cargar provincias
    fetch('https://services.arcgis.com/LjCtRQt1uf8M6LGR/arcgis/rest/services/Distritos_CR/FeatureServer/0/query?where=1%3D1&outFields=NOM_PROV&returnGeometry=false&outSR=4326&f=json')
        .then(response => response.json())
        .then(data => {
            const provinces = data.features.map(province => province.attributes.NOM_PROV);
            const uniqueProvinces = [...new Set(provinces)];
            displayProvinces(uniqueProvinces, savedProvince);

            // Si hay una provincia guardada, cargar los cantones correspondientes
            if (savedProvince) {
                loadCantons(savedProvince, savedCanton);
            }
        })
        .catch(error => console.error(error));

    function displayProvinces(provinces, selectedProvince) {
        const select = document.getElementById('province-select');
        select.innerHTML = '<option value="">Seleccione una provincia</option>';
        provinces.forEach(province => {
            const option = document.createElement('option');
            option.value = province;
            option.textContent = province;
            if (province === selectedProvince) {
                option.selected = true;  // Seleccionar la provincia guardada
            }
            select.appendChild(option);
        });
    }

    function loadCantons(province, selectedCanton) {
        fetch(`https://services.arcgis.com/LjCtRQt1uf8M6LGR/arcgis/rest/services/Distritos_CR/FeatureServer/0/query?where=NOM_PROV='${province}'&outFields=NOM_CANT&returnGeometry=false&outSR=4326&f=json`)
            .then(response => response.json())
            .then(data => {
                const cantons = data.features.map(canton => canton.attributes.NOM_CANT);
                const uniqueCantons = [...new Set(cantons)];
                displayCantons(uniqueCantons, selectedCanton);

                // Si hay un cantón guardado, cargar los distritos correspondientes
                if (selectedCanton) {
                    loadDistricts(selectedCanton, savedDistrict);
                }
            })
            .catch(error => console.error(error));
    }

    function displayCantons(cantons, selectedCanton) {
        const select = document.getElementById('canton-select');
        select.innerHTML = '<option value="">Seleccione un cantón</option>';
        select.removeAttribute('disabled');
        cantons.forEach(canton => {
            const option = document.createElement('option');
            option.value = canton;
            option.textContent = canton;
            if (canton === selectedCanton) {
                option.selected = true;  // Seleccionar el cantón guardado
            }
            select.appendChild(option);
        });
    }

    function loadDistricts(canton, selectedDistrict) {
        fetch(`https://services.arcgis.com/LjCtRQt1uf8M6LGR/arcgis/rest/services/Distritos_CR/FeatureServer/0/query?where=NOM_CANT='${canton}'&outFields=NOM_DIST,ID,COD_CANT&returnGeometry=false&outSR=4326&f=json`)
            .then(response => response.json())
            .then(data => {
                const districts = data.features.map(feature => feature.attributes.NOM_DIST);
                const uniqueDistricts = [...new Set(districts)];
                displayDistricts(uniqueDistricts, selectedDistrict);
            })
            .catch(error => console.error(error));
    }

    function displayDistricts(districts, selectedDistrict) {
        const select = document.getElementById('district-select');
        select.innerHTML = '<option value="">Seleccione un distrito</option>';
        select.removeAttribute('disabled');
        districts.forEach(district => {
            const option = document.createElement('option');
            option.value = district;
            option.textContent = district;
            if (district === selectedDistrict) {
                option.selected = true;  // Seleccionar el distrito guardado
            }
            select.appendChild(option);
        });
    }

    // Eventos para cargar cantones y distritos cuando el usuario selecciona una provincia o cantón
    document.getElementById('province-select').addEventListener('change', function () {
        const selectedProvince = this.value;
        loadCantons(selectedProvince);
        document.getElementById('district-select').innerHTML = '<option value="">Seleccione un distrito</option>';
    });

    document.getElementById('canton-select').addEventListener('change', function () {
        const selectedCanton = this.value;
        loadDistricts(selectedCanton);
    });
});

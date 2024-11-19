using Models;

public class Client
{
    public int ClientID { get; set; }
    public string ClientFullName { get; set; }
    public string Province { get; set; }
    public string Canton { get; set; }
    public string District { get; set; }
    public string ClientFullDirection { get; set; }

    public MowingPreference SummerMowingPreferenceID { get; set; }
    public MowingPreference WinterMowingPreferenceID { get; set; }

    // Propiedad que devuelve el nombre del enum
    public string SummerMowingPreferenceName => SummerMowingPreferenceID.ToString();
    public string WinterMowingPrecerenceName => WinterMowingPreferenceID.ToString();

}

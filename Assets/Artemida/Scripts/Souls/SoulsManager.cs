using UnityEngine;

public class SoulsManager : IDataPersistence
{
    private static int _fireSouls;
    private static int _waterSouls;
    private static int _airSouls;
    private static int _generalSouls;

    public static int FireSouls => _fireSouls;
    public static int WaterSouls => _waterSouls;
    public static int AirSouls => _airSouls;
    public static int GeneralSouls => _generalSouls;

    public static void AddSouls(int firesouls, int watersouls, int airsouls, int gensouls){
        _fireSouls += firesouls;
        _waterSouls += watersouls;
        _airSouls += airsouls;
        _generalSouls += gensouls;
    }
    public static void RemoveSouls(int firesouls, int watersouls, int airsouls, int gensouls){
        _fireSouls -= firesouls;
        _waterSouls -= watersouls;
        _airSouls -= airsouls;
        _generalSouls -= gensouls;
    }

    public void LoadData(GameData data)
    {
        _fireSouls = data.fireSoulsForSave;
        _waterSouls = data.waterSoulsForSave;
        _airSouls = data.airSoulsForSave;
        _generalSouls = data.generalSoulsForSave;
    }

    public void SaveData(GameData data)
    {
        data.fireSoulsForSave = _fireSouls;
        data.waterSoulsForSave = _waterSouls;
        data.airSoulsForSave= _airSouls;
        data.generalSoulsForSave= _generalSouls;
    }
}

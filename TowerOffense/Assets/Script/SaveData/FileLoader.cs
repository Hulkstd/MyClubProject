using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class FileLoader{
    public void Save(SaveData saveData) {
        string path = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(path)) {
            file = File.OpenWrite(path);
        }
        else {
            file = File.Create(path);
        }

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, saveData);
        file.Close();
    }

    public SaveData Load() {
        string path = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (!File.Exists(path)) {
            return new SaveData();
        }

        file = File.OpenRead(path);

        BinaryFormatter bf = new BinaryFormatter();
        SaveData data = (SaveData)bf.Deserialize(file);
        file.Close();

        return data;
    }
}
[System.Serializable]
public class SaveData
{
    public int Speed;
    public int HP;
    public int Damage;

    public int Duration;
    public int IncreaseEffect;

    public int GetSpeed;
    public int MaxMoney;

    public int UpgradeCount;

    public SaveData()
    {
        Speed = 0;
        HP = 0;
        Damage = 0;

        Duration = 0;
        IncreaseEffect = 0;

        GetSpeed = 0;
        MaxMoney = 0;

        UpgradeCount = 0;
    }

    public SaveData(UpgradeList upgrade)
    {
        Duration = upgrade.Duration;
        IncreaseEffect = upgrade.IncreaseEffect;

        Speed = upgrade.Speed;
        HP = upgrade.HP;
        Damage = upgrade.Damage;

        GetSpeed = upgrade.GetSpeed;
        MaxMoney = upgrade.Max;

        UpgradeCount = upgrade.UpgradeCount;
    }

    public void Save()
    {
        new FileLoader().Save(this);
    }
}
/*public class SaveData{
    public int Speed;
    public int HP;
    public int Damage;

    public int Duration;
    public int IncreaseEffect;

    public int GetSpeed;
    public int MaxMoney;

    public SaveData()
    {
        Speed = 0;
        HP = 0;
        Damage = 0;

        Duration = 0;
        IncreaseEffect = 0;

        GetSpeed = 0;
        MaxMoney = 0;
    }

    public SaveData(UpgradeList upgrade) {
        Duration = upgrade.Duration;
        IncreaseEffect = upgrade.IncreaseEffect;
        Speed = upgrade.Speed;
        HP = upgrade.HP;
        Damage = upgrade.Damage;


        GetSpeed = upgrade.GetSpeed;
        MaxMoney = upgrade.Max;
    }

    public void Save()
    {
        new FileLoader().Save(this);
    }
}*/
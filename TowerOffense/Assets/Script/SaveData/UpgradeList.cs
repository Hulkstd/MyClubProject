public class UpgradeList{
    private int[] Unit = new int[3];
    private int[] Skill = new int[2];
    private int[] Money = new int[2];
    private int upgradeCount;

    public int Speed {
        get {
            return Unit[0];
        }
        set
        {
            if(Unit[0] + value > 5)
            {
                return;
            }

            Unit[0] = Unit[0] + value;
        }
    }

    public int HP
    {
        get
        {
            return Unit[1];
        }
        set
        {
            if (Unit[1] + value > 5)
            {
                return;
            }

            Unit[1] = Unit[1] + value;
        }
    }

    public int Damage
    {
        get
        {
            return Unit[2];
        }
        set
        {
            if (Unit[2] + value > 5)
            {
                return;
            }

            Unit[2] = Unit[2] + value;
        }
    }

    public int Duration
    {
        get
        {
            return Skill[0];
        }
        set
        {
            if (Skill[0] + value > 5)
            {
                return;
            }

            Skill[0] = Skill[0] + value;
        }
    }

    public int IncreaseEffect
    {
        get
        {
            return Skill[1];
        }
        set
        {
            if (Skill[1] + value > 5)
            {
                return;
            }

            Skill[1] = Skill[1] + value;
        }
    }

    public int GetSpeed
    {
        get
        {
            return Money[0];
        }
        set
        {
            if (Money[0] + value > 5)
            {
                return;
            }

            Money[0] = Money[0] + value;
        }
    }

    public int Max
    {
        get
        {
            return Money[1];
        }
        set
        {
            if (Money[1] + value > 5)
            {
                return;
            }

            Money[1] = Money[1] + value;
        }
    }


    public int UpgradeCount
    {
        get
        {
            return upgradeCount;
        }
        set
        {
            upgradeCount = value;
        }
    }


    public UpgradeList(SaveData saveData)
    {
        Speed = saveData.Speed;
        HP = saveData.HP;
        Damage = saveData.Damage;

        Duration = saveData.Duration;
        IncreaseEffect = saveData.IncreaseEffect;

        GetSpeed = saveData.GetSpeed;
        Max = saveData.MaxMoney;

        UpgradeCount = saveData.UpgradeCount;
    }

    public UpgradeList()
    {
        Speed = 0; 
        HP = 0;
        Damage = 0;

        Duration = 0;
        IncreaseEffect = 0;

        GetSpeed = 0;
        Max = 0;

        UpgradeCount = 0;
    }
}

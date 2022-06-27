using System;

[Serializable]
public class Data
{
    public float amountOfMoney;

    public override string ToString()
    {
        return $"{amountOfMoney}";
    }

}

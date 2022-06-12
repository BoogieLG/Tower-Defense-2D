using System;

[Serializable]
public struct Data
{
    public float amountOfMoney;

    public override string ToString()
    {
        return $"{amountOfMoney}";
    }

}

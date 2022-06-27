using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Data data;

    private Data tset;

    private void Start()
    {
        tset = data;
        tset.amountOfMoney++;
        Debug.Log($"1) = {data} + 2) = {tset}");
    }
}

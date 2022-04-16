using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBase : MonoBehaviour
{
    [SerializeField] private int BaseHealth;
    private void OnTriggerEnter(Collider other)
    {
      if(other.TryGetComponent<AttackComponent>(out AttackComponent attackComponent))
        {
            BaseHealth -= (int)attackComponent.Damage;
            if (BaseHealth <= 0)
            {
                Debug.Log("GameOVer");
            }
        }
    }
}

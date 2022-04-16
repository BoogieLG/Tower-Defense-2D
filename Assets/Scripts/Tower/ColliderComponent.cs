using System;
using System.Collections.Generic;
using UnityEngine;

public class ColliderComponent : MonoBehaviour, IComparer<HealthComponent>
{

    [SerializeField] private List<HealthComponent> collidersInRadius;
    public List<HealthComponent> CollidersInRadius
    {
        get
        {
            collidersInRadius.Sort(Compare);
            return collidersInRadius;
        }
    }

    public enum listChanged
    {
        Added,
        Removed
    }

    public Action<HealthComponent,listChanged> OnChangedList { get; set; }
    public Action<HealthComponent> OnRemovedFromList { get; set; }

    private void OnTriggerStay(Collider other)
    {
        HealthComponent healthComponent = other.GetComponent<HealthComponent>();
        bool IsExist = collidersInRadius.Contains(healthComponent);
        if (!IsExist)
        {
            collidersInRadius.Add(healthComponent);
            OnChangedList?.Invoke(healthComponent, listChanged.Added);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        HealthComponent temp = collider.GetComponent<HealthComponent>();
        RemoveFromList(temp);
    }

    public void RemoveFromList(HealthComponent temp)
    {
        collidersInRadius.Remove(temp);
        OnChangedList?.Invoke(temp, listChanged.Removed);
        OnRemovedFromList?.Invoke(temp);
    }

    public int Compare(HealthComponent x, HealthComponent y)
    {
        if (x.CurrentHealth > y.CurrentHealth)
        {
            return 1;
        }
        else if (x.CurrentHealth < y.CurrentHealth)
        {
            return -1;
        }
        return 0;
    }
}

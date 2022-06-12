using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ColliderComponent : MonoBehaviour, IComparer<HealthComponent>
{

    [SerializeField] protected List<HealthComponent> collidersInRadius;
    public virtual List<HealthComponent> CollidersInRadius
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

    public Action<HealthComponent, listChanged> OnChangedList { get; set; }
    public Action<HealthComponent> OnRemovedFromList { get; set; }

    private void OnTriggerStay2D(Collider2D other)
    {
        HealthComponent healthComponent = other.GetComponent<HealthComponent>();
        bool IsExist = collidersInRadius.Contains(healthComponent);
        if (!IsExist)
        {
            collidersInRadius.Add(healthComponent);
            OnChangedList?.Invoke(healthComponent, listChanged.Added);
        }
    }

    protected void OnTriggerExit2D(Collider2D collider)
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

    public virtual int Compare(HealthComponent x, HealthComponent y)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public BarController healthBar,fuelBar;

    public ResourceCounterController resources;

    public void AddResource()
    {
        resources.Increment();
    }

    public void Damage(int amount)
    {
        healthBar.Reduce(amount);
    }

    public void SpendFuel(int amount)
    {
        fuelBar.Reduce(amount);
    }
}

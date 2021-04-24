using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    float remainingFuel = 100;

    float fuelBurnRate = 0.3f;

    public float highBurnRate = 1.3f;

    public float lowBurnRate = 0.3f;

    public void ToggleConsumption()
    {
        StartCoroutine(consumeFuel());
    }

    public void ToggleHighBurnRate()
    {
        fuelBurnRate = highBurnRate;
    }

    public void ToggleLowBurnRate()
    {
        fuelBurnRate = lowBurnRate;
    }

    public void AddFuel(float amount)
    {
        remainingFuel = Mathf.Min(100.0f, remainingFuel + amount);
        GameManager.Instance.ui.SetFuel(remainingFuel);
    }

    IEnumerator consumeFuel()
    {
        while (remainingFuel > 0)
        {
            remainingFuel -= fuelBurnRate;
            GameManager.Instance.ui.SetFuel(remainingFuel);
            yield return new WaitForSeconds(1.0f);
        }
    }


}

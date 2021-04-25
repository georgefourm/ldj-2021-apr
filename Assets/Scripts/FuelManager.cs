using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    public float totalFuel = 100;

    float remainingFuel = 100;

    float fuelBurnRate = 0.3f;

    public float highBurnRate = 1.3f;

    public float lowBurnRate = 0.3f;

    private IEnumerator coroutine;

    public void Reset()
    {
        remainingFuel = totalFuel;
        fuelBurnRate = lowBurnRate;
        GameManager.Instance.ui.SetFuel(remainingFuel);
    }

    public void StartConsumption()
    {
        coroutine = consumeFuel();
        StartCoroutine(coroutine);
    }

    public void StopConsumption()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
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
        if (remainingFuel == 0)
        {
            return;
        }
        remainingFuel = Mathf.Min(100.0f, remainingFuel + amount);
        GameManager.Instance.ui.SetFuel(remainingFuel);
    }

    IEnumerator consumeFuel()
    {
        while (remainingFuel > 0)
        {
            remainingFuel = Mathf.Max(0,remainingFuel - fuelBurnRate);
            GameManager.Instance.ui.SetFuel(remainingFuel);
            yield return new WaitForSeconds(1.0f);
        }
        GameManager.Instance.SetFuelDepleted();
    }


}

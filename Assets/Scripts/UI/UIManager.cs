using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public BarController healthBar,fuelBar;

    public ResourceCounterController resources;

    public GameObject gameOverPanel;

    public Text gameOverText;

    public TextPanelController text;

    public void InitResources(int amount)
    {
        resources.maxAmount = amount;
        resources.ResetCounter();
    }

    public void InitHealth(int amount)
    {
        healthBar.MaxValue = amount;
        healthBar.SetAmount(amount);
    }

    public void AddResource()
    {
        resources.Increment();
    }

    public void Damage(int amount)
    {
        healthBar.Reduce(amount);
    }

    public void InitFuel(float amount)
    { 
        fuelBar.MaxValue = (Mathf.CeilToInt(amount));
        fuelBar.SetAmount(Mathf.CeilToInt(amount));
    }

    public void SetFuel(float amount)
    {
        fuelBar.SetAmount(Mathf.CeilToInt(amount));
    }

    public void ShowGameOver(string message)
    {
        gameOverText.text = message;
        gameOverPanel.SetActive(true);
    }

    public void HideGameOver()
    {
        gameOverPanel.SetActive(false);
    }

    public void Reset()
    {
        HideGameOver();
        resources.ResetCounter();
        healthBar.Reset();
        fuelBar.Reset();
        text.StartText();
    }
}

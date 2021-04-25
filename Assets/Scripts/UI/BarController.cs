using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{ 
    public Image barFill;

    public Text barText;

    public int MaxValue = 100;

    int currValue;

    void Start()
    {
        barText.text = MaxValue.ToString();
    }

    public void Reduce(int amount)
    {
        currValue = Mathf.Max(currValue - amount, 0);
        UpdateUi();
    }

    public void SetAmount(int amount)
    {
        currValue = amount;
        UpdateUi();
    }

    protected void UpdateUi()
    {
        barFill.fillAmount = (float) currValue / MaxValue;
        barText.text = currValue.ToString();
    }
}

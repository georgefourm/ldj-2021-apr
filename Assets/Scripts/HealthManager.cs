using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int totalHealth = 100;

    int currentHealth;

    public void Reset()
    {
        currentHealth = totalHealth;
    }
    public void Damage(int amount)
    {
        currentHealth = Mathf.Max(0, currentHealth - amount);
        GameManager.Instance.ui.Damage(amount);
        if (currentHealth == 0)
        {
            GameManager.Instance.SetHealthDepleted();
        }
    }
}

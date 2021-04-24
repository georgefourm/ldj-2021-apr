using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player;

    public UIManager ui;
    public static GameManager Instance { get; private set; }

    int resourcesCollected = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectResource()
    {
        ui.AddResource();
        resourcesCollected++;
    }

    public void ToggleMovement()
    {
        player.canMove = !player.canMove;
    }

}

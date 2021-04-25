using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [HideInInspector]
    public PlayerController player;

    [HideInInspector]
    public UIManager ui;

    [HideInInspector]
    public FuelManager fuel;

    [HideInInspector]
    public ResourceManager resources;

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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        ui = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        fuel = GetComponent<FuelManager>();
        ui.InitFuel(fuel.maxFuel);

        resources = GetComponent<ResourceManager>();
        ui.InitResources(resources.resourcesRequired);
        
        RestartLevel();
    }

    public void RestartLevel()
    {
        ui.HideGameOver();
        player.Reset();
        fuel.Reset();
        
        resources.Reset();
        ui.resources.ResetCounter();

        ui.text.StartText();
    }

    public void StartLevel()
    {
        player.canMove = true;
        fuel.ToggleConsumption();
        resources.PopulateResourceAreas();
    }

    public void SetResourcesCompleted()
    {

    }

    public void SetFuelDepleted()
    {
        player.canMove = false;
        ui.ShowGameOver("Fuel Depleted");
    }

    public void SetHealthDepleted()
    {
        player.canMove = false;
        ui.ShowGameOver("You were killed");
    }

    public void CompleteLevel()
    {

    }

    public void Quit()
    {

    }


}

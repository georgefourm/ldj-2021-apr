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
    public HealthManager health;

    [HideInInspector]
    public ResourceManager resources;

    GameObject goal;

    public GameObjectPooler pooler;

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
        pooler = GetComponent<GameObjectPooler>();
        pooler.CreatePool("resources");
        pooler.CreatePool("projectiles");

        goal = GameObject.FindGameObjectWithTag("Finish");
        goal.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        ui = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        fuel = GetComponent<FuelManager>();
        ui.InitFuel(fuel.totalFuel);

        resources = GetComponent<ResourceManager>();
        ui.InitResources(resources.GetTotalResouces());

        health = GetComponent<HealthManager>();
        ui.InitHealth(health.totalHealth);

        RestartLevel();
    }

    public void RestartLevel()
    {
        player.Reset();
        fuel.Reset();
        resources.Reset();
        health.Reset();

        ui.Reset();
        
        goal.SetActive(false);
    }

    public void StartLevel()
    {
        player.canMove = true;
        fuel.StartConsumption();
        resources.PopulateResourceAreas();
    }

    public void SetResourcesCompleted()
    {
        goal.SetActive(true);
    }

    public void SetFuelDepleted()
    {
        player.canMove = false;
        ui.ShowGameOver("Fuel Depleted");
    }

    public void SetHealthDepleted()
    {
        player.canMove = false;
        fuel.StopConsumption();
        ui.ShowGameOver("You were killed");
    }

    public void CompleteLevel()
    {
        LevelManager.Instance.NextLevel();
    }

    public void Quit()
    {
        LevelManager.Instance.QuitToMenu();
    }


}

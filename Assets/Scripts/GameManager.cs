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

    GameObject[] enemies;

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

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        RestartLevel();
    }

    public void RestartLevel()
    {
        player.Reset();
        fuel.Reset();
        resources.Reset();
        health.Reset();
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyController>().Reset();
        }
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
        ui.ShowGameOver("Fuel depleted");
    }

    public void SetHealthDepleted()
    {
        player.canMove = false;
        fuel.StopConsumption();
        ui.ShowGameOver("You were killed");
    }

    public void BlackHoleGameOver()
    {
        player.canMove = false;
        fuel.StopConsumption();
        ui.ShowGameOver("You were pulled into a black hole");
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

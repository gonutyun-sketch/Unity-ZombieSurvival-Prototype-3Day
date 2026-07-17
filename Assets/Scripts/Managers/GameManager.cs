using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentWave = 1;

    public EnemySpawner spawner;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        StartWave();
    }


    void StartWave()
    {
        Debug.Log("Wave " + currentWave + " Start!");

        int zombieAmount = currentWave * 5;

        spawner.SpawnWave(zombieAmount);
    }
}
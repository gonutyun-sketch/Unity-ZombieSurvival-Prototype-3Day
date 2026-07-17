using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject zombiePrefab;
    public Transform spawnPoint;

    [Header("Random Spawn Range")]
    public float spawnRadius = 3f;

    public void SpawnWave(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;

            Vector3 spawnPosition = spawnPoint.position + new Vector3(
                randomOffset.x,
                randomOffset.y,
                0f
            );

            Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
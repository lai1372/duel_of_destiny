using System.Collections.Generic;
using UnityEngine;
public interface ISpawnable
{
    void Spawn();
}
public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabsToSpawn;
    public Transform spawnPoints;
    public string prefabName;

    public GameObject spawnedEnemy;

    public void SpawnRandomPrefab()
    {
        // If no prefabs or spawn points, exit
        if (prefabsToSpawn.Count == 0)
        {
            Debug.LogWarning("No prefabs to spawn or no spawn points defined.");
            return;
        }

        // Select a random prefab from the list prefabsToSpawn
        int prefabIndex = Random.Range(0, prefabsToSpawn.Count);
        GameObject prefabToSpawn = prefabsToSpawn[prefabIndex];

        // Instantiate the selected prefab at the spawner's position and rotation
        spawnedEnemy = Instantiate(prefabToSpawn, transform.position, transform.rotation);
        prefabName = spawnedEnemy.name;

        Enemy enemyComponent = spawnedEnemy.GetComponent<Enemy>();

        // Log the spawn event with enemy details
        if (enemyComponent != null)
        {
            Debug.Log(prefabName + " spawned! " + prefabName + " Attack power: " + enemyComponent.getAttackPower() + ", Health: " + enemyComponent.getHealth());
        }
        else
        {
            Debug.LogWarning("Enemy component not found on spawned enemy.");
        }
    }
    void Start()
    {
        SpawnRandomPrefab();

    }

    void Update()
    {

    }
}

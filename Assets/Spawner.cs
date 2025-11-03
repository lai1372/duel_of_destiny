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
        if (prefabsToSpawn.Count == 0)
        {
            Debug.LogWarning("No prefabs to spawn or no spawn points defined.");
            return;
        }

        int prefabIndex = Random.Range(0, prefabsToSpawn.Count);
        GameObject prefabToSpawn = prefabsToSpawn[prefabIndex];

        spawnedEnemy = Instantiate(prefabToSpawn, transform.position, transform.rotation);
        prefabName = spawnedEnemy.name;

        Debug.Log("Spawning prefab: " + prefabName);

        Enemy enemyComponent = spawnedEnemy.GetComponent<Enemy>();
        if (enemyComponent != null)
        {
            Debug.Log("Spawned enemy attack power: " + enemyComponent.getAttackPower());
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

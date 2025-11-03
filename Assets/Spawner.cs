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

        // Select a random prefab
        int prefabIndex = Random.Range(0, prefabsToSpawn.Count);
        GameObject prefabToSpawn = prefabsToSpawn[prefabIndex];
        spawnedEnemy = prefabToSpawn;
        prefabName = prefabToSpawn.name;

        Debug.Log("Spawning prefab: " + prefabName);

        // Instantiate the prefab at the selected spawn point
        Instantiate(prefabToSpawn, this.transform.position, this.transform.rotation);

        Enemy enemyComponent = spawnedEnemy.GetComponent<Enemy>();
        Debug.Log("Spawned enemy attack power: " + enemyComponent.getAttackPower());


    }
    void Start()
    {
        SpawnRandomPrefab();

    }

    void Update()
    {

    }
}

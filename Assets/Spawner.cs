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
        prefabName = prefabToSpawn.name;
        Debug.Log("Spawning prefab: " + prefabName);

        // Select a random spawn point
        // int spawnPointIndex = Random.Range(0, spawnPoints.childCount);

        // Transform spawnPoint = spawnPoints.GetChild(spawnPointIndex);

        // Instantiate the prefab at the selected spawn point
        Instantiate(prefabToSpawn, this.transform.position, this.transform.rotation);
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       SpawnRandomPrefab(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

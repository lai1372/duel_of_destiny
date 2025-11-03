using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;

    public void SpawnPlayer()
    {
        Debug.Log("Spawning prefab: Player");


        GameObject playerInstance = Instantiate(playerPrefab, transform.position, transform.rotation);

        Player playerComponent = playerInstance.GetComponent<Player>();
        Debug.Log("Spawned player attack power: " + playerComponent.getDefaultAttackPower());
    }

    void Start()
    {
        SpawnPlayer();
    }
}
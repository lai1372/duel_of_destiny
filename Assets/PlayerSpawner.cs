using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;

    public void SpawnPlayer()
    {
        // Instantiate the player prefab at the spawner's position and rotation
        GameObject playerInstance = Instantiate(playerPrefab, transform.position, transform.rotation);

        // Get the Player component to access its properties
        Player playerComponent = playerInstance.GetComponent<Player>();

        // Log the spawn event with player details
        Debug.Log("Player spawned! Attack Power: " + playerComponent.getAttackPower() + ", Health: " + playerComponent.getHealth());


    }

    void Start()
    {
        SpawnPlayer();
    }
}
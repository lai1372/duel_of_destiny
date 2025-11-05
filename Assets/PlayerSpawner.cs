using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;

    public void SpawnPlayer()
    {
        Debug.Log("Spawning Player");


        GameObject playerInstance = Instantiate(playerPrefab, transform.position, transform.rotation);

        Player playerComponent = playerInstance.GetComponent<Player>();
        Debug.Log("Spawned player attack power: " + playerComponent.getDefaultAttackPower());
        Debug.Log("Player health: " + playerComponent.getHealth());

    }

    void Start()
    {
        SpawnPlayer();
    }
}
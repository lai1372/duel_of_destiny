using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;

    public void SpawnPlayer()
    {

        GameObject playerInstance = Instantiate(playerPrefab, transform.position, transform.rotation);

        Player playerComponent = playerInstance.GetComponent<Player>();
        Debug.Log("Player spawned! Attack Power: " + playerComponent.getAttackPower() + ", Health: " + playerComponent.getHealth());


    }

    void Start()
    {
        SpawnPlayer();
    }
}
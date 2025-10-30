using Unity.VisualScripting;
using UnityEngine;


public class Player : Character
{
    Rigidbody2D rb;
    float speed;
    float horizontalInput;
    Spawner spawner;
    public Player() : base(playerName: "Hero", attackPower: 15)
    {

    }
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        speed = 3f;
        gameObject.transform.position = new Vector2(-3f, 0f);

        spawner = FindFirstObjectByType<Spawner>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive())
        {
            FindFirstObjectByType<GameManager>().GameOver("Enemy");
            gameObject.SetActive(false); // Optional: hide player
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            bool used = useMedkit();
            if (used)
            {
                Debug.Log("Player used a medkit!");
            }
            else
            {
                Debug.Log("Player tried to use a medkit but had none.");
            }
        }
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
        {
            rb.AddForce(new Vector2(horizontalInput * speed, 0f));
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * 500f); // Adjust force as needed
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack(spawner.spawnedEnemy.GetComponent<Enemy>());
            Debug.Log("Player attacked the enemy!");
            Debug.Log("Enemy Health after attack: " + spawner.spawnedEnemy.GetComponent<Enemy>().getHealth());

            if (!spawner.spawnedEnemy.GetComponent<Enemy>().isAlive())
            {
                FindFirstObjectByType<GameManager>().GameOver("Player");
            }
        }

        if (!isAlive())
        {
            FindFirstObjectByType<GameManager>().GameOver("Enemy");
        }
    }
}
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
        speed = 3f; // Movement speed
        gameObject.transform.position = new Vector2(-3f, 0f); // Starting position

        spawner = FindFirstObjectByType<Spawner>();

    }

    // Update is called once per frame
    void Update()
    {
        // If player is not alive, trigger game over with Enemy as winner
        if (!isAlive())
        {
            FindFirstObjectByType<GameManager>().GameOver("Enemy");
            gameObject.SetActive(false);
        }

        // Handle medkit usage on 'M' key press
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

        // Handle movement input with arrow keys
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
        {
            rb.AddForce(new Vector2(horizontalInput * speed, 0f));
        }

        // Handle jump when up arrow key pressed
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * 500f);
        }

        // Handle attack on spacebar press
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
        // If player is not alive, trigger game over with Enemy as winner
        if (!isAlive())
        {
            FindFirstObjectByType<GameManager>().GameOver("Enemy");
        }
    }
}
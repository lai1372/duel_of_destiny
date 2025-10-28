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
        speed = 5f;
        gameObject.transform.position = new Vector2(-3f, 0f);

        spawner = FindFirstObjectByType<Spawner>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
        {
            rb.AddForce(new Vector2(horizontalInput * speed, 0f));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // attack(insert instance of enemy here);
            attack(spawner.spawnedEnemy.GetComponent<Enemy>());
            Debug.Log("Player attacked the enemy!");
            Debug.Log("Enemy Health after attack: " + spawner.spawnedEnemy.GetComponent<Enemy>().getHealth());
        }
    }
}
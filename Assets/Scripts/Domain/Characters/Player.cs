using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    float horizontalInput;
    Spawner spawner;
    public Player() : base(playerName: "Hero")
    {

    }

    public override int getAttackPower()
    {
        return getDefaultAttackPower() + 9; // Player has a bonus of 9 to default attack power
    }
    public override void attack(Character target)
    {
        int damage = getAttackPower(); // Player's attack power
        target.takeDamage(damage); // Attack enemy
    }
    Animator animator;
    Transform model;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        speed = 3f; // Movement speed
        gameObject.transform.position = new Vector2(-3f, 0f); // Starting position

        spawner = FindFirstObjectByType<Spawner>();
        animator = GetComponentInChildren<Animator>();
        model = animator != null ? animator.transform : null;

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
        if (animator != null)
        {
            float v = rb.linearVelocity.magnitude;
            animator.SetFloat("Speed", v);

            // Face direction by rotating model on Y axis
            if (model != null)
            {
                model.localRotation = Quaternion.Euler(0f, (horizontalInput < 0) ? 180f : 0f, 0f);
            }
        }
        // Handle attack on spacebar press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (animator != null)
                animator.SetTrigger("Attack");

            GameObject enemyObj = spawner.spawnedEnemy;
            if (enemyObj != null)
            {
                float distance = Vector2.Distance(transform.position, enemyObj.transform.position);
                if (distance <= 5f)
                {
                    Enemy enemy = enemyObj.GetComponent<Enemy>();
                    attack(enemy);
                    Debug.Log("Player attacked the enemy!");
                    Debug.Log("Enemy Health after attack: " + enemy.getHealth());

                    if (!enemy.isAlive())
                    {
                        FindFirstObjectByType<GameManager>().GameOver("Player");
                    }
                }
                else
                {
                    Debug.Log("Enemy is too far to attack.");
                }
            }

            // If player is not alive, trigger game over with Enemy as winner
            if (!isAlive())
            {
                FindFirstObjectByType<GameManager>().GameOver("Enemy");

            }
        }
    }
}
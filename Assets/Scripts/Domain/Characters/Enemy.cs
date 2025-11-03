using UnityEngine;

// TODO: Enemy to use medkit and follow player and health bar
public abstract class Enemy : Character
{

    [SerializeField] GameObject player;
    [SerializeField] float defaultStep = 0.05f;

    public Enemy() : base(playerName: "Enemy", attackPower: 5)
    {
    }

    // Abstract method to get attack power
    public abstract int getAttackPower();

    void OnCollisionEnter2D(Collision2D collision) // Detect collision with player, attack on contact
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Character playerCharacter = collision.gameObject.GetComponent<Character>();
            if (playerCharacter != null)
            {
                attack(playerCharacter);
                Debug.Log("Enemy attacked the player on collision!");
                Debug.Log("Player Health after attack: " + playerCharacter.getHealth());
            }
        }
    }
    void Start()
    {
        // Initialize enemy position
        // transform.position = new Vector2(3f, 0f);
        Debug.Log("Enemy Health: " + getHealth());

        player = GameObject.FindWithTag("Player");

    }

    void Update()
    {
        // Move towards player
        if (player != null && isAlive())
        {
            float step = defaultStep * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
        }


        // Use medkit if health is 20 or less
        if (getHealth() <= 20)
        {
            bool used = useMedkit();
            if (used)
            {
                Debug.Log("Enemy used a medkit!");
            }
            else
            {
                Debug.Log("Enemy tried to use a medkit but had none.");
            }
        }


        // Trigger Game Over when enemy dies
        if (!isAlive())
        {
            GameManager gm = FindFirstObjectByType<GameManager>();
            if (gm != null)
            {
                gm.GameOver("Player");
            }
            else
            {
                Debug.LogWarning("GameManager not found in scene.");
            }

            Destroy(gameObject);
        }
    }

}

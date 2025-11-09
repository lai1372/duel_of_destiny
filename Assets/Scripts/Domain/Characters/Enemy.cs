using UnityEngine;

public abstract class Enemy : Character
{

    [SerializeField] GameObject player;
    [SerializeField] float defaultStep = 0.05f;

    public Enemy() : base(playerName: "Enemy")
    {
    }
    Animator animator;
    Transform model;

    void OnCollisionEnter2D(Collision2D collision) // Detect collision with player, attack on contact
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Character playerCharacter = collision.gameObject.GetComponent<Character>();
            if (playerCharacter != null)
            {
                // Trigger attack animation
                if (animator != null) animator.SetTrigger("Attack");

                // Apply damage (consider timing this with an Animation Event for better feel)
                attack(playerCharacter);

                Debug.Log("Enemy attacked the player on collision! Player Health after attack: " + playerCharacter.getHealth());
            }
        }
    }
    void Start()
    {

        player = GameObject.FindWithTag("Player");

        animator = GetComponentInChildren<Animator>();

        if (animator != null)
        {
            // Ensure movement stays code-driven
            animator.applyRootMotion = false;
            model = animator.transform;
        }
    }

    void Update()
    {
        // Move towards player
        float speedThisFrame = 0f;
        if (player != null)
        {
            float step = defaultStep * Time.deltaTime;
            Vector2 start = transform.position;
            Vector2 target = player.transform.position;

            // Face the player by rotating the model
            if (model != null)
            {
                bool faceRight = (target.x - start.x) >= 0f;
                model.localRotation = Quaternion.Euler(0f, faceRight ? 180f : 0f, 0f);

            }

            // Move
            Vector2 newPos = Vector2.MoveTowards(start, target, step);
            transform.position = newPos;

            // Approximate speed for animation blending
            speedThisFrame = (newPos - start).magnitude / Time.deltaTime; // world units / sec
        }

       
        if (animator != null)
        {
            // Drive Idle<->Walk
            animator.SetFloat("Speed", speedThisFrame);

        }

        // Use medkit if health is 20 or less
        if (getHealth() <= 20 && getMedkits() > 0)
        {
            useMedkit();
            Debug.Log("Enemy used a medkit! Enemy Health after using medkit: " + getHealth());
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
        }
    }

}

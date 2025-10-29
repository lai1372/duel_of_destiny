using UnityEngine;


    public abstract class Enemy : Character
{
 [SerializeField] GameObject player;
    public Enemy() : base(playerName: "Enemy", attackPower: 5)
    {


    }
    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        Character playerCharacter = collision.gameObject.GetComponent<Character>();
        if (playerCharacter != null)
        {
            attack(playerCharacter);
            Debug.Log("Enemy attacked the player on collision!");
        }
    }
}
    void Start()
    {
        gameObject.transform.position = new Vector2(3f, 0f);
        Debug.Log("Enemy spawned at position: " + gameObject.transform.position);
        Debug.Log("Enemy Health: " + getHealth());
        Debug.Log("Enemy Attack Power: " + getDefaultAttackPower());
    }
    
    void Update()
    {

    if (player != null && isAlive())
    {
        float step = 2f * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
    }

    if (getHealth() <= 20)
    {
        useMedkit();
    }

    if (!isAlive())
    {
        FindFirstObjectByType<GameManager>().GameOver("Player");
        Destroy(gameObject);
    }
}
        
    }

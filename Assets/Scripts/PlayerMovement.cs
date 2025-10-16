using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    // unity properties
    
    Rigidbody2D rb;
    float speed;
    float horizontalInput;
    //character properties

    [SerializeField] private string playerName;

    // Always to be set to 100 by default when a new character is instantiated
    [SerializeField] private int health;

    // To differ based on if player or enemy. Enemy will have lower power.
    [SerializeField] private int attackPower;
    [SerializeField] string weapon;
    public List<GameObject> inventory;

    // Removed role from class diagram as not necessary to be defined. Instead, create enemy or player class


    public PlayerMovement(string playerName, int attackPower, string weapon, List<GameObject> inventory)
    {
        this.playerName = playerName;
        this.health = 100;
        this.attackPower = attackPower;
        this.weapon = weapon;
        this.inventory = inventory;
    }

    public string getName()
    {
        return playerName;
    }
    public int getHealth()
    {
        return health;
    }

    public void setHealth(int health)
    {
        this.health = health;
    }

    public void attack(Character target)
    {
        target.setHealth(target.getHealth() - this.attackPower);
    }

    public void takeDamage(int damage)
    {
        this.health -= damage;
    }

    public bool isAlive()
    {
        return this.health > 0;
    }

    public void useItem(GameObject item)
    {
        if (inventory.Contains(item))
        {
            // Implement item effects here
            inventory.Remove(item);
        }
    }





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
        {
            rb.AddForce(new Vector2(horizontalInput * speed, 0f));
        }
    }
}

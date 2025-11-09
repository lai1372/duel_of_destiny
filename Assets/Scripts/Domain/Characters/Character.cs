using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour

{

    // Character properties
    [SerializeField] private string playerName;
    [SerializeField] private int medkits;
    [SerializeField] protected int health;
    [SerializeField] protected int defaultAttackPower;


    // Character constructor
    public Character(string playerName)
    {
        this.playerName = playerName;
        this.health = 100;
        this.medkits = 1;

    }

    // Initialize default values
    void Awake()
    {
        health = 100;
        medkits = 1;
        defaultAttackPower = 5;
    }


    // Getter and Setter methods
    public string getName()
    {
        return playerName;
    }
    public int getHealth()
    {
        return health;
    }

    public int getMedkits()
    {
        return medkits;
    }

    public void setHealth(int health)
    {
        this.health = Mathf.Clamp(health, 0, 100); // Keeps health between 0 and 100
    }

    public int getDefaultAttackPower()
    {
        return defaultAttackPower;
    }

    // Character actions
    public virtual void attack(Character target)
    {
        target.setHealth(target.getHealth() - this.defaultAttackPower);
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
    }

    // Abstract method to get attack power
    public abstract int getAttackPower();

    public bool isAlive()
    {
        return this.health > 0;
    }


    public bool useMedkit()
    {
        if (medkits > 0)
        {
            setHealth(getHealth() + 20); // Each medkit restores 20 health
            if (getHealth() > 100)
            {
                setHealth(100); // Cap health at 100
            }
            medkits--; // Decrease medkit count
            return true;
        }
        Debug.Log("No medkits left to use.");
        return false;
    }

}

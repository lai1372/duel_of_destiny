using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour

{
    
    // Character properties
    [SerializeField] private string playerName;
    [SerializeField] private int health;
    [SerializeField] private int medkits;
    [SerializeField] private int defaultAttackPower;

    public Character(string playerName, int attackPower)
    {
        this.playerName = playerName;
        this.health = 100;
        this.defaultAttackPower = attackPower;
        this.medkits = 1;

    }
    void Awake()
{
    health = 100;
    medkits = 1;
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
    this.health = Mathf.Clamp(health, 0, 100); // Keeps health between 0 and 100
}

    public int getDefaultAttackPower()
    {
        return defaultAttackPower;
    }
    public void setAttackPower(int attackPower)
    {
        this.defaultAttackPower = attackPower;
    }

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

    public bool isAlive()
    {
        return this.health > 0;
    }


    public bool useMedkit()
    {
        Debug.Log("Attempting to use medkit. Medkits available: " + medkits);
        if (medkits > 0)
        {
            setHealth(getHealth() + 20); // Each medkit restores 20 health
            if (getHealth() > 100)
            {
                setHealth(100); // Cap health at 100
            }
            medkits--; // Decrease medkit count
            Debug.Log("Medkit used. Current health: " + getHealth() + ". Medkits left: " + medkits);
            return true;
        }
        return false;
    }

}

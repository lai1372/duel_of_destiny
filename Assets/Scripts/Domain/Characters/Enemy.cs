using UnityEngine;


    public abstract class Enemy : Character
{

    public Enemy() : base(playerName: "Enemy", attackPower: 5)
    {
    }
     void Start()
    {
        gameObject.transform.position = new Vector2(3f, 0f);
        Debug.Log("Enemy spawned at position: " + gameObject.transform.position);
        Debug.Log("Enemy Health: " + getHealth());
        Debug.Log("Enemy Attack Power: " + getDefaultAttackPower());
    }
    }
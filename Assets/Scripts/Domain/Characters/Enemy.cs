using UnityEngine;


    public abstract class Enemy : Character
{
   Rigidbody2D rb;

    public Enemy() : base(playerName: "Enemy", attackPower: 5)
    {
    }
     void Start()
    {
        gameObject.transform.position = new Vector2(3f, 0f);
    }
    }
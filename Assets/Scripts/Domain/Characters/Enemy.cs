using UnityEngine;


    public abstract class Enemy : Character
    {
        public Enemy() : base(playerName: "Enemy", attackPower: 5, weapon: "Claws")
        {
        }
    }
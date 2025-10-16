using UnityEngine;

namespace Domain.Characters
{
    public abstract class Character : MonoBehaviour
    {
        private int health;

        public Character()
        {
            this.health = 100; // All characters start with full health
        }


        public int getHealth()
        {
            return health;
        }
    }
}
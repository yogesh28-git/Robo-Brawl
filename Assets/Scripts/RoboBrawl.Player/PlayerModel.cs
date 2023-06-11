using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Player
{
    public class PlayerModel
    {
        public float MoveSpeed { get { return moveSpeed; } set { } }
        public float BulletSpeed { get { return bulletSpeed; } set { } }
        public int Damage { get { return damage; } private set { } }

        private int currHealth = 800;
        private int maxHealth = 800;
        private int damage = 30;
        private float moveSpeed = 100f;
        private float bulletSpeed = 10f;

        public int GetHealth( )
        {
            return currHealth;
        }
        public void SetHealth( int health )
        {
            currHealth = health;
        }
        public void ResetHealth( )
        {
            currHealth = maxHealth;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Enemy
{
    public class SmallEnemyModel
    {
        public float MoveSpeed { get { return moveSpeed; } private set { } }
        public float BulletSpeed { get { return bulletSpeed; } private set { } }
        public int Damage { get { return damage; } private set { } }

        private int maxHealth = 100;
        private int currHealth = 100;
        private int damage = 20;
        private float moveSpeed = 100f;
        private float bulletSpeed = 6f;

        public int GetHealth( )
        {
            return currHealth;
        }
        public void SetHealth(int health )
        {
            currHealth = health;    
        }
        public void ResetHealth( )
        {
            currHealth = maxHealth;
        }
    }
}

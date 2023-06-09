using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Enemy
{
    public class SmallEnemyModel
    {
        public float MoveSpeed { get { return moveSpeed; } set { } }
        public float BulletSpeed { get { return bulletSpeed; } set { } }

        private float moveSpeed = 100f;
        private float bulletSpeed = 6f;
    }
}

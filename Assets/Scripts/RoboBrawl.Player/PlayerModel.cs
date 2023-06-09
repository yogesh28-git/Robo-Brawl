using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Player
{
    public class PlayerModel
    {
        public float MoveSpeed { get { return moveSpeed; } set { } }
        public float BulletSpeed { get { return bulletSpeed; } set { } }

        private float moveSpeed = 100f;
        private float bulletSpeed = 10f;
    }
}

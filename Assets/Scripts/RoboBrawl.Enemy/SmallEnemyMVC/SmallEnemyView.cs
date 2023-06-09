using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Enemy
{
    public class SmallEnemyView : MonoBehaviour
    {
        private SmallEnemyController smallEnemyController;
        public void SetController( SmallEnemyController smallEnemyController )
        {
            this.smallEnemyController = smallEnemyController;
        }

    }
}

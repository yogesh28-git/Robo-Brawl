using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Enemy
{
    public class BossEnemyView : MonoBehaviour
    {
        private BossEnemyController bossController;
        public void SetController(BossEnemyController bossController )
        {
            this.bossController = bossController;
        }
    }
}

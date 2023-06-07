using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Enemy
{
    public class BossEnemyController
    {
        public BossEnemyView BossView { get { return bossView; } set { } }
        public BossEnemyModel BossModel { get { return bossModel; } set { } }

        private BossEnemyView bossView;
        private BossEnemyModel bossModel;
        public BossEnemyController( BossEnemyView bossView, BossEnemyModel bossModel )
        {
            this.bossView = bossView;
            this.bossModel = bossModel;

            bossView.SetController( this );
            bossView.gameObject.SetActive( true );
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Enemy
{
    public class SmallEnemyController: IDamagable
    {
        public SmallEnemyModel SmallEnemyModel { get { return smallEnemyModel; } set { } }
        public SmallEnemyView SmallEnemyView { get { return smallEnemyView; } set { } }

        private SmallEnemyModel smallEnemyModel;
        private SmallEnemyView smallEnemyView;
        public SmallEnemyController(SmallEnemyView smallEnemyView, SmallEnemyModel smallEnemyModel )
        {
            this.smallEnemyModel = smallEnemyModel;
            this.smallEnemyView = smallEnemyView;

            smallEnemyView.SetController( this );
        }

        public float GetBulletSpeed( )
        {
            return SmallEnemyModel.BulletSpeed;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Enemy
{
    public class SmallEnemyController: IDamagable
    {
        public SmallEnemyModel SmallEnemyModel { get { return smallEnemyModel; } private set { } }
        public SmallEnemyView SmallEnemyView { get { return smallEnemyView; } private set { } }

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

        public void TakeDamage( int dmg )
        {
            int newHealth = smallEnemyModel.GetHealth( ) - dmg;
            smallEnemyModel.SetHealth( newHealth );
            if(newHealth < 0 )
            {
                DestroySmallEnemy( );
            }
        }

        public int GiveDamage( )
        {
            return smallEnemyModel.Damage;
        }

        private void DestroySmallEnemy( )
        {
            EnemyService.Instance.ReturnToPool( smallEnemyView );
            smallEnemyModel.ResetHealth( );
        }
        public GameObject GetGameObject( )
        {
            return this.smallEnemyView.gameObject;
        }
    }
}

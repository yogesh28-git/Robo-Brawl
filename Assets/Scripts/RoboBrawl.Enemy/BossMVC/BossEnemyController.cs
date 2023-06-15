using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Enemy
{
    public class BossEnemyController: IDamagable
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

        public float GetBulletSpeed( )
        {
            return bossModel.BulletSpeed;
        }

        public void TakeDamage( int dmg )
        {
            int newHealth = bossModel.GetHealth( ) - dmg;
            bossModel.SetHealth( newHealth );
            if ( newHealth < 0 )
            {
                DestroyBoss( );
            }
        }

        public int GiveDamage( )
        {
            return bossModel.Damage;
        }

        private void DestroyBoss( )
        {
            BossView.StopSpawning( );
            BossModel.ResetHealth( );
            GameManagerService.Instance.OnGameOver.InvokeEvent( );
            //Game Win Condition
        }

        public GameObject GetGameObject( )
        {
            return this.bossView.gameObject;
        }
    }
}

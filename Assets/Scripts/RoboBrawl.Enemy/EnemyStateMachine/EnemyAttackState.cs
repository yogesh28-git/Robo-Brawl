using UnityEngine;

namespace RoboBrawl.Enemy
{
    public class EnemyAttackState : IEnemyState
    {
        private IEnemyStateUser enemyView;
        private Transform enemyTransformRef;
        private Transform playerTransformRef;
        public EnemyAttackState( IEnemyStateUser enemyView , Transform enemyTransformRef)
        {
            this.enemyView = enemyView;
            this.enemyTransformRef = enemyTransformRef;

            playerTransformRef = enemyView.GetPlayerTransform( );
        }
        public void OnStateEnter( )
        {
            enemyView.StartShooting( );
        }

        public void OnStateExit( )
        {
            enemyView.StopShooting( );
        }

        public void OnStateUpdate( )
        {
            Vector3 playerPos = playerTransformRef.position;
            if((playerTransformRef.position - enemyTransformRef.position).sqrMagnitude > 16 )
            {
                enemyView.ChangeStateTo( EnemyStateEnum.CHASE );
            }
            enemyTransformRef.LookAt(new Vector3(playerPos.x, enemyTransformRef.position.y, playerPos.z));
        }

        public EnemyStateEnum GetState( )
        {
            return EnemyStateEnum.ATTACK;
        }
    }
}

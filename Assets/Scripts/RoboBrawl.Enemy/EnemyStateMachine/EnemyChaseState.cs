using UnityEngine;
using UnityEngine.AI;

namespace RoboBrawl.Enemy
{
    public class EnemyChaseState : IEnemyState
    {
        private NavMeshAgent navAgent;
        private IEnemyStateUser enemyView;
        private Transform playerTransformRef;
        private Transform enemyTransformRef;
        
        public EnemyChaseState(NavMeshAgent agent, IEnemyStateUser enemyView)
        {
            this.navAgent = agent;
            this.enemyView = enemyView;
            navAgent.enabled = false;

            playerTransformRef = enemyView.GetPlayerTransform( );
            enemyTransformRef = navAgent.gameObject.transform;
        }
        public void OnStateEnter( )
        {
            navAgent.enabled = true;
        }
        public void OnStateUpdate( )
        {
            navAgent.SetDestination( playerTransformRef.position );

            if ( ( playerTransformRef.position - enemyTransformRef.position ).sqrMagnitude <= 25 )
            {
                enemyView.ChangeStateTo( EnemyStateEnum.ATTACK );
            }
            if ( ( playerTransformRef.position - enemyTransformRef.position ).sqrMagnitude > 144 )
            {
                enemyView.ChangeStateTo( EnemyStateEnum.PATROL );
            }
        }
        public void OnStateExit( )
        {
            navAgent.enabled = false;
        }
        public EnemyStateEnum GetState( )
        {
            return EnemyStateEnum.CHASE;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RoboBrawl.Player;

namespace RoboBrawl.Enemy
{
    public class EnemyPatrolState : IEnemyState
    {
        private NavMeshAgent navAgent;
        private Transform[] patrolPointsList;
        private IEnemyStateUser enemyView;
        private Transform playerTransformRef;
        private Transform enemyTransformRef;
        
        public EnemyPatrolState( NavMeshAgent agent, IEnemyStateUser enemyView )
        {
            this.navAgent = agent;
            navAgent.enabled = false;

            this.enemyView = enemyView;

            this.patrolPointsList = EnemyService.Instance.PatrolPoints;
            enemyTransformRef = navAgent.gameObject.transform;
            playerTransformRef = PlayerService.Instance.PlayerController.PlayerView.transform;
        }
        public void OnStateEnter( )
        {
            navAgent.enabled = true;

            int randIndex = Random.Range( 0, patrolPointsList.Length );
            Vector3 targetPos = patrolPointsList[randIndex].position;
            navAgent.SetDestination( targetPos );
        }
        public void OnStateUpdate( )
        {
            if(navAgent.remainingDistance < 0.1f )
            {
                int randIndex = Random.Range( 0, patrolPointsList.Length );
                Vector3 targetPos = patrolPointsList[randIndex].position;
                navAgent.SetDestination( targetPos );
            }
            if ( ( playerTransformRef.position - enemyTransformRef.position ).sqrMagnitude <= 144 )
            {
                enemyView.ChangeStateTo( EnemyStateEnum.CHASE );
            }
        }
        public void OnStateExit( )
        {
            navAgent.enabled = false;
        }

        public EnemyStateEnum GetState( )
        {
            return EnemyStateEnum.PATROL;
        }
    }
}

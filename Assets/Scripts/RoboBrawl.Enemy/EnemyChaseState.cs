using UnityEngine;
using UnityEngine.AI;
using RoboBrawl.Player;

namespace RoboBrawl.Enemy
{
    public class EnemyChaseState : IEnemyState
    {
        private NavMeshAgent agent;
        private Transform playerTransformRef;

        public EnemyChaseState(NavMeshAgent agent )
        {
            this.agent = agent;
        }
        public void OnStateEnter( )
        {
            playerTransformRef = PlayerService.Instance.PlayerController.PlayerView.transform;
        }

        public void OnStateExit( )
        {
            
        }

        public void OnStateUpdate( )
        {
            
            agent.SetDestination( playerTransformRef.position );
        }
    }
}

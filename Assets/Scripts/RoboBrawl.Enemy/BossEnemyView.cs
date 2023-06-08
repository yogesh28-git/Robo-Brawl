using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RoboBrawl.Enemy
{
    public class BossEnemyView : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;

        private BossEnemyController bossController;
        private IEnemyState currentState;
        private EnemyChaseState chaseState;

        private void Start( )
        {
            chaseState = new EnemyChaseState( agent );
            currentState = chaseState;
            currentState.OnStateEnter();
        }
        private void Update( )
        {
            currentState.OnStateUpdate( );
        }

        public void SetController(BossEnemyController bossController )
        {
            this.bossController = bossController;
        }
    }
}

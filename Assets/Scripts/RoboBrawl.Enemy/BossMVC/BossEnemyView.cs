using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RoboBrawl.Bullets;

namespace RoboBrawl.Enemy
{
    public class BossEnemyView : MonoBehaviour, IEnemyStateUser
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Transform bulletSpawnPos;

        private BossEnemyController bossController;
        private IEnemyState currentState;
        private EnemyPatrolState patrolState;
        private EnemyChaseState chaseState;
        private EnemyAttackState attackState;
        private Coroutine shootCoroutine;


        private void Start( )
        {
            patrolState = new EnemyPatrolState( agent, this );
            chaseState = new EnemyChaseState( agent , this );
            attackState = new EnemyAttackState( this , transform);

            currentState = patrolState;
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

        public void StartShooting( )
        {
            shootCoroutine = StartCoroutine( ShootingCoroutine( ) );
        }
        public void StopShooting( )
        {
            StopCoroutine( shootCoroutine );
        }

        private IEnumerator ShootingCoroutine( )
        {
            while ( true )
            { 
                BulletView bullet = BulletService.Instance.GetFromPool( bulletSpawnPos );
                bullet.SetShooterObject( bossController );
                yield return new WaitForSeconds( 2f );
            }
        }

        public void ChangeStateTo( EnemyStateEnum state )
        {
            currentState.OnStateExit( );
            switch ( state )
            {
                case EnemyStateEnum.PATROL: currentState = patrolState;
                    break;
                case EnemyStateEnum.CHASE: currentState = chaseState;
                    break;
                case EnemyStateEnum.ATTACK: currentState = attackState;
                    break;
            }
            currentState.OnStateEnter( );
            Debug.Log( "NewState: " + currentState.GetState( ) );
        }
    }
}

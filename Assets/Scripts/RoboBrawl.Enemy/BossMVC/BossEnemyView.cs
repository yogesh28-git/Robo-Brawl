using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using RoboBrawl.Bullets;
using RoboBrawl.Player;

namespace RoboBrawl.Enemy
{
    public class BossEnemyView : MonoBehaviour, IEnemyStateUser, ICharacterView
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Transform bulletSpawnPos;

        private BossEnemyController bossController;
        private IEnemyState currentState;
        private EnemyPatrolState patrolState;
        private EnemyChaseState chaseState;
        private EnemyAttackState attackState;
        private Coroutine shootCoroutine;
        private Coroutine spawnCoroutine;
        private Transform playerTransform;

        public void SetController( BossEnemyController bossController )
        {
            this.bossController = bossController;
        }
        public Transform GetPlayerTransform( )
        {
            return playerTransform;
        }

        public void StartShooting( )
        {
            shootCoroutine = StartCoroutine( ShootingCoroutine( ) );
        }
        public void StopShooting( )
        {
            StopCoroutine( shootCoroutine );
        }
        public void StartSpawning( )
        {
            spawnCoroutine = StartCoroutine( SmallEnemySpawner( ) );
        }
        public void StopSpawning( )
        {
            StopCoroutine( spawnCoroutine );
        }
        public void ChangeStateTo( EnemyStateEnum state )
        {
            currentState.OnStateExit( );
            switch ( state )
            {
                case EnemyStateEnum.PATROL:
                    currentState = patrolState;
                    break;
                case EnemyStateEnum.CHASE:
                    currentState = chaseState;
                    break;
                case EnemyStateEnum.ATTACK:
                    currentState = attackState;
                    break;
            }
            currentState.OnStateEnter( );
        }

        public IDamagable GetController( )
        {
            return bossController;
        }

        public int GetHealth( )
        {
            return bossController.BossModel.GetHealth( );
        }

        private void Start( )
        {
            playerTransform = PlayerService.Instance.PlayerController.PlayerView.transform;
            patrolState = new EnemyPatrolState( agent, this );
            chaseState = new EnemyChaseState( agent , this );
            attackState = new EnemyAttackState( this , transform);

            currentState = patrolState;
            currentState.OnStateEnter();

            StartSpawning( );
        }
        private void Update( )
        {
            currentState.OnStateUpdate( );
        }
        private IEnumerator ShootingCoroutine( )
        {
            yield return new WaitForSeconds( 2f );
            while ( true )
            { 
                BulletView bullet = BulletService.Instance.GetFromPool( bulletSpawnPos );
                bullet.SetShooterObject( bossController );
                yield return new WaitForSeconds( 1.5f );
            }
        }
        private IEnumerator SmallEnemySpawner( )
        {
            while ( true )
            {
                EnemyService.Instance.SpawnSmallEnemies( );
                yield return new WaitForSeconds( 45f );
            }
        }
    }
}

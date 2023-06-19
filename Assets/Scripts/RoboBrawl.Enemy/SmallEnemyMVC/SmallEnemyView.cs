using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using RoboBrawl.Bullets;
using RoboBrawl.Player;

namespace RoboBrawl.Enemy
{
    public class SmallEnemyView : MonoBehaviour, IEnemyStateUser, ICharacterView
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Transform bulletSpawnPos;

        private SmallEnemyController smallEnemyController;

        private IEnemyState currentState;
        private EnemyChaseState chaseState;
        private EnemyAttackState attackState;
        private Coroutine shootCoroutine;
        private Transform playerTransform;

        public void SetController( SmallEnemyController smallEnemyController )
        {
            this.smallEnemyController = smallEnemyController;
        }

        public void StartShooting( )
        {
            shootCoroutine = StartCoroutine( ShootingCoroutine( ) );
        }

        public void StopShooting( )
        {
            StopCoroutine( shootCoroutine );
        }

        public void ChangeStateTo( EnemyStateEnum state )
        {
            if ( state == EnemyStateEnum.PATROL )
            {
                return;
            }

            currentState.OnStateExit( );
            if ( state == EnemyStateEnum.ATTACK )
            {
                currentState = attackState;
            }
            else
            {
                currentState = chaseState;
            }
            currentState.OnStateEnter( );
        }

        public Transform GetPlayerTransform( )
        {
            return playerTransform;
        }

        public IDamagable GetController( )
        {
            return smallEnemyController;
        }

        public int GetHealth( )
        {
            return smallEnemyController.SmallEnemyModel.GetHealth( );
        }

        private void Awake( )
        {
            chaseState = new EnemyChaseState( agent, this );
            attackState = new EnemyAttackState( this, transform );
        }
        private void OnEnable( )
        {
            playerTransform = PlayerService.Instance.PlayerController.PlayerView.transform;
            currentState = chaseState;
            currentState.OnStateEnter( );
        }
        private void Start( )
        {
            GameManagerService.Instance.OnGameOver.AddListener( smallEnemyController.DestroySmallEnemy );
        }
        
        private void Update( )
        {
            currentState?.OnStateUpdate( );
        }
        
        private IEnumerator ShootingCoroutine( )
        {
            yield return new WaitForSeconds( 2f );
            while ( true )
            {
                BulletView bullet = BulletService.Instance.GetFromPool( bulletSpawnPos );
                bullet.SetShooterObject( smallEnemyController );
                yield return new WaitForSeconds( 3f );
            }
        }

        private void OnDestroy( )
        {
            smallEnemyController.DestroySmallEnemy( );
        }
    }
}

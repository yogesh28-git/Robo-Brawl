using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Bullets
{
    public class BulletView : MonoBehaviour
    {
        private bool isShooting = false;
        private Vector3 startingPoint;
        private float travelDistance = 7f;
        private float bulletSpeed = 10f;
        private Vector3 endingPoint;
        private Vector3 offset;
        private IDamagable shooter;
        
        public void SetShooterObject(IDamagable shooter )
        {
            this.shooter = shooter;
            this.bulletSpeed = shooter.GetBulletSpeed();
        }

        private void Start( )
        {
            GameManagerService.Instance.OnGameOver.AddListener( DestroyBullet );
        }

        private void OnEnable( )
        {
            startingPoint = transform.position;
            endingPoint = startingPoint + transform.forward * travelDistance;
        }
        
        private void Update( )
        {
            transform.position = Vector3.MoveTowards( transform.position, endingPoint, Time.deltaTime * bulletSpeed );
            offset = endingPoint - transform.position;
            if ( offset.sqrMagnitude <= 0.1f )
            {
                DestroyBullet( );
            }
        }
        private void DestroyBullet( )
        {
            BulletService.Instance.ReturnToPool( this );
        }

        private void OnTriggerEnter( Collider collider )
        {
            if(collider.gameObject == shooter.GetGameObject( ) )
            {
                return;
            }

            ICharacterView collidedCharacter = collider.GetComponent<ICharacterView>( );

            if(collidedCharacter != null )
            {
                IDamagable collidedController = collidedCharacter.GetController( );
                if( collidedController.GetCharacterType() != shooter.GetCharacterType( ) )
                {
                    collidedController.TakeDamage( shooter.GiveDamage( ) );
                }
            }

            BulletService.Instance.ReturnToPool( this );
        }
    }
}

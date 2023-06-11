using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Player
{
    public class PlayerController: IDamagable
    {
        public PlayerView PlayerView { get; private set; }
        public PlayerModel PlayerModel { get; private set; }

        private Rigidbody playerRigidBody;
        private Animator playerAnimator;

        public PlayerController(PlayerView playerView, PlayerModel playerModel)
        {
            this.PlayerView = playerView;
            this.PlayerModel = playerModel;

            PlayerView.SetController( this );
            playerView.gameObject.SetActive( true );
            SetInitialVariables( );
        }

        public void SetInitialVariables( )
        {
            this.playerRigidBody = PlayerView.PlayerRigidBody;
            this.playerAnimator = PlayerView.PlayerAnimator;
        }

        public void Move( float horizontal, float vertical)
        {
            Vector3 dir = new Vector3( horizontal, 0f, vertical ).normalized;
            if(dir.magnitude > 0.1f )
            {
                playerAnimator.SetBool( "Move", true );
                float targetAngle = Mathf.Atan2( dir.x, dir.z ) * Mathf.Rad2Deg;
                PlayerView.transform.rotation = Quaternion.Euler( 0f, targetAngle, 0f );
                playerRigidBody.AddRelativeForce( Vector3.forward * PlayerModel.MoveSpeed );

            }
            else
            {
                playerAnimator.SetBool( "Move", false );
            }
        }

        public float GetBulletSpeed( )
        {
            return PlayerModel.BulletSpeed;
        }

        public void TakeDamage( int dmg )
        {
            int newHealth = PlayerModel.GetHealth( ) - dmg;
            PlayerModel.SetHealth( newHealth );
            if ( newHealth < 0 )
            {
                DestroyPlayer( );
            }
        }

        public int GiveDamage( )
        {
            return PlayerModel.Damage;
        }

        private void DestroyPlayer( )
        {
            PlayerModel.ResetHealth( );
        }

        public GameObject GetGameObject( )
        {
            return this.PlayerView.gameObject;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboBrawl.Bullets;

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
            Debug.Log( "works" );
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

        public void Shoot( )
        {
            BulletView bullet = BulletService.Instance.GetFromPool(PlayerView.BulletSpawnPos);
            bullet.SetShooterObject( this );
        }
    }
}

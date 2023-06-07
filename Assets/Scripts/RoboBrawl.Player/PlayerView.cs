using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboBrawl.Bullets;
using RoboBrawl.UI;

namespace RoboBrawl.Player
{
    public class PlayerView : MonoBehaviour
    {
        public Rigidbody PlayerRigidBody { get { return playerRigidBody; } private set { } }
        public Animator PlayerAnimator { get { return playerAnimator; } set { } }

        private PlayerController playerController;
        private float horizontalInput;
        private float verticalInput;
        private bool isShooting = false;

        //Ammo Reloading Parameters
        private float maxAmmoBlockSize = 3f;
        private float ammoBlocks = 3f;
        private Coroutine ammoRefillCoroutine;

        [SerializeField] private Rigidbody playerRigidBody;
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private Transform bulletSpawnPos;
        public void SetController(PlayerController playerController )
        {
            this.playerController = playerController;
        }
        private void Update( )
        {
            HandleInput( );
            UIService.Instance.ammo.text = "Ammo: " + ammoBlocks;
        }
        private void FixedUpdate( )
        {
            playerController.Move(horizontalInput,verticalInput);
        }
        private void HandleInput( )
        {
            horizontalInput = Input.GetAxis( "Horizontal" );
            verticalInput = Input.GetAxis( "Vertical" );

            if ( Input.GetKeyDown( KeyCode.Space ) && isShooting == false && ammoBlocks>=1)
            {
                isShooting = true;
                StartCoroutine( ShootingCoroutine( ) );
                if(ammoRefillCoroutine != null)
                    StopCoroutine( ammoRefillCoroutine );
                ammoBlocks = Mathf.Floor(ammoBlocks-1);
                ammoRefillCoroutine = StartCoroutine( AmmoBlockRefill( ) );
            }
        }
        private IEnumerator ShootingCoroutine( )
        {
            for ( int i = 0; i < 3; i++ )
            {
                BulletView bullet = BulletService.Instance.GetFromPool(bulletSpawnPos );
                bullet.SetShooterObject( playerController );
                yield return new WaitForSeconds( 0.1f );
            }
            isShooting = false;
        }
        private IEnumerator AmmoBlockRefill( )
        {
            while(ammoBlocks < maxAmmoBlockSize )
            {
                yield return new WaitForSeconds( 0.2f );
                ammoBlocks += 0.1f;
            }
        }
    }
}

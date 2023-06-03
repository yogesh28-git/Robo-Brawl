using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Player
{
    public class PlayerView : MonoBehaviour
    {
        public Rigidbody PlayerRigidBody { get { return playerRigidBody; } private set { } }
        public Animator PlayerAnimator { get { return playerAnimator; } set { } }

        private PlayerController playerController;
        private float horizontalInput;
        private float verticalInput;

        [SerializeField] private Rigidbody playerRigidBody;
        [SerializeField] private Animator playerAnimator;
        public void SetController(PlayerController playerController )
        {
            this.playerController = playerController;
            Debug.Log( "yey" );
        }
        private void Update( )
        {
            HandleInput( );
        }
        private void FixedUpdate( )
        {
            playerController.Move(horizontalInput,verticalInput);
        }
        private void HandleInput( )
        {
            horizontalInput = Input.GetAxis( "Horizontal" );
            verticalInput = Input.GetAxis( "Vertical" );
        }
        private void OnCollisionEnter( Collision collision )
        {
            Debug.Log( "collided", collision.gameObject );
        }
    }
}

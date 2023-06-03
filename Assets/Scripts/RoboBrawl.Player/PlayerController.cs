using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Player
{
    public class PlayerController
    {
        public PlayerView PlayerView { get; private set; }
        public PlayerModel PlayerModel { get; private set; }

        private Rigidbody playerRigidBody;

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
        }

        public void Move( float horizontal, float vertical)
        {
            playerRigidBody.AddForce( PlayerView.transform.forward * horizontal * PlayerModel.MoveSpeed );
            playerRigidBody.AddRelativeForce( PlayerView.transform.forward * vertical * PlayerModel.MoveSpeed );
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RoboBrawl.Player
{
    public class PlayerService : MonoSingletonGeneric<PlayerService>
    {
        public PlayerController PlayerController { get { return playerController; } private set { } }
        public PlayerView PlayerView { get { return playerView; } private set { } }

        [SerializeField] private Transform playerSpawnPos;
        [SerializeField] private PlayerView playerPrefab;

        private PlayerView playerView;
        private PlayerModel playerModel;
        private PlayerController playerController;

        private void OnEnable( )
        {
            Debug.Log( "PlayerService is Listening" );
            GameManagerService.Instance.OnGameStart.AddListener( SpawnPlayer );
        }
        private void SpawnPlayer( )
        {
            this.playerView = GameObject.Instantiate<PlayerView>( playerPrefab, playerSpawnPos.position, Quaternion.identity );
            this.playerView.gameObject.SetActive( false );
            this.playerModel = new PlayerModel( );
            this.playerController = new PlayerController( playerView, playerModel );
        }
    }
}
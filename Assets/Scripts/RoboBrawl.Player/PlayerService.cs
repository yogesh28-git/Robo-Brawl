using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RoboBrawl.Player
{
    public class PlayerService : MonoSingletonGeneric<PlayerService>
    {
        public PlayerController PlayerController { get { return playerController; } set { } }
        [SerializeField] private Transform playerSpawnPos;
        [SerializeField] private PlayerView playerPrefab;
        private PlayerView playerView;
        private PlayerModel playerModel;
        private PlayerController playerController;

        public EventController OnPlayerSpawn;

        protected override void Awake( )
        {
            base.Awake( );
            OnPlayerSpawn = new EventController( );
            GameManagerService.Instance.OnGameStart.AddListener( SpawnPlayer );
        }
        private void SpawnPlayer( )
        {
            playerView = GameObject.Instantiate<PlayerView>( playerPrefab );
            playerView.gameObject.SetActive( false );
            playerView.transform.position = playerSpawnPos.position;
            playerModel = new PlayerModel( );
            playerController = new PlayerController(playerView, playerModel);

            OnPlayerSpawn.InvokeEvent( );
        }
    }
}


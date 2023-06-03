using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Player
{
    public class PlayerService : MonoSingletonGeneric<PlayerService>
    {
        public PlayerController PlayerController { get { return playerController; } set { } }
        [SerializeField] private List<Transform> spawnPos = new List<Transform>();
        [SerializeField] private PlayerView playerPrefab;
        private PlayerView playerView;
        private PlayerModel playerModel;
        private PlayerController playerController;


        protected override void Awake( )
        {
            base.Awake( );
            SpawnPlayer( );
        }
        private void SpawnPlayer( )
        {
            playerView = GameObject.Instantiate<PlayerView>( playerPrefab );
            playerView.gameObject.SetActive( false );
            int randomPosIndex = Random.Range( 0, spawnPos.Count);
            Debug.Log( randomPosIndex );
            playerView.transform.position = spawnPos[randomPosIndex].position;
            playerModel = new PlayerModel( );
            playerController = new PlayerController(playerView, playerModel);
        }
    }
}


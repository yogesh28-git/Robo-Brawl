using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RoboBrawl
{
    public class LobbyScript : MonoBehaviour
    {
        private void Start( )
        {
            Invoke( "PlayGame", 5f );
        }

        private void PlayGame( )
        {
            GameManagerService.Instance.LoadGameScene( );
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RoboBrawl.UI;
using UnityEngine.SceneManagement;

namespace RoboBrawl
{
    public class GameManagerService: MonoSingletonGeneric<GameManagerService>
    {
        public EventController OnGameOver;
        public EventController OnGameStart;
        private int gameTimeSeconds = 150;
        private int timeLeftSeconds;
        private Coroutine countDownCoroutine;

        private void Start( )
        {
            OnGameOver = new EventController( );
            OnGameStart = new EventController( );
            OnGameStart.AddListener( StartTimer );
            OnGameOver.AddListener( StopTimer );
            OnGameOver.AddListener( LoadLobbyScene );

            SceneManager.sceneLoaded += OnGameSceneLoad;
        }
        private void StartTimer( )
        {
            Debug.Log( "Start Timer" );
            countDownCoroutine = StartCoroutine( GameTimer() );
        }
        private void StopTimer( )
        {
            StopCoroutine( countDownCoroutine );
        }
        private IEnumerator GameTimer( )
        {
            timeLeftSeconds = gameTimeSeconds;
            while (timeLeftSeconds > 0 )
            {
                yield return new WaitForSecondsRealtime( 1f );
                UIService.Instance.UpdateTimerText( timeLeftSeconds );
                timeLeftSeconds--;
            }

            OnGameOver.InvokeEvent( );
        }

        public void LoadGameScene( )
        {
            SceneManager.LoadScene( 1 );
        }
        public void LoadLobbyScene( )
        {
            SceneManager.LoadScene( 0 );
        }
        
        public void OnGameSceneLoad( Scene scene, LoadSceneMode mode )
        {
            Debug.Log( "Scene Loaded: " + scene.name);
            if(scene.buildIndex == 1 )
            {
                OnGameStart.InvokeEvent( );
                Debug.Log( "Game Started" );
            }
        }
    }
}

using System.Collections;
using UnityEngine;
using RoboBrawl.UI;
using UnityEngine.SceneManagement;

namespace RoboBrawl
{
    public class GameManagerService: MonoSingletonGeneric<GameManagerService>
    {
        public EventController OnGameOver = new EventController( );
        public EventController OnGameStart = new EventController( );
        public EventController OnGameWin = new EventController( );
        public EventController OnGameLost = new EventController( );

        private int gameTimeSeconds = 10;
        private int timeLeftSeconds;
        private Coroutine countDownCoroutine;

        public void LoadGameScene( )
        {
            AudioManagerService.Instance.PlayMusic( SoundType.gameMusic );
            SceneManager.LoadScene( 1 );
        }
        public void LoadLobbyScene( )
        {
            AudioManagerService.Instance.PlayMusic( SoundType.menuMusic );
            SceneManager.LoadScene( 0 );
            UIService.Instance.DisableGameCanvas( );
        }

        public void OnGameSceneLoad( Scene scene, LoadSceneMode mode )
        {
            if ( scene.buildIndex == 1 )
            {
                OnGameStart.InvokeEvent( );
            }
        }

        private void Start( )
        {
            
            OnGameStart.AddListener( StartTimer );
            OnGameOver.AddListener( StopTimer );

            AudioManagerService.Instance.PlayMusic( SoundType.menuMusic );

            SceneManager.sceneLoaded += OnGameSceneLoad;
        }
        private void StartTimer( )
        {
            countDownCoroutine = StartCoroutine( GameTimer() );
        }
        private void StopTimer( )
        {
            StopCoroutine( countDownCoroutine );
        }
        private IEnumerator GameTimer( )
        {
            timeLeftSeconds = gameTimeSeconds;
            while (timeLeftSeconds >= 0 )
            {
                yield return new WaitForSeconds( 1f );
                UIService.Instance.UpdateTimerText( timeLeftSeconds );
                timeLeftSeconds--;
            }

            OnGameOver.InvokeEvent( );
            OnGameLost.InvokeEvent( );
        }
    }
}

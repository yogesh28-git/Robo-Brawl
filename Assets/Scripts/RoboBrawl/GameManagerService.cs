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
        public EventController OnGameOver = new EventController( );
        public EventController OnGameStart = new EventController( );
        private int gameTimeSeconds = 150;
        private int timeLeftSeconds;
        private Coroutine countDownCoroutine;

        private void Start( )
        {
            OnGameStart.AddListener( StartTimer );
            OnGameOver.AddListener( StopTimer );

            OnGameStart.InvokeEvent( );
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
            OnGameStart.InvokeEvent( );
        }
    }
}

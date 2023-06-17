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

        protected override void Awake( )
        {
            base.Awake( );
            OnGameOver = new EventController( );
            OnGameStart = new EventController( );
            OnGameStart.AddListener( StartTimer );
            OnGameOver.AddListener( StopTimer );
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
    }
}

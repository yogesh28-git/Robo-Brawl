using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RoboBrawl.UI
{
    public class UIService : MonoSingletonGeneric<UIService>
    {
        [Header( "In Game UI" )]
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private TextMeshProUGUI startMessage;
        [SerializeField] private Button pause;
        [SerializeField] private GameObject GameCanvas;
        

        [Header( "Extra Panel" )]
        [SerializeField] private GameObject inGamePanel;
        [SerializeField] private GameObject gameOverObject;
        [SerializeField] private Button restart;
        [SerializeField] private Button menu;
        [SerializeField] private Button resume;
        [SerializeField] private GameObject pauseObject;
        [SerializeField] private GameObject victory;

        public void EnableGameCanvas( )
        {
            GameCanvas.SetActive( true );
        }
        public void DisableGameCanvas( )
        {
            GameCanvas.SetActive( false );
        }

        public void UpdateTimerText(int timeRemainingSeconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds( timeRemainingSeconds );
            string timeString = timeSpan.ToString( @"mm\:ss" );
            timerText.text = "Time Left:  " + timeString;
        }

        private void Start( )
        {
            GameManagerService.Instance.OnGameStart.AddListener( ShowStartingMessage );
            GameManagerService.Instance.OnGameLost.AddListener( DisplayGameOver );
            GameManagerService.Instance.OnGameWin.AddListener( DisplayGameWon );
            GameManagerService.Instance.OnGameStart.AddListener( EnableGameCanvas );

            GameCanvas.SetActive( false );
            pauseObject.SetActive( false );
            gameOverObject.SetActive( false );
            victory.SetActive( false );
            inGamePanel.SetActive( false );


            pause.onClick.AddListener( PauseGame );
            restart.onClick.AddListener( RestartGame );
            resume.onClick.AddListener( ResumeGame );
            menu.onClick.AddListener( Menu );
        }

        private void ShowStartingMessage( )
        {
            startMessage.enabled = true;
            Invoke( nameof( DisableStartMessage ), 3f );
        }
        private void DisableStartMessage( )
        {
            startMessage.enabled = false;
        }

        private void PauseGame( )
        {
            AudioManagerService.Instance.PlaySfx( SoundType.pause );
            Time.timeScale = 0;
            inGamePanel.SetActive( true );
            pauseObject.SetActive( true );
        }
        private void ResumeGame( )
        {
            AudioManagerService.Instance.PlaySfx( SoundType.resume );
            Time.timeScale = 1;
            pauseObject.SetActive( false );
            inGamePanel.SetActive( false );
        }

        private void DisplayGameOver( )
        {
            AudioManagerService.Instance.PlaySfx( SoundType.lose );
            Time.timeScale = 0;
            inGamePanel.SetActive( true );
            gameOverObject.SetActive( true );
        }

        private void DisplayGameWon( )
        {
            AudioManagerService.Instance.PlaySfx( SoundType.win );
            Time.timeScale = 0;
            inGamePanel.SetActive( true );
            gameOverObject.SetActive( false );
            victory.SetActive( true );
        }

        private void RestartGame( )
        {
            AudioManagerService.Instance.PlaySfx( SoundType.buttonClick );
            GameManagerService.Instance.OnGameOver.InvokeEvent( );
            Time.timeScale = 1;
            pauseObject.SetActive( false );
            gameOverObject.SetActive( false );
            victory.SetActive( false );
            inGamePanel.SetActive( false );
            GameManagerService.Instance.LoadGameScene( );
        }

        private void Menu( )
        {
            AudioManagerService.Instance.PlaySfx( SoundType.buttonClick );
            Time.timeScale = 1;
            GameManagerService.Instance.OnGameOver.InvokeEvent( );
            gameOverObject.SetActive( false );
            pauseObject.SetActive( false );
            victory.SetActive( false );
            inGamePanel.SetActive( false );
            GameManagerService.Instance.LoadLobbyScene( );
        }

    }
}

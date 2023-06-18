using System;
using System.Collections;
using System.Collections.Generic;
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
        [SerializeField] private Button restart;
        [SerializeField] private Button pause;

        [Header( "Game End" )]
        [SerializeField] private GameObject inGamePanel;
        [SerializeField] private Button resume;
        [SerializeField] private Button menu;

        public void Awake( )
        {
            base.Awake( );
            GameManagerService.Instance.OnGameStart.AddListener( ShowStartingMessage );
        }

        public void UpdateTimerText(int timeRemainingSeconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds( timeRemainingSeconds );
            string timeString = timeSpan.ToString( @"mm\:ss" );
            timerText.text = "Time Left:  " + timeString;
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
    }
}

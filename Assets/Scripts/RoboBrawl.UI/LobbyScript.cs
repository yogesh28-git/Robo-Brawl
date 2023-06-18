using UnityEngine;
using UnityEngine.UI;

namespace RoboBrawl
{
    public class LobbyScript : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;
        private void Start( )
        {
            playButton.onClick.AddListener( PlayGame );
            quitButton.onClick.AddListener( QuitGame );
        }
        private void PlayGame( )
        {
            GameManagerService.Instance.LoadGameScene( );
        }
        private void QuitGame( )
        {
            Application.Quit( );
        }
    }
}

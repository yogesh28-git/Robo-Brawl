using UnityEngine;
using UnityEngine.UI;

namespace RoboBrawl.UI
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
            AudioManagerService.Instance.PlaySfx( SoundType.buttonClick );
            GameManagerService.Instance.LoadGameScene( );
        }
        private void QuitGame( )
        {
            AudioManagerService.Instance.PlaySfx( SoundType.buttonClick );
            Application.Quit( );
        }
    }
}

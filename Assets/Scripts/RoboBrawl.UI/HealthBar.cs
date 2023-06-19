using UnityEngine;
using UnityEngine.UI;

namespace RoboBrawl.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Gradient gradient;
        [SerializeField] private Slider healthBar;
        [SerializeField] private Transform characterTransform;
        [SerializeField] private Image fill;

        private ICharacterView character;
        private int currHealth;
        private int maxHealth;

        private void Start( )
        {
            character = characterTransform.gameObject.GetComponent<ICharacterView>( );

            maxHealth = character.GetHealth( );

            healthBar.maxValue = maxHealth;

            currHealth = maxHealth;
        }
        private void LateUpdate( )
        {
            transform.LookAt( transform.position + Camera.main.transform.forward );

            currHealth = character.GetHealth( );

            healthBar.value = currHealth;
            fill.color = gradient.Evaluate( healthBar.normalizedValue );
        }
    }
}

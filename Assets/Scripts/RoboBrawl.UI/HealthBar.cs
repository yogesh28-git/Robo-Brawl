using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RoboBrawl
{
    public class HealthBar : MonoBehaviour
    {
        private Camera cam;
        [SerializeField] private Gradient gradient;
        [SerializeField] private Slider healthBar;
        [SerializeField] private Transform characterTransform;
        [SerializeField] private Image fill;

        private ICharacterView character;
        private int currHealth;
        private int maxHealth;

        private void Start( )
        {
            this.character = characterTransform.gameObject.GetComponent<ICharacterView>( );
            this.cam = Camera.main;

            maxHealth = character.GetHealth( );

            healthBar.maxValue = maxHealth;

            currHealth = maxHealth;
        }
        private void LateUpdate( )
        {
            transform.LookAt( transform.position + cam.transform.forward );

            currHealth = character.GetHealth( );

            healthBar.value = currHealth;
            fill.color = gradient.Evaluate( healthBar.normalizedValue );
        }
    }
}

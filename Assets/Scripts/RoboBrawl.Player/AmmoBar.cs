using UnityEngine.UI;
using UnityEngine;

namespace RoboBrawl.Player
{
    public class AmmoBar : MonoBehaviour
    {
        [SerializeField] Slider ammoBar1;
        [SerializeField] Slider ammoBar2;
        [SerializeField] Slider ammoBar3;
        private Camera cam;

        private void Start( )
        {
            this.cam = Camera.main;

            ammoBar1.maxValue = 1;
            ammoBar2.maxValue = 1;
            ammoBar3.maxValue = 1;

            ammoBar1.value = 1;
            ammoBar1.value = 1;
            ammoBar1.value = 1;
        }
        private void LateUpdate( )
        {
            transform.LookAt( transform.position + cam.transform.forward );
        }
        public void UpdateAmmoBar(float ammo)
        {
            ammoBar1.value = ammo;
            ammoBar2.value = ammo - 1;
            ammoBar3.value = ammo - 2;
        }
    }
}

using UnityEngine;

namespace RoboBrawl
{
    public interface IDamagable
    {
        public float GetBulletSpeed();

        public void TakeDamage( int dmg );

        public int GiveDamage( );

        public GameObject GetGameObject( );
    }
}
using UnityEngine;

namespace RoboBrawl.Enemy
{
    public interface IEnemyStateUser
    {
        public Transform GetPlayerTransform( );
        public void StartShooting( );
        public void StopShooting( );
        public void ChangeStateTo( EnemyStateEnum state );
    }
}
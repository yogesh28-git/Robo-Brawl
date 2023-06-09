using UnityEngine;

namespace RoboBrawl.Enemy
{
    public interface IEnemyStateUser
    {
        public void StartShooting( );
        public void StopShooting( );
        public void ChangeStateTo( EnemyStateEnum state );
    }
}
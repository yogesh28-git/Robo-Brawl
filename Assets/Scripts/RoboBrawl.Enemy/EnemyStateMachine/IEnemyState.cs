namespace RoboBrawl.Enemy
{
    public interface IEnemyState
    {
        public void OnStateEnter( );
        public void OnStateUpdate( );
        public void OnStateExit( );
        public EnemyStateEnum GetState( );
    }
}

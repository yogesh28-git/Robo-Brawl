namespace RoboBrawl.Enemy
{
    public interface IEnemyState
    {
        public void SetController( IDamagable controller);
        public void OnStateEnter( );
        public void OnStateUpdate( );
        public void OnStateExit( );
    }
}

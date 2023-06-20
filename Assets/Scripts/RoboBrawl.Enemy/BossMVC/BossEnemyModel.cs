namespace RoboBrawl.Enemy
{
    public class BossEnemyModel
    {
        public float BulletSpeed { get { return bulletSpeed; } set { } }
        public int Damage { get { return damage; } private set { } }

        private int currHealth = 800;
        private int damage = 50;
        private float bulletSpeed = 6f;

        public int GetHealth( )
        {
            return currHealth;
        }
        public void SetHealth( int health )
        {
            currHealth = health;
        }
    }
}

namespace RoboBrawl.Enemy
{
    public class SmallEnemyModel
    {
        public float BulletSpeed { get { return bulletSpeed; } private set { } }
        public int Damage { get { return damage; } private set { } }

        private int maxHealth = 120;
        private int currHealth = 120;
        private int damage = 20;
        private float bulletSpeed = 6f;

        public int GetHealth( )
        {
            return currHealth;
        }
        public void SetHealth(int health )
        {
            currHealth = health;    
        }
        public void ResetHealth( )
        {
            currHealth = maxHealth;
        }
    }
}

namespace RoboBrawl.Player
{
    public class PlayerModel
    {
        public float MoveSpeed { get { return moveSpeed; } set { } }
        public float BulletSpeed { get { return bulletSpeed; } set { } }
        public int Damage { get { return damage; } private set { } }

        private int currHealth = 300;
        private int damage = 30;
        private float moveSpeed = 100f;
        private float bulletSpeed = 10f;

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

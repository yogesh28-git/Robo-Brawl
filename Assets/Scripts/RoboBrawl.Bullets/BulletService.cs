using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Bullets
{
    public class BulletService : GenericObjectPool<BulletService, BulletView>
    {
        [SerializeField] private BulletView bulletPrefab;
        public override BulletView CreateNewItem( )
        {
            BulletView item = GameObject.Instantiate<BulletView>( bulletPrefab );
            return item;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Bullets
{
    public class BulletView : MonoBehaviour
    {
        private Vector3 startingPoint;
        private float travelDistance = 10f;
        private float bulletSpeed = 100f;
        private Vector3 endingPoint;
        private Vector3 offset;
        private IDamagable shooterObject;
        
        public void SetShooterObject(IDamagable shooterObject )
        {
            this.shooterObject = shooterObject;
        }
        private void OnEnable( )
        {
            startingPoint = transform.position;
            endingPoint = startingPoint + transform.forward * travelDistance;
        }
        private void Update( )
        {
            transform.position = Vector3.MoveTowards( transform.position, endingPoint, Time.deltaTime * bulletSpeed );
            offset = endingPoint - transform.position;
            if(offset.sqrMagnitude <= 0.1f )
            {
                DestroyBullet( );
            }
        }
        private void DestroyBullet( )
        {
            BulletService.Instance.ReturnToPool( this );
        }
    }
}

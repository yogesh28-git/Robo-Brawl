using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboBrawl.Player;

namespace RoboBrawl
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private LayerMask boundaryLayer;
        [SerializeField] private GameObject leftWall;
        [SerializeField] private GameObject rightWall;
        [SerializeField] private GameObject topWall;
        [SerializeField] private GameObject bottomWall;

        private RaycastHit lowerLeftHit;
        private RaycastHit upperRightHit;
        private Transform playerTransform;
        Vector3 lowerLeft = new Vector3( 0, 0, 0 );
        Vector3 upperRight = new Vector3( Screen.width - 1, Screen.height - 1, 0 );
        Vector3 lowerLeftBound = new Vector3( -21, 0, -21 );
        Vector3 upperRightBound = new Vector3( 21, 0, 21 );

        private void Start( )
        {
            playerTransform = PlayerService.Instance.PlayerController.PlayerView.transform;
        }
        private void FixedUpdate( )
        {
            Vector3 previousPos = this.transform.position;
            this.transform.position = playerTransform.position;
           
            Ray ray1 = mainCamera.ScreenPointToRay( lowerLeft );
            Ray ray2 = mainCamera.ScreenPointToRay( upperRight );

            bool isLeftCrossed = Physics.Raycast( ray1,out lowerLeftHit ,1000f, boundaryLayer );
            bool isRightCrossed = Physics.Raycast( ray2,out upperRightHit, 1000f, boundaryLayer );

            if ( isLeftCrossed )
            {
                Vector3 hitPoint = lowerLeftHit.point;
                hitPoint.y = 0;
                if(hitPoint.x <= lowerLeftBound.x )
                {
                    Vector3 temp = this.transform.position;
                    temp.x = previousPos.x;
                    this.transform.position = temp;
                }
                if(hitPoint.z <= lowerLeftBound.z )
                {
                    Vector3 temp = this.transform.position;
                    temp.z = previousPos.z;
                    this.transform.position = temp;
                }
            }
            if ( isRightCrossed )
            {
                Vector3 hitPoint = upperRightHit.point;
                Debug.Log( hitPoint );
                hitPoint.y = 0;
                if ( hitPoint.z >= upperRightBound.z )
                {
                    Debug.Log( "up" );
                    Vector3 temp = this.transform.position;
                    temp.z = previousPos.z;
                    this.transform.position = temp;
                }
                if ( hitPoint.x >= upperRightBound.x )
                {
                    Vector3 temp = this.transform.position;
                    temp.x = previousPos.x;
                    this.transform.position = temp;
                }
            }
        }
    }
}

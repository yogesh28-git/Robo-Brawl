using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Enemy
{
    public class EnemyService : GenericObjectPool<EnemyService, SmallEnemyView>
    {
        [Header( "Boss Enemy" )]
        [SerializeField] private BossEnemyView bossPrefab;
        [SerializeField] private Transform bossSpawnTransform;

        [Header( "Small Robot Enemy" )]
        [SerializeField] private SmallEnemyView smallEnemyPrefab;
        [SerializeField] private List<Transform> smallEnemySpawnTransformList = new List<Transform>();

        [SerializeField]
        private List<Transform> smallEnemyDuplicateList = new List<Transform>( );
        private BossEnemyController bossEnemyController;
        private int currentSmallEnemyCount = 0;
        private int MaxSmallEnemyCount;

        private void Awake( )
        {
            base.Awake( );
            SpawnBoss( );
            CreateSmallEnemyMVC( 3 );

            SpawnSmallEnemies( );
        }

        private void SpawnBoss( )
        {
            BossEnemyView bossEnemyView = GameObject.Instantiate<BossEnemyView>( bossPrefab, bossSpawnTransform );
            bossEnemyView.gameObject.SetActive( false );
            BossEnemyModel bossEnemyModel = new BossEnemyModel( );
            bossEnemyController = new BossEnemyController( bossEnemyView, bossEnemyModel );
        }

        private void CreateSmallEnemyMVC(int count)
        {
            this.MaxSmallEnemyCount = count;

            for(int i=0; i<count; i++ )
            {
                SmallEnemyView smallEnemyView = GameObject.Instantiate<SmallEnemyView>( smallEnemyPrefab );
                smallEnemyView.gameObject.SetActive( false );
                SmallEnemyModel smallEnemyModel = new SmallEnemyModel( );
                SmallEnemyController smallEnemyController = new SmallEnemyController( smallEnemyView, smallEnemyModel );
                ReturnToPool( smallEnemyView );
            }

            
        }

        private void SpawnSmallEnemies()
        {
            for (int i=0; i<MaxSmallEnemyCount; i++ )
            {
                int randIndex = Random.Range( 0, smallEnemySpawnTransformList.Count );
                Transform smallEnemyTransform = smallEnemySpawnTransformList[randIndex];
                smallEnemyDuplicateList.Add( smallEnemySpawnTransformList[randIndex] );
                smallEnemySpawnTransformList.RemoveAt(randIndex);

                SmallEnemyView smallEnemyView = GetFromPool( smallEnemyTransform );
            }
            foreach(var element in smallEnemyDuplicateList )
            {
                smallEnemySpawnTransformList.Add( element );
            }
            smallEnemyDuplicateList.Clear( );
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl.Enemy
{
    public class EnemyService : GenericObjectPool<EnemyService, SmallEnemyView>
    {
        public Transform[] PatrolPoints { get { return patrolPoints; } set { } }

        [Header( "Boss Enemy" )]
        [SerializeField] private BossEnemyView bossPrefab;
        [SerializeField] private Transform bossSpawnTransform;
        [SerializeField] private Transform[] patrolPoints;

        [Header( "Small Robot Enemy" )]
        [SerializeField] private SmallEnemyView smallEnemyPrefab;
        [SerializeField] private List<Transform> enemySpawnTransformList = new List<Transform>();

        [SerializeField]
        private List<Transform> smallEnemyDuplicateList = new List<Transform>( );
        private BossEnemyController bossEnemyController;
        private int currentSmallEnemyCount = 0;
        private int MaxSmallEnemyCount;

        private void Awake( )
        {
            base.Awake( );
            SpawnBoss( );
            CreateSmallEnemyMVC( 4 );
            SpawnSmallEnemies( );
        }

        private void SpawnBoss( )
        {
            int randIndex = Random.Range( 0, enemySpawnTransformList.Count );
            Transform enemyTransform = enemySpawnTransformList[randIndex];
            BossEnemyView bossEnemyView = GameObject.Instantiate<BossEnemyView>( bossPrefab, enemyTransform.position, Quaternion.identity );
            bossEnemyView.gameObject.SetActive( false );
            BossEnemyModel bossEnemyModel = new BossEnemyModel( );
            bossEnemyController = new BossEnemyController( bossEnemyView, bossEnemyModel );
        }

        private void CreateSmallEnemyMVC(int count)
        {
            this.MaxSmallEnemyCount = count;
            this.currentSmallEnemyCount = count;

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
                int randIndex = Random.Range( 0, enemySpawnTransformList.Count );
                Transform smallEnemyTransform = enemySpawnTransformList[randIndex];
                smallEnemyDuplicateList.Add( enemySpawnTransformList[randIndex] );
                enemySpawnTransformList.RemoveAt(randIndex);

                SmallEnemyView smallEnemyView = GetFromPool( smallEnemyTransform );
            }
            foreach(var element in smallEnemyDuplicateList )
            {
                enemySpawnTransformList.Add( element );
            }
            smallEnemyDuplicateList.Clear( );
        }

        private void KillSmallEnemy( SmallEnemyView smallEnemy)
        {
            currentSmallEnemyCount--;
            ReturnToPool( smallEnemy );
        }
    }
}

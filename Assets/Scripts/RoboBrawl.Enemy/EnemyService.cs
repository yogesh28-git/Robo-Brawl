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
        private int MaxSmallEnemyCount = 4;

        private BossEnemyController bossController;
        private BossEnemyModel bossModel;
        private BossEnemyView bossView;

        private void OnEnable( )
        {
            GameManagerService.Instance.OnGameStart.AddListener( SpawnBoss );
        }

        public override SmallEnemyView CreateNewItem( )
        {
            SmallEnemyView smallEnemyView = GameObject.Instantiate<SmallEnemyView>( smallEnemyPrefab, this.transform);
            smallEnemyView.gameObject.SetActive( false );
            SmallEnemyModel smallEnemyModel = new SmallEnemyModel( );
            SmallEnemyController smallEnemyController = new SmallEnemyController( smallEnemyView, smallEnemyModel );

            return smallEnemyView;
        }
        private void SpawnBoss( )
        {
            int randIndex = Random.Range( 0, enemySpawnTransformList.Count );
            Transform enemyTransform = enemySpawnTransformList[randIndex];
            bossView = GameObject.Instantiate<BossEnemyView>( bossPrefab, enemyTransform.position, Quaternion.identity );
            bossView.gameObject.SetActive( false );
            bossModel = new BossEnemyModel( );
            bossController = new BossEnemyController( bossView, bossModel );
        }
        public void SpawnSmallEnemies()
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
    }
}

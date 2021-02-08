using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemySpawner : MonoBehaviour
{
    public BundleManager loader;

    public Transform[] spawnPoints;
    private int randX;
    private float posX;
    private Vector2 whereToSpawn;

    public float spawnRate = 2f;

    private float nextSpawn = 0.0f;
    private int iterator = 1;

    private GameObject SpawnPrefab;

    private GameObject EnemyPrefab1;
    private GameObject EnemyPrefab2;
    private GameObject EnemyPrefab3;

    private GameObject BossPrefab1;
    private GameObject BossPrefab2;
    private GameObject BossPrefab3;

    void Start()
    {
        EnemyLoader();
    }

    void EnemyLoader()
    {
        //AssetBundle tex = loader.LoadBundle("enemy_texture");
        //AssetBundle anim = loader.LoadBundle("enemy_animation");

        EnemyPrefab1 = AssetLoader.Instance.EnemyPrefab1; //loader.GetAsset<GameObject>("enemy_prefab", "Enemy1");
        EnemyPrefab2 = AssetLoader.Instance.EnemyPrefab2; //loader.GetAsset<GameObject>("enemy_prefab", "Enemy2");
        EnemyPrefab3 = AssetLoader.Instance.EnemyPrefab3; //loader.GetAsset<GameObject>("enemy_prefab", "Enemy3");

        BossPrefab1 = AssetLoader.Instance.BossPrefab1; //loader.GetAsset<GameObject>("enemy_prefab", "Boss1");
        BossPrefab2 = AssetLoader.Instance.BossPrefab2; //loader.GetAsset<GameObject>("enemy_prefab", "Boss2");
        BossPrefab3 = AssetLoader.Instance.BossPrefab3; //loader.GetAsset<GameObject>("enemy_prefab", "Boss3");
    }


    void Update()
    {
        if (Time.time > nextSpawn)
        {
            /*
            float randomSpawn = Random.Range(0, 10);
            
            if (randomSpawn < 5)
            {
                SpawnPrefab = EnemyPrefab1;
            }
            else
            {
                SpawnPrefab = EnemyPrefab2;
            }*/
            switch (iterator)
            {
                case 1: SpawnPrefab = EnemyPrefab1;break;
                case 2: SpawnPrefab = EnemyPrefab2;break;
                case 3: SpawnPrefab = EnemyPrefab3;break;
                case 4: SpawnPrefab = BossPrefab1;break;
                case 5: SpawnPrefab = BossPrefab2;break;
                case 6: SpawnPrefab = BossPrefab3;break;
            }

            iterator++;
            if (iterator > 6) { iterator = 1; }

            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(0, spawnPoints.Length);
            whereToSpawn = spawnPoints[randX].transform.position;

            GameObject clone = Instantiate(SpawnPrefab, whereToSpawn,Quaternion.identity);

            if (clone != null)
            {
                clone.AddComponent<Rigidbody2D>();
            }
        }
    }
}

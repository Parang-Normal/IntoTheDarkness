using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetLoader : MonoBehaviour
{
    public static AssetLoader Instance;

    BundleManager bundleManager;

    public GameObject PlayerPrefab { get; private set; }

    public GameObject BulletPrefab1 { get; private set; }
    public GameObject BulletPrefab2 { get; private set; }
    public GameObject BulletPrefab3 { get; private set; }


    public Sprite BulletSprite1 { get; private set; }
    public Sprite BulletSprite2 { get; private set; }
    public Sprite BulletSprite3 { get; private set; }


    public GameObject EnemyPrefab1 { get; private set; }
    public GameObject EnemyPrefab2 { get; private set; }
    public GameObject EnemyPrefab3 { get; private set; }


    public GameObject BossPrefab1 { get; private set; }
    public GameObject BossPrefab2 { get; private set; }
    public GameObject BossPrefab3 { get; private set; }


    public GameObject Environment1 { get; private set; }
    public GameObject Environment2 { get; private set; }
    public GameObject Environment3 { get; private set; }
    public GameObject Environment4 { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

        bundleManager = new BundleManager();
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        LoadBundles();
        LoadPrefabs();
    }

    private void LoadBundles()
    {
        AssetBundle environment = bundleManager.LoadBundle("environment_texture");

        AssetBundle playerTex = bundleManager.LoadBundle("player_texture");
        AssetBundle playerAnim = bundleManager.LoadBundle("player_animation");

        AssetBundle bulletTex = bundleManager.LoadBundle("bullet_texture");

        AssetBundle enemyTex = bundleManager.LoadBundle("enemy_texture");
        AssetBundle enemyAnim = bundleManager.LoadBundle("enemy_animation");
    }

    private void LoadPrefabs()
    {
        PlayerPrefab = bundleManager.GetAsset<GameObject>("player_prefab", "Player");

        BulletPrefab1 = bundleManager.GetAsset<GameObject>("bullet_prefab", "Arrow1");
        BulletPrefab2 = bundleManager.GetAsset<GameObject>("bullet_prefab", "Arrow2");
        BulletPrefab3 = bundleManager.GetAsset<GameObject>("bullet_prefab", "Arrow3");

        BulletSprite1 = bundleManager.GetAsset<Sprite>("bullet_texture", "Arrow1");
        BulletSprite2 = bundleManager.GetAsset<Sprite>("bullet_texture", "Arrow3");
        BulletSprite3 = bundleManager.GetAsset<Sprite>("bullet_texture", "Arrow4");

        EnemyPrefab1 = bundleManager.GetAsset<GameObject>("enemy_prefab", "Enemy1");
        EnemyPrefab2 = bundleManager.GetAsset<GameObject>("enemy_prefab", "Enemy2");
        EnemyPrefab3 = bundleManager.GetAsset<GameObject>("enemy_prefab", "Enemy3");

        BossPrefab1 = bundleManager.GetAsset<GameObject>("enemy_prefab", "Boss1");
        BossPrefab2 = bundleManager.GetAsset<GameObject>("enemy_prefab", "Boss2");
        BossPrefab3 = bundleManager.GetAsset<GameObject>("enemy_prefab", "Boss3");

        Environment1 = bundleManager.GetAsset<GameObject>("environment_prefab", "Battleground1");
        Environment2 = bundleManager.GetAsset<GameObject>("environment_prefab", "Battleground2");
        Environment3 = bundleManager.GetAsset<GameObject>("environment_prefab", "Battleground3");
        Environment4 = bundleManager.GetAsset<GameObject>("environment_prefab", "Battleground4");
    }
}

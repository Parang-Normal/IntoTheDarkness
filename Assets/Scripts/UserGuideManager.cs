using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGuideManager : MonoBehaviour
{
    public Transform Enemy1;
    public Transform Enemy2;
    public Transform Enemy3;

    public Transform Boss1;
    public Transform Boss2;
    public Transform Boss3;

    public SpriteRenderer Bullet1;
    public SpriteRenderer Bullet2;
    public SpriteRenderer Bullet3;

    void Start()
    {
        GameObject E1 = Instantiate(AssetLoader.Instance.EnemyPrefab1);
        E1.transform.position = Enemy1.position;
        Destroy(E1.GetComponent<EnemyMovement>());

        GameObject E2 = Instantiate(AssetLoader.Instance.EnemyPrefab2);
        E2.transform.position = Enemy2.position;
        Destroy(E2.GetComponent<EnemyMovement>());

        GameObject E3 = Instantiate(AssetLoader.Instance.EnemyPrefab3);
        E3.transform.position = Enemy3.position;
        Destroy(E3.GetComponent<EnemyMovement>());

        GameObject B1 = Instantiate(AssetLoader.Instance.BossPrefab1);
        B1.transform.position = Boss1.position;
        Destroy(B1.GetComponent<EnemyMovement>());

        GameObject B2 = Instantiate(AssetLoader.Instance.BossPrefab2);
        B2.transform.position = Boss2.position;
        Destroy(B2.GetComponent<EnemyMovement>());

        GameObject B3 = Instantiate(AssetLoader.Instance.BossPrefab3);
        B3.transform.position = Boss3.position;
        Destroy(B3.GetComponent<EnemyMovement>());

        Bullet2.sprite = AssetLoader.Instance.BulletSprite2;
        Bullet3.sprite = AssetLoader.Instance.BulletSprite3;
        Bullet1.sprite = AssetLoader.Instance.BulletSprite1;
    }

}

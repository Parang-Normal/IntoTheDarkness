using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public WeaponStats Stats;
    public float ArrowSpeed = 10f;

    Vector2 move = new Vector2(1, 0);
    int DamageAmp = 0;

    private void OnValidate()
    {
        switch (Stats.Type)
        {
            case WeaponType.Arrow1:
                Stats.Damage = 4;
                Stats.ArrowCount = 20;
                break;

            case WeaponType.Arrow2:
                Stats.Damage = 5;
                Stats.ArrowCount = 30;
                break;

            case WeaponType.Arrow3:
                Stats.Damage = 10;
                Stats.ArrowCount = 10;
                break;

        }
    }

    private void Start()
    {
        
        if(Stats.Type == WeaponType.Arrow1)
        {
            DamageAmp = PlayerPrefs.GetInt("Arrow1_Amp", 0);
        }
    }

    void Update()
    {
        gameObject.transform.Translate(move * ArrowSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyMovement>().Stats;

        if (enemyStats.Weakness == Stats.Type)
        {
            enemyStats.Health -= Stats.Damage;
        }

        if (enemyStats.Health <= 0)
        {
            PlayerManager.Instance.GainPoints(enemyStats.Points);
            PlayerManager.Instance.GainCoins(enemyStats.Coins);
            Destroy(collision.gameObject);
        }
    }
}

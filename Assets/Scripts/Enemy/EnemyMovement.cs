using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyStats Stats;
    public float AttackInterval = 1f;

    private float AttackTime = 0f;
    private Vector2 moveVec = new Vector2(-1.0f, 0.0f);
    private Animator anim;
    private bool isAttacking = false;
    private bool isHurt = false;

    private void OnValidate()
    {
        switch (Stats.Type)
        {
            case EnemyType.Enemy1:
                Stats.Weakness = WeaponType.Arrow1;
                Stats.Health = 8;
                Stats.MovementSpeed = 1.75f;
                Stats.Damage = 5;
                Stats.Coins = 2;
                break;

            case EnemyType.Enemy2:
                Stats.Weakness = WeaponType.Arrow2;
                Stats.Health = 15;
                Stats.MovementSpeed = 1.25f;
                Stats.Damage = 10;
                Stats.Coins = 3;
                break;

            case EnemyType.Enemy3:
                Stats.Weakness = WeaponType.Arrow3;
                Stats.Health = 30;
                Stats.MovementSpeed = 1f;
                Stats.Damage = 15;
                Stats.Coins = 5;
                break;

            case EnemyType.Boss1:
                Stats.Weakness = WeaponType.Arrow1;
                Stats.Health = 24;
                Stats.MovementSpeed = 0.7f;
                Stats.Damage = 20;
                Stats.Coins = 20;
                break;

            case EnemyType.Boss2:
                Stats.Weakness = WeaponType.Arrow2;
                Stats.Health = 30;
                Stats.MovementSpeed = 0.5f;
                Stats.Damage = 20;
                Stats.Coins = 30;
                break;

            case EnemyType.Boss3:
                Stats.Weakness = WeaponType.Arrow3;
                Stats.Health = 60;
                Stats.MovementSpeed = 0.3f;
                Stats.Damage = 20;
                Stats.Coins = 50;
                break;

        }

        Stats.Points = Stats.Coins * 10;
    }

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    

    void Update()
    {
        if (!isAttacking && !isHurt)
        {
            gameObject.transform.Translate(moveVec * Stats.MovementSpeed * Time.deltaTime);
        }

        AttackTime += Time.deltaTime;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10) 
        {
            isAttacking = true;
            anim.SetBool("Attack", true);
            if (AttackTime >= AttackInterval)
            {
                AttackTime = 0;

                PlayerManager.Instance.DamageCharacter(Stats.Damage);
            }
        }
        if (collision.gameObject.layer == 8)
        {
            isHurt = true;
            anim.SetBool("Hurt", true);
            StartCoroutine(IsHit());
        }
    }

    IEnumerator IsHit()
    {
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("Hurt", false);
        isHurt = false;
    }
}

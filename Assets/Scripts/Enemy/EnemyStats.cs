using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Enemy1,
    Enemy2,
    Enemy3,
    Boss1,
    Boss2,
    Boss3,
}

[System.Serializable]
public class EnemyStats
{
    [Tooltip("Type of Enemy")]
    public EnemyType Type;

    [Tooltip("Enemy can only be damaged by this weapon")]
    public WeaponType Weakness;

    public int Health = 0;
    public float MovementSpeed = 0.0f;
    public int Damage = 0;
    public int Points = 0;
    public int Coins = 0;

}

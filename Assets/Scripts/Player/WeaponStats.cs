using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Arrow1,
    Arrow2,
    Arrow3
}

[System.Serializable]
public class WeaponStats
{
    [Tooltip("Type of Arrow")]
    public WeaponType Type;

    [Tooltip("Damage per arrow")]
    public int Damage = 0;

    [Tooltip("Arrow count per quiver")]
    public int ArrowCount = 0;
}

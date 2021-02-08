using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShootProperty 
{
    [Tooltip("Amount of time to shoot again.")]
    public float ShootInterval = 0.5f;

    [Tooltip("Destroy bullet after N seconds")]
    public float BulletLifetime = 10f;
}

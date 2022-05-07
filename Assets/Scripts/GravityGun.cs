using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New gun", menuName = "Guns/Gravity gun")]
public class GravityGun : GunConfig
{
    public float force;

    public float radius;
}

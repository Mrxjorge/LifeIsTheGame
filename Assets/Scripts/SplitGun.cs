using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New gun", menuName = "Guns/Split gun")]
public class SplitGun : GunConfig
{
    public int shards;

    public float separationAngle;
}

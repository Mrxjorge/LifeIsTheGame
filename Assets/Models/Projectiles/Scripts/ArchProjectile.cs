using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchProjectile : Projectile
{

    public bool bounce;

    public PhysicMaterial bouncyMat;

    public override void Launch(Vector3 direction, float velocity)
    {
        Debug.Log("ArchProjectile.Launch");
        base.Launch(direction, velocity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityProjectile : Projectile
{
    public float force;

    public float radius;

    public GameObject blackHole;

    public override void Launch(Vector3 direction, float velocity)
    {
        StartTimer(3);
        timeOver += spawnBlackHole;
        base.Launch(direction, velocity);
    }

    private void spawnBlackHole()
    {
        GameObject spawned = Instantiate(blackHole, gameObject.transform.position, Quaternion.identity);
        BlackHole bh = spawned.GetComponent<BlackHole>();
        bh.radius = this.radius;
        bh.force = this.force;
        bh.UpdateRadius();
        bh.startTimer(7);
    }
}

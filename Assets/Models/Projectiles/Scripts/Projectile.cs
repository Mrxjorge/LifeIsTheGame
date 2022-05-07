using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    protected delegate void TimeOver();
    protected TimeOver timeOver;

    public float velocity;

    public bool useGravity = true;

    protected Rigidbody rb;

    protected Collider coll;

    private float countdown = -1f;

    private bool isCounting = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    protected void StartTimer(float duration)
    {
        Debug.Log("Starting timer of " + duration);
        countdown = duration;
        isCounting = true;
    }

    public void stopTimer()
    {
        countdown = 0;
        isCounting = false;
    }

    private void Update()
    {
        if (isCounting)
        {
            if (countdown > 0)
            {
                countdown -= Time.deltaTime;
            }
            else
            {
                isCounting = false;
                timeOver();
                Debug.Log("Time over");
            }
        }
    }

    public virtual void Launch(Vector3 direction, float velocity)
    {
        Debug.Log("Projectile.Launch");
        this.velocity = velocity;
        GetComponent<Rigidbody>().AddForce(velocity * direction);
    }
}

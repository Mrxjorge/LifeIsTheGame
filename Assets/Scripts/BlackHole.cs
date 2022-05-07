using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{

    public float radius;

    public float force;

    private float countdown = 0;

    private bool isCounting = false;

    public void startTimer(float duration)
    {
        countdown = duration;
        isCounting = true;
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
                Destroy(gameObject);
                Debug.Log("Time over");
            }
        }
    }

    private void Start()
    {
        UpdateRadius();
    }

    public void UpdateRadius()
    {
        GetComponent<SphereCollider>().radius = radius;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<Projectile>())
        {
            Vector3 direction = gameObject.transform.position - other.gameObject.transform.position;
            float distance = Vector3.Distance(gameObject.transform.position, other.gameObject.transform.position);
            float currentForce = force / (distance * distance);
            other.gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * force * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunActivator : MonoBehaviour
{

    public GunConfig toActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent && other.gameObject.transform.parent.gameObject.name == "FPSPlayer")
        {
            Debug.Log("FPSPlayer in activator");
            Debug.Log("Component name: " + other.gameObject.name);
            BodyCollider body = other.gameObject.GetComponent<BodyCollider>();
            body.ActivateGun(toActivate.GetType());
        }
    }

}

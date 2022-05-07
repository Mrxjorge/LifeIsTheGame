using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollider : MonoBehaviour
{
    public GameObject GunSocket;

    public void ActivateGun(System.Type Gun)
    {
        Debug.Log("Activating " + Gun.Name);
        List<GameObject> children = new List<GameObject>();
        int childCount = GunSocket.transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            children.Add(GunSocket.transform.GetChild(i).gameObject);
        }
        foreach(GameObject x in children)
        {
            Gun currentGun = x.GetComponent<Gun>();
            if(currentGun.gunConfig.GetType() == Gun)
            {
                currentGun.controlGunActivation(true);
                break;
            }
        }
    }
}

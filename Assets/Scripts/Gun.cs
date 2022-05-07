using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunConfig gunConfig;

    public GameObject spawnPoint;

    public Camera playerCam;

    private System.Type gunType;

    private void Awake()
    {
        gunType = gunConfig.GetType();
        Debug.Log(gunType.Name);
        gameObject.SetActive(false);
    }

    public void controlGunActivation(bool Action)
    {
        if(Action)
        {
            Gun[] guns = FindObjectsOfType<Gun>();
            foreach (Gun x in guns)
            {
                x.gameObject.SetActive(false);
            }
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void Shoot()
    {
        Debug.Log("Gun.Shoot");
        GameObject projectile = Instantiate(gunConfig.toSpawn, spawnPoint.transform.position, spawnPoint.transform.rotation);
        var comp = projectile.GetComponent<Projectile>();
        Debug.Log(comp.GetType().Name);
        switch(comp.GetType().Name)
        {
            case "ArchProjectile":
                Debug.Log("Gun.Shoot.ArchGun");
                ArchGun archGun = gunConfig as ArchGun;
                ArchProjectile archProjectile = projectile.GetComponent<ArchProjectile>();
                archProjectile.Launch(playerCam.transform.forward.normalized, gunConfig.projectileSpeed);
                break;
            case "SplitProjectile":
                
                break;
            case "GravityProjectile":
                Debug.Log("Gun.Shoot.GravityGun");
                GravityGun gravityGun = gunConfig as GravityGun;
                GravityProjectile gravityProjectile = projectile.GetComponent<GravityProjectile>();
                gravityProjectile.Launch(playerCam.transform.forward.normalized, gunConfig.projectileSpeed);
                break;
        }
        //projectile.GetComponent<Rigidbody>().AddForce(playerCam.transform.forward.normalized * gunConfig.projectileSpeed);
    }
}

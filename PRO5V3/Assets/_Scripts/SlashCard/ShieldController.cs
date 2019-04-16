using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [HideInInspector]
    public GameObject currentProjectile = null;

    public LauncherManager launcher;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("projectile"))
        {
            currentProjectile = other.gameObject;
            currentProjectile.GetComponent<ProjectileController>().enabled = false;
        }
    }

    private void Update()
    {
        if (currentProjectile != null)
        {
            currentProjectile.transform.position = this.transform.GetChild(0).transform.position;
        }
    }

    public void ShootProjectile()
    {
        Destroy(currentProjectile);
        launcher.NextLauncher();
    }
}

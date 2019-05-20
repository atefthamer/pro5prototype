using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [HideInInspector]
    public GameObject currentProjectile = null;

    public LineRenderer pointer;
    public GameObject pointerEnd;
    private GameObject shootingPoint;
    [HideInInspector]
    public bool fired = false;
    public float speed = 1.0f;

    public LauncherManager launcher;
    public TargetManager tMan;

    private void Start()
    {
        shootingPoint = new GameObject("ShootingPoint");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("projectile"))
        {
            currentProjectile = other.gameObject;
            currentProjectile.GetComponent<ProjectileController>().enabled = false;
            currentProjectile.GetComponent<AudioSource>().enabled = false;
            this.transform.GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        pointer.SetPosition(0, transform.position);
        pointer.SetPosition(1, pointerEnd.transform.position);

        if (currentProjectile != null && fired == false && tMan.score < 5)
        {
            currentProjectile.transform.position = this.transform.GetChild(0).transform.position;
        }
        else if (currentProjectile != null && fired == true && tMan.score < 5)
        {
            float shot = speed * Time.deltaTime;
            currentProjectile.transform.position = Vector3.MoveTowards(currentProjectile.transform.position, shootingPoint.transform.position, shot);

            if (Vector3.Distance(currentProjectile.transform.position, shootingPoint.transform.position) < 0.001f)
            {
                Destroy(currentProjectile);
                currentProjectile = null;
                fired = false;
                launcher.NextLauncher();
            }
        }
    }

    public void ShootProjectile()
    {
        shootingPoint.transform.position = pointerEnd.transform.position;
        this.transform.GetChild(1).gameObject.SetActive(false);
        this.transform.GetChild(2).gameObject.SetActive(false);
        fired = true;
    }
}

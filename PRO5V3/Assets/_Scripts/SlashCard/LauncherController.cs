using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;

    private void OnEnable()
    {
        GameObject shoot = Instantiate(projectile, this.transform.position, Quaternion.identity);
    }
}

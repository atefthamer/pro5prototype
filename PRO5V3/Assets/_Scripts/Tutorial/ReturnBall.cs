﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBall : MonoBehaviour
{
    private Vector3 startPos;
    private bool respawn;
    public GameObject particle;

    [SerializeField]
    Transform activeCamera = null;

    public void Start()
    {
        startPos = this.transform.position;
        respawn = false;
    }

    private void Update()
    {
        if (respawn == true)
        {
            this.transform.position = startPos;
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            respawn = false;
        }
    }

    public void RespawnBall()
    {
        respawn = true;
    }

    public void Explode()
    {
        GameObject explode = Instantiate(particle, this.transform.position, Quaternion.identity);
        explode.GetComponent<ParticleController>().targetCamera = (Transform)activeCamera;
        particle.GetComponent<ParticleSystem>().Play();
        Destroy(explode, 1.0f);
    }
}

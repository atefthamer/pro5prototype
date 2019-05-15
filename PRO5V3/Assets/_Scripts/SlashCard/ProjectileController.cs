using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    protected float anim;
    private Vector3 startPos;
    private Vector3 playerPos;
    private GameObject player;

    private void Start()
    {
        startPos = this.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
    }

    void Update()
    {
        anim += Time.deltaTime;
        anim = anim % 4f;
        transform.position = MathParabola.Parabola(startPos, playerPos, 3.5f, anim / 1.5f);
    }
}

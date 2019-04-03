﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticule : MonoBehaviour
{
    public Pointer m_Pointer;
    public SpriteRenderer m_CircleRenderer;

    public Sprite m_OpenSprite;
    public Sprite m_ClosedSprite;

    private Camera m_Camera = null;

    [SerializeField]
    Transform activeCamera = null;

    public GameObject particle;

    private void Awake()
    {
        m_Pointer.OnPointerUpdate += UpdateSprite;

        m_Camera = Camera.main;
    }

    private void Update()
    {
        transform.LookAt(m_Camera.gameObject.transform);
    }

    private void OnDestroy()
    {
        m_Pointer.OnPointerUpdate -= UpdateSprite;
    }

    private void UpdateSprite(Vector3 point, GameObject hitObject)
    {
        transform.position = point;

        if (hitObject)
        {
            m_CircleRenderer.sprite = m_ClosedSprite;
        }
        else
        {
            m_CircleRenderer.sprite = m_OpenSprite;
        }
    }

    public void Explode()
    {
        GameObject explode = Instantiate(particle, this.transform.position, Quaternion.identity);
        explode.GetComponent<ParticleController>().targetCamera = (Transform)activeCamera;
        particle.GetComponent<ParticleSystem>().Play();
        Destroy(explode, 2.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThrowInteractable : MonoBehaviour
{
    [HideInInspector]
    public ThrowHand m_ActiveHand = null;
}

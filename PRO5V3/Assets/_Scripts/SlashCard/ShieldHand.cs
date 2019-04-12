using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ShieldHand : MonoBehaviour
{
    public SteamVR_Action_Boolean m_GrabAction = null;
    private SteamVR_Behaviour_Pose m_Pose = null;

    public ShieldController shield;

    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    private void Update()
    {
        // Down
        if (m_GrabAction.GetStateDown(m_Pose.inputSource))
        {
            shield.ShootProjectile();
        }
    }
}

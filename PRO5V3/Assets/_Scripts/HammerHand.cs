using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HammerHand : MonoBehaviour
{
    public SteamVR_Action_Boolean m_GrabAction = null;

    private SteamVR_Behaviour_Pose m_Pose = null;
    private FixedJoint m_Joint = null;

    public GameObject hammer;

    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();
    }

    private void Update()
    {
        // Down
        if (m_GrabAction.GetStateDown(m_Pose.inputSource))
        {
            print(m_Pose.inputSource + " Trigger Down");
            ChargeHammer();
        }

        // Up
        if (m_GrabAction.GetStateUp(m_Pose.inputSource))
        {
            print(m_Pose.inputSource + " Trigger Up");
            DischargeHammer();
        }
    }

    public void ChargeHammer()
    {
        hammer.gameObject.GetComponent<BoxCollider>().enabled = true;
        hammer.gameObject.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void DischargeHammer()
    {
        hammer.gameObject.GetComponent<BoxCollider>().enabled = false;
        hammer.gameObject.transform.GetChild(3).gameObject.SetActive(false);
    }
}

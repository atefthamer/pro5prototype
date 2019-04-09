using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HandBalloon : MonoBehaviour
{
    public SteamVR_Action_Boolean m_GrabAction = null;

    private SteamVR_Behaviour_Pose m_Pose = null;
    private FixedJoint m_Joint = null;

    private Interactable m_CurrentInteractable = null;
    public List<Interactable> m_ContactInteractables = new List<Interactable>();

    public BalloonManager bManager;

    //public BalloonController balloon;
    //public GameObject[] balloons;
    //[SerializeField]
    //List<GameObject> balloons = new List<GameObject>();

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
            //print(m_Pose.inputSource + " Trigger Down");
            foreach (GameObject obj in bManager.balloons)
            {
                obj.GetComponent<BalloonController>().hit = true;

                if (obj.GetComponent<BalloonController>().hit == true)
                {
                    obj.GetComponent<BalloonController>().BalloonScaler();
                }
            }
        }
        if (m_GrabAction.GetStateUp(m_Pose.inputSource))
        {
            //print(m_Pose.inputSource + " Trigger Up");
            foreach (GameObject obj in bManager.balloons)
            {
                obj.GetComponent<BalloonController>().hit = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;

        m_ContactInteractables.Add(other.gameObject.GetComponent<Interactable>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;

        m_ContactInteractables.Remove(other.gameObject.GetComponent<Interactable>());
    }
}
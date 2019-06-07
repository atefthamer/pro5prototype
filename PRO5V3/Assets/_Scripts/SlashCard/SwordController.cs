using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public GameObject swordRunes;
    private bool stopAnimation;

    private void Start()
    {
        stopAnimation = false;
    }

    public void ChargeSword()
    {
        StartCoroutine(runesBlinking());
        //this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

    }

    public void UnchargeSword()
    {
        stopAnimation = true;
        //this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    private IEnumerator runesBlinking()
    {
        swordRunes.gameObject.GetComponent<Animator>().Play("SwordRunesBlinking");
        yield return new WaitUntil(() => stopAnimation == true);
        swordRunes.gameObject.GetComponent<Animator>().Play("SwordRunesBlinking_Idle");
        stopAnimation = false;
    }
}

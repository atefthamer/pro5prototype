using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour {

    public float scaleFactor = 1.2f;
    public float maxScale = 8;
    private bool pop = false;
    public BalloonSoundScript sound;
    public BLN_Rub_SFX bln_rub;
    public SceneSwitch sw;

    [SerializeField]
    public bool hit = false;

    public void BalloonScaler() {
        transform.localScale *= scaleFactor;
        bln_rub.PlaySound();

        if (transform.localScale.x >= maxScale) {
            sound.PlaySound();
            Destroy(gameObject);
            pop = true;

            if (pop == true)
            {
                sw.DestroyPlayer(3);
            }
        }
    }
}
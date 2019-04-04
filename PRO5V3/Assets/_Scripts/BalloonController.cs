using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour {

    public float scaleFactor = 1.2f;
    public float maxScale = 8;
    public BalloonSoundScript sound;
    public BLN_Rub_SFX bln_rub;

    // Start is called before the first frame update
    void Start() {
        if (scaleFactor <= 1);
    }
    void OnMouseDown() {
        transform.localScale *= scaleFactor;
        bln_rub.PlaySound();
        if (transform.localScale.x >= maxScale) {
            sound.PlaySound();
            Destroy(gameObject);
        }
    }
}
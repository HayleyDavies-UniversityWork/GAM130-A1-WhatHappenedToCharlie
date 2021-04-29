using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {
    public Animator anim;

    // Update is called once per frame
    public void RunAnimations() {
        anim.SetFloat("Vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        if (Input.GetKeyDown(KeyCode.E)) {
            anim.SetTrigger("PickUp");
        } else {
            anim.ResetTrigger("PickUp");
        }
    }
}
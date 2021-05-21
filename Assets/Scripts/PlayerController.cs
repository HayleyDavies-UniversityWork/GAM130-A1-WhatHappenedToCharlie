using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerSpeed;
    public float speedRot = 10f;
    private Vector3 movement = Vector3.zero;

    public bool playerEnabled = true;

    public Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        ControlPlayer();
    }

    void ControlPlayer() {
        CharacterController controller = GetComponent<CharacterController>();
        // DO NOT REMOVE
        // IF YOU DO, THE CAMERA WILL BOUNCE.
        // WHY? NO IDEA!
        controller.Move(Vector3.zero);

        if (playerEnabled) {
            movement = new Vector3(0, 0, Input.GetAxis("Vertical"));
            movement = transform.TransformDirection(movement);
            movement *= playerSpeed * Time.deltaTime;
            RunAnimations();
            transform.Rotate(0, Input.GetAxis("Horizontal") * speedRot * Time.deltaTime, 0);
            controller.Move(movement);
        } else {
            anim.SetFloat("Vertical", 0);
            anim.SetFloat("Horizontal", 0);
        }
    }

    public void SetControllable(bool controllable) {
        playerEnabled = controllable;
    }

    public void RunAnimations() {
        anim.SetFloat("Vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
    }
}
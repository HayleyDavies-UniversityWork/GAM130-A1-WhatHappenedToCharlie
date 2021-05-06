using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerSpeed;
    public float speedRot = 10f;
    private Vector3 movement = Vector3.zero;

    public bool playerEnabled = true;

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
            GetComponent<Walk>().RunAnimations();
            transform.Rotate(0, Input.GetAxis("Horizontal") * speedRot * Time.deltaTime, 0);
            controller.Move(movement);
        }
    }

    public void SetControllable(bool controllable) {
        playerEnabled = controllable;
    }
}
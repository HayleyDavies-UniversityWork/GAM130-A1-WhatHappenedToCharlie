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
        if (playerEnabled) {
            CharacterController controller = GetComponent<CharacterController>();
            GetComponent<Walk>().RunAnimations();

            movement = new Vector3(0, 0, Input.GetAxis("Vertical"));
            movement = transform.TransformDirection(movement);
            movement *= playerSpeed * Time.deltaTime;
            transform.Rotate(0, Input.GetAxis("Horizontal") * speedRot * Time.deltaTime, 0);
            controller.Move(movement);
        }
    }

    public void SetControllable(bool controllable) {
        playerEnabled = controllable;
    }
}
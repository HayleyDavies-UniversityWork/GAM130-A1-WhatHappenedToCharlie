using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed;
    public float speedRot = 10f;
    private Vector3 movement = Vector3.zero;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        movement = new Vector3(0, 0, Input.GetAxis("Vertical"));
        movement = transform.TransformDirection(movement);
        movement *= playerSpeed * Time.deltaTime;
        transform.Rotate(0, Input.GetAxis("Horizontal") * speedRot * Time.deltaTime,0);
        controller.Move(movement);

    }
}


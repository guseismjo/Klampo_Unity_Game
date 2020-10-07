using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public float jumpSpeed = 1.0f;
    private CharacterController _charCont;
    // Start is called before the first frame update
    void Start()
    {
        _charCont = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);


        movement = Vector3.ClampMagnitude(movement, speed); //clamps the movement speed to speed.



        movement.y += gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        /*
        if (Input.GetButton("Jump"))
        {
            movement.y = jumpSpeed;
        }
        */
        _charCont.Move(movement);



    }
}

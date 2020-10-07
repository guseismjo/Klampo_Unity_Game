using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float minVert = -45.0f;
    public float maxVert = 45.0f;
    public float sensHorizontal = 5.0f;
    public float sensVertical = 5.0f;
    public float _rotationX = 0.0f;

    public enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axis = RotationAxis.MouseX;
    // Update is called once per frame
    void Update()
    {
        if (axis == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0);
        }
        else if (axis == RotationAxis.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensVertical;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert); //keeps the vertical angle within the min and max limits
            float rotationY = transform.localEulerAngles.y;         //keeps the y angle the same so there is no horizontal rotation
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

        }
    }
}

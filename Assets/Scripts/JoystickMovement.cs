using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    public Rigidbody cubeRb;
    public float speed;

    private Joystick _joyStick;
    // Start is called before the first frame update
    void Start()
    {
        _joyStick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCube();
    }

    public void MoveCube()
    {
        Vector3 direction = new Vector3(_joyStick.Direction.x, 0, _joyStick.Direction.y);
        cubeRb.velocity = direction * speed;
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //movement variable
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool moving = false;

    //movement vector
    Vector2 move;

    //Find rigidBody
    public Rigidbody2D rb;

    InputAction.CallbackContext useMe;
    public void Jump()
    {
        Debug.Log("Jumped?");
        move = Vector2.up;
    }
    public void Move(InputAction.CallbackContext context)
    {
        if (context.started || context.canceled)
        {
            Debug.Log("pressed"+ context.control.name);
            if (moving) {moving = false;}
            else {moving = true;}
        }
        useMe = context;
    }
    //Runs the code every time unity updates
    public void Update()
    {
        if (moving) {direction(useMe);}
        else {move = Vector2.zero; Debug.Log("Speed: "+move); direction(useMe);}
    }
    private void direction(InputAction.CallbackContext useMe)
    {
        if (!useMe.performed) {return;}
        switch (useMe.control.name)
        {
            case "w":
                move.y = 1;
                rb.AddForce(move * speed);
                break;
            case "a":
                move.x = -1;
                rb.AddForce(move * speed);
                break;
            case "s":
                move.y = -1;
                rb.AddForce(move * speed);
                break;
            case "d":
                move.x = 1;
                rb.AddForce(move * speed);
                break;
        }
    }
}

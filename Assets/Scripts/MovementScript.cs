using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    //Movement Actions
    private InputAction _moveAction, _dashAction;

    //Rigidbody
    Rigidbody2D rb;

    //Vector
    Vector2 moveVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Asign Actions to Actionmaps...?
        _moveAction = InputSystem.actions["Player/Move"];
        _dashAction = InputSystem.actions["Player/Dash"];

        //Get Rigidbody Component
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        moveVector = _moveAction.ReadValue<Vector2>();
        //Debug.Log("ah: "+moveVector);

        rb.AddForce(moveVector * speed * Time.deltaTime);
    }
}

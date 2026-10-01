using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    //variables
    [SerializeField] float speed = 1f;

    //Movement Actions
    private InputAction _moveAction;

    //Rigidbody
    Rigidbody2D rb;

    //Vector
    Vector2 moveVector;
    public Vector2 force = Vector2.zero;

    private void Awake()
    {
        //Assign Actions to Actionmaps
        _moveAction = InputSystem.actions["Player/Move"];
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get Rigidbody Component
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Get vector value from action
        moveVector = _moveAction.ReadValue<Vector2>();
            //Debug.Log("ah: "+moveVector);

        //Using this convoluted code so that Force can be used in the bullet script. 
        force = (moveVector * speed * Time.deltaTime);
        rb.AddForce(force);
    }
}

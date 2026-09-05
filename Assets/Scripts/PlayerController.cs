using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    //movement variables
    [SerializeField] private float speed = 2f;

    //movement vectors
    Vector2 move;

    //Måste göra en Callback Action stuff!!!
    InputAction.CallbackContext context;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("HEJ");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(InputAction.CallbackContext context)
    {
        
        Debug.Log("Tryckt knapp: "+context.control.name);
    }
    public void Jump()
    {
        Debug.Log("Tryckt knapp: ");
    }

}

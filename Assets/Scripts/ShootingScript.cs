using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingScript : MonoBehaviour
{
    //To Find position 
    [SerializeReference]private Camera mainCam;
    private Vector2 mousePos;
    public Transform rotPoint;
    private float rotZ;

    //For Activate Shooting
    private InputAction shooting;


    //Movement Actions
    private InputAction _shootAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Asign Actions to Actionmaps...?
        _shootAction = InputSystem.actions["Player/Shoot"];
    }

    // Update is called once per frame
    void Update()
    {
        //Aim
        mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        var rotation = ((Vector3)mousePos - transform.position).normalized;
        rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        rotPoint.rotation = Quaternion.Euler(0f, 0f, rotZ);

        //Run through Shoot void
        Shoot();
    }

    public void Shoot()
    {
        if (_shootAction.WasPerformedThisDynamicUpdate())
        {
            Debug.Log("SHOOOT!!!");
        }
        else if (_shootAction.WasCompletedThisDynamicUpdate())
        {
            Debug.Log("Not SHOOT??!!");
        }
        
    }
}

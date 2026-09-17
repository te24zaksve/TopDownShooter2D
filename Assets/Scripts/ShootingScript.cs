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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        var rotation = ((Vector3)mousePos - transform.position).normalized;
        rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        rotPoint.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
}

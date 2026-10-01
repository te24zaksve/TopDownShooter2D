using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimScript : MonoBehaviour
{
    //AIM
    //To Find position 
    [SerializeReference]private Camera mainCam;

    //Vector/direction to mouse
    private Vector2 mousePos;

    //transform that will rotate
    public Transform rotPoint;

    //The rotation calculation
    private float rotZ;

    // Update is called once per frame
    void Update()
    {
        //Find mouse position
        mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
        //Calculate direction based on mouse and playerTransform
        var rotation = ((Vector3)mousePos - transform.position).normalized;
        rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        rotPoint.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
}

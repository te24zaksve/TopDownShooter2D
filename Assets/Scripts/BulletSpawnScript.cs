using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletSpawnScript : MonoBehaviour
{
    //SHOOT

    //Shoot Actions
    private InputAction _shootAction;

    //Projectile/bullet
    public Rigidbody2D prefabRb;
    public Transform BulletSpawnPoint;

    //Variables
    bool activeShooting = false;
    bool allowedToShoot = true;
    bool fireBullet = true;
    [SerializeField] float reloadTime = 1;
    [SerializeField] float bulletSpeed = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Asign Actions to Actionmaps
        _shootAction = InputSystem.actions["Player/Shoot"];
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the shoot button is being held down

        //Debug.Log("Allowed to shoot: "+ allowedToShoot);
        if (allowedToShoot)
        {
            if (_shootAction.WasPressedThisFrame())
            {
                activeShooting = true;
            }
            else if (_shootAction.WasReleasedThisFrame())
            {
                activeShooting = false;
            }
            //Debug.Log("Actively Shooting: "+ activeShooting);
            if (activeShooting)
            {
                allowedToShoot = false;
                Shooting();
                allowedToShoot = true;
            }
            return;
        }
    }

    void Shooting()
    {
        //Spawns a bullet based on reload time.
        if (fireBullet)
        {
            Rigidbody2D clone;
            clone = Instantiate(prefabRb, BulletSpawnPoint.position, transform.rotation);
            //Vector2 positive = new Vector2(Mathf.Abs(add.x), Mathf.Abs(add.y));
            clone.linearVelocity = transform.TransformDirection(Vector2.right * bulletSpeed);
            fireBullet = false;
            Invoke("TimeDelay", 1f * reloadTime);
        }
    }
    void TimeDelay()
    {
        fireBullet = true;
    }
}

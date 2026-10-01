using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //Variables
    [SerializeField] GameObject gameObject;
    public int seconds = 1;
    float time;

    // Update is called once per frame
    void Update()
    {
        //sets up a timer
        time += Time.deltaTime;
        timer(seconds);
        
    }

    void timer(int seconds)
    {
        //Destroys the projectile after a set amount of time 
        if (time < seconds)
        {
            //Debug.Log(time+"'s");
        }
        else if (gameObject.name == "Bullet(Clone)")
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        //When colliding with a Enemy Bullet gets destroyed
        if (hit.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("Collided Enemy");
            Destroy(gameObject);
        }
    }
}

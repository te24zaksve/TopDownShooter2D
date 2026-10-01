using UnityEngine;

public class PlayerHealthScrip : MonoBehaviour
{
    //Variables
    public float health = 10;
    public bool canAttack = true;

    // Update is called once per frame
    void Update()
    {
        //When health reaches 0 player get destroyed
        // alongside all of its children including camera :(
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    //I have 2 methods where on activates when collision appears
    // and one while collisions are continually touching.
    void OnTriggerEnter2D(Collider2D hit)
    {
        //Debug.Log("Enter");
        GetHurt(hit);
    }
    private void OnTriggerStay2D(Collider2D hit)
    {
        //Debug.Log("Stay");
        GetHurt(hit);
    }
    void GetHurt(Collider2D hit)
    {
        //When colliding with enemy take damage

        //Debug.Log("GetHurt by: " + hit);
        if ((hit.gameObject.CompareTag("Enemy") && (canAttack)))
        {
            health -= 1;
            canAttack = false;

            //Invulnerability time
            Invoke("GotHurt", 0.5f);
        }
    }
    void GotHurt()
    {
        canAttack = true;
    }
}

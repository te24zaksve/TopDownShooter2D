using UnityEngine;

public class PlayerHealthScrip : MonoBehaviour
{
    public float health = 10;
    public bool canAttack = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
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

        //Debug.Log("GetHurt by: " + hit);
        if ((hit.gameObject.CompareTag("Enemy") && (canAttack)))
        {
            health -= 1;
            canAttack = false;
            Invoke("GotHurt", 0.5f);
        }
    }
    void GotHurt()
    {
        canAttack = true;
    }
}

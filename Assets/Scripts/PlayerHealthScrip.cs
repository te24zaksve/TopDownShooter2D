using UnityEngine;

public class PlayerHealthScrip : MonoBehaviour
{
    public float health = 10;

    public bool canAttack = true;
    GameObject capsule;
    public Transform capTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        capTransform = gameObject.GetComponentInChildren<Transform>();
        Debug.Log("Capsule transform?"+capTransform);

        capsule = capTransform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(capsule);
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
            Invoke("GotHurt", 2);
        }
    }
    void GotHurt()
    {
        canAttack = true;
    }
}

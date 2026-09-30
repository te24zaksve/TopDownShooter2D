using System;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    //Target pos = Source pos normalized.
    public float moveSpeed = 1f;
    public Rigidbody2D rb;
    private Vector2 _movementDelta;
    private float _rotation;
    [SerializeField] Transform target;
    [SerializeField] float enemyHealth = 10;

    public void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        //Debug.Log("Player:"+player);
        target = player.transform;
    }
    private void Update()
    {
        //Debug.Log("Target:" + target);
        var directionToTarget = ((Vector2)target.position - rb.position).normalized;
        float rotation = MathF.Atan2(directionToTarget.y, directionToTarget.x) * 180/MathF.PI - 90f;
        _movementDelta = directionToTarget * moveSpeed;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movementDelta * Time.fixedDeltaTime);
        rb.SetRotation(_rotation);

    }

    void OnTriggerEnter2D(Collider2D gotHit)
    {
        //Debug.Log("Enemy Got hit by" + gotHit.tag + ", Enemy health: " + enemyHealth);

        if (gotHit.gameObject.CompareTag("Projectile"))
        {
            enemyHealth -= 1;
            //Debug.Log("EnemySelf got hurt" + enemyHealth);
            if (enemyHealth <= 0) 
            {
                //Debug.Log("DIED");
                Destroy(gameObject);
            }
        }
    }
}

using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    //Target pos = Source pos normalized.

    public Transform target;
    public float moveSpeed = 1f;
    public Rigidbody2D rb;
    private Vector2 _movementDelta;
    private float _rotation;
    private void Update()
    {
        var directionToTarget = ((Vector2)target.position - rb.position).normalized;
        float rotation = MathF.Atan2(directionToTarget.y, directionToTarget.x) * 180/MathF.PI - 90f;
        _movementDelta = directionToTarget * moveSpeed;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movementDelta * Time.fixedDeltaTime);
        rb.SetRotation(_rotation);
    }
    
}

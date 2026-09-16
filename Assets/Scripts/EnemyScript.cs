using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    //Target pos = Source pos normalized.

    public Transform playerTransform;
    public float moveSpeed = 1f;

    private void Update()
    {
        //Vector2 directionToPlayer = Vector2.Normalize(playerTransform.position-transform.position);
        //transform.rotation = Quaternion.LookRotation(directionToPlayer, Vector3.forward);



    }
}

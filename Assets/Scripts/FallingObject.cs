using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField]
    private Transform collisionCheckObject;
    [SerializeField]
    private float collisionCheckRadius = 3.0f;
    [SerializeField]
    private LayerMask groundCheckLayer;

    // Update is called once per frame
    void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(collisionCheckObject.position, collisionCheckRadius, groundCheckLayer);

        bool isGround = (collider != null);

        if (isGround)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (collisionCheckObject != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(collisionCheckObject.position, collisionCheckRadius);
        }
    }
}

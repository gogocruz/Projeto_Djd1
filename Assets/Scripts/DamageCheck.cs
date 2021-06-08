using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCheck : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private GameObject fallingGameObject;
    private float distance;

    void OnTriggerEnter2D(Collider2D collision)
    {
        FallingObject fallingObject = collision.GetComponent<FallingObject>();
        fallingGameObject = collision.gameObject;

        if (fallingObject != null)
        {
            Vector2 hitDirection = player.transform.position - fallingGameObject.transform.position;
            Vector2 normalizedHitDirection = hitDirection.normalized;

            if (normalizedHitDirection.x > 0)
            {
                distance = player.knockbackDistance;
            }
            else if (normalizedHitDirection.x < 0)
            {
                distance = -player.knockbackDistance;
            }

            player.TakeKnockback(normalizedHitDirection, distance);
            Destroy(fallingGameObject);
        }
    }
}

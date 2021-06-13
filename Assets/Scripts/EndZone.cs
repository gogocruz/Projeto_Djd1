using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            if (player.CanFinishLevel)
            {
                Debug.Log("Level complete");
            }
            else
            {
                Debug.Log("Cant exit yet");
            }
        }
    }
}

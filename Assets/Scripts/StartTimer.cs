using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimer : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            Timer timer = FindObjectOfType<Timer>(true);
            Debug.Log("Player is here");
            timer.Activate();
        }
        else
        {
            Debug.Log("Did't find Player");
        }
    }
}

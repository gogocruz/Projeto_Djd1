using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStop : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
        if (collision.tag == "Player")
        {
            Timer timer = FindObjectOfType<Timer>();

            if (timer != null)
            {   
                if (timer.StartCount)
                {
                    timer.StopCount();
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            if (player.CanFinishLevel)
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                LevelLoader levelLoader = FindObjectOfType<LevelLoader>();

                if (levelLoader != null)
                {
                    levelLoader.IsLevelComplete = true;
                }
            }
        }
    }
}

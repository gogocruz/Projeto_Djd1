using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarsTrigger : MonoBehaviour
{
    [SerializeField]
    DialogueSystem.DialogueItem[] dialogue;
    [SerializeField]
    Sprite image;
    [SerializeField]
    private int scoreIncrease = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.UpdateScore(scoreIncrease);
            DialogueSystem ds = FindObjectOfType<DialogueSystem>();
            
            ds.ShowTarsMessage(dialogue, image);
            Destroy(gameObject);
        }
    }
}

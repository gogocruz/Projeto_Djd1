using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogPickUp : MonoBehaviour
{
    [SerializeField]
    DialogueSystem.DialogueItem[] dialogue;
    [SerializeField]
    Sprite image;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            DialogueSystem ds = FindObjectOfType<DialogueSystem>();
            // ds.StartLog(dialogue);
            // ds.StartDialog(dialogue, GetComponent<SpriteRenderer>(), player);
            ds.StartLog(dialogue, image);
            Destroy(gameObject);
        }
    }
}

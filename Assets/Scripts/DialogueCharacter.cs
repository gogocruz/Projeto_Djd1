using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCharacter : MonoBehaviour
{
    [SerializeField]
    DialogueSystem.DialogueItem[] dialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(SpriteRenderer otherObject)
    {
        DialogueSystem ds = FindObjectOfType<DialogueSystem>();
        ds.StartDialog(dialogue, GetComponent<SpriteRenderer>(), otherObject);
    }
}

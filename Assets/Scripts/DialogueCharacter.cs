using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCharacter : MonoBehaviour
{
    [SerializeField]
    DialogueSystem.DialogueItem[] dialogue;

    public void StartDialogue(SpriteRenderer otherObject)
    {
        DialogueSystem ds = FindObjectOfType<DialogueSystem>();
        ds.StartDialog(dialogue, GetComponent<SpriteRenderer>(), otherObject);
    }
}

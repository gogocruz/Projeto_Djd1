using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [System.Serializable]
    public struct DialogueItem
    {
        public bool self;
        public string text;
    };

    [SerializeField]
    GameObject          system;
    [SerializeField]
    TextMeshProUGUI     characterName;
    [SerializeField]
    TextMeshProUGUI     dialogueText;
    [SerializeField]
    Image               characterImage;

    DialogueItem[] currentDialogue;
    int            dialogueIndex;
    SpriteRenderer selfSpriteRenderer;
    SpriteRenderer otherSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        system.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDialogue != null)
        {
            if (Input.GetButtonDown("Use"))
            {
                dialogueIndex++;

                if (dialogueIndex < currentDialogue.Length)
                {
                    DisplayDialogue();
                }
                else
                {
                    system.SetActive(false);
                    currentDialogue = null;

                    Player player = FindObjectOfType<Player>();
                    player.enabled = true;
                }
            }
        }
    }

    public void StartDialog(DialogueItem[] dialogue, SpriteRenderer selfObject, SpriteRenderer otherObject)
    {
        Player player = FindObjectOfType<Player>();
        player.enabled = false;

        system.SetActive(true);

        selfSpriteRenderer = selfObject;
        otherSpriteRenderer = otherObject;

        currentDialogue = dialogue;
        dialogueIndex = 0;

        DisplayDialogue();
    }

    private void DisplayDialogue()
    {
        dialogueText.text = currentDialogue[dialogueIndex].text;

        if (currentDialogue[dialogueIndex].self)
        {
            characterName.text = selfSpriteRenderer.name;
            characterImage.sprite = selfSpriteRenderer.sprite;
        }
        else
        {
            characterName.text = otherSpriteRenderer.name;
            characterImage.sprite = otherSpriteRenderer.sprite;
        }
    }
}

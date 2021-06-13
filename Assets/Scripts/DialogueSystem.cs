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
    DialogueItem[] currentLog;
    int            dialogueIndex;
    int            logIndex;
    SpriteRenderer selfSpriteRenderer;
    SpriteRenderer otherSpriteRenderer;
    Sprite         logImage;

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
        else if (currentLog != null)
        {
            if (Input.GetButtonDown("Use"))
            {
                logIndex++;

                if (logIndex < currentLog.Length)
                {
                    ShowLog();
                }
                else
                {
                    system.SetActive(false);
                    currentLog = null;

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

    public void StartLog(DialogueItem[] dialogue, Sprite logSprite)
    {
        Player player = FindObjectOfType<Player>();
        player.enabled = false;

        system.SetActive(true);

        logImage = logSprite;

        currentLog = dialogue;
        logIndex = 0;

        ShowLog();
    }

    private void ShowLog()
    {
        dialogueText.text = currentLog[logIndex].text;

        characterName.text = "Log";
        characterImage.sprite = logImage;
    }

    public void ShowTarsMessage(DialogueItem[] dialogue, Sprite logSprite)
    {
        Player player = FindObjectOfType<Player>();
        player.enabled = false;

        system.SetActive(true);

        logImage = logSprite;

        currentLog = dialogue;
        logIndex = 0;

        ShowMessage();
    }

    public void ShowMessage()
    {
        dialogueText.text = currentLog[logIndex].text;

        characterName.text = "Tars";
        characterImage.sprite = logImage;
    }
}

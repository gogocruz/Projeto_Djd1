using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI countDownText;

    public float CurrentTime { get; private set; }
    
    [SerializeField]
    private float startingTime = 20f;
    public bool StartCount { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        countDownText.enabled = false;
        CurrentTime = startingTime;
        StartCount = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartCount)
        {
            CurrentTime -= 1 * Time.deltaTime;
            
            if (CurrentTime <= 10.0f)
            {
                countDownText.color = new Color32(180, 24, 9, 255);
            }

            countDownText.text = System.String.Format("{0:0.00}", CurrentTime);

            if (CurrentTime <= 0)
            {
                countDownText.text = "0.00";
                countDownText.enabled = false;
            }
        }
    }
    /*public void ResetScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }*/

    public void Activate()
    {
        countDownText.enabled = true;
        StartCount = true;
    }

    public void StopCount()
    {
        countDownText.enabled = false;
        StartCount = false;
    }
}

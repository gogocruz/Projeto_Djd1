﻿using System.Collections;
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
    public bool startCount { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        countDownText.enabled = false;
        CurrentTime = startingTime;
        startCount = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startCount)
        {
            CurrentTime -= 1 * Time.deltaTime;
            //countDownText.text = $"{currentTime.ToString():f4}";
            countDownText.text = System.String.Format("{0:0.00}", CurrentTime);
            //Invoke("ResetScene", startingTime);

            if (CurrentTime <= 0)
            {
                countDownText.text = "0.00";
                countDownText.enabled = false;
            }
        }
    }
    public void ResetScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Activate()
    {
        countDownText.enabled = true;
        startCount = true;
    }

    public void ResetTimer()
    {
        CurrentTime = startingTime;
    }

    public void StopCount()
    {
        countDownText.enabled = false;
        startCount = false;
    }
}

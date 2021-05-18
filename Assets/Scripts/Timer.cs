﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI countDownText;

    private float currentTime = 0f;
    
    [SerializeField]
    private float startingTime = 20f;
    private bool startCount;

    // Start is called before the first frame update
    void Start()
    {
        countDownText.enabled = false;
        currentTime = startingTime;
        startCount = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startCount)
        {
            currentTime -= 1 * Time.deltaTime;
            //countDownText.text = $"{currentTime.ToString():f4}";
            countDownText.text = System.String.Format("{0:0.00}", currentTime);
            Invoke("ResetScene", startingTime);

            if (currentTime <= 0)
            {
                countDownText.text = "0.00";
                
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
}

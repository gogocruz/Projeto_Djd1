﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textScoreElement;

    Player player;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }

        if (player != null)
        {
            int score = player.score;
            string scoreText = $"Score: {score}";

            textScoreElement.text = scoreText;
        }
    }
}

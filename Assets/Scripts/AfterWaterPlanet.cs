using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterWaterPlanet : MonoBehaviour
{
    public void LoadNextScene()
    {
        LevelLoader levelLoader = FindObjectOfType<LevelLoader>();

        if (levelLoader != null)
        {
            levelLoader.IsLevelComplete = true;
        }
    }
}

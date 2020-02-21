﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    public bool onTitleScreen = false;
    void Update()
    {
        
        if (Input.GetKey(KeyCode.E) && onTitleScreen)
        {
            FadeToLevel(1);
        }
        
    }
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
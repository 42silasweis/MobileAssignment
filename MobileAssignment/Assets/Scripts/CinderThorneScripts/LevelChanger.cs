using System.Collections;
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
        // Line of code put into the script you want it to change levels under whatever conditions: FindObjectOfType<LevelChanger>().FadeToLevel(SceneIndexNumber);
        // LevelIndex needs to be an int and it needs to correspond with what is given in the build settings for each scene
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

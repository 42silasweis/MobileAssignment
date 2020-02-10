using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int Lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Lives", Lives);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNewGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("SampleScene");
        
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

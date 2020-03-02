using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void LoadTutorial()
    {
        //SceneManager.LoadScene("Tutorial");
        FindObjectOfType<LevelChanger>().FadeToLevel(1);
    }
    public void LoadBoard1()
    {
        //SceneManager.LoadScene("Board1");
        FindObjectOfType<LevelChanger>().FadeToLevel(2);
    }
    public void LoadBoard2()
    {
        //SceneManager.LoadScene("Board2");
    }
    public void LoadBoard3()
    {
        //SceneManager.LoadScene("Board3");
    }
    public void LoadBoard4()
    {
        //SceneManager.LoadScene("Board4");
    }
    public void LoadMainMenu()
    {
        FindObjectOfType<LevelChanger>().FadeToLevel(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

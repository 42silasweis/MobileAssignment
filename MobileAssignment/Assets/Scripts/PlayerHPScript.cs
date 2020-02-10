using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHPScript : MonoBehaviour
{
    public float Health = 1.0f;
    public int Lives = 3;
    public int maxLives = 3;
    int initialLives;
    float initialHealth;
    public Text healthText;
    public Slider healthSlider;
    public Text liveText;
    public int level = 1;

    private void Start()
    {
        Lives = PlayerPrefs.GetInt("Lives"); //Sets current Lives to what is stored in the Lives playerPrefs
        //PlayerPrefs.SetInt("Lives", Lives);
        initialLives = Lives;
        initialHealth = Health;
        healthText.text = "HEALTH: " + Health + "/" + initialHealth;
        healthSlider.maxValue = Health;
        healthSlider.value = Health;
        //liveText.text = "LIVES: " + Lives;
        liveText.text = "LIVES: " + Lives + "/" + maxLives;
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "LevelEnd")
        {
            if(level == 1)
            {
                SceneManager.LoadScene("Level2");
            }
            if(level == 2)
            {
                SceneManager.LoadScene("Win");
            }
            
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Gethurt();
            if (Health <= 0)
            {
                LoseLife();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (Lives < 0)
            {
                Lives = 0;
                liveText.text = "0";// + Lives;
                SceneManager.LoadScene("Lose");
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    void LoseLife()
    {
        Lives--;
        PlayerPrefs.SetInt("Lives", Lives);
        //liveText.text = "LIVES: " + Lives;
        liveText.text = "LIVES: " + Lives + "/" + maxLives;
        //Health = initialHealth;
    }
    void Gethurt()
    {
        Health--;
        healthText.text = "HEALTH: " + Health + "/" + initialHealth;
        healthSlider.value = Health;
        //Instantiate(deathParticle, player.transform.position, player.transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectCoins2 : MonoBehaviour
{
    public int Coins = 0;
    int initialCoins = 0;
    public int neededCoins;
    public Text coinText;

    void Start()
    {
        coinText.text = "Coins: " + Coins + "/" + neededCoins;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Coins++;
            coinText.text = "COINS: " + Coins + "/" + neededCoins;
            Destroy(collision.gameObject);

            if (Coins >= neededCoins)
            {
                SceneManager.LoadScene("MainMenu");
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    void Update()
    {

    }
}

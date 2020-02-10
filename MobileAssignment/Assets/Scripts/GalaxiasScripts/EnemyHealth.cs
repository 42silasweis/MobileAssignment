using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 6;
    public GameObject heart;
    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Playershoot")
        {
            enemyHealth--;
            if (enemyHealth <= 0)
            {
                GameObject dropheart = Instantiate(heart, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}

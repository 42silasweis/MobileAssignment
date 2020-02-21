using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour
{
    public int health = 130;
    int maxHealth;
    public int healthToIncrease = 58;

    int initialHealth;
    public int defense = 9;
    public int strength = 6;
    public int critChance = 3;
    public int attackSpeed = 7;
    public Slider healthSlider;
    GameObject targetedEnemy;

    void Start()
    {
        maxHealth = health;
        initialHealth = health;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    }

    void Update()
    {
       if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

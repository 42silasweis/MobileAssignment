using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleScript : MonoBehaviour
{
    public int health = 270;
    int maxHealth = 270;
    public int healthToIncrease = 58;

    int initialHealth;
    public int defense = 9;
    public int strength = 3;
    public int critChance = 3;
    public int attackSpeed = 7;
    public int weaponBaseDamage = 58;
    public int finalAttackDamage;
    float timer;

    float shroomTimer;
    public float redShroomDelay = 1.0f;
    public int redShroomDamage = 8;

    public float healthDelay = 1.0f;
    public Text healthText;
    public Slider healthSlider;
    public Slider attack1Slider;

    public bool inCombat = false;
    public bool standingInRedShrooms = false;
    public GameObject cannotUseAttackIndicator;
    GameObject targetedEnemy;
    public GameObject floatingPoints;
    public float attack1CoolDownTime = 8.0f;
    float attack1CoolDown;

    void Start()
    {
        //finalAttackDamage = weaponBaseDamage * strength - targetedEnemy.GetComponent<EnemyHealthScript>().defense;
        //Lives = PlayerPrefs.GetInt("Lives"); //Sets current Lives to what is stored in the Lives playerPrefs
        //PlayerPrefs.SetInt("Lives", Lives);
        initialHealth = health;
        healthText.text = "" + health;// + "/" + initialHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
        attack1Slider.maxValue = attack1CoolDownTime;
        attack1Slider.value = attack1CoolDown;
        //liveText.text = "LIVES: " + Lives;
        //liveText.text = "" + Lives;
    }

    void Update()
    {
        targetedEnemy = GetComponent<FindClosestEnemie>().closestEnemy; 
        timer += Time.deltaTime;
        shroomTimer += Time.deltaTime;
        Attack1CoolDownFunction();
        HealthManagement();
    }
    public void Attack1()
    {
        if(attack1CoolDown >= attack1CoolDownTime && targetedEnemy != null)
        {
            targetedEnemy = GetComponent<FindClosestEnemie>().closestEnemy;
            finalAttackDamage = (weaponBaseDamage * strength) - (targetedEnemy.GetComponent<EnemyHealthScript>().defense); // Calculates the damage output to the selected nearest enemy
            GameObject points = Instantiate(floatingPoints, targetedEnemy.transform.position, Quaternion.identity) as GameObject; // Displays final damage output as text that briefly appears above the enemy
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "" + finalAttackDamage; // Displays final damage output as text that briefly appears above the enemy
            targetedEnemy.GetComponent<EnemyHealthScript>().health -= finalAttackDamage;
            targetedEnemy.GetComponent<EnemyHealthScript>().healthSlider.value = targetedEnemy.GetComponent<EnemyHealthScript>().health;
            attack1CoolDown = 0;
            attack1Slider.value = attack1CoolDown;
            finalAttackDamage = 0;
        }
        
    }
    void HealthManagement()
    {
        if (health < maxHealth && !inCombat && !standingInRedShrooms)
        {
            RegainHealth();
        }
        else if (health > maxHealth && !inCombat && !standingInRedShrooms)
        {
            health = maxHealth;
            healthText.text = "" + health;// + "/" + initialHealth;
            healthSlider.value = health;
        }
        if (health < 0)
        {
            health = 0;
        }
    }
    void Attack1CoolDownFunction()
    {
        if (attack1CoolDown < attack1CoolDownTime)
        {
            attack1CoolDown += Time.deltaTime;
            attack1Slider.value = attack1CoolDown;

            if (cannotUseAttackIndicator.GetComponent<Image>().enabled == false) // Only sets image to darken Attack_1 if it is currently disabled
            {
                cannotUseAttackIndicator.GetComponent<Image>().enabled = true;
            }
        }
        else if (attack1CoolDown >= attack1CoolDownTime && cannotUseAttackIndicator.GetComponent<Image>().enabled == true)// Only sets image to not darken Attack_1 if it is currently enabled
        {
            cannotUseAttackIndicator.GetComponent<Image>().enabled = false;
        }
    }
    void RegainHealth()
    {
        if (timer > healthDelay)
        {
            health += healthToIncrease;
            healthText.text = "" + health;// + "/" + initialHealth;
            healthSlider.value = health;
            timer = 0;
        }      
    }
    void gethurt()
    {
        health--;
        healthText.text = "HEALTH: " + health;// + "/" + initialHealth;
        healthSlider.value = health;
        //Instantiate(deathParticle, player.transform.position, player.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RedShrooms" && shroomTimer > redShroomDelay) //Walking in red mushrooms cause damage
        {
            standingInRedShrooms = true;
            //standingInRedShrooms = true;
            health -= redShroomDamage;
            healthText.text = "" + health;// + "/" + initialHealth;
            healthSlider.value = health;
            shroomTimer = 0;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "RedShrooms" && shroomTimer > redShroomDelay) //Walking in red mushrooms cause damage
        {
            standingInRedShrooms = true;
            //standingInRedShrooms = true;
            health -= redShroomDamage;
            healthText.text = "" + health;// + "/" + initialHealth;
            healthSlider.value = health;
            shroomTimer = 0;
            //Debug.Log("Currently in shrooms" + collision.gameObject.tag);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RedShrooms") //Changes standingInRedShrooms to false so the player may begin regaining health
        {
            standingInRedShrooms = false;
            //Debug.Log("ExitedTrigger");
        }
    }
}

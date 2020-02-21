using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosestEnemie : MonoBehaviour
{
    public GameObject indicator;
    GameObject targetedEnemy;
    GameObject[] allEnemies;
    public GameObject closestEnemy;
    public float tooFar;

    void Update()
    {
        FindClosestEnemy();
    }

    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        //NewEnemyPace closestEnemy = null;
        //NewEnemyPace[] allEnemies = GameObject.FindObjectsOfType<NewEnemyPace>();
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        Vector2 closestEnemyVector = new Vector2(transform.position.x - closestEnemy.transform.position.x, transform.position.y - closestEnemy.transform.position.y);
        if (closestEnemyVector.magnitude > tooFar)
        {
            closestEnemy = null;
        }
        if (closestEnemy != null)
        {
            indicator.transform.position = new Vector3(closestEnemy.transform.position.x, closestEnemy.transform.position.y + 0.8f);
            Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
        }
        if (closestEnemy == null)
        {
            indicator.transform.position = new Vector3(-200, 0, 0);
        }
        
    }
}

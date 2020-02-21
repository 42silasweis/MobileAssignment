using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPointHandler : MonoBehaviour
{
    GameObject floatingPoints;
    void Start()
    {
        Destroy(gameObject, 1.15f);
        transform.localPosition += new Vector3(0, 0.6f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Code for the scripts it is Instantiated in
    void ForOtherScripts()
    {
        GameObject points = Instantiate(floatingPoints, transform.position, Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<TextMesh>().text = "145";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsLayerFix : MonoBehaviour
{
    public string SortingLayerName = "Default";
    public int SortingOrder = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Awake()
    {
        this.gameObject.GetComponent<MeshRenderer>().sortingLayerName = "Foreground";
        //gameObject.GetComponentInChildren<MeshRenderer>().sortingLayerName = SortingLayerName;
        //gameObject.GetComponentInChildren<MeshRenderer>().sortingOrder = SortingOrder;
        this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 50;
    }
}

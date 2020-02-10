using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusMinusButtons : MonoBehaviour
{
    public int roadNumber;
    public int highwayNumber;
    //public Text highwayText;
    public Text roadText;

    // Start is called before the first frame update
    void Start()
    {
        //highwayText.text = "Highway: " + highwayNumber;
        roadText.text = "Road: " + roadNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseRoadNumber()
    {
        roadNumber++;
        roadText.text = "Road: " + roadNumber;
    }
    public void DecreaseRoadNumber()
    {
       roadNumber--;
       roadText.text = "Road: " + roadNumber;
    }
    public void IncreaseHighwayNumber()
    {
        //highwayNumber++;
        //highwayText.text = "Highway: " + highwayNumber;
    }
    public void DecreaseHighwayNumber()
    {
        //highwayNumber--;
        //highwayText.text = "Highway: " + highwayNumber;
    }
}

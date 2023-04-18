using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public TMP_Text goldText;
    public TMP_Text distanceText;

    // Start is called before the first frame update
    void Start()
    {
        goldText.text = EndScore.gold.ToString();
        distanceText.text = EndScore.distance.ToString();

    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShowScore : MonoBehaviour
{
    public TMP_Text goldText;
    public TMP_Text distanceText;
    public Button ButtonPlayAgain;

    // Start is called before the first frame update
    void Start()
    {
        goldText.text = EndScore.gold.ToString();
        distanceText.text = EndScore.distance.ToString();

    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Inicio");

    }


}

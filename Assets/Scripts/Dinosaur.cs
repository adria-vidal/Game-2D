using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dinosaur : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text dinosaur;

    void Start()
    {
        dinosaur = GetComponent<TMP_Text>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        /* Setting the text of the dinosaur to the number of troglodytes in the
        gameManager.troglodytes list. */
        dinosaur.text = gameManager.troglodytes.Count.ToString() + "/3" ;
        if (gameManager.troglodytes.Count >= 3)
        {
            dinosaur.color = Color.green;
        }
        else
        {
            dinosaur.color = Color.red;
        }

    }
}

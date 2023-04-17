using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Count : MonoBehaviour
{
    public GameManager gameManager;
    private TMP_Text troglodyteCountText;

    void Start()
    {
        troglodyteCountText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        /* Setting the text of the troglodyteCountText to the number of troglodytes in the
        gameManager.troglodytes list. */
        troglodyteCountText.text = "X" + gameManager.troglodytes.Count.ToString();
        if (gameManager.troglodytes.Count == 0)
        {
            troglodyteCountText.color = Color.red;
        }
        else
        {
            troglodyteCountText.color = Color.green;
        }

    }
}

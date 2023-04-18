using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    public GameManager gameManager;
    public float scoreCount;
    public float pointsPerSecond;

    private Player player;

    public TMP_Text scoreText;
    public int followersCount;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        /* This code is updating the score count and displaying it on the screen. */
        
        scoreCount = player.transform.position.x;
        if (scoreCount < 0){
            scoreCount = 0;
        }
        Debug.Log(scoreCount);
        scoreText.text = "" + Mathf.Round(scoreCount);
        //le enviamos distancia para mostrar el record al GameOver
        EndScore.distance = (int)scoreCount;
    }

    
}

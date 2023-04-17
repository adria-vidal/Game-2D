using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    //Speed at which the sprite will move
    public float velocidad = -5f; 
    public float fuerzaSalto = 5f; 
    private Rigidbody2D rb2d; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento horizontal constante hacia la derecha
        Vector2 movimiento = new Vector2(velocidad, rb2d.velocity.y);
        rb2d.velocity = movimiento;
        Debug.Log(movimiento);
    }
    void FixedUpdate()
    {
        
    }
}

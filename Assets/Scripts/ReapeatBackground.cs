using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidht;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        /* Getting the width of the box collider and dividing it by 2. */
        repeatWidht = GetComponent<BoxCollider2D>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        /* Checking if the position of the background is less than the start position minus the repeat
        width. If it is, then it will set the position of the background to the start position. */
        if(transform.position.x < startPos.x - repeatWidht){
            transform.position = startPos; 
        }
    }
}

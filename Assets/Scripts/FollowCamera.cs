using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 cameraOffset;

    public GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
    cameraOffset = transform.position - playerTransform.position;

    }

    // Update is called once per frame
    void Update() {
    
    
    }
    private void LateUpdate() {
    transform.position = new Vector3(playerTransform.position.x + cameraOffset.x, transform.position.y, transform.position.z);

    }

}

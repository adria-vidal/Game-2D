using UnityEngine;
using System.Collections;


public class Troglodyte : MonoBehaviour
{
    public bool hasColision;
    private Player player;
    private Rigidbody2D rb2d;
    public Vector2 offset;
    public BoxCollider2D bc;


    private bool playerJumping = false;
    public float jumpDelay = 0.5f; // tiempo de espera antes de saltar
    public bool isBehindPlayer = false;
    private GameManager gameManager;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        offset = new Vector2(Random.Range(-2.8f, -1f), 0);
        bc = GetComponent<BoxCollider2D>();
        gameManager = GameManager.instance;
        
    }

    private void Update()
    {
        if (hasColision)
        {
            moveTroglodyte();
        }
    }
    /// The function moves a Troglodyte game object towards the player with a slight delay if it is
    /// behind the player.
  
    public void moveTroglodyte()
    {
        Vector2 targetPos = (Vector2)player.gameObject.transform.position + offset;
        rb2d.isKinematic = false;
        //StartCoroutine(DeactivateTriggerAfterDelay());
        if (isBehindPlayer)
        {
            //troglodyte velocity
            rb2d.velocity = new Vector2(player.GetComponent<Player>().velocidad + 0.33f, rb2d.velocity.y);
            StartCoroutine(delayMove());
        }
        else
        {
            rb2d.MovePosition(targetPos);
        }

        // Vector2 velocity = new Vector2(1,0);
        isBehindPlayer = true;

    }

    /// This function adds a force to a 2D rigidbody when a collider with the tag "jump" is triggered.
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("jump"))
        {
            rb2d.AddForce(new Vector2(0f, player.GetComponent<Player>().fuerzaSalto), ForceMode2D.Impulse);
        }
    }

    /// This function checks if a collision occurs with a game object tagged as "fire" and removes the
    /// current game object if true.
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("fire"))
        {
            GameManager.instance.RemoveTrogloyte(gameObject);
            Destroy(gameObject);
        }

    }


    /// The function delays the movement of an object by 0.02 seconds before disabling its trigger.

    IEnumerator delayMove()
    {
        yield return new WaitForSeconds(0.02f);
        bc.isTrigger = false;
    }
}


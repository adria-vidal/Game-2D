using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Speed at which the sprite will move
    public float velocidad = 5f;
    //Jumping force
    public float fuerzaSalto = 5f;
    private Rigidbody2D rb2d;
    private BoxCollider2D bc;

    // //Indicates if the character is touching the ground
    public bool enSuelo = true;
    private Vector3 posPlayer;
    float tiempoBloqueado = 0f;

    public GameObject delayGameObject;
    private GameManager gameManager;

    public AudioSource audioSource;
    public GameObject goldPrefab;





    // Inicialización
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

        posPlayer = transform.position;

    }

    // Actualización de físicas
    void FixedUpdate()
    {
        // Movimiento horizontal constante hacia la derecha
        Vector2 movimiento = new Vector2(velocidad, rb2d.velocity.y);
        rb2d.velocity = movimiento;


    }
    private void Update()
    {
        // Salto al pulsar la tecla de espacio
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            Instantiate(delayGameObject, transform.position, Quaternion.identity);
            rb2d.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
            enSuelo = false;
        }
        // Measure the time the player is blocked for
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.1f)
        {
            tiempoBloqueado += Time.deltaTime;
        }
        else
        {
            tiempoBloqueado = 0f;
        }
        // we move the player if it gets stuck to avoid failures
        if (tiempoBloqueado > 0.5f)
        {
            transform.position += new Vector3(0.2f, 0f, 0f);
            tiempoBloqueado = 0f;
        }
    }

    // Detects if the character is touching the ground

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            enSuelo = true;
        }

        Debug.Log("El jugador ha colisionado con: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("fire") && GameManager.instance.troglodytes.Count == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (collision.gameObject.CompareTag("fire") && GameManager.instance.troglodytes.Count > 0)
        {
            bc.isTrigger = true;
            StartCoroutine(desactiveIsTrigger());
            foreach (GameObject troglodyte in GameManager.instance.troglodytes)
            {
                troglodyte.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }

         if (collision.gameObject.CompareTag("dinosaur") && GameManager.instance.troglodytes.Count >= 3)
        {
            Destroy(collision.gameObject);
            for (int i = 0; i < 4; i++)
            {
                Instantiate(goldPrefab, new Vector2(collision.gameObject.transform.position.x + i, collision.gameObject.transform.position.y),collision.gameObject.transform.rotation);
            }
        }
        else if (collision.gameObject.CompareTag("dinosaur") && GameManager.instance.troglodytes.Count < 3)
        {
            SceneManager.LoadScene("GameOver");

        }


    }

    /// This function sets a boolean variable to true when a collision with a game object tagged as
    /// "suelo" ends.

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            enSuelo = true;
        }
    }


    /// If the object that collides with the trigger has the tag "troglodita", then add it to the list of
    /// troglodytes in the game manager and set the troglodyte's hasColision variable to true
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("troglodita"))
        {
            GameManager.instance.AddTrogloyte(other.gameObject);
            other.gameObject.GetComponent<Troglodyte>().hasColision = true;

        }


        if (other.gameObject.CompareTag("Gold"))
        {
            EndScore.gold++;
            audioSource.Play();
            Destroy(other.gameObject);
        }
       


    }

    /// This function waits for 0.1 seconds and then sets the isTrigger property of a collider component
    /// to false.
    IEnumerator desactiveIsTrigger()
    {
        yield return new WaitForSeconds(0.1f);
        bc.isTrigger = false;
    }
}

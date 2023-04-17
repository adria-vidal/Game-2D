using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;

    public static GameManager instance;
    public List<GameObject> troglodytes = new List<GameObject>(); 
    public int points = 0;
    private float lastPlayerJumpTime;
    public float jumpDelay = 1.5f; // tiempo de espera antes de permitir que los troglodytes salten

    public void AddTrogloyte(GameObject troglodyte){
        troglodytes.Add(troglodyte);
    }
    
    /// This function removes a troglodyte from the list of troglodytes
    public void RemoveTrogloyte(GameObject troglodyte){
        troglodytes.Remove(troglodyte);
    }
    public int Counter(int points){
        points += points;
        return points;
    }
    
    /// If the instance of the class is null, then set the instance to this
    
    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
    }
   
   ///  If the player has not jumped in the last `jumpDelay` seconds, then for each troglodyte, make it
   /// jump and move it to the player's position
   
    public void UpdateTroglodytesPosition()
    {
        Vector2 playerPosition = player.transform.position;
        if (Time.time - lastPlayerJumpTime > jumpDelay)
        {
            foreach (var troglodyte in troglodytes)
            {
                // salta el troglodyte
                troglodyte.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);

                // actualiza la posición del troglodyte
                troglodyte.transform.position = new Vector2(playerPosition.x - 2f, playerPosition.y);
            }
        }
    }
    public void PlayerJumped()
    {
        lastPlayerJumpTime = Time.time;
    }

}

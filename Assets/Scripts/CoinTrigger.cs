using UnityEngine;

public class CoinTester : MonoBehaviour
{
    public Coin coinToTest; // Drag the coin GameObject here in inspector


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collided with coin!");
            
            // Check if player is hitting from below (same logic as brick_move.cs)
            Vector2 hitDirection = (Vector2)other.transform.position - (Vector2)transform.position;
            
            // If the player is below the coin's center, player is hitting from below
            if (hitDirection.y < 0)
            {
                // Player is hitting coin from below
                coinToTest.collected = true;
                Debug.Log("Coin collected - hit from below");
            }
            else
            {
                Debug.Log("Coin hit from above/side - no collection");
            }
        }
    }
}
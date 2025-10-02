using UnityEngine;

public class CoinTester : MonoBehaviour
{
    public Coin coinToTest; // Drag the coin GameObject here in inspector

    void Update()
    {
        // Press 'C' key to test coin collection
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (coinToTest != null && !coinToTest.collected)
            {
                Debug.Log("Testing coin collection!");
                coinToTest.collected = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collided with coin!");
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();

            // Check if player is moving upward (jumping into coin from below)
            if (playerRb.linearVelocity.y > 0.1f)
            {
                Vector2 collisionDirection = (transform.position - other.transform.position).normalized;
                if (collisionDirection.y > 0.5f)
                {
                    // Player is jumping up into coin from below
                    coinToTest.collected = true;
                }
            }
        }
    }
}
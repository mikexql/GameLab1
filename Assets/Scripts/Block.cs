using UnityEngine;

public class Block : MonoBehaviour
{
    private Rigidbody2D block;
    private bool pendingFall;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        block = GetComponent<Rigidbody2D>();
        block.bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (!pendingFall) return;
        pendingFall = false;
        block.bodyType = RigidbodyType2D.Dynamic;
        Invoke(nameof(makeKinematic), 1.0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;

        Debug.Log("Collided with " + collision.collider.name);

        // Optional: log player velocity, but don't gate on it
        var playerRb = collision.collider.GetComponent<Rigidbody2D>();
        if (playerRb != null)
            Debug.Log($"Player vel.y = {playerRb.linearVelocity.y}");

        // Use contact normal (from block -> player)
        var contact = collision.GetContact(0);
        // From-below hit => normal points downward
        bool fromBelow = contact.normal.y > 0.5f;

        Debug.Log($"fromBelow={fromBelow}, contact.normal={contact.normal}");

        if (fromBelow)
        {
            Debug.Log("From-below confirmed, making Dynamic");
            pendingFall = true;
        }
    }

    void makeKinematic()
    {
        block.bodyType = RigidbodyType2D.Kinematic;
    }
}

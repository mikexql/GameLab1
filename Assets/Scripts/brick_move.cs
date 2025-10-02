using UnityEngine;

public class brick_move : MonoBehaviour
{
    [SerializeField] private Animator blockAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blockAnimator.enabled = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collided with " + col.collider.name);
        if (col.collider.CompareTag("Player"))
        {
            // Check if player is hitting from below
            Vector2 hitDirection = col.contacts[0].point - (Vector2)transform.position;
            
            // If the hit point is below the block's center, player is hitting from below
            if (hitDirection.y < 0)
            {
                blockAnimator.SetTrigger("hit");
                Debug.Log("Brick hit animation triggered - hit from below");
            }
            else
            {
                Debug.Log("Brick hit from above/side - no animation");
            }
        }
    }
}

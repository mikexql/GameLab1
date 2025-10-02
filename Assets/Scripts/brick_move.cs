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
            blockAnimator.SetTrigger("hit");
            Debug.Log("Brick hit animation triggered");
        }
    }
}

using UnityEngine;

public class Coin : MonoBehaviour
{

    public Coin coin;
    private Rigidbody2D coinBody;
    private SpriteRenderer coinSprite;

    public Animator coinAnimator;
    public AudioSource coinAudio;
    public AudioClip coinCollect;
    public Animator blockAnimator;
    public SpriteRenderer blockSprite;

    public Sprite blockSpriteCollected;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Sprite defaultSprite;

    // state
    [System.NonSerialized]
    public bool collected = false;

    public float Impulse = 5;

    void Start()
    {
        coinBody = GetComponent<Rigidbody2D>();
        coinSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (collected)
        {
            collected = false;
            Debug.Log("Coin collected!");
            sr.enabled = true;
            coinAnimator.Play("coin-spin");
            CoinJump();
            coinAudio.PlayOneShot(coinCollect);
            sr.sprite = defaultSprite;
            blockAnimator.enabled = false;
            blockSprite.sprite = blockSpriteCollected;
        }
    }

    void CoinJump()
    {
        // Start the kinematic jump animation
        StartCoroutine(KinematicJumpAnimation());
    }

    private System.Collections.IEnumerator KinematicJumpAnimation()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + Vector3.up * (Impulse / 5f); // Scale down for reasonable jump height
        float animationDuration = 0.3f; // Time for upward movement
        float elapsed = 0f;

        // Upward movement
        while (elapsed < animationDuration)
        {
            elapsed += Time.deltaTime;
            float progress = elapsed / animationDuration;

            // Use easing curve for more natural movement
            float easedProgress = 1f - (1f - progress) * (1f - progress); // Ease out quad

            transform.position = Vector3.Lerp(startPosition, targetPosition, easedProgress);
            yield return null;
        }

        // Downward movement back to start (optional)
        elapsed = 0f;
        while (elapsed < animationDuration)
        {
            elapsed += Time.deltaTime;
            float progress = elapsed / animationDuration;

            // Ease in for falling motion
            float easedProgress = progress * progress;

            transform.position = Vector3.Lerp(targetPosition, startPosition, easedProgress);
            yield return null;
        }

        // Ensure final position is exact
        transform.position = startPosition;
        Destroy(gameObject, 0.2f); // Delay destruction slightly to allow animation to complete
    }


}
using TMPro;
using UnityEngine;

public class StompGoomba : MonoBehaviour
{
    GameManager gameManager;
    public Sprite stompedSprite;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }


    private System.Collections.Generic.HashSet<GameObject> stompedEnemies = new System.Collections.Generic.HashSet<GameObject>();

    public void HandleStomp(GameObject enemy)
    {
        if (enemy == null) return;
        if (!enemy.CompareTag("Enemy")) return;

        if (stompedEnemies.Contains(enemy)) return; // already stomped

        stompedEnemies.Add(enemy);

        // award one point
        if (gameManager != null)
            gameManager.IncreaseScore(1);

        var goombaSprite = enemy.GetComponent<SpriteRenderer>();
        if (goombaSprite != null)
        {
             goombaSprite.sprite = stompedSprite;
        }

        // stop physics
        var rb = enemy.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.simulated = false;
        }

        Destroy(enemy, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void FixedUpdate()
    {

    }

}

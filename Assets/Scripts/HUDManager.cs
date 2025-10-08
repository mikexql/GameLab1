using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject inGameCanvas;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameStart()
    {
        gameOverCanvas.SetActive(false);
        inGameCanvas.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void SetScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
        finalScoreText.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOverCanvas.SetActive(true);
        inGameCanvas.SetActive(false);
    }
}

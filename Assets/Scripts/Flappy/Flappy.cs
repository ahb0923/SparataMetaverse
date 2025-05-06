using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Flappy : Minigame
{
    [SerializeField]
    private FlappyPlayer player;

    [SerializeField]
    private BgLooper bgLooper;

    
    [SerializeField]
    private Canvas uiCanvas;

    private TextMeshProUGUI gameoverText;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI bestScoreText;

    private int nowScore;

    private void Awake()
    {
        if (player == null)
            Debug.Log("Flappy Player is NULL!");

        if (uiCanvas == null)
            return;
        gameoverText = uiCanvas.transform.Find("GameOver").GetComponent<TextMeshProUGUI>();
        if (gameoverText==null)
            Debug.Log("tmpro is NULL!");
        gameoverText.gameObject.SetActive(false);
        scoreText = uiCanvas.transform.Find("Score").GetComponent<TextMeshProUGUI>();
        bestScoreText = uiCanvas.transform.Find("GameOver/BestScore/Score").GetComponent<TextMeshProUGUI>();
        nowScore = 0;
    }

    public void ViewGameOverUI()
    {
        if (gameoverText != null)
        {
            GameManager.Instance.SetPoint(nowScore);
            bestScoreText.text = GameManager.Instance.FlappyPoint.ToString();
            gameoverText.gameObject.SetActive(true);
            
        }
           
    }

    public void AddScore(int score)
    {
        nowScore += score;
    }
    private void Update()
    {
        scoreText.text = nowScore.ToString();
    }
    protected override void OnGameUpdate()
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    
    public static Text score;
    public static Text ballsText;
    [SerializeField]
    Text _scoreText;

    [SerializeField]
    Text ballsLeft;

    static int scoreValue = 0;

    static int balls;

    public static void ScoreManager(int increment)
    {
        scoreValue += increment;
        score.text = scoreValue.ToString();
        
    }

    public static void BallManager()
    {
        balls--;
        ballsText.text = balls.ToString();
    }

    void Start()
    {
        score = _scoreText;
        ballsText = ballsLeft;
        balls = ConfigurationUtils.BallsLeft;
        ballsText.text = balls.ToString();
        EventManager.HUDModification += ScoreManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        EventManager.HUDModification -= ScoreManager;
    }
}

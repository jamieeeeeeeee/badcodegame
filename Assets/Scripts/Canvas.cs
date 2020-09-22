using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Sets the score of the game
public class Canvas : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text livesText;
    [SerializeField] UnityEngine.UI.Text scoreText;
    [SerializeField] GameObject prefabLostLife;

    float elapsedSeconds;
    static int score;
    int lives;

    bool gameRunning = true;

    public static int GetScore()
    {
        return Canvas.score;
    }


    // Start is called before the first frame update
    void Start()
    {
        elapsedSeconds = 0;
        score = 0;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedSeconds += Time.deltaTime;
    }

    public void StopGameTimer()
    {
        gameRunning = false;
    }

    public void IncreaseScore(int numberValue)
    {
        score += numberValue;
        scoreText.text = score.ToString();

        if (score <= 0)
        {
            lives -= 1;
            score = 0;
        }
    }

    public void DecreaseLives(Vector3 pos)
    {
        lives -= 1;
        string suffixText = lives > 1 ? " lives" : " life";
        livesText.text = lives.ToString() + suffixText;
        if (lives <= 1)
        {
            livesText.color = Color.red;
        }
        if (lives <= 0)
        {
            SceneManager.LoadScene("Loss");
        }
        Instantiate(prefabLostLife, new Vector3(0,0,0), Quaternion.identity);
    }
}

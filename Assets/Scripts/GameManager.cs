using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text timerText;
    public bool startTimer = false;
    public GameObject[] scoreBoard;
    public GameObject board;
    private float startTime;
    private bool finnished = false;
    private int time;
   

    // Use this for initialization
    void Start ()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (startTimer)
            time = Timer(finnished);

      
        CheckVoid(transform.position.y,-25f); 
    }

    // Update is called once per frame
    void CheckVoid(float ypoint, float depth)
    {
        if (ypoint < depth)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    int Timer(bool done)
    {
        float t = 0;
        int tOut = 0;

        if (!done)
        {
            t = Time.time - startTime;
            tOut = Mathf.RoundToInt(t);
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            timerText.text = minutes + ":" + seconds;
        }

        return tOut;
    }

    public void Finnish()
    {
        finnished = true;
        timerText.color = Color.blue;

        int[] scores = new int[3];

        int scoreToMove = 0;
        bool moveScores = false;

        for (int i = 0; i < 3; i++)
        {
            if (PlayerPrefs.GetInt("Score" + i) != 0)
                scores[i] = PlayerPrefs.GetInt("Score" + i);    
        }

        for (int j = 0; j < 3; j++)
        {
            if(scores[j] > time && !moveScores)
            {
                scoreToMove = scores[j];
                scores[j] = time;
            }
            else
            {
                int t = scores[j];
                scores[j] = scoreToMove;
                scoreToMove = t;
            }
        }
        PlayerPrefs.SetString("Score" + 0, timerText.text);
        scoreBoard[0].GetComponent<Text>().text = PlayerPrefs.GetString("HighScore");

        board.SetActive(true);
    }    
}

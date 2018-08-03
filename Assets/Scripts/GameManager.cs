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
    private float time;

    void Update()
    {
        if (startTimer && !finnished)
            time = Timer();
        else
            startTime = Time.time;

        CheckVoid(transform.position.y,-25f);

        if (Input.GetKeyDown(KeyCode.R))
            ResetScore();

          if (Input.GetKeyDown(KeyCode.Escape))
            Quit();
    }

    void CheckVoid(float ypoint, float depth)
    {
        if (ypoint < depth)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    float Timer()
    {
        float t = 0;
        t = Time.time - startTime;
        timerText.text = TimeConvert(t);
        return t;
    }

    string TimeConvert(float t)
    {
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        return  minutes + ":" + seconds;        
    }

    public void Finnish()
    {
        finnished = true;
        timerText.color = Color.cyan;

        float[] scores = new float[3];
        int yourScore = -1;
        float scoreToMove = 0;
        bool moveScores = false;

        for (int i = 0; i < 3; i++)
        {
            if (PlayerPrefs.GetFloat("Score" + i) != 0)
                scores[i] = PlayerPrefs.GetFloat("Score" + i);    
        }

        for (int j = 0; j < 3; j++)
        {
            if(scores[j] > time && !moveScores || scores[j] == 0f && !moveScores)
            {
                scoreToMove = scores[j];
                scores[j] = time;
                moveScores = true;
                yourScore = j;
            }
            else if(moveScores)
            {
                float t = scores[j];
                scores[j] = scoreToMove;
                scoreToMove = t;
            }
            else
            {
                //do nothing
            }
            PlayerPrefs.SetFloat("Score" + j, scores[j]);
            scoreBoard[j].GetComponent<Text>().text = TimeConvert(scores[j]);
            if(yourScore != -1) 
                scoreBoard[yourScore].GetComponent<Text>().color = Color.cyan;

        }
        board.SetActive(true);
    }   
    
    void ResetScore()
    {
        for(int k = 0; k < 3; k ++)
        {
            PlayerPrefs.SetFloat("Score" + k, 0f);
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    public bool CheckRabbits()
    {
        if (GameObject.FindGameObjectsWithTag("Bunny").Length <= 0)
            return true;

        return false;
    }
}

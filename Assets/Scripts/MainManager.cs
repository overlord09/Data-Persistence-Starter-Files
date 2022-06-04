using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    
    public Text playername;
    public Text bestScore;
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;
    private int lastScore;


   
    
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Started main");
        //check if score >0
        if (ScoreManager.ScoreInstance!=null)
        {
            Debug.Log("Check score manager");
            if(ScoreManager.ScoreInstance.score>m_Points)
            {
                //set lastcore variable as the last score set
lastScore = ScoreManager.ScoreInstance.score;
            }
 //set the playername text in the main game player name
 playername.text = ScoreManager.ScoreInstance.currentName;
      
        }
        
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {  
      
        if (!m_Started)
        {
            ShowBestScore();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            //show the best score and set the current score to be the last score 
               
           
                if(ScoreManager.ScoreInstance!=null)
            {
            ScoreManager.ScoreInstance.score=m_Points;

            }
          


                //set the game to restart with the same name or go back to menu to change
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            } 
            if(Input.GetKeyDown(KeyCode.Escape))
        {
             
            SceneManager.LoadScene(0);
        }
        }
      
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
        ShowBestScore();

    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        ShowBestScore();
       
    }
 void ShowBestScore()
    { 
        //compare and show best score
        if(ScoreManager.ScoreInstance!= null)
        {
            bestScore.text="Best Score:"+ ScoreManager.ScoreInstance.playerName +": "+ ScoreManager.ScoreInstance.GetBestScore(m_Points,  lastScore);

        }
    }
}

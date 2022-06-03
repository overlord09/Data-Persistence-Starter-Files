using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager ScoreInstance;

        int ScoreResult;
    public string playerName;
   public int score;
   public string currentName;
  public  string previoustName;

  public  string[][] bestPlayer= new string[0][];

    // Start is called before the first frame update
    private void Awake()
    {
       
        if (ScoreInstance != null)
        {
            Destroy(gameObject);
            return;
        }


        ScoreInstance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        Debug.Log("score Started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
 public   int GetBestScore(int currentScore, int lastScore )
    { 
        
        
        if (currentScore <= lastScore)
        {

            playerName = previoustName;
            ScoreResult = lastScore;
            Debug.Log("Last score"+playerName);
       
           
        }
        else if (currentScore >= lastScore)
        {

            Debug.Log("Current score" + playerName);

            
            playerName = currentName;
            
           
            ScoreResult = currentScore;
        }
        

        return ScoreResult;
    }
  
 /* public  int KeepScore()
    {
        if(ScoreResult>bestScore)
        {
            bestScore = ScoreResult;
            playerName = bestPlayer;
        }
        else
        {
            bestScore = 0;
        }
        return bestScore;
    }*/

}

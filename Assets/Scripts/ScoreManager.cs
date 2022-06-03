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
    // Start is called before the first frame update
    private void Awake()
    {
       
        if (ScoreInstance != null)
        {
            Destroy(ScoreInstance);
            return;
        }


        ScoreInstance = this;
        DontDestroyOnLoad(ScoreInstance);
    }
    void Start()
    {
        Debug.Log("score Started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int AddScore(int addScore)
    {
        score += addScore;
        return score; 

    }
 public   int GetBestScore(int currentScore, int lastScore)
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
   
    
}

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
       //dont instantiate more than once (singleton)
        if (ScoreInstance != null)
        {
            Destroy(gameObject);
            return;
        }


        ScoreInstance = this;
        DontDestroyOnLoad(gameObject);
    }
   //compare the last score
 public   int GetBestScore(int currentScore, int lastScore )
    { 
        
        
     
        if (currentScore > lastScore)
        {

            

            
            playerName = currentName;
            
           
            ScoreResult = currentScore;
        }
        

        return ScoreResult;
    }
  

}

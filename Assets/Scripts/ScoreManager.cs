
using UnityEngine;

using System.IO;
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
    //a serializable class to save the highscore
    [System.Serializable]
  public class SaveHighScore
    {
       public string bestPlayer;
     public   int bestScore;
    }
    //save the high score in a file and store it in the local drive
    public void SaveScore()
    {
        SaveHighScore savescore = new SaveHighScore();
        savescore.bestPlayer = playerName;
        savescore.bestScore = ScoreResult;
        string json=JsonUtility.ToJson(savescore);
        File.WriteAllText(Application.persistentDataPath + "/savescore.json", json);


    }

}

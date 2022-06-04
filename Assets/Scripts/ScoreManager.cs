
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
   public int bestscore;
   public string bestplayer;

 

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
        LoadScore();
    }
   //compare the last score
 public   int GetBestScore(int currentScore, int lastScore )
    { 
        
        
     
        if (currentScore > lastScore)
        { 
            
          //  playerName 
            
           bestplayer= currentName;
            bestscore= currentScore;
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
        savescore.bestPlayer = bestplayer;
        savescore.bestScore = bestscore;
        string json=JsonUtility.ToJson(savescore);
        File.WriteAllText(Application.persistentDataPath + "/savescore.json", json);


    }
    public void LoadScore()  
    {
     string   path =Application.persistentDataPath+"/savescore.json";
        if(File.Exists(path))
        {
            string json =File.ReadAllText(path);
            SaveHighScore loadscore = JsonUtility.FromJson<SaveHighScore>(json);
            bestplayer = loadscore.bestPlayer;
            bestscore=loadscore.bestScore;    
        }
    }

}

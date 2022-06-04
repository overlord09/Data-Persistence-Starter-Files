using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuHanddler : MonoBehaviour
{
  
 
 
  
 
   

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  public  void playGame()
    {
        //get a previous name 
            if (ScoreManager.ScoreInstance!=null)
        {

            ScoreManager.ScoreInstance.previoustName= ScoreManager.ScoreInstance.playerName;
            Debug.Log("Play game" + ScoreManager.ScoreInstance.previoustName);
        }
        
      
       SceneManager.LoadScene(1);
       
    }
  public  void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
   
}

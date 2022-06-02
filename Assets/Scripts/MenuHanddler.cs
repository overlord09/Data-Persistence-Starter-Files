using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuHanddler : MonoBehaviour
{
  
 public  static MenuHanddler Instance;
   // public int score;
    public string name;
 
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }
      
        
            Instance = this;
            DontDestroyOnLoad(Instance);
        
    }

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

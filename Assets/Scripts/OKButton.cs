using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OKButton : MonoBehaviour
{

   
    [SerializeField] public TextMeshProUGUI inputText;
    public void OnClickOk()
    {
       // if (MenuHanddler.Instance != null)
        
            SceneManager.LoadScene(2);
           
             ScoreManager.ScoreInstance.currentName = inputText.text;
        Debug.Log("clickedok"+ ScoreManager.ScoreInstance.currentName);

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

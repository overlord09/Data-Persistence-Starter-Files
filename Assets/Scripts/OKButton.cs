using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OKButton : MonoBehaviour
{

   
    [SerializeField] public TextMeshProUGUI inputText;
    //function to use in the ok button
    public void OnClickOk()
    {
      //load main scene and ad the inputted tex in the current name variable

        SceneManager.LoadScene(2);
    
             ScoreManager.ScoreInstance.currentName = inputText.text;
        Debug.Log("clickedok"+ ScoreManager.ScoreInstance.currentName);

    }
    //back to menu button function
    public void BackToMenu()
    {
        //return to main menu
        SceneManager.LoadScene(0);
    }
}

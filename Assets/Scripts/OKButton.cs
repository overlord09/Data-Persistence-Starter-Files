using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OKButton : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    [SerializeField] public TextMeshProUGUI inputText;
    public void OnClickOk()
    {
        if (MenuHanddler.Instance != null)
        {

            MenuHanddler.Instance.name = inputText.text;
            SceneManager.LoadScene(2);
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

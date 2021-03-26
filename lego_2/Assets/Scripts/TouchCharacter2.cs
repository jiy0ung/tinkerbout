using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchCharacter2 : MonoBehaviour
{
    private void OnMouseDown()
    {
        string name = gameObject.name.ToString();
        switch (name) {
            case "1":
                PlayerPrefs.SetString("BlockName", "Prefebs/1");
                SceneManager.LoadScene("SampleScene");
                break;
            case "2":
                PlayerPrefs.SetString("BlockName", "Prefebs/2");
                SceneManager.LoadScene("SampleScene");
                break;
            case "3":
                PlayerPrefs.SetString("BlockName", "Prefebs/3");
                SceneManager.LoadScene("SampleScene");
                break;
            case "4":
                PlayerPrefs.SetString("BlockName", "Prefebs/4");
                SceneManager.LoadScene("SampleScene");
                break;
        }
    }

    public void HomeClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}

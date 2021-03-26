using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BookSelect : MonoBehaviour
{
    public void Click(int n)
    {
        PlayerPrefs.SetInt("BookNo", n);
        if (n == 1) {
            SceneManager.LoadScene(2);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCharacterScript : MonoBehaviour
{
    public GameObject guidePopup;
    public GameObject XBtn;
    public GameObject arGuideBtn;
   
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                SceneManager.LoadScene("SelectScene");
            }
        }
    }

    // 뒤로가기 버튼 클릭
    public void BackClick() {
        SceneManager.LoadScene("SelectScene");
    }

    // X 버튼 클릭
    public void XBtnClick() {
        guidePopup.SetActive(false);
    }

    // ar 사용방법 버튼 클릭
    public void arGuideBtnClick() {
        if (!guidePopup.active) {
            guidePopup.SetActive(true);
        }
        else {
            guidePopup.SetActive(false);
        }
    }
}
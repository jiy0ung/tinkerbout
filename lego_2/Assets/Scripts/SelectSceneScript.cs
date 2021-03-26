using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSceneScript : MonoBehaviour
{
    public GameObject blockPrevPopup;
    public GameObject XBtn;
    public GameObject blockPrevBtn;
    public GameObject mbtnPrefab;
    public GameObject popup;
    public GameObject XBtn2;
    public GameObject[] outline = new GameObject[8];
    public GameObject[] scene_btn = new GameObject[8];
    public static int[] click = { 0, 0, 0, 0, 0, 0, 0, 0 }; // 버튼 클릭되면 1로 바뀜
    public int popupClicked = 0;
    public int xBtnClicked = 0;

    void Start()
    {
        Debug.Log("start()");

        Screen.orientation = ScreenOrientation.Portrait;
        blockPrevPopup.SetActive(false);

        for (int i = 0; i < 8; i++) {
            if (click[i] == 0) {
                outline[i].SetActive(false);
            }
            else {
                outline[i].SetActive(true);
            }
        }
        popup.SetActive(false);

        if (mbtnPrefab == null) {
            Debug.Log("mbtnPrefab은 null이다");
        }

    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                SceneManager.LoadScene("MainScene");
            }
        }

        for (int i = 0; i < 8; i++) {
            if (click[i] == 0) {
                outline[i].SetActive(false);
            }
            else {
                outline[i].SetActive(true);
            }
        }
    }

    public void SceneClick(int sceneN) { // 각 씬 클릭시
        Debug.Log("SceneClick()/ 클릭된 씬 = " + sceneN);
        switch (sceneN) {
            case 6:
                click[sceneN] = 1;
                SceneManager.LoadScene("VideoPlay1");
                break;

            case 0: case 1:
            case 2: case 3:
            case 4: case 5:
            case 7:
                click[sceneN] = 1;
                popup.SetActive(true);
                break;
        }
    }

    public void XBtnClick() { // x버튼 클릭시
        Debug.Log("XBtnClick()");
        blockPrevPopup.SetActive(false);
    }

    public void XbtnClick2() {
        Debug.Log("XBtnClick2()");
        popup.SetActive(false);
        xBtnClicked = 1;
    }

    public void arGuideBtnClick() { // 가이드 버튼 클릭시
        Debug.Log("arGuideBtnClick()");
        if (!blockPrevPopup.active) {
            blockPrevPopup.SetActive(true);
        }
        else {
            blockPrevPopup.SetActive(false);
        }
    }

    public void BackClick() { // 뒤로가기 버튼 클릭시
        Debug.Log("BackClick()");
        SceneManager.LoadScene("MainScene");
    }

    public void HomeClick() { // 홈 버튼 클릭시
        Debug.Log("HomeClick()");
        SceneManager.LoadScene("MainScene");
    }
}
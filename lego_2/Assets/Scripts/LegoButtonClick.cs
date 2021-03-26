using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LegoButtonClick : MonoBehaviour
{
    int counter = 1;
    public GameObject lego;
    Transform[] legoList;
    Renderer[] renderList;

    public GameObject prevButton;
    public GameObject nextButton;
    public GameObject saveButton;
    public GameObject backButton;
    public Camera camera1; // 추가된부분
    public GameObject savePopup;

    void Start()
    {
        savePopup.SetActive(false);

        camera1.transform.SetPositionAndRotation(new Vector3(-0.2f, 1.13f, -0.23f), Quaternion.Euler(6.569f, 0, 0)); // 추가된 부분
        GameObject game = Instantiate(Resources.Load<GameObject>(PlayerPrefs.GetString("BlockName")));
        game.transform.SetParent(lego.transform.parent, false);
        game.transform.SetPositionAndRotation(new Vector3(-0.19f, 0.29538f, 2.534f), Quaternion.Euler(0, -90, 0));
        game.SetActive(true);
        legoList = game.gameObject.GetComponentsInChildren<Transform>();
        renderList = new Renderer[legoList.Length];

        for (int i = 1; i < legoList.Length; i++){
            renderList[i] = legoList[i].GetComponent<Renderer>();
        }
        SetScale();
        saveButton.SetActive(false);
    }

    void Update()
    {
        camera1.transform.SetPositionAndRotation(new Vector3(-0.2f, 1.13f, -0.23f), Quaternion.Euler(6.569f, 0, 0)); // 추가된 부분
        
        if (counter == 1) {
            SetTransparency();
            SetTransparency(1f);
            prevButton.SetActive(false);
        }
        else if (counter == legoList.Length - 1) {
            nextButton.SetActive(false);
            saveButton.SetActive(true);
        }
        else {
            prevButton.SetActive(true);
            nextButton.SetActive(true);
            saveButton.SetActive(false);
        }
    }

    public void SetTransparency()
    {
        for (int i = 1; i < renderList.Length; i++) {
            renderList[i].material.color = new Color(renderList[i].material.color.r, renderList[i].material.color.g, renderList[i].material.color.b, 0.09f);
        }
    }

    public void SetTransparency(float f)
    {
        renderList[counter].material.color = new Color(renderList[counter].material.color.r, renderList[counter].material.color.g, renderList[counter].material.color.b, f);
    }

    public void SetScale()
    {
        legoList[0].localScale = new Vector3(3, 3, 3);
    }

    public void PrevBtnClick()
    {
        SetTransparency(0.09f);
        counter--;
        SetTransparency(1f);
    }

    public void NextBtnClick()
    {
        SetTransparency(0.6f);
        counter++;
        SetTransparency(1f);
    }

    public void PrevBtnClick2()
    {
        legoList[0].transform.Rotate(new Vector3(0, -20, 0), Space.Self);
    }

    public void NextBtnClick2()
    {
        legoList[0].transform.Rotate(new Vector3(0, 20, 0), Space.Self);
    }

    public void BackBtnClick()
    {
        SceneManager.LoadScene("CheckCharacter");
    }

    public void HomeClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void SaveClick()
    {
        //컴퓨터에서는 이동
        /* 
        string fileName = "stl1.stl";
        string sourcePath = string.Format(@"\Resources");
        string sourceFile = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
        sourceFile = sourceFile.Substring(0, sourceFile.LastIndexOf('/'));
        sourceFile = sourceFile + "/Assets/stl1.stl";
        Debug.Log(sourceFile);

        string filePath3 = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
        filePath3 = filePath3.Substring(0, filePath3.LastIndexOf('/'));
        Debug.Log(filePath3);
        filePath3 = filePath3 + "/stl1.stl";
        Debug.Log(filePath3);
        System.IO.File.Move(sourceFile, filePath3);
        */
        string path = "";
        string fileName = "";
        string book = PlayerPrefs.GetString("BlockName");
        Debug.Log(book[book.Length - 1]);
        switch (book[book.Length - 1]) {
            case '1':
                fileName = "pig1.stl";
                break;
            case '2':
                fileName = "pig2.stl";
                break;
            case '3':
                fileName = "pig3.stl";
                break;
            case '4':
                fileName = "wolf.stl";
                break;
        }
        path = "jar:file://" + Application.dataPath + "!/assets/" + fileName;
        Debug.Log(path);
        byte[] result;
        StartCoroutine(Example());

        IEnumerator Example() {
            if (path.Contains("://")) {
                WWW www = new WWW(path);
                yield return www;
                result = www.bytes;
                System.IO.File.WriteAllBytes(Application.persistentDataPath + "/../" + fileName, result);
            }
            else {
                result = System.IO.File.ReadAllBytes(path);
                System.IO.File.WriteAllBytes(Application.persistentDataPath + "/stl01.stl", result);
            }
        }
        savePopup.SetActive(true);
    }

    public void savePopupX()
    {
        savePopup.SetActive(false);
    }
}
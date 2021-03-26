using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlay : MonoBehaviour
{
    public bool end = false;
    private VideoPlayer video;
    public GameObject loadImage;
    int sec;

    void Start()
    {
        //Screen.orientation = ScreenOrientation.Landscape;
        video = GetComponent<VideoPlayer>();
        video.loopPointReached += CheckOver;
        sec = 0;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
       Debug.Log("영상끝");
       end = true;
       SceneManager.LoadScene("CheckCharacter");
    }

    void Update()
    {
        if (video.isPlaying && video.isPrepared) {
            sec++;
            if(sec == 20)
                loadImage.SetActive(false);
        }
    }

    public void BackClick()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void NextClick()
    {
        SceneManager.LoadScene("CheckCharacter");
    }
}
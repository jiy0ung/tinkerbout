using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileTransfer : MonoBehaviour
{
    public void click()
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

        string path = "jar:file://" + Application.dataPath + "!/assets/stl0.stl";
        byte[] result;
        StartCoroutine(Example());
        
        IEnumerator Example()
        {
            if (path.Contains("://"))
            {
                WWW www = new WWW(path);
                yield return www;
                result = www.bytes;
                System.IO.File.WriteAllBytes(Application.persistentDataPath + "/../stl00.stl", result);
            }
            else
            {
                result = System.IO.File.ReadAllBytes(path);
                System.IO.File.WriteAllBytes(Application.persistentDataPath + "/stl01.stl", result);
            }
        }
        
        //System.IO.File.Move(result, Application.persistentDataPath);
        //File.WriteAllBytes(Application.persistentDataPath + "/stl0.stl", result);

        //WWW asset = WWW.LoadFromCacheOrDownload(path, 1);
        //asset
    }
}

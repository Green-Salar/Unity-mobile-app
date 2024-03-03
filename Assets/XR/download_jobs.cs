using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using System.Text;
using System.IO;
public class download_jobs : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {
        try
        {

                Debug.Log("starting to dl  ");
                StartCoroutine(DownloadFile());

        }
        catch { }
        
    }
    IEnumerator DownloadFile_old()
    {
        var uwr = new UnityWebRequest("https://drive.google.com/file/d/13gtS2XGnNEmuDwCc0-QEDOIAG6fvDIrx/view?usp=share_link", UnityWebRequest.kHttpVerbGET);
        string path = Path.Combine(Application.persistentDataPath, "jobs.db");
        uwr.downloadHandler = new DownloadHandlerFile(path);
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
            Debug.LogError(uwr.error);
        else
            Debug.Log("File successfully downloaded and saved to " + path);
    }
        IEnumerator DownloadFile()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://drive.google.com/file/d/13gtS2XGnNEmuDwCc0-QEDOIAG6fvDIrx/view?usp=share_link");
        yield return request.SendWebRequest();
        string path = Path.Combine(Application.persistentDataPath, "jobs.db");
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            byte[] bytes = request.downloadHandler.data;
            File.WriteAllBytes(path, bytes);
            Debug.Log("File downloaded to " + path);
        }
    }

    
}

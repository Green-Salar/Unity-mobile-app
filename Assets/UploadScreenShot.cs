
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using Firebase.Storage;
public class UploadScreenShot : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void StartUpload()
    {
        StartCoroutine(UploadCoroutine());
    }


    private IEnumerator UploadCoroutine()
    {
        var storage = FirebaseStorage.DefaultInstance;//Firebase.Storage.FirebaseStorage.DefaultInstance;
        //var storageRef = storage.GetReferenceFromUrl("gs://fir-test-1-1c0f5.appspot.com");
        //var screenshotRef = storageRef.Child("screenshot.png");
        // REFRENCE IS THE GOOGLE CLOUD STORAGE NAME
        var screenshotRef = storage.GetReference("/screenshot/2.png");
        //var bytes = screenshot.EncodeToPNG();

                // Load the PNG file as a Texture2D
        Texture2D texture = new Texture2D(2, 2); // Create an empty Texture2D
        byte[] pngBytes = File.ReadAllBytes(Application.persistentDataPath + "/2.png"); // Read the PNG file bytes
        texture.LoadImage(pngBytes); // Load the bytes into the Texture2D

        // Encode the Texture2D as a PNG and get the bytes
        byte[] pic = texture.EncodeToPNG();

        var metadata = new MetadataChange()
        {
            ContentEncoding = "image/png",
            CustomMetadata = new Dictionary<string, string>
            {
                {"ReportID", "TEST"},
                {"Inspector", "sss"},
                
                {"Location", "Montreal"},
                {"Warehouse", "This is a test one! "}
            }
        };
        var uploadTask = screenshotRef.PutBytesAsync(pic, metadata);
        yield return new WaitUntil(() => uploadTask.IsCompleted);
        if (uploadTask.Exception != null)
        {
            Debug.LogError($"failed to upload because{uploadTask.Exception}");
            yield break;
        }
        else
        {
            Debug.Log("Upload complete");
        }
        var downloadUrl = screenshotRef.GetDownloadUrlAsync();
        yield return new WaitUntil(() => downloadUrl.IsCompleted);

        if (downloadUrl.Exception != null)
        {
            Debug.LogError($"failed to get download url because{downloadUrl.Exception}");
            yield break;
        }
        else
        {
            Debug.Log($"Download url is {downloadUrl.Result}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

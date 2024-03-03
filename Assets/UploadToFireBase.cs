using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Storage;
public class UploadToFireBase : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void StartUpload(byte[] pic, string storageRef, Dictionary<string,string> CustomMetadata)
    {
        StartCoroutine(UploadCoroutine_pics(pic, storageRef,CustomMetadata));
    }


    private IEnumerator UploadCoroutine_pics(byte[] pic, string storageRef, Dictionary<string,string> CustomMetadata){
        
        Debug.Log("UploadCoroutine_pics"+storageRef);
        
        var storage = FirebaseStorage.DefaultInstance;

        var picRef = storage.GetReference("/image/"+storageRef);
        
        var metadata = new MetadataChange()
        {
            ContentEncoding = "image/png",
            CustomMetadata = CustomMetadata
        };

        var uploadTask = picRef.PutBytesAsync(pic, metadata);

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
        var downloadUrl = picRef.GetDownloadUrlAsync();
        yield return new WaitUntil(() => downloadUrl.IsCompleted);
        if (downloadUrl.Exception != null)
        {
            Debug.LogError($"failed to get download url because{downloadUrl.Exception}");
            yield break;
        }
        else
        {
            Debug.Log($"download url is {downloadUrl.Result}");
        }
    }

}

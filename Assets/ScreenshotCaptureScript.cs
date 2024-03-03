using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class ScreenshotCaptureScript : MonoBehaviour, IPointerClickHandler
{
    
    public RawImage profileImage;
    private Texture2D textureImg;

    //public ScreenshotEvent OnScreenshotCaptured = new ScreenshotEvent();

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(CaptureScreenshotCorutine());
    }

    private IEnumerator CaptureScreenshotCorutine()
    {
        yield return new WaitForEndOfFrame();
        //textureImg = profileImage.texture as Texture2D;
       // var screenshot = ScreenCapture.CaptureScreenshotAsTexture();
        Debug.Log("screenshot owi1");
       // OnScreenshotCaptured.Invoke();
    }

    public void testStart()
    {
                var uploadScreenShot = FindObjectOfType<UploadScreenShot>();
        uploadScreenShot.StartUpload();
    }
   // [System.Serializable]
    // Update is called once per frame
    //public class ScreenshotEvent : UnityEvent<>
    //{
        
    //}
}

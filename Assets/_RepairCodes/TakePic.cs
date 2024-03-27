using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class TakePic: MonoBehaviour
{
    public string RepairStepName;
    // Start is called before the first frame update
    void Start()
    {
        if (RepairStepName == null)
        {
            Debug.LogError("## RepairStepName for image btn is not set");
        }
    }
    public void TakePicture()
    {
        // OldCapture(512);
        Capture();
    }
    public void Capture()
    {
        string jobID="JobID";
        string insID="insID";
        
        NativeCamera.Permission permission = NativeCamera.TakePicture((tempPath) =>
        {
            Debug.Log("Image path: ##" + tempPath);
            if (tempPath != null)
            {
                // Create a Texture2D from the captured image
                Texture2D texture = NativeCamera.LoadImageAtPath(tempPath);
                if (texture == null)
                {
                    Debug.LogError("Couldn't load texture from path null ## " + tempPath);
                    return;
                }
                
                Image img =GetComponentInParent<Image>();
                img.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                
                string newPath = Path.Combine(Application.persistentDataPath, $"{jobID}-{insID}-{RepairStepName}.jpg");

                 bool saved =  movethePic(tempPath, newPath );

                if(saved)
                { 
                    ImageManagerSingleton.Instance.AddImageToJob(jobID, insID, newPath);
                }
                else {
                    ImageManagerSingleton.Instance.AddImageToJob(jobID, insID, tempPath);
                }

            }
        } );

        Debug.Log("Image Permission result: ##" + permission);
    }

     bool movethePic(string originalPath, string  newPath )
    {
        int i = 0;
        bool fileMoved = false;
        try
        {
            
            if (File.Exists(newPath))
            {
                File.Delete(newPath);
            }
            File.Move(originalPath, newPath);
            fileMoved = true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred in moving file ##: {ex.Message}");
        }
        return fileMoved;

    }
    Texture2D CropTextureToSquare(Texture2D originalTexture)
    {
        int smallestSide = Mathf.Min(originalTexture.width, originalTexture.height);
        int startX = (originalTexture.width - smallestSide) / 2;
        int startY = (originalTexture.height - smallestSide) / 2;

        Texture2D squareTexture = new Texture2D(smallestSide, smallestSide);
        squareTexture.SetPixels(originalTexture.GetPixels(startX, startY, smallestSide, smallestSide));
        squareTexture.Apply();

        return squareTexture;
    }
/*
    public void OldCapture(int maxSize)
    {
        NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
        {
            Debug.Log("Image path: ##" + path);
            if (path != null)
            {
                // Create a Texture2D from the captured image
                Texture2D texture = NativeCamera.LoadImageAtPath(path, maxSize);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }

                // Assign texture to a temporary quad and destroy it after 5 seconds
                GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
                quad.transform.forward = Camera.main.transform.forward;
                quad.transform.localScale = new Vector3(1f, texture.height / (float)texture.width, 1f);

                Material material = quad.GetComponent<Renderer>().material;
                if (!material.shader.isSupported) // happens when Standard shader is not included in the build
                    material.shader = Shader.Find("Legacy Shaders/Diffuse");

                material.mainTexture = texture;

                Destroy(quad, 5f);

                // If a procedural texture is not destroyed manually, 
                // it will only be freed after a scene change
                Destroy(texture, 5f);
            }
        }, maxSize);

        Debug.Log("Permission result: " + permission);
    }
*/
}

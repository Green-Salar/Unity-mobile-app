using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
public class editImage : MonoBehaviour
{
    [SerializeField]
    private Image img;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Load_Image_review(string _img_name_str, int imgNum)// imgnums 1-7 imgs. 1-6 for report and 7th is for showing the img clicked
    {
        if (_img_name_str != "-")
        {
            try
            {
                string path = Application.persistentDataPath + $"/{_img_name_str}";
                Debug.Log(path);
                Texture2D texture = new Texture2D(500, 500, TextureFormat.RGB24, false);
                texture.filterMode = FilterMode.Point;
                byte[] text = File.ReadAllBytes(path);
                texture.LoadImage(text);
                Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f, 1, SpriteMeshType.FullRect);
                img.sprite = newSprite;

            }
            catch
            {
                Debug.Log("no image number." + imgNum);
            }
        }
        else if (_img_name_str == "-")
        { Debug.Log("no image taken." + imgNum); img.gameObject.SetActive(false); }
    }
    // Update is called once per frame

    // Update is called once per frame
    void Update()
    {
        
    }
}

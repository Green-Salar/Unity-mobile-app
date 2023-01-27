using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

// this script is checking wether we have a new piture then show it down here
public class image_sprit_manager1 : MonoBehaviour
{
    
    [SerializeField]
    private Image[] img;
    void Update()
    {
        //for ( int i 
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
                img[imgNum].sprite = newSprite;
                //img[imgNum].gameObject.AddComponent<Button>().onClick.AddListener(() => { background_img_viewPort.gameObject.SetActive(true); Load_Image_review(_img_name_str, 6); });//6th is the full screen image

            }
            catch
            {
                Debug.Log("no image number." + imgNum);
            }
        }
        else if (_img_name_str == "-")
        { Debug.Log("no image taken." + imgNum); img[imgNum].gameObject.SetActive(false); }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

}

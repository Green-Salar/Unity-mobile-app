using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class review_text_manager : MonoBehaviour
{

    public static Dictionary<string, string> ins_list;
    [SerializeField]
    private Image[] img; // 7 imgs 1-6 for report and 7th is for showing the img clicked
    [SerializeField]
    private Image img_viewPort;
    [SerializeField]
    private Image background_img_viewPort;
    [SerializeField]
    private RawImage safety_img;
    [SerializeField]
    private InputField comment;
    int set = 0;
    float t;
    [SerializeField]
    private Text defect_lbl,safety_lbl, safety_number_lbl;
    void Update()
    {
        t += Time.deltaTime;
        if (t > .2&& set == 0)
        {
            set = 1;
            text_handler();
            for (int i = 0; i < 6; i++)
            {
                string _img_name_str = ins_list[$"img{i + 1}"];
                Load_Image_review(_img_name_str, i);
            }
            safty_image_handeling();

            background_img_viewPort.gameObject.SetActive(false);
        }
       
    }

    void Start()
    {
        t = 0; 
        background_img_viewPort.gameObject.SetActive(false);
    }
    public void img_deActivator()
    {
        background_img_viewPort.gameObject.SetActive(false);
    }
    private void safty_image_handeling()
    {
        int safety_number = Int32.Parse(ins_list["SN"]);
        Color[] _colors = safty_vars.safty_colors;
        safety_img.color = _colors[safety_number];
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
                img[imgNum].gameObject.AddComponent<Button>().onClick.AddListener(() => { background_img_viewPort.gameObject.SetActive(true); Load_Image_review(_img_name_str, 6); });//6th is the full screen image

            }
            catch
            {
                Debug.Log("no image number." + imgNum);
            }
        }else if(_img_name_str =="-")
        { Debug.Log("no image taken." + imgNum); img[imgNum].gameObject.SetActive(false); }
    }
    // Update is called once per frame

    public void SetString(string KeyName, string Value)
    {
        PlayerPrefs.SetString(KeyName, Value);
        PlayerPrefs.Save();
    }

    public string GetString(string KeyName)
    {
        return PlayerPrefs.GetString(KeyName);
    }
    void text_handler()
    {
        try
        {
            string txt = "<b>Inspection ID:</b> " + ins_list["ID"] + "\n" + "\n" + "<b>Location:</b> " + ins_list["Location"] + "\n" + "\n";
            txt += "<b>Racking Tyoe:</b> " + ins_list["RT"] + "\n" + "\n" + "<b>Defect category:</b> " + ins_list["DC"] + "\n" + "\n" + "<b>Defect sub category:</b> " + ins_list["DSC"] + "\n" + "\n";
            txt += "<b>Defects:</b> " + ins_list["D"] + "\n" + "\n" + "<b>Recomended Solutions:</b>   " + ins_list["RS"];
            
            string safety_txt = "<b>Safety Action:</b> " + ins_list["SA"] + "\n" + "\n";
            safety_txt += "<b>Safety Corrective Action:</b> " + ins_list["SCA"] + "\n" + "\n" ;
            safety_txt += "<b>Safety Using Action:</b> " + ins_list["SUA"] + "\n" + "\n" ;
            safety_txt += "<b>Safety Timeline:</b> " + ins_list["ST"] + "\n" + "\n";
            
            defect_lbl.text = txt;
            safety_number_lbl.text = "Safety Number:  " + ins_list["SN"];
            safety_lbl.text = safety_txt;
            comment.text = ins_list["comment"];
        }
        catch { }


    }
    void btn_text_handlerFR()
    {
        try
        {

        }
        catch { }

    }

    public string delete_this_inspection(){
        
        String answer;
        
        answer = "unknown";
        
        //string sql_command = "DELETE FROM inspections WHERE ID = " + ins_list["ID"];
        sql_handler.delete_byID("inspectionsENFR", ins_list["ID"]);
        
        return answer;
        
    }

}

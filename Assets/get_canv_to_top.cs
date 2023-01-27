using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// problem will be seen in the android app because when client is typin in the search bar the key board is covering the RS so this wil get it to top and civerwhole screen
public class get_canv_to_top : MonoBehaviour
{
    public GameObject search_pannel;
    public Image panel_background;
    public RectTransform searchpanel_rect;
    public GameObject finish_btn,search_backGround;
    public InputField search_box;
    float y, height;

    // Start is called before the first frame update
    void Start()
    {
        search_backGround.SetActive(false);
        finish_btn.SetActive(false);
    }
    public void take_to_top()
    {

        search_backGround.SetActive(true);
        finish_btn.SetActive(true);
        Debug.Log("here");
        searchpanel_rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top,60,300);
        panel_background.color = Color.white;
    }

    public void back_down()
    {
        search_box.text = "";
        finish_btn.SetActive(false);
        search_backGround.SetActive(false);
        searchpanel_rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 451, 190);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

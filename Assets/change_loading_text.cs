using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class change_loading_text : MonoBehaviour
{
    static TMP_Text loadingText;
    void Start()
    {
        loadingText = GetComponent<TMP_Text>();
    }
    // Start is called before the first frame update
    public static void changeLoadingText(string txt)
    {
        loadingText.text = txt;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

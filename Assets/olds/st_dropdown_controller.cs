using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class st_dropdown_controller : MonoBehaviour
{
    //Create a List of new Dropdown options
    List<string> m_DropOptions = new List<string> { };

     static Dropdown m_Dropdown;
    public static string selected_txt;
    static string caption;
    int m_DropdownValue;
    void Start()
    {
        m_Dropdown = GetComponent<Dropdown>();
        re_clear_after_SN_st();
    }

    public static void changeScript_st_dropdown(List<string> m_DropOptions)
    {
        
        m_Dropdown.ClearOptions();
        m_Dropdown.AddOptions(m_DropOptions);
        m_DropOptions.Insert(0, caption);
    }
    public static void re_clear_after_SN_st(){
        if (Language_Manager.lang == 0){
            caption = "safety timeline: ";
            caption +=  playerPrefsMANAGER.ins_list["ST"];
            changeScript_st_dropdown(safty_vars.safty_timeline);            
        } 
        if(Language_Manager.lang == 1) {
            caption = "Calendrier de sécurité: ";
            caption += playerPrefsMANAGER.ins_list["STF"];
            changeScript_st_dropdown(safty_vars.safty_timelineFR);
        }
    }
}

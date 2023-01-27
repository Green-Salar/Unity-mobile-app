using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class sua_dropdown_controller : MonoBehaviour
{
    List<string> m_DropOptions = new List<string> { };

    public static Dropdown m_Dropdown;
    public static string selected_txt;
    static string caption;
    int m_DropdownValue;
    void Awake()
    {
        m_Dropdown = GetComponent<Dropdown>();
        //Debug.Log(m_Dropdown);
        caption = "Select safety using action";
        if(Language_Manager.lang == 1 )caption =  "Utilisation de l'action de sécurité";
        changeScript_sua_dropdown(safty_vars.safty_using_action);
        if(Language_Manager.lang == 1) changeScript_sua_dropdown(safty_vars.safty_using_actionFR);
    }
    
    static void changeScript_sua_dropdown(List<string> m_DropOptions)
    {
        m_Dropdown.ClearOptions();
        m_Dropdown.AddOptions(m_DropOptions);
        m_DropOptions.Insert(0, caption);
    }

    public static void re_clear_after_SN_sua(){
        
        if(Language_Manager.lang == 0){
            caption = "safety using action: ";
            caption +=  playerPrefsMANAGER.ins_list["SUA"];
            changeScript_sua_dropdown(safty_vars.safty_using_action);            
        } 
        if(Language_Manager.lang == 1) {
            caption = "Utilisation de l'action: ";
            caption += playerPrefsMANAGER.ins_list["SUAF"];
            changeScript_sua_dropdown(safty_vars.safty_using_actionFR);
        }
    }
    
}

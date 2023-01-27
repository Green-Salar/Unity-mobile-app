using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sca_dropdown_controller : MonoBehaviour
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
        caption = "Select corrective action";
        if (Language_Manager.lang==1 )caption =  "Mesure corrective";
        changeScript_sca_dropdown(safty_vars.safty_corrective_action);
        if(Language_Manager.lang == 1) changeScript_sca_dropdown(safty_vars.safty_corrective_actionFR);
    }

    static void changeScript_sca_dropdown(List<string> m_DropOptions)
    {
        m_Dropdown.ClearOptions();
        m_Dropdown.AddOptions(m_DropOptions);
        m_DropOptions.Insert(0,caption);
    }
    public static void re_clear_after_SN_sca(){
        
        if(Language_Manager.lang == 0){
            caption = "Corrective action: ";
            caption +=  playerPrefsMANAGER.ins_list["SCA"];
            changeScript_sca_dropdown(safty_vars.safty_unloading_action);            
        } 
        if(Language_Manager.lang == 1) {
            caption = "Mesure corrective: ";
            caption += playerPrefsMANAGER.ins_list["SCAF"];
            changeScript_sca_dropdown(safty_vars.safty_unloading_actionFR);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sa_dropdown_controller : MonoBehaviour
{
    //Create a List of new Dropdown options
    List<string> m_DropOptions = new List<string> { };

    public static Dropdown m_Dropdown;
    public static string selected_txt;
    static string caption;
    int m_DropdownValue;

    void Awake()
    {
        m_Dropdown = GetComponent<Dropdown>();
        //Debug.Log(m_Dropdown);
        caption = "Select unloading action";
        if (Language_Manager.lang==1 )caption = "Sélectionnez Action déchargement";
        changeScript_SA_Dropdown(safty_vars.safty_unloading_action);
        if(Language_Manager.lang == 1) changeScript_SA_Dropdown(safty_vars.safty_unloading_actionFR);
    }

    static void changeScript_SA_Dropdown(List<string> m_DropOptions)
    {
        m_Dropdown.ClearOptions();
        m_Dropdown.AddOptions(m_DropOptions);
        m_DropOptions.Insert(0, caption);
    }

    public static void re_clear_after_SN_sa(){
        Debug.Log(playerPrefsMANAGER.ins_list["SA"]);    
        if(Language_Manager.lang == 0){
            caption = "unloading action: ";
            caption +=  playerPrefsMANAGER.ins_list["SA"];
            changeScript_SA_Dropdown(safty_vars.safty_unloading_action);            
        } 
        if(Language_Manager.lang == 1) {
            caption = "Action déchargement: ";
            caption += playerPrefsMANAGER.ins_list["SAF"];
            changeScript_SA_Dropdown(safty_vars.safty_unloading_actionFR);
        }
    }
}

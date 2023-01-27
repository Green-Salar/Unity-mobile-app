using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

    public class RT_review : MonoBehaviour
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
        if (playerPrefsMANAGER.ins_list["RT"] == "-") {

            caption = "Select Racking type";
            if (Language_Manager.lang == 1) caption = "Sélectionnez le type de rayonnage";
        } else
        {
            Debug.Log("we have sth here RT!");

            caption = "Racking type:" + playerPrefsMANAGER.ins_list["RT"];
            if (Language_Manager.lang == 1)  caption = "Plattier: " + playerPrefsMANAGER.ins_list["RTF"];
        }
        m_DropOptions.Insert(0, caption);
    }

    public static void changeScript(List<string> m_DropOptions)
    {
        //Clear the old options of the Dropdown menu
        try { m_Dropdown.ClearOptions(); } catch { }
        //Add the options created in the List above
        m_DropOptions.Insert(0, caption);
        m_Dropdown.AddOptions(m_DropOptions);
        // m_Dropdown.captionText.text = caption;
        //DC_review.m_Dropdown.interactable = false;
        //DSC_review.m_Dropdown.interactable = false;
        clear_children.Clear_toggleParent();
    }
    public void on_value_changed()
    {
        //Keep the current index of the Dropdown in a variable
        m_DropdownValue = m_Dropdown.value;
        //Change the message to say the name of the current Dropdown selection using the value
        selected_txt = m_Dropdown.options[m_DropdownValue].text;
        //Change the onscreen Text to reflect the current Dropdown selection
        if (selected_txt != caption) relats_review.DCgetter(selected_txt);
    }

}
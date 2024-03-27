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
    public Text dctxt, dsctxt, Text;
    public GameObject dcdrp, dscdrp;
    void Awake()
    {
        m_Dropdown = GetComponent<Dropdown>();
        Debug.Log("RT_review Awake");
        foreach( var kvp in playerPrefsMANAGER.ins_list)
        {
                Debug.Log(kvp.Key + " " + kvp.Value);
        }
    }
    void Start()
    {
        m_Dropdown = GetComponent<Dropdown>();
        if (playerPrefsMANAGER.ins_list["RT"] == "-") {

            caption = "Select Racking type";
            if (Language_Manager.lang == 1) caption = "S�lectionnez le type de rayonnage";
        } else
        {
            Debug.Log("we have sth here RT!");
            caption = "Racking type:" + playerPrefsMANAGER.ins_list["RT"];
            if (Language_Manager.lang == 1)  caption = "Plattier: " + playerPrefsMANAGER.ins_list["RTF"];
        }
        m_DropOptions.Insert(0, caption);
        initiate_txt_object_dc_dsc();

    }
    //the next 2 functions are because I couldn't change the dropdown value on start so its another way to do it. 
    void initiate_txt_object_dc_dsc()
    {
        dcdrp.SetActive(false);
        dscdrp.SetActive(false);
        dctxt.gameObject.SetActive(true);
        dctxt.text = (Language_Manager.lang == 0 ? "Defect Category: " + playerPrefsMANAGER.ins_list["DC"] : "Cat�gorie de d�faut: " + playerPrefsMANAGER.ins_list["DCF"]);
        dsctxt.gameObject.SetActive(true);
        dsctxt.text = (Language_Manager.lang == 0 ? "Defect Sub Category: " + playerPrefsMANAGER.ins_list["DSC"] : "Sous-cat�gorie de d�faut: " + playerPrefsMANAGER.ins_list["DSCF"]);
    }
    void start_edditing_dc_dsc()
    {

    }
    public void startEditing()
    {
        try
        {
            dctxt.gameObject.SetActive(false);
            dsctxt.gameObject.SetActive(false);

            dcdrp.SetActive(true);
            dscdrp.SetActive(true);
        }
        catch
        {

        }
    }
    public static  void changeScript(List<string> m_DropOptions)
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
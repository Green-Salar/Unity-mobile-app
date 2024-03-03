using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DSC_review : MonoBehaviour
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
    }
    void Start()
    {

        if (playerPrefsMANAGER.ins_list["DSC"] == "-")
        {
            caption = "Sélectionnez la sous-catégorie de défaut";
            if (Language_Manager.lang == 0) caption = "Select Defect Sub Category";
        }

        else
        {
            if (Language_Manager.lang == 0)
            {
                Debug.Log("eng dsc is insdise");
                caption = playerPrefsMANAGER.ins_list["DSC"];
                Defectgetter(playerPrefsMANAGER.ins_list["RT"], playerPrefsMANAGER.ins_list["DC"], playerPrefsMANAGER.ins_list["DSC"]);
            }
            else{
                caption = playerPrefsMANAGER.ins_list["DSCF"];
                // instantiate the toggles;)
                Defectgetter(playerPrefsMANAGER.ins_list["RTF"], playerPrefsMANAGER.ins_list["DCF"], playerPrefsMANAGER.ins_list["DSCF"]);
                
            }
            StartCoroutine(init_defects());
        }
        m_DropOptions.Insert(0, caption);
    }

    private IEnumerator init_defects()
    {
        yield return new WaitForSeconds(.2f);
        //if (Language_Manager.lang == 0) preValue_toggle_Instantiator(playerPrefsMANAGER.ins_list["D"]);
        //else preValue_toggle_Instantiator(playerPrefsMANAGER.ins_list["DF"]);
        Defectgetter(playerPrefsMANAGER.ins_list["RT"], playerPrefsMANAGER.ins_list["DC"], playerPrefsMANAGER.ins_list["DSC"]);
    }
    public static void changeScript(List<string> m_DropOptions)
    {
        m_Dropdown.ClearOptions();
        m_Dropdown.interactable = true;
        m_DropOptions.Insert(0, caption);
        m_Dropdown.AddOptions(m_DropOptions);
        //Add the options created in the List above
        clear_children.Clear_toggleParent();
    }
    public void on_value_changed()
    {
        //Keep the current index of the Dropdown in a variable
        m_DropdownValue = m_Dropdown.value;
        //Change the message to say the name of the current Dropdown selection using the value
        selected_txt = m_Dropdown.options[m_DropdownValue].text;
        //Change the onscreen Text to reflect the current Dropdown selection
        string RT_val = RT_review.selected_txt;
        string DC_val = DC_review.selected_txt;
        //Change the message to say the name of the current Dropdown selection using the value
        if (selected_txt != caption) Defectgetter(RT_val, DC_val, selected_txt);
        //Change the onscreen Text to reflect the current Dropdown selection

    }
    static string sqlQuery;
    void Defectgetter(string RT, string DC, string DSC)
    {
        sqlQuery = "Select D from " + relats_review.tableName + " where  RT = '" + RT + "'AND DC = '" + DC + "'AND DSC = '" + DSC + "';";
        if (Language_Manager.lang == 1) sqlQuery = "Select DF from " + relats_review.tableName + " where  RTF = '" + RT + "'AND DCF = '" + DC + "'AND DSCF = '" + DSC + "';";

        List<string> defect_list = relats_review.sqliteExecuter(sqlQuery);

        clear_children.Clear_toggleParent();

        foreach (string i in defect_list)
        {
            Instantiator(i);
        }
    }

    public GameObject canvas;
    public GameObject toggle;

    void Clear_toggleParent()
    {
        foreach (Transform child in canvas.transform)
        {
            Destroy(child.gameObject);
        }
    }
    void Instantiator(string i)
    {

        GameObject newtoggle = Instantiate(toggle) as GameObject;
        try { newtoggle.GetComponentInChildren<Text>().text = i; } catch { Debug.Log("failed to name toggle"); }
        newtoggle.transform.SetParent(canvas.transform, false);
        Toggle _Toggle = newtoggle.GetComponent<Toggle>();
        if (playerPrefsMANAGER.ins_list["D"].Contains(i)) _Toggle.isOn =true;
        if (i[0] == '#')
        {
            
            _Toggle.onValueChanged.AddListener(delegate {
                ToggleValueChanged(_Toggle);
            });
        }
    }
    void ToggleValueChanged(Toggle _Toggle)
    {
        if (_Toggle.isOn)
        {
            //_Toggle.GetComponentInChildren<Text>().text = "hiihaaaaw" + _Toggle.isOn;
            Toggle_scence_handler.pop_it_up(_Toggle);
        }
    }

    void preValue_toggle_Instantiator(string i)
    {

        GameObject newtoggle = Instantiate(toggle) as GameObject;
        try { newtoggle.GetComponentInChildren<Text>().text = i; } catch { Debug.Log("failed to name toggle"); }
        newtoggle.transform.SetParent(canvas.transform, false);
        newtoggle.GetComponentInChildren<Toggle>().isOn = true;
        newtoggle.transform.SetSiblingIndex(0);
        
    }
}


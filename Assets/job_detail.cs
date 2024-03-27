using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
public class job_detail : MonoBehaviour
{
    public TextMeshProUGUI reportIDText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI contactText;
    //public TextMeshProUGUI addressText;
    public TextMeshProUGUI addressLinkText;
    public TextMeshProUGUI telephoneText;

    public static string report_ID,warehouse,contact,address,addressLink,telephone;
    public static bool T_activesymbol = false;
    public static List<string> job_details;
    public void Start(){
        gameObject.SetActive(false);
    }
    public static void load_page(List<string> _job_details){
        job_details = _job_details;
        T_activesymbol = true;
    }
    public  void unload_page(){
            gameObject.SetActive(false);
    }
    public void start_it_test(){
        Debug.Log("start_it_test called");
        job_details = new List<string>();
        job_details = new List<string>(){"11111-22222-insv1","Test Company","Test Address ",
        "Joe Johnson","https://www.google.com/maps/place/IKEA+Montreal/@45.491986,-73.6913528,15z/data=!4m6!3m5!1s0x4cc917d1536e3e4f:0x628982dfacdbf88d!8m2!3d45.491986!4d-73.6913528!16s%2Fg%2F1tplpydj","333 444 55555"};
        UpdateValues(job_details[0],job_details[1],job_details[2],job_details[3],job_details[4],job_details[5]);
    }
        public void start_it_test2(){
        Debug.Log("start_it_test called");
        job_details = new List<string>();
        job_details = new List<string>(){"11111-33333-insv1","Test Company2","Test Address2 ",
        "Joe Johnson2","https://www.google.com/maps/place/IKEA+Montreal/@45.491986,-73.6913528,15z/data=!4m6!3m5!1s0x4cc917d1536e3e4f:0x628982dfacdbf88d!8m2!3d45.491986!4d-73.6913528!16s%2Fg%2F1tplpydj","222 444 55555"};
        UpdateValues(job_details[0],job_details[1],job_details[2],job_details[3],job_details[4],job_details[5]);
    }
    void Update()
    {
        if (T_activesymbol ==    true){
            Debug.Log("T_activesymbol is true");

            UpdateValues(job_details[0],job_details[1],job_details[2],job_details[3],job_details[4],job_details[5]);
            
            T_activesymbol = false;
        }
    }
    void UpdateValues(string _reportID,string _name, string _address,string _contact,  string _addressLink, string _telephone)
    {
        PlayerPrefs.SetString("report_ID",_reportID);
        report_ID=_reportID;warehouse=_name;contact=_contact;address=_address;addressLink=_addressLink;telephone=_telephone;
        reportIDText.text = "Report ID: "+_reportID;
        nameText.text = "Warehouse: "+_name;
        contactText.text = "Contact Person: "+_contact;
        //addressText.text = "Address: "+ _address;
        addressLinkText.text = "Address: "+ _address;
        telephoneText.text = "Call: "+_telephone;

        gameObject.SetActive(true);
    }
        public void Call()
    {
        Application.OpenURL("tel:" + telephone);
    }
        public void OpenURL()
    {
        Application.OpenURL(addressLink);
    }
}

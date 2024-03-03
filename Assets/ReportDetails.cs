using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportDetails : MonoBehaviour
{
    public static string report_id,inspector,warehouse_name,date ;
    // Start is called before the first frame update
    void Start()
    {
        report_id = "Report_id_fromPlayerprefs";
        inspector = "Inspector_fromPlayerprefs";
        warehouse_name = "warehouse_fromPlayerprefs";
        date = "date_test_fromPlayerprefs";
        setdetails(report_id,inspector,warehouse_name,date);
    }
    public static void setdetails(string id,string InspectorName,string warehouse,string date){
        PlayerPrefs.SetString("report_id", report_id);
        PlayerPrefs.SetString("inspector", InspectorName);
        PlayerPrefs.SetString("warehouse_name", warehouse);
        PlayerPrefs.SetString("date", date);
    }

}

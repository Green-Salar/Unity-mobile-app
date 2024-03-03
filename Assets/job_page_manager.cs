using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class job_page_manager : MonoBehaviour
{
    string dbname;
    string table;
    string user_id;
    public GameObject job_prefab;
    public static GameObject job_prefab_static;
    public static Transform transform_static;
   string querry;
    // Start is called before the first frame update
    void Start()
    {
        job_prefab_static = job_prefab;
        transform_static = transform;
        dbname = "jobs";
        table = "user_jobs";
        user_id = PlayerPrefs.GetString("user_ID");
        Debug.Log("userid is: "+ user_id);
        querry = "select report_ID from " + table + " where user_ID = '" + user_id+"'";
        Screen_Manager.load_loading();
        //sql_coroutine_handler.job_getter(dbname,querry);
        
    }

    // Update is called once per frame
    public static void job_instantiator(Dictionary <string,List <string> > dict)
    {
        Debug.Log("job_instantiator called");
        Screen_Manager.unload_loading();
        foreach( var kvp in dict)
        {
            Debug.Log(kvp.Key + " : " + kvp.Value+"is instantiated");
            Instantiate(job_prefab_static,transform_static).AddComponent<job_prefab_manager>().set_job(kvp.Key,kvp.Value);
            
        }
        //querry = "select * from " + table + " where user_id = " + user_ID + " and job_ID = " + job_id;
    }
}

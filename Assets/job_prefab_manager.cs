using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class job_prefab_manager : MonoBehaviour
{
    public string job_id;
    public List<string> job_details;
    // Start is called before the first frame update
    void Start()
    {
            }

    // Update is called once per frame
    public void set_job(string _job_id,object _job_details)
    {
        job_id = _job_id;
        job_details = (List<string>) _job_details;
        Debug.Log(job_id);
        Debug.Log((List<string>) job_details);
        this.gameObject.AddComponent<Button>().onClick.AddListener(() => { job_detail.T_activesymbol=true; job_detail.job_details= job_details;});

    }
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class review_screen_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public void save_and_continue_review_review1()
    {
        Debug.Log("save_and_continue");
        SceneManager.LoadScene("ins_rev_page2", LoadSceneMode.Additive);
    }
    public void save_and_continue_review_2_to_3()
    {
        Debug.Log("save_and_continue");
        SceneManager.LoadScene("ins_review_3", LoadSceneMode.Additive);
    }
    public void unload_ins_review_2()
    {
        SceneManager.UnloadSceneAsync("ins_rev_page2");
    }
    public void unload_ins_review_1()
    {
        SceneManager.UnloadSceneAsync("ins_review_1");
    }
    public void unload_ins_review_3()
    {
        SceneManager.UnloadSceneAsync("ins_review_3");
        //Debug.Log("ok");
    }
    public void Save_lastPage_review()
    {
        Report_Manager.report_list.Add(playerPrefsMANAGER.ins_list["ID"], playerPrefsMANAGER.ins_list);
        unload_ins_review_1(); unload_ins_review_2(); unload_ins_review_3();
    }

}

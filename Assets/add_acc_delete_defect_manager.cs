using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class add_acc_delete_defect_manager : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> defects = new List<GameObject> { };
    public GameObject parentObject;
    public GameObject prefab;
    public GameObject addbtn, accbtn, deletebtn;
    void Start()
    {
        //addbtn.SetActive(true);
        accbtn.SetActive(false); 
    }
    public void add()
    {
        Vector3 center = Vector3.zero;
        GameObject childObject = Instantiate(prefab, center, Quaternion.identity, parentObject.transform);
        
        childObject.transform.SetParent(parentObject.transform);
        childObject.transform.localPosition = center;
        
        Debug.Log("childObject.transform.position: " + childObject.transform.position);
        
        defects.Add(childObject);

        addbtn.SetActive(false);
        accbtn.SetActive(true);
    }
    public void delete()
    {
        if (defects.Count > 0)
        {
            defects[defects.Count - 1].SetActive(false);
            Destroy(defects[defects.Count - 1]);
            defects.RemoveAt(defects.Count - 1);
            addbtn.SetActive(true);
            accbtn.SetActive(false);
        }
    }
     public void accept()
    {
        defects[defects.Count-1].GetComponent<zoomer>().enabled = false;
        //GameObject zoomer =  defects[defects.Count - 1];
        //Zoomer script = zoomer.GetComponent<Zoomer>();
        //script.enabled = false;
        //add();

        addbtn.SetActive(true);
        accbtn.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
    }
}

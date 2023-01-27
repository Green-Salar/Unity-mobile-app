using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPrinter : MonoBehaviour
{
    Dictionary<string, string> insTemp;
    // Start is called before the first frame update
    void Start()
    {
        insTemp = playerPrefsMANAGER.ins_list;



        foreach (var i in insTemp)
        {
            Debug.Log("Key: " + i.Key + " - Value:" + i.Value);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}

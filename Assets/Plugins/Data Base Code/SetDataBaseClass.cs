using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


    public class SetDataBaseClass
    {
        public static string SetDataBase(string DataBaseName)
        {
            string conn = "";
#if UNITY_EDITOR
            conn = "URI=file:" + Application.dataPath + "\\StreamingAssets" + "/"+ DataBaseName; //Path to database
            //Debug.Log("Windows Mode");

#elif UNITY_ANDROID
            //Debug.Log("Android Mode");
            //Debug.Log(Application.persistentDataPath);
            //conn =  Application.persistentDataPath + "\" + DataBaseName; 
             conn = "URI=file:"+Path.Combine(Application.persistentDataPath,DataBaseName);
            //Debug.Log(conn);
            //Debug.Log(File.Exists(conn));
#endif
        //Debug.Log(conn);


        return conn;
        }

    


}

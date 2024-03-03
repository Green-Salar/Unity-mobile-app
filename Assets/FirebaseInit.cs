using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FirebaseInit : MonoBehaviour
{
    public UnityEvent OnFirebaseInitialized = new UnityEvent();

    private async void Start(){
        var dependencyStatus= await Firebase.FirebaseApp.CheckAndFixDependenciesAsync();
        if(dependencyStatus == Firebase.DependencyStatus.Available){
            Debug.Log("Firebase is ready to use");
        OnFirebaseInitialized.Invoke();
        }else{
            Debug.LogError(System.String.Format(
                "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
        }
    }




    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}

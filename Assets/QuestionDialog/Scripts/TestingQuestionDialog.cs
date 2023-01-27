using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestingQuestionDialog : MonoBehaviour {


    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            QuestionDialogUI.Instance.ShowQuestion("Are you sure you want to quit the game?", () => {
                QuestionDialogUI.Instance.ShowQuestion("Are you really sure?", () => {//QuestionDialogUI.Hide();
                Debug.Log("1yes");
                }, () => {
                    Debug.Log("1no");
                });
            }, () => {
                //QuestionDialogUI.Hide();
                Debug.Log("1no");
                // Do nothing on No
            });
        }
    }

}
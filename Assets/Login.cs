using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
public class Login : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_Text errorText;
    public Button loginButton;
    // Start is called before the first frame update
    float timer = 0;
    int attempts = 0;
void Start()
{
    timer = 0;
    
    errorText.text = "";
    //loginButton.onClick.AddListener(login);
}

    // Update is called once per frame



public void login()
{
    if(attempts>7)
    {
        if(timer<20)
        {
            errorText.text = "Max attem reached. Please wait " + ((int)(20-timer)).ToString() + " seconds...";
        }
        else
        {
            timer = 0;
            attemp();
                attempts = 0;
        }        
     }else
     {
        attemp();
     }
}
void Update()
{
    timer += Time.deltaTime;
}
public void attemp()
{

    string username = usernameInput.text.Trim();
    string password = passwordInput.text.Trim();

    // Check if username and password are valid
    if (username == "vahid@op-st.ca" && password == "V@hid111")
    {
        // Successful login
        Debug.Log("Login successful!");
        PlayerPrefs.SetString("user_ID", username);
        errorText.text = "Login successful!";
        errorText.color = Color.green;
        load_nextscene();
    }
    else
    {
        // Failed login
        Debug.Log("Login failed!");
        attempts = attempts + 1;
        errorText.color = Color.red;
        errorText.text = attempts>7 ? "Max attemps reached. Please wait 20 seconds..." : "Login failed! Please try again.";
        timer = 0;
        usernameInput.text = "";
        passwordInput.text = "";
    }
        if (username == "s" && password == "s")
    {
        // Successful login

        PlayerPrefs.SetString("user_ID", username);
                Debug.Log("Login successful!"+username+"saved"+PlayerPrefs.GetString("user_ID"));
        
        errorText.color = Color.green;
        errorText.text = "Login successful!";
        load_nextscene();
    }

}
void load_nextscene()
  {
    SceneManager.LoadScene("start_lang");

  }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButton : MonoBehaviour
{
    public GameObject loginPanel;
    public GameObject signInPanel;
    public GameObject mainPanel;

    private bool login_signIn;
    private bool login_Main;

    public void ChangeLoginSignIn()
    {
        if (login_signIn == false)
        {
            loginPanel.SetActive(false);
            signInPanel.SetActive(true);
            login_signIn = true;
        }
    }

    public void ChangeSignInLogin()
    {
        if (login_signIn == true)
        {
            signInPanel.SetActive(false);
            loginPanel.SetActive(true);
            login_signIn = false;
        }
    }

    public void ChangeLoginMain()
    {
        if (login_Main == false)
        {
            loginPanel.SetActive(false);
            mainPanel.SetActive(true);
            login_Main = true;
        }
    }

    public void ChangeMainLogin()
    {
        if(login_Main == true)
        {
            mainPanel.SetActive(false);
            loginPanel.SetActive(true);
            login_Main = false;
        }
    }
}

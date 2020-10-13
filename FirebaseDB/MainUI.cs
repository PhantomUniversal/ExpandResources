using Firebase.Unity.Editor;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Firebase;
using Firebase.Database;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Security.Cryptography;
using Firebase.Auth;


public class MainUI : MonoBehaviour
{
    public GameObject userIMData;
    public GameObject userIcon;
    private bool state;

    public Text roomText;
    public Text nameText;
    public Text emailText;

    public string RoomText { get; set; }
    public string NameText { get; set; }
    public string EmailText { get; set; }

    public static FirebaseUser user;

    FirebaseApp firebaseApp;
    FirebaseAuth firebaseAuth;
    DatabaseReference databaseReference;

    public DatabaseReference A;
    

    private void Awake()
    {
        firebaseAuth = FirebaseAuth.DefaultInstance;
        firebaseApp = FirebaseDatabase.DefaultInstance.App;
        firebaseApp.SetEditorDatabaseUrl("https://pria-mainserver.firebaseio.com/");
        // FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("testrealtimedatebase-aae7a@appspot.gserviceaccount.com");        
        FirebaseApp.DefaultInstance.SetEditorP12FileName("pria-mainserver-750ca53b8350.p12");
        FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");

        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    private void Update()
    {
        if (EmailText != "")
        {
            emailText.text = EmailText;
            EmailText = "";
        }
        if (NameText != "")
        {
            nameText.text = NameText;
            NameText = "";
        }
        if (RoomText != "")
        {
            roomText.text = RoomText;
            RoomText = "";
        }

    }

    public void ReceiveUserData()
    {
        //FirebaseDatabase.DefaultInstance.GetReference("userdata").OrderByChild("email").EqualTo("chho1365@gmail.com")
        //    .GetValueAsync().Result.GetRawJsonValue();

        FirebaseDatabase.DefaultInstance.GetReference("userdata").OrderByChild("chho1365@gmail.com")
            .GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;

                    foreach (var item in snapshot.Children)
                    {
                        Debug.Log("Email : " + item.Child("email").Value);
                        Debug.Log("NickName : " + item.Child("nickName").Value);
                        Debug.Log("RoomName : " + item.Child("roomName").Value);

                        EmailText = item.Child("email").Value.ToString();
                        NameText = item.Child("nickName").Value.ToString();
                        RoomText = item.Child("roomName").Value.ToString();
                        //if(item.Child("email").Value != null)
                        //    emailText.text = item.Child("email").Value.ToString();
                        //if (item.Child("nickName").Value != null)
                        //    nameText.text = item.Child("nickName").Value.ToString();
                        //if (item.Child("roomName").Value != null)
                        //    roomText.text = item.Child("roomName").Value.ToString();

                    }
                }
            });

        if (state == false)
        {
            userIcon.SetActive(false);
            userIMData.SetActive(true);
            state = true;                    
        }       
    }

    public void CancelUserData()
    {
        if (state == true)
        {
            userIcon.SetActive(true);
            userIMData.SetActive(false);
            state = false;
        }
    }

    public void UserLogout()
    {
        firebaseAuth.SignOut();  
        if (state == true)
        {
            userIcon.SetActive(false);
            userIMData.SetActive(false);
            state = false;
        }
    } 
}

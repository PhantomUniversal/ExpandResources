using Firebase.Unity.Editor;
using UnityEngine;
using Newtonsoft.Json;
using Firebase;
using Firebase.Database;
using UnityEngine.UI;
using Firebase.Auth;

public class FirebaseJoin : MonoBehaviour
{
    [SerializeField] string s_email;
    [SerializeField] string s_nickName;
    [SerializeField] string s_roomName;

    public InputField emailField;
    public InputField passwordField;
    public InputField nicknameField;
    public InputField roomnameField;
    public Text joinResultText;
    
    FirebaseAuth firebaseAuth;
    FirebaseApp firebaseApp;
    DatabaseReference databaseReference;

    public static FirebaseUser user;

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

    public void FirebaseJoinUser()
    {
        firebaseAuth.CreateUserWithEmailAndPasswordAsync(emailField.text, passwordField.text).ContinueWith(task =>
        {   
            if (task.IsCanceled)
            {
                Debug.LogError("Join in with Email And Password async was canceled.");
                joinResultText.text = "회원가입 취소";
            }
            else if (task.IsFaulted)
            {
                Debug.LogError("Join in with Email And Password async encountered an error : " + task.Exception);
                joinResultText.text = "회원가입 실패, Email, Password를 확인하세요.";
            }
            else
            {
                Firebase.Auth.FirebaseUser newUser = task.Result;
                Debug.LogFormat($"User Joined in successfully: [Email : {emailField.text}],[Nickname : {nicknameField.text}],[Roomname : {roomnameField.text}]");

                JoinAccountDateSave userData = new JoinAccountDateSave(emailField.text,passwordField.text, nicknameField.text, roomnameField.text);
                string json = JsonConvert.SerializeObject(userData);
                databaseReference.Child("Userdata").Child(newUser.UserId).SetRawJsonValueAsync(json);

                joinResultText.text = "회원가입 완료 뒤로가기를 누르세요";
            }
        });
    }

    public class JoinAccountDateSave
    {
        public string email;
        public string password;
        public string nickName;
        public string roomName;

        public JoinAccountDateSave(string userEmail, string userPassword, string userNickName, string userRoomName)
        {
            this.email = userEmail;
            this.password = userPassword;
            this.nickName = userNickName;
            this.roomName = userRoomName;
        }
    }

    public void JoinBtnClick()
    {
        FirebaseJoinUser();

        s_email = emailField.text;
        s_nickName = nicknameField.text;
        s_roomName = roomnameField.text;

        Debug.Log("Email : " + s_email + " Nickname : " + s_nickName + " Roomname : " + s_roomName);
    }

  
}

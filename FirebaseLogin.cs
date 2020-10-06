using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase.Extensions;


public class FirebaseLogin : MonoBehaviour
{
    [SerializeField] string email;
    [SerializeField] string password;
  
    public InputField emailField;
    public InputField passwordField;
    public Text loginResultText;

    FirebaseAuth firebaseAuth;
    public static FirebaseUser user;

    private void Awake()
    {
        firebaseAuth = FirebaseAuth.DefaultInstance;
        //firebaseAuth.StateChanged += AuthStateChanged;
        //AuthStateChanged(this, null);
    }

    public void LoginUser()
    {
         firebaseAuth.SignInWithEmailAndPasswordAsync(emailField.text, passwordField.text)
            .ContinueWithOnMainThread(continuation: task =>
        {
               if (task.IsCanceled)
               {
                   Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                   loginResultText.text = "로그인 취소";
               }
               else if (task.IsFaulted)
               {
                   Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: "
                       + task.Exception);
                   loginResultText.text = "로그인 실패";
               }
               else
               {
                   
                   Debug.LogFormat("User signed in successfully: {0},{1}", emailField.text,
                       passwordField.text);
               }
           });
    }
    //public void AuthStateChanged(object sender, System.EventArgs eventArgs)
    //{
    //    if (firebaseAuth.CurrentUser != user)
    //    {
    //        bool signedln = user != firebaseAuth.CurrentUser && firebaseAuth.CurrentUser != null;
    //        if (!signedln && user != null)
    //        {
    //            Debug.Log("Signed out" + user.UserId);
    //        }
    //        user = firebaseAuth.CurrentUser;
    //        if (signedln)
    //        {
    //            Debug.Log("Signed in" + user.UserId);
    //        }
    //    }
    //}

    public void LoginBtnClick()
    {
        email = emailField.text;
        password = passwordField.text;

        Debug.Log("email : " + email + ",password : " + password);

        LoginUser();
    }

}

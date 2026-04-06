using UnityEngine;
using Firebase.Auth;
using Firebase.Extensions;
using TMPro;

public class code2 : MonoBehaviour
{
    FirebaseAuth auth;

    public TMP_InputField loginEmail;
    public TMP_InputField loginPassword;

    public TMP_InputField signupEmail;
    public TMP_InputField signupPassword;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    public void SignUp()
    {
        auth.CreateUserWithEmailAndPasswordAsync(
            signupEmail.text.Trim(),
            signupPassword.text.Trim()
        ).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("Signup Failed");
                return;
            }

            Debug.Log("Signup Success: " + task.Result.User.Email);
        });
    }

    public void Login()
    {
        auth.SignInWithEmailAndPasswordAsync(
            loginEmail.text.Trim(),
            loginPassword.text.Trim()
        ).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("Login Failed");
                return;
            }

            Debug.Log("Login Success: " + task.Result.User.Email);
        });
    }

    public void Logout()
    {
        auth.SignOut();
        Debug.Log("Logged Out");
    }
}
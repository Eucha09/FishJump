using Firebase;
using Firebase.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class FirebaseManager
{
    FirebaseApp _app;
    public bool ReceiveMessage
    {
        get { return FirebaseMessaging.TokenRegistrationOnInitEnabled; }
        set { FirebaseMessaging.TokenRegistrationOnInitEnabled = value; Debug.Log(FirebaseMessaging.TokenRegistrationOnInitEnabled); }
    }

    public void Init()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                _app = FirebaseApp.DefaultInstance;
                FirebaseMessaging.TokenReceived += OnTokenReceived;
                FirebaseMessaging.MessageReceived += OnMessageReceived;
            }
            else
            {
                Debug.LogError("[FIREBASE] Could not resolve all dependencies: " + task.Result);
            }
        });
    }

    void OnTokenReceived(object sender, TokenReceivedEventArgs e)
    {
        if (e != null)
        {
            Debug.LogFormat("[FIREBASE] Token: {0}", e.Token);
        }
    }

    void OnMessageReceived(object sender, MessageReceivedEventArgs e)
    {
        if (e != null && e.Message != null && e.Message.Notification != null)
        {
            Debug.LogFormat("[FIREBASE] From: {0}, Title: {1}, Text: {2}",
                e.Message.From,
                e.Message.Notification.Title,
                e.Message.Notification.Body);
        }
    }

    public void AllowMessageReceipt()
    {
        FirebaseMessaging.TokenRegistrationOnInitEnabled = true;
    }

    public void DenyMessageReceipt()
    {
        FirebaseMessaging.TokenRegistrationOnInitEnabled = false;
    }
}

using Firebase;
using Firebase.Messaging;
using System;
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
        set { FirebaseMessaging.TokenRegistrationOnInitEnabled = value; if (!value) DeleteToken(); }
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
                FirebaseMessaging.DeleteTokenAsync();
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

    async void DeleteToken()
    {
        try
        {
            await FirebaseMessaging.DeleteTokenAsync();

            Debug.Log("토큰이 성공적으로 삭제되었습니다.");
        }
        catch (Exception ex)
        {
            ReceiveMessage = true;
            Debug.LogError("토큰 삭제 작업이 실패했습니다: " + ex.Message);
        }
    }
}

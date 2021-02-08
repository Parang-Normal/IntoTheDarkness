
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class Notification : MonoBehaviour
{
    private void Awake()
    {
       BuiltDefaultNotifChannel();
    }

    public void SendEarnCoinNotif()
    {
        string title = "Congratulations!";
        string text = "You won 50 coins!";
        DateTime fireTime = DateTime.Now.AddSeconds(3);

        
        var notif = new AndroidNotification(title,text,fireTime);
        AndroidNotificationCenter.SendNotification(notif, "default");
        
    }
    public void SendSampleNotif()
    {
        string title = "Test Notification";
        string text = "The test is working";
        DateTime fireTime = DateTime.Now.AddSeconds(3);


        var notif = new AndroidNotification(title, text, fireTime);
        AndroidNotificationCenter.SendNotification(notif, "default");

    }

    public void BuiltDefaultNotifChannel()
    {
        string channel_id = "default";

        string channel_name = "Default Channel";

        Importance importance = Importance.Default;

        string channel_description = "Default channel for this game";

        var channel = new AndroidNotificationChannel(channel_id, channel_name, channel_description,importance);
       
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }
}

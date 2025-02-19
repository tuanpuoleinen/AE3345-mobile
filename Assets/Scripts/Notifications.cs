using UnityEngine;
using Unity.Notifications.Android;
using UnityEngine.Android;

public class Notifications : MonoBehaviour
{
    void Start()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }

        var notification = new AndroidNotification();
        notification.Title = "Hello World!";
        notification.Text = "Play me ;)";
        notification.SmallIcon = "my_custom_icon_id";
        notification.FireTime = System.DateTime.Now.AddMinutes(0.1f);
        AndroidNotificationCenter.SendNotification(notification, "channel_id");

    }
}
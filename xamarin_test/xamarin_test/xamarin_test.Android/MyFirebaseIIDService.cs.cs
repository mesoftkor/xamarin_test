using System;
using Android.App;
using Firebase.Iid;
using Firebase.Messaging;
using Android.Util;

namespace FCMClient
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIIDService : FirebaseMessagingService
    {
        string refreshedToken = "";
        const string TAG = "MyFirebaseIIDService";
        //public override void OnTokenRefresh()
        //{
        //    var refreshedToken = FirebaseInstanceId.Instance.Token;
        //    Log.Debug(TAG, "Refreshed token: " + refreshedToken);
        //}

        public override void OnNewToken(string newToken)
        {
            base.OnNewToken(newToken); 
            Log.Info("MyFirebaseMessagingService", "Firebase Token: " + newToken);
            Console.WriteLine("Firebase Token: " + newToken);
            saveToken(newToken); // send to server or store somewhere 
        }
            void saveToken(string token)
        {
            // Add custom implementation, as needed.
        }


     }
}
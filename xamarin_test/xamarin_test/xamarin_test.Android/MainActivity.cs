using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Common;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;

namespace xamarin_test.Droid
{
    [Activity(Label = "xamarin_test", Icon = "@mipmap/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static readonly string TAG = "MainActivity";

        internal static readonly string CHANNEL_ID = "my_notification_channel";
        internal static readonly int NOTIFICATION_ID = 100;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //SetContentView(Resource.Layout.Main);
            //msgText = FindViewById<TextView>(Resource.Id.msgText);

            IsPlayServicesAvailable();
            CreateNotificationChannel();

            LoadApplication(new App());
        }
        /// <summary>
        /// 현재 핸드폰에서 GooglePlay서비스를 사용할 수 있는지 확인하는 메소드
        /// </summary>
        /// <returns></returns>
        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                {
                    Console.WriteLine(GoogleApiAvailability.Instance.GetErrorString(resultCode));
                    //msgText.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                }
                else
                {
                    Console.WriteLine("This device is not supported");
                    Finish();
                }
                return false;
            }
            else
            {
                Console.WriteLine("Google Play Services is available.");
                return true;
            }
        }
        /// <summary>
        /// 알림채널 생성
        /// </summary>
        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel(CHANNEL_ID,
                                                  "FCM Notifications",
                                                  NotificationImportance.Default)
            {

                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        [Service]
        [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
        public class PushFcmMessagingService : FirebaseMessagingService
        {
            //public override void OnMessageReceived(RemoteMessage message)
            //{
            //    //앱이 실행 중인 상태에서 푸시 메시지를 수신했을 때 실행됨
            //    //직접 Local Notification을 띄우거나 원하는 방향으로 처리할 수 있음
            //    string messageFrom = message.From;
            //    string messageString = message.GetNotification().Body;
            //    Log.Debug("PushFirebaseMessagingService", "From: " + messageFrom);
            //    Log.Debug("PushFirebaseMessagingService", "Notification Message Body: " + messageString);

            //}
            public override void OnMessageReceived(RemoteMessage remoteMessage)
            {
                base.OnMessageReceived(remoteMessage);
                var message = remoteMessage.Data["message"];
                Log.Debug("MyFirebaseMessagingService", "From: " + remoteMessage.From);
                Log.Debug("MyFirebaseMessagingService", "Message: " + message);
                //sendNotification(defaultNotificationTitle, message);
                // i just use same title for everything 
            }
        }
    }
}
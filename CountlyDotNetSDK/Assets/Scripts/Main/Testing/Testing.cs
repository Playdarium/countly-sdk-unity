﻿using Assets.Scripts.Models;
using Assets.Scripts.Main.Development;
using UnityEngine;
using Assets.Scripts.Helpers;
using UnityEngine.UI;

namespace Assets.Scripts.Main.Testing
{
    public class Testing : MonoBehaviour
    {
        private static Countly _instance { get; set; }
        public static Countly Instance => _instance ??
            (_instance = new Countly(
                                "https://us-try.count.ly/",
                                Constants.AppKey,
                                Constants.DeviceID));

        private static int x = 0;

        private void Start()
        {
        }

        void Ok_Clicked(string data)
        {
            Countly.Message = data;
        }

        void Cancel_Clicked(string data)
        {
            Countly.Message = Countly.Message + data;
        }

        public void Set()
        {
            LocalNotification.SendNotification(1, 5000, "Title", "Long message text", new Color32(0xff, 0x44, 0x44, 255));
            //Instance.EnablePush();

            //Countly.AllowSendingRequests = true;
            //CountlyUserDetailsModel.Set("Eyes", "Blue");
            //int x = 0;
            //while(x < 100)
            //{
            //    SetOnce();
            //    Save();
            //    Increment();
            //    Save();
            //    IncrementBy();
            //    Save();
            //    Mulitply();
            //    Save();
            //    Max();
            //    Save();
            //    Min();
            //    Save();
            //    Push();
            //    Save();
            //    PushUnique();
            //    Save();
            //    Pull();
            //    Save();

            //    x++;
            //}
        }

        public void SetOnce()
        {
            var inp = GameObject.Find("InputField");
            var tt = inp.GetComponent<InputField>();
            tt.text = Countly.Message + "Hhiii";

            //Instance.ReportView("TestView");
            //CountlyUserDetailsModel.SetOnce("BP", "120/80");
            //Save();
            //await Instance.ChangeDeviceAndEndCurrentSession("d4937c60-04fc-478f-87f6-efd7331b6de8");
        }

        public void Increment()
        {
            
            //LocalNotification.SendNotification(1, 5, "Hey!!", "I'm with Buttons.", new Color32(0x44, 0x44, 0x44, 0x44),
            //true, true, true, null, null, "default",
            //new LocalNotification.Action[]
            //{
            //    new LocalNotification.Action("btn_OK", "OK", this),
            //    new LocalNotification.Action("btn_Cancel", "Cancel", this)
            //});
            //Instance.EnablePush();
            //CountlyUserDetailsModel.Increment("Weight");
        }

        public void IncrementBy()
        {
            CountlyUserDetailsModel.IncrementBy("Height", 1);
        }

        public void Mulitply()
        {
            CountlyUserDetailsModel.Multiply("Weight", 2);
        }

        public void Max()
        {
            CountlyUserDetailsModel.Max("Weight", 85);
        }

        public void Min()
        {
            CountlyUserDetailsModel.Min("Height", 5.5);
        }

        public void Push()
        {
            CountlyUserDetailsModel.Push("Mole", new string[] { "Left Cheek", "Back", "Toe", "Back of the Neck", "Back" });
        }

        public void PushUnique()
        {
            CountlyUserDetailsModel.PushUnique("Mole", new string[] { "Right & Leg", "Right Leg", "Right Leg" });
        }

        public void Pull()
        {
            CountlyUserDetailsModel.Pull("Mole", new string[] { "Right & Leg", "Back" });
        }

        public async void Save()
        {
            await CountlyUserDetailsModel.Save();
        }

        public void Test()
        {
            #region Events
            Countly.EventSendThreshold = 1000;
            while (x < 5)
            {
                Instance.StartEvent("Events_" + x);
                x++;
            }

            #endregion

            #region Device ID



            #endregion

            #region User Details

            //CountlyUserDetailsModel userDetails = null;
            //switch (x)
            //{
            //    case 1:
            //        userDetails = new CountlyUserDetailsModel(null, null, null, null, null, null, null, "https://pbs.twimg.com/profile_images/1442562237/012_n_400x400.jpg", null);
            //        break;
            //    case 2:
            //        userDetails = new CountlyUserDetailsModel(null, null, null, null, null, "https://images.pexels.com/photos/349758/hummingbird-bird-birds-349758.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260", null, null, null);
            //        break;
            //    case 3:
            //        userDetails = new CountlyUserDetailsModel(null, null, null, null, null, "https://images.pexels.com/photos/97533/pexels-photo-97533.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260", null, null, null);
            //        break;
            //    case 4:
            //        userDetails = new CountlyUserDetailsModel(null, null, null, null, null, "http://animals.sandiegozoo.org/sites/default/files/2016-08/category-thumbnail-mammals_0.jpg", null, null, null);
            //        break;
            //    case 5:
            //        userDetails = new CountlyUserDetailsModel(null, null, null, null, null, "https://images.pexels.com/photos/75973/pexels-photo-75973.jpeg?auto=compress&cs=tinysrgb&h=350", null, null, null);
            //        break;
            //    case 6:
            //        userDetails = new CountlyUserDetailsModel(null, null, null, null, null, "https://images.pexels.com/photos/459198/pexels-photo-459198.jpeg?auto=compress&cs=tinysrgb&h=350", null, null, null);
            //        break;

            //}
            //if (userDetails != null)
            //    userDetails.SetUserDetails();

            #endregion
        }
    }
}

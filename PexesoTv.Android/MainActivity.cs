using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Views.InputMethods;
using Android.OS;
using Android.Hardware.Input;
using Android.Util;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using VisualGameController;
using Xamarin.Forms;
using PexesoTv.Models;
using PexesoTv.Common;

namespace PexesoTv.Droid
{
    [Activity(Label = "PexesoTv", Icon = "@mipmap/pexeso", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
  
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            KeyModelEvent keyModelEvent = new KeyModelEvent();
            keyModelEvent.DisplayLabel = e.DisplayLabel.ToString();
            keyModelEvent.KeyCode = (int)e.KeyCode;
            keyModelEvent.KeyPad = ProcessKey(keyCode, e);

            try
            {
                MessagingCenter.Send<KeyModelEvent>(keyModelEvent, "KeyDown");
            }
            catch
            {

            }

            return base.OnKeyDown(keyCode, e);
        }

        private KeyPad ProcessKey(Keycode keyCode, KeyEvent e)
        {
            Console.WriteLine(e.KeyCode);
            if (e.KeyCode == Keycode.Enter)
                return KeyPad.ENTER;

            switch ((int)e.KeyCode)
            {
                case 23:
                    return KeyPad.ENTER;
                case 4:
                    return KeyPad.BACK;
                case 21:
                    return KeyPad.LEFT;
                case 22:
                    return KeyPad.RIGHT;
                case 19:
                    return KeyPad.UP;
                case 20:
                    return KeyPad.DOWN;
            };

            return KeyPad.NONE;
        }

        public override bool OnKeyUp(Keycode keyCode, KeyEvent e)
        {
            return base.OnKeyUp(keyCode, e);
        }

        private bool IsGamepad(InputDevice device)
        {
            if ((device.Sources & InputSourceType.Gamepad) == InputSourceType.Gamepad ||
               (device.Sources & InputSourceType.ClassJoystick) == InputSourceType.Joystick)
            {
                return true;
            }
            return false;
        }


        public void OnInputDeviceChanged(int deviceId)
        {
            Log.Debug("", "OnInputDeviceChanged: " + deviceId);
            //controller_view.Invalidate();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}
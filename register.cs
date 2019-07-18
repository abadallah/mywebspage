using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using App1.Model;
namespace App1
{
    [Activity(Label = "register" ,Theme = "@style/AppTheme", MainLauncher = true)]
    public class register : Activity
    {
        EditText txt_First, txt_Last, txt_email, txt_Pass;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.register);

            string json1 = "";
            AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("koko.json"))) { json1 = sr.ReadToEnd(); }
            @public.conection(json1);

            txt_First = FindViewById<EditText>(Resource.Id.txt_First_Name);
             txt_Last = FindViewById<EditText>(Resource.Id.txt_Last_Name);
             txt_email= FindViewById<EditText>(Resource.Id.txt_email);
             txt_Pass = FindViewById<EditText>(Resource.Id.txt_password);
            var btn_register = FindViewById<Button>(Resource.Id.btn_register);

            btn_register.Click += Btn_register_Click;


        }
        private bool CheckData()
        {
            if (txt_First.Text == "" || txt_Last.Text == "" || txt_email.Text == "" || txt_Pass.Text == "")
            {

                return false;
            }
               

            return true;
        }

        private void Btn_register_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                Acount data = new Acount();

                data.uid = 1;
                data.FName = txt_First.Text;
                data.LName = txt_Last.Text;
                data.Email = txt_email.Text;
                data.Password = txt_Pass.Text;

                data.AddUser();


              //  var intent = new Intent(this, typeof(MainActivity));
               // StartActivity(intent);
            }
        }
    }
}
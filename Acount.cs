using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Google.Cloud.Firestore;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore.V1;
using Grpc.Auth;
using Android.Content.Res;
using System.IO;
using Android.Graphics;

namespace App1.Model
{
   public  class Acount
    {
        public int uid { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        FirestoreDb db = FirestoreDb.Create("fkaha-766ef", @public.client);

        public async void AddUser()
        {
         


            DocumentReference docRef = db.Collection("users").Document(Email);


            Dictionary<string, object> userr = new Dictionary<string, object>
            {
                { "id", uid },
                { "First", FName },
                { "Last", LName },
                { "E-mail", Email },
                { "password",Password }
            };

            await docRef.SetAsync(userr);


        }

        public async Task<Acount> GetUser(string Search_Email)
        {
            Acount user =new Acount();
            //DocumentReference docRef = db.Collection("users").Document("alovelace");
            //DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            //if (snapshot.Exists)
            //{

            //    Dictionary<string, object> city = snapshot.ToDictionary();
            //    foreach (KeyValuePair<string, object> pair in city)
            //    {
            //        Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            //    }

            //    Console.WriteLine("Document data for {0} document:", snapshot.Id);
            //     user = snapshot.ConvertTo<Acount>();

            //}




            Query capitalQuery = db.Collection("usres").WhereEqualTo("id", 1);
            QuerySnapshot capitalQuerySnapshot = await capitalQuery.GetSnapshotAsync();
            foreach (DocumentSnapshot documentSnapshot in capitalQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Console.WriteLine("Document data for {0} document:", documentSnapshot.Id);
                    Dictionary<string, object> city = documentSnapshot.ToDictionary();
                    foreach (KeyValuePair<string, object> pair in city)
                    {
                        Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                    }
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Document {0} does not exist!", documentSnapshot.Id);
                }
            }
            return user;
            

        }


    }

   
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore.V1;
using Grpc.Auth;

namespace App1
{
   public static class @public
    {

        public static FirestoreClient client;

       static  public void conection(string json1)
        {
           
             var credential = GoogleCredential.FromJson(json1).CreateScoped(FirestoreClient.DefaultScopes);


             var channel = new Grpc.Core.Channel(
                                               FirestoreClient.DefaultEndpoint.ToString(),
                                               credential.ToChannelCredentials());

            client= FirestoreClient.Create(channel);
        }

     

    }
}
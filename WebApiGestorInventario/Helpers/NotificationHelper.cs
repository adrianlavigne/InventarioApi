using System;
using System.Collections.Generic;
using System.Web.Configuration;
using WebApiGestorInventario.Models;
using WebPush;

namespace WebApiGestorInventario.Helpers
{
    public static class NotificationHelper
    {

        public static void Notificar(string payload)
        {
            foreach (var suscriptor in GetSuscriptores())
            {
                string vapidPublicKey = WebConfigurationManager.AppSettings["PublicKey"];
                string vapidPrivateKey = WebConfigurationManager.AppSettings["PrivateKey"];
                string subject = WebConfigurationManager.AppSettings["Subject"];

                var pushSubscription = new PushSubscription(suscriptor.PushEndpoint, suscriptor.PushP256DH, suscriptor.PushAuth);
                var vapidDetails = new VapidDetails(subject, vapidPublicKey, vapidPrivateKey);

                var webPushClient = new WebPushClient();
                webPushClient.SendNotification(pushSubscription, payload, vapidDetails);
            }
        }

        private static List<Suscriptor> GetSuscriptores()
        {
            return new List<Suscriptor>();
        }
    }
}
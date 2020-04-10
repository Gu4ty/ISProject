using System;
using ISProject.Models;

namespace ISProject.Utils
{
    public static class NotiApi
    {
        public static void SetSeen(Notification n){
            n.Seen=true;  
           
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace ISProject.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public string SendToUser { get; set; }

        public string Message { get; set; }

        [DataType(DataType.Date)]
        public DateTime NotiDate { get; set; }

        public bool Seen { get; set; }


    }
}
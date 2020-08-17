using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARE_Web_API.Models
{
    public class IReminder
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int RemedyId { get; set; }


        public IReminder()
        { }

        public IReminder(string date, int userId, int remedyId)
        {
            Date = DateTime.Parse(date);
            UserId = userId;
            RemedyId = remedyId;
        }

        public IReminder(int id, string date, int userId, int remedyId)
        {
            Id = id;
            Date = DateTime.Parse(date);
            UserId = userId;
            RemedyId = remedyId;
        }
    }
}

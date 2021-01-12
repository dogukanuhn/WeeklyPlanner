using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Models;

namespace WeeklyPlanner.Application.Models
{
    public class AssignmentDTO
    {
        public AssignmentDTO()
        {
            Priority = 0;
            IsCompleted = false;

        }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Priority { get; set; }
        public int Order { get; set; }
        public bool IsCompleted { get; set; }
        public List<NotifyUser> Notify { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime EndDate { get; set; }

        public string ModifiedBy { get; set; }


    }
}

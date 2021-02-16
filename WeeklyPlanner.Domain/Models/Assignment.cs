using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace WeeklyPlanner.Domain.Models
{
    public class Assignment : BaseModel
    {
        public Assignment()
        {
            IsCompleted = false;
            Priority = 0;
            IsNotified = false;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }

        public List<NotifyUser> Notify { get; set; }
        public bool IsNotified { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime EndDate { get; set; }

        public List<string> LastModifications { get; set; }


    }
    public class NotifyUser
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

    }



}
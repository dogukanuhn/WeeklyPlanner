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
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }
        public List<NotifyUser> MyProperty { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime EndDate { get; set; }


    }
    public class NotifyUser
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

    }



}
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Domain.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            if (Id == ObjectId.Empty)
                Id = ObjectId.GenerateNewId();

            if (Created == null)
            {
                Created = DateTime.Now;
            }

            LastModified = DateTime.Now;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? Created { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? LastModified { get; set; }

    }
}

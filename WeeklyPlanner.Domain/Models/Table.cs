using System.Collections.Generic;

namespace WeeklyPlanner.Domain.Models
{
    public class Table:BaseModel
    {
        public string TableName { get; set; }
        public List<Assignment> Assignments { get; set; }
    }
}
using System.Collections.Generic;

namespace WeeklyPlanner.Domain.Models
{
    public class Table:BaseModel
    {
        public Table()
        {
            Assignments = new List<Assignment>();
        }

        
        public string TableName { get; set; }
        public int Order { get; set; }
        public List<Assignment> Assignments { get; set; }
    }
}
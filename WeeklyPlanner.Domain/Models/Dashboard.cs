using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Domain.Models
{
    public class Dashboard : BaseModel
    {
        public Dashboard(Company company, List<string> tables)
        {
            Company = company;
            Tables = new List<Table>();

            foreach (var item in tables)
            {
                var table = new Table
                {
      
                    TableName = item,
                };
                Tables.Add(table);
            }
        }

        public string Team { get; set; }
        public Company Company { get; set; }
        public List<Table> Tables { get; set; }

    }
}

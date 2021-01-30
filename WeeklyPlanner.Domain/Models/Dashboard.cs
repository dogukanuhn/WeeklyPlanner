using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Domain.Models
{
    public class Dashboard : BaseModel
    {
        public Dashboard(string cName, List<string> tables)
        {
            CompanyName = cName;
            Tables = new List<Table>();

            foreach (var (item, index) in tables.Select((value, i) => (value, i)))
            {
                var table = new Table
                {
                    Order = index,
                    TableName = item,
                };
                Tables.Add(table);
            }
        }


        public string CompanyName { get; set; }
        public List<Table> Tables { get; set; }

    }
}

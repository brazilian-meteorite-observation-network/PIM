using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsClient._Data
{
    public class Trajectory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime Last_Visit { get; set; }
        public string Station { get; set; }
        public string Directory { get; set; }
    }
}

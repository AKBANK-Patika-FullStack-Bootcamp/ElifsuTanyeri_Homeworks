using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class PlaneMaintanance

    {
        public int Id { get; set; }
        public int PlaneId { get; set; }

        public DateTime LastMaintanance { get; set; }

        public string? ModelFamily { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.CORE.Entities.Base;

namespace Simulation.CORE.Entities
{
    public class Features : BaseAudiTableEntity
    {
        public string  Title { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
    }
}

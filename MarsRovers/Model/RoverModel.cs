using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Model
{
    public class RoverModel
    {
        public RoverModel()
        {
            Location = new RoverLocationModel();
        }
        public Guid Id { get; set; }
        public RoverLocationModel Location { get; set; }
    }
}

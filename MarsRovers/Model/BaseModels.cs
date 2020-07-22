using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRovers.Model
{
    public class BaseModels<TModel>
    {
        public BaseModels()
        {
            Errors = new List<string>();
        }
        public bool HasError => Errors.Any();
        public List<string> Errors { get; set; }
        public TModel Data { get; set; }
    }
}

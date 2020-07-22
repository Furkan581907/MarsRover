using MarsRovers.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Services
{
    public interface IPlateauService
    {
        BaseModels<PlateauModel> Create(int width, int height);
        BaseModels<bool> Validate(PlateauModel plateau);
    }
}

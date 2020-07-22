using MarsRovers.Common.Exceptions;
using MarsRovers.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Services.Implementations
{
    public class PlateauService : IPlateauService
    {


        public BaseModels<PlateauModel> Create(int width, int height)
        {
            BaseModels<PlateauModel> model = new BaseModels<PlateauModel>();

            PlateauModel plateauModel = new PlateauModel()
            {
                Width = width,
                Height = height
            };

            BaseModels<bool> validationResponse = Validate(plateauModel);

            if (validationResponse.Data)
            {
                model.Data = plateauModel;
                Console.WriteLine("Plateau created successfully.");

            }

            return model;
        }

        public BaseModels<bool> Validate(PlateauModel plateau)
        {
            BaseModels<bool> model = new BaseModels<bool>();

            if (plateau != null && plateau.Width > 0 && plateau.Height > 0)
            {
                model.Data = true;
                Console.WriteLine($"Plateau has valid size ({plateau.Width}-{plateau.Height}).");
            }
            else
            {
                ValidatePlateauException exception = new ValidatePlateauException();
                Console.WriteLine(exception.Message);
                throw exception;
            }

            return model;
        }
    }
}

using Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class FeesCalculator
    {
        public static void CalculateNormalFees(float vehiclePrice, int vehicleTypeId, out float baseFee, out float specialFee, out float associationFee, out float fixedStorageFee)
        {
            baseFee = (vehiclePrice * 10) / 100;
            specialFee = 0;
            associationFee = 0;
            fixedStorageFee = 100;

            if (vehicleTypeId == (int)VehicleTypeEnum.Common)
            {
                baseFee = baseFee < 10 ? 10 : baseFee > 50 ? 50 : baseFee;
                specialFee = (vehiclePrice * 2) / 100;
            }
            else if (vehicleTypeId == (int)VehicleTypeEnum.Luxury)
            {
                baseFee = baseFee < 25 ? 25 : baseFee > 200 ? 200 : baseFee;
                specialFee = (vehiclePrice * 4) / 100;
            }

            switch (vehiclePrice)
            {
                case float i when i >= 1 && i <= 500:
                    associationFee = 5;
                    break;
                case float i when i > 500 && i <= 1000:
                    associationFee = 10;
                    break;
                case float i when i >= 1000 && i <= 3000:
                    associationFee = 15;
                    break;
                case float i when i >= 3000:
                    associationFee = 20;
                    break;
            }

            //var total = vehiclePrice + baseFee + specialFee + associationFee + fixedStorageFee;
        }
    }
}

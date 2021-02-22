using System;

namespace parking
{

    class Parking {
        float tresholdPrice;
        float priceOverTime;
        int priceMax;
        int tresholdTime;
        int timeMax;

        public Parking(float _tresholdPrice, float _priceOverTime, int _priceMax, int _tresholdTime, int _timeMax) { 
            tresholdPrice = _tresholdPrice;
            priceOverTime = _priceOverTime;
            priceMax = _priceMax;
            tresholdTime = _tresholdTime;
            timeMax = _timeMax;
        }

        public float Pay(int timeSpent) {
            if (timeSpent == timeMax) {
                return priceMax;
            }
            if (timeSpent > timeMax) {
                Console.WriteLine($"Assume that no car can park more than {timeMax} hours");
                return -1f;
            }
            if (timeSpent < tresholdTime) {
                return tresholdPrice;
            }
            float value = (timeSpent - tresholdTime) * priceOverTime + tresholdPrice;
            return value < priceMax ? value : priceMax; 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Parking parking = new Parking(2, 0.5f, 10, 3, 24);
            for (int i = 0; i <= 25; i++)
            {
                Console.WriteLine(i + ": " + parking.Pay(i));
            }
        }
    }
}

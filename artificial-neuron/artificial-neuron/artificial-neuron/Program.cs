using System;

namespace artificial_neuron
{
    class Program
    {
        class Neuron
        {
            private decimal weight = 0.5m;
            public decimal LastError { get; private set; }
            public decimal Smothing { get; set; } = 0.00001m;
            public decimal ProcessInputData(decimal input)
            {
                return input * weight;
            }
            public decimal RestoreInputData(decimal output)
            {
                return output / weight;
            }
            public void Train(decimal input, decimal expectedResult)
            {
                var actualResult = input * weight;
                LastError = expectedResult - actualResult;
                var correction = (LastError / actualResult) * Smothing;
                weight += correction;
            }
        }

        static void Main(string[] args)
        {
            decimal km = 100;
            decimal miles = 62.1371m;

            Neuron neuron = new Neuron();
            int i = 0;
            do
            {
                i++;
                neuron.Train(km, miles);
                Console.WriteLine($"Iteration: {i}\tError:\t{neuron.LastError}");
            } while (neuron.LastError > neuron.Smothing || neuron.LastError <  -neuron.Smothing);

            Console.WriteLine("Training finished");

            Console.WriteLine($"{neuron.ProcessInputData(100)} miless in {100} km");
            Console.WriteLine($"{neuron.ProcessInputData(100)} miless in {100} km");
            Console.WriteLine($"{neuron.ProcessInputData(100)} miless in {100} km");
        }
    }
}

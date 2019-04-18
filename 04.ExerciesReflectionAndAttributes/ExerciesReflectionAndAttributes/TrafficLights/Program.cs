namespace TrafficLights
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            string[] lights = Console.ReadLine().Split();
            int cyclesCount = int.Parse(Console.ReadLine());

            List<TrafficLight> trafficLights = GetTrafficLights(lights);

            for (int curr = 0; curr < cyclesCount; curr++)
            {
                trafficLights.ForEach(tl => tl.ChangeLightColor());

                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }

        private static List<TrafficLight> GetTrafficLights(string[] lights)
        {
            List<TrafficLight> trafficLights = new List<TrafficLight>();

            foreach (string light in lights)
            {
                TrafficLight trafficLight = new TrafficLight(light);

                trafficLights.Add(trafficLight);
            }

            return trafficLights;
        }
    }
}

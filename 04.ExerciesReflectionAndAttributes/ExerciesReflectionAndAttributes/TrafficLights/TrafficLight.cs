namespace TrafficLights
{
    using System;

    public class TrafficLight
    {
        public TrafficLight(string light)
        {
            this.Light = (Light)Enum.Parse(typeof(Light), light);
        }

        public Light Light { get; private set; }

        public void ChangeLightColor()
        {
            this.Light++;

            if((int)this.Light > 2)
            {
                this.Light = Light.Red;
            }
        }

        public override string ToString()
        {
            return this.Light.ToString();
        }
    }
}

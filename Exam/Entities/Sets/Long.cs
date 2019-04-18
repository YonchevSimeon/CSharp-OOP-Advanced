namespace FestivalManager.Entities.Sets
{
    using System;

    public class Long : Set
    {
        private const int Hours = 1;
        private const int Minutes = 0;
        private const int Seconds = 0;

        public Long(string name)
            : base(name, new TimeSpan(Hours, Minutes, Seconds)) { }
    }
}

namespace FestivalManager.Entities.Sets
{
	using System;

	public class Short : Set
	{
        private const int Hours = 0;
        private const int Minutes = 15;
        private const int Seconds = 0;

        public Short(string name)
            : base(name, new TimeSpan(Hours, Minutes, Seconds)) { }
	}
}
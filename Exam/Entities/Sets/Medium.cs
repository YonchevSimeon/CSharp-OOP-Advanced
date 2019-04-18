namespace FestivalManager.Entities.Sets
{
	using System;

	public class Medium : Set
	{
        private const int Hours = 0;
        private const int Minutes = 40;
        private const int Seconds = 0;

        public Medium(string name)
            : base(name, new TimeSpan(Hours, Minutes, Seconds)) { }
	}
}
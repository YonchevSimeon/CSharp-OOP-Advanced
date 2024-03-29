﻿namespace FestivalManager.Entities.Sets
{
	using System;
	using System.Linq;
	using System.Text;
    using System.Collections.Generic;

    using Core.Constants;
    using Contracts;

	public abstract class Set : ISet
	{
		private readonly List<IPerformer> performers;
		private readonly List<ISong> songs;

		protected Set(string name, TimeSpan maxDuration)
		{
			this.Name = name;
			this.MaxDuration = maxDuration;

			this.performers = new List<IPerformer>();
			this.songs = new List<ISong>();
		}

		public string Name { get; private set; }

		public TimeSpan MaxDuration { get; private set; }

		public TimeSpan ActualDuration => new TimeSpan(this.Songs.Sum(s => s.Duration.Ticks));

        public IReadOnlyCollection<IPerformer> Performers => this.performers;

        public IReadOnlyCollection<ISong> Songs => this.songs;

		public void AddPerformer(IPerformer performer) => this.performers.Add(performer);

		public void AddSong(ISong song)
		{
			if (song.Duration + this.ActualDuration > this.MaxDuration)
			{
				throw new InvalidOperationException(ConstantMessages.SongIsOverTheSetLimit);
			}

			this.songs.Add(song);
		}

		public bool CanPerform()
		{
			if (this.Performers.Count < 1)
			{
				return false;
			}

			if (this.Songs.Count < 1)
			{
				return false;
			}

            var allPerformersHaveFunctioningInstruments = this.performers.All(p => p.Instruments.Any(i => !i.IsBroken));

            if (!allPerformersHaveFunctioningInstruments)
			{
				return false;
			}

			return true;
		}

		public override string ToString()
		{
			var sb = new StringBuilder();

			sb.AppendLine(string.Join(", ", this.Performers));

			foreach (var song in this.Songs)
			{
				sb.AppendLine($"-- {song}");
			}

			var result = sb.ToString();
			return result;
		}
	}
}

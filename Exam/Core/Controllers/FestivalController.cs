namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Linq;
    using System.Collections.Generic;

    using Entities;
    using Constants;
	using Contracts;
	using Entities.Contracts;
    using Entities.Factories;
    using Entities.Factories.Contracts;
    using System.Text;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";

		private readonly IStage stage;
        private readonly ISetFactory setFactory;
        private readonly IInstrumentFactory instrumentFactory;

		public FestivalController(IStage stage)
		{
            this.setFactory = new SetFactory();
            this.instrumentFactory = new InstrumentFactory();

			this.stage = stage;
		}

		public string RegisterSet(string[] args)
		{
            string name = args[0];
            string type = args[1];

            ISet set = this.setFactory.CreateSet(name, type);

            this.stage.AddSet(set);

            return string.Format(ConstantMessages.AddedNewSet, type);
		}

		public string SignUpPerformer(string[] args)
		{
            string name = args[0];
            int age = int.Parse(args[1]);

            IPerformer performer = new Performer(name, age);

            for (int i = 2; i < args.Length; i++)
            {
                IInstrument instrument = this.instrumentFactory.CreateInstrument(args[i]);

                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return string.Format(ConstantMessages.AddedPerformerToStage, performer.Name);
		}

		public string RegisterSong(string[] args)
		{
            string name = args[0];

            string[] durationArgs = args[1].Split(':');

            int minutes = int.Parse(durationArgs[0]);
            int seconds = int.Parse(durationArgs[1]);

            ISong song = new Song(name, new TimeSpan(0, minutes, seconds));

            this.stage.AddSong(song);

            return string.Format(ConstantMessages.AddingSong, song.ToString());
		}
        
		public string AddPerformerToSet(string[] args)
		{
            string performerName = args[0];
            string setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException(ConstantMessages.InvalidPerformerProvided);
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(ConstantMessages.InvalidSetProvided);
            }

            IPerformer performer = this.stage.GetPerformer(performerName);
            ISet set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return string.Format(ConstantMessages.AddedPerformerToSet, performerName, setName);
		}

		public string RepairInstruments(string[] args)
		{
            IInstrument[] instrumentsToRepair = this.stage.Performers.SelectMany(s => s.Instruments).ToArray();

            int counter = 0;

            foreach (var item in instrumentsToRepair)
            {
                if(item.Wear < 100)
                {
                    counter++;
                    item.Repair();
                }
            }
            
            return string.Format(ConstantMessages.RepairedInstruments, counter);
		}

        public string ProduceReport()
        {
            StringBuilder sb = new StringBuilder();

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            sb.AppendLine("Results:");
            sb.AppendLine($"Festival length: {FormatTime(totalFestivalLength)}");

            foreach (var set in this.stage.Sets)
            {
                sb.AppendLine($"--{set.Name} ({FormatTime(set.ActualDuration)}):");

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    sb.AppendLine($"---{performer.Name} ({instruments})");
                }

                if (!set.Songs.Any())
                    sb.AppendLine("--No songs played");
                else
                {
                    sb.AppendLine("--Songs played:");
                    foreach (var song in set.Songs)
                    {
                        sb.AppendLine($"----{song.Name} ({song.Duration.ToString(TimeFormat)})");
                    }
                }
            }

            return sb.ToString().Trim();
        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(ConstantMessages.InvalidSetProvided);
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException(ConstantMessages.InvalidSongProvided);
            }

            ISong song = this.stage.GetSong(songName);
            ISet set = this.stage.GetSet(setName);

            set.AddSong(song);

            return string.Format(ConstantMessages.AddedSongToSet,
                song.ToString(), set.Name);
        }

        private string FormatTime(TimeSpan time)
        {
            int minutes = time.Minutes + (time.Hours * 60);
            int seconds = time.Seconds;

            return $"{minutes:d2}:{seconds:d2}";
        }
    }
}
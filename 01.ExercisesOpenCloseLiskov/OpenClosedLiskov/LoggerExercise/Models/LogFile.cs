namespace LoggerExercise.Models
{
    using LoggerExercise.Contracts;
    using System.IO;
    using System.Linq;
    using System;

    public class LogFile : ILogFile
    {
        const string DEFAULT_PATH = "./WrittenFiles/";
        //const string ALPHABET = "abcdefghijklmnopqrstuvwxyz";

        public LogFile(string fileName)
        {
            this.Path = DEFAULT_PATH + fileName;
            this.Size = 0;
        }

        public string Path { get; }

        public int Size { get; private set; }

        public void Write(string error)
        {
            File.AppendAllText(this.Path, error + Environment.NewLine);
            this.Size += error.Where(c => Char.IsLetter(c)).Select(c => (int)c).Sum();
            //foreach (char c in error)
            //{
            //    if(Char.IsLetter(c))
            //    {
            //        this.Size += (int)c;
            //    }
            //}
        }
    }
}

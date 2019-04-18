namespace Froggy
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Lake<T> : IEnumerable<T>
    {
        public Lake(params T[] stones)
        {
            this.Stones = stones;
        }

        public IList<T> Stones { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            for (int index = 0; index < this.Stones.Count; index += 2)
                yield return this.Stones[index];


            int reverseIndex = this.Stones.Count % 2 != 0 ? this.Stones.Count - 2 : this.Stones.Count - 1;

            for (int indexR = reverseIndex; indexR >= 1; indexR -= 2)
                yield return this.Stones[indexR];
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}

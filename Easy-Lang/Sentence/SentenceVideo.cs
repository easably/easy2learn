using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class SentenceVideo : Sentence
    {
        public double Start { get; private set; }
        public double End { get; private set; }
        public double Length { get; private set; }

        public SentenceVideo(string text, List<Sentence> parentList, double start, double end)
            : base(text, parentList)
        {
            this.Start = start;
            this.End = end;
            this.Length = SentenceParser.DefaultSubtitleLength; // by default
            //if (this.Start > End)
            //    this.End = this.Start + 1;
        }

        public void SetLength(double startTime, double newLength)
        {
            this.Start = startTime;
            this.Length = newLength;
            this.End = startTime + newLength;
        }


        internal void InitLength(double length)
        {
            this.Length = Math.Round(length, 3);
            //System.Diagnostics.Debug.Assert(this.Length > 0);
            if (this.Length <= 0)
                return;
        }
    }
}
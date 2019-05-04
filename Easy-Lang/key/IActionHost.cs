using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace f
{
    public interface IActionPlayerHost
    {
        void RePlay();
        void PlayNext();
        void PlayPrev();
        void Play();
        void Pause();
    }
}

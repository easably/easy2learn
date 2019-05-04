using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public interface IScoreUnit
    {
        // if ScoreData was not assigned then Score will be created on call getter of this property
        string ID { get; }
        ScoreData ScoreData { get; }
        /// <summary>scoreData создали из сериализации</summary>
        void SetScoreData(ScoreData scoreData);
        void ClearScoreData();
        bool IsHaveScore { get; }
    }

    //public interface IScoreUnit
    //{
    //    public ScoreState GetScoreStatus();

    //    public int Number { get; set; }
    //    public int Passed { get; set; }
    //    public int Hints { get; set; }
    //    public int Errors { get; set; }
    //    public bool IsGuessed { get; set; }

    //    protected void OnStateChange();

    //    public event EventHandler StateChange;
    //}
}

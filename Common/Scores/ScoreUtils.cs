using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace f
{
    public static class ScoreUtils
    {
        #region GetScoreState
        public static void GetScoreState(ScoreData unit, bool strongRule)
        {
            ScoreState state = ScoreState.Unknown;
            // common rule
            if (unit.CurPasses == 0 && unit.CurErrors == 0)
            {
                state = ScoreState.Unknown;
            }
            // diveded by strongRule and not strong rule
            else
            {
                if (strongRule)
                {
                    if (unit.CurErrors > 0) state = ScoreState.HasError;
                    else if (unit.CurHints > 0) state = ScoreState.Warning;
                    // passed
                    else
                    {
                        if (unit.PrevState == ScoreState.HasError)
                            state = ScoreState.Warning;
                        else
                            state = ScoreState.Complete;
                    }
                }
                else
                {
                    //if (!unit.IsGuessed) return ScoreState.Unknown;
                    //else 
                    if (unit.CurErrors > 0)
                    {
                        int allCount = unit.CurPasses + unit.CurHints + unit.CurErrors;
                        if (allCount > 10 && IsManyLettersAndFewErrors(unit))
                            state = ScoreState.Warning;
                        else
                            state = ScoreState.HasError;
                    }
                    else if (unit.CurHints > 0)
                    {
                        if (unit.PrevState == ScoreState.HasError)
                        {
                            if (unit.CurPasses == 0)
                                state = ScoreState.HasError;
                            else state = ScoreState.Warning;
                        }
                        else state = ScoreState.Warning;
                    }
                    else if (unit.CurPasses > 0) //&& unit.IsGuessed)
                    {
                        if (unit.PrevState == ScoreState.HasError)
                            state = ScoreState.Warning;
                        else // ScoreState.Complete or Unknown
                            state = ScoreState.Complete;
                    }
                }
            }
            unit.PrevState = state;
        }

        static bool IsManyLettersAndFewErrors(ScoreData unit)
        {
            if (unit.CurErrors == 1)
                return unit.CurPasses > 9 && unit.CurHints < 1; 
            else if (unit.CurErrors == 2)
                return unit.CurPasses > 15 && unit.CurHints < 2;
            else return false;
        } 
        #endregion

        #region SetStateForControl
        //public static void SetStateForControl(ScoreProgress control, ScoreData data, int maxCount)
        //{
        //    try
        //    {
        //        control.BeginUpdate();
        //        control.Errors = data.CurErrors + data.PrevErrors;
        //        control.Hints = data.CurHints + data.PrevHints;
        //        control.Passes = data.CurPasses + data.PrevPasses;
        //        control.Maximum = maxCount + data.PrevErrors + data.PrevHints + data.PrevPasses;
        //    }
        //    finally
        //    {
        //        control.EndUpdate();
        //    }
        //}
        //public static void SetStateForControl(ScoreProgress control, ScoreData data)
        //{
        //    try
        //    {
        //        control.BeginUpdate();
        //        control.Errors = data.CurErrors + data.PrevErrors;
        //        control.Hints = data.CurHints + data.PrevHints;
        //        control.Passes = data.CurPasses + data.PrevPasses;
        //        control.GetDefaultMaximum();
        //    }
        //    finally
        //    {
        //        control.EndUpdate();
        //    }
        //}

        public static ScoreData GetScoreData(IEnumerable<IScoreUnit> units)
        {
            int unitCount = 0;
            List<ScoreData> scores = GetScores(units, ref unitCount);
            ScoreData scoreData = new ScoreData("Global score", ScoreState.Unknown, unitCount);

            int p, h, e;
            p = h = e = 0;
            foreach (ScoreData state in scores)
            {
                if (state.PrevState == ScoreState.HasError) ++e;
                else if (state.PrevState == ScoreState.Warning) ++h;
                else if (state.PrevState == ScoreState.Complete) ++p;
            }
            scoreData.PrevErrors = e;
            scoreData.PrevHints = h;
            scoreData.PrevPasses = p;
            return scoreData;
        }        

        public static void SetStateForControl(ScoreProgress control, IEnumerable<IScoreUnit> units)
        {
            int unitCount = 0;
            List<ScoreData> scores = GetScores(units, ref unitCount);
            if (scores.Count == 0)
            {
                control.ResetProgress();
                return;
            }
            try
            {
                control.BeginUpdate();
                int p, h, e;
                p = h = e = 0;
                foreach (ScoreData scoreData in scores)
                {
                    if (scoreData.IsContainsCurrent)
                    {
                        if (scoreData.PrevState == ScoreState.HasError) ++e;
                        else if (scoreData.PrevState == ScoreState.Warning) ++h;
                        else if (scoreData.PrevState == ScoreState.Complete) ++p;
                    }
                }
                control.ScoreData.CurErrors = e;
                control.ScoreData.CurHints = h;
                control.ScoreData.CurPasses = p;
                //control.Maximum = unitCount;

                //TODO: здесь может быть делать прогресс по максимумму большим ??!!
                //control.Maximum = p + h + e;
                //control.Maximum = scores.Count;
                //control.GetDefaultMaximum();
            }
            finally
            {
                control.EndUpdate();
            }
        }        
        #endregion

        #region XmlSerialization
        readonly static string extForScore = ".scores";
        //bool IsHaveLessonFile { get { return !string.IsNullOrEmpty(this.LessonFileName); } }

        static string GetFileNameForScore(string fileName)
        {
            //TODO: взять текущий католог
            return fileName + extForScore;
        }

        public static void ClearScore(string fileName)
        {
            string _fileName = GetFileNameForScore(fileName);
            File.Exists(_fileName);
            File.Delete(_fileName);
        }

        public static void SaveScore(IEnumerable<IScoreUnit> units, string fileName)
        {
            int foo = 0;
            List<ScoreData> scores = GetScores(units, ref foo);
            if (scores.Count == 0) return;
            foreach (ScoreData score in scores)
            {
                score.PrevErrors += score.CurErrors; score.CurErrors = 0;
                score.PrevHints += score.CurHints; score.CurHints = 0;
                score.PrevPasses += score.CurPasses; score.CurPasses = 0;
            }

            try
            {

                XmlSerializer serializer = new XmlSerializer(typeof(List<ScoreData>));
                using (TextWriter WriteFileStream = new StreamWriter(GetFileNameForScore(fileName)))
                {
                    serializer.Serialize(WriteFileStream, scores);
                }
            }
            catch(Exception ex)
            {
                string message = "There was an error saving score result" + Environment.NewLine + 
                    "Error Message: " + Environment.NewLine + ex.Message;
                MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static List<ScoreData> GetScores(IEnumerable<IScoreUnit> units, ref int unitCount)
        {
            List<ScoreData> scores = new List<ScoreData>();
            foreach (IScoreUnit unit in units)
            {
                ++unitCount;
                if (unit.IsHaveScore)
                    if (!unit.ScoreData.IsEmpty)
                        scores.Add(unit.ScoreData);
            }
            return scores;
        }

        public static void AssignScore(string fileName, IEnumerable<IScoreUnit> units)
        {
            List<ScoreData> _scores = new List<ScoreData>();
            // if (!IsHaveLessonFile) return;
            if (!File.Exists(GetFileNameForScore(fileName))) return;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<ScoreData>));
                using (FileStream ReadFileStream = new FileStream(GetFileNameForScore(fileName), FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    _scores = (List<ScoreData>)serializer.Deserialize(ReadFileStream);
                    foreach (ScoreData score in _scores)
                    {
                        foreach (IScoreUnit unit in units)
                        {
                            if (unit.ID == score.ID)
                            {
                                unit.SetScoreData(score);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "Score results from previous sessions were not downloaded. " + Environment.NewLine +
                    "Error Message: " + Environment.NewLine + ex.Message;
                MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return;
        } 
        #endregion
    }
}

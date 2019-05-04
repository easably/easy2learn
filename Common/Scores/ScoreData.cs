using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace f
{
    [Serializable()]
    // statistic
    public class ScoreData //: ISerializable
    {
        string m_ID;

        public ScoreData()
        { }

        public ScoreData(string id, ScoreState scoreState, int maxScrore)
        {
            this.m_ID = id;
            this.PrevState = scoreState;
            this.m_MaxScrore = maxScrore;
        }

        /// <summary>
        /// Sentence Number
        /// </summary>
        public string ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        //[NonSerialized]
        public ScoreState PrevState
        {
            get { return (ScoreState)StateValue; }
            set { StateValue = (int)value; }        
        }

        int StateValue = (int)ScoreState.Unknown;
        // counters after completion guessing
        public int PrevPasses = 0;
        public int PrevHints = 0;
        public int PrevErrors = 0;

        ////public ScoreState CurState;
        //[NonSerialized]
        //public bool IsGuessed;

        [NonSerialized()]
        int m_MaxScrore = 0;
        public int MaxScrore { get { return m_MaxScrore; } set { m_MaxScrore = value; OnStateChange(); } }

        public bool IsContainsCurrent{ get { return CurPasses > 0 || CurHints > 0 || CurErrors > 0;} }

        [NonSerialized()]
        int m_Passes = 0;
        public int CurPasses { get { return m_Passes; } set { m_Passes = value; OnStateChange(); } }

        [NonSerialized()]
        int m_Hints = 0;
        public int CurHints { get { return m_Hints; } set { m_Hints = value; OnStateChange(); } }

   //     [NonSerialized()]
        int m_Errors = 0;
        public int CurErrors { get { return m_Errors; } set { m_Errors = value; OnStateChange(); } }

        void OnStateChange()
        {
            if (StateChange != null)
                StateChange.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler StateChange;

        public bool IsEmpty { 
            get { return this.CurPasses==0 && this.CurHints==0 && this.CurErrors==0 
                && this.PrevState == ScoreState.Unknown; } 
        }

        #region ISerializable Members
        //public Score(SerializationInfo info, StreamingContext ctxt)
        //{
        //    this.State = (ScoreState)info.GetValue("State", typeof(ScoreState));
        //    this.m_SentenceNumber = (int)info.GetValue("SentenceNumber", typeof(int));
        //}

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //  info.AddValue("State", this.State);
        //  info.AddValue("SentenceNumber", this.SentenceNumber);
        //}
        #endregion
    }

//    [Serializable()]
//    public class ScoreContainer : ISerializable
//    {
//        private List<Score> scores;

//        public List<Score> Scores
//        {
//            get { return this.scores; }
//            set { this.scores = value; }
//        }

//        public ScoreContainer()
//        {
//        }

//        //public ScoreContainer(SerializationInfo info, StreamingContext ctxt)
//        //{
//        //    this.scores = (List<Score>)info.GetValue("Scores", typeof(List<Score>));
//        //}

//        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
//        {
//            info.AddValue("Scores", this.scores);
//        }
//    }

//    public class Serializer
//    {
//        public Serializer()
//        {
//        }

//        public void SerializeObject(string filename, ScoreContainer objectToSerialize)
//        {
//            Stream stream = File.Open(filename, FileMode.Create);
//            BinaryFormatter bFormatter = new BinaryFormatter();
////            BinaryFormatter bFormatter = new BinaryFormatter();
//            bFormatter.Serialize(stream, objectToSerialize);
//            stream.Close();
//        }

//        public ScoreContainer DeSerializeObject(string filename)
//        {
//            ScoreContainer objectToSerialize;
//            Stream stream = File.Open(filename, FileMode.Open);
////            BinaryFormatter bFormatter = new BinaryFormatter();
//            BinaryFormatter bFormatter = new BinaryFormatter();
//            objectToSerialize = (ScoreContainer)bFormatter.Deserialize(stream);
//            stream.Close();
//            return objectToSerialize;
//        }
//    }


}

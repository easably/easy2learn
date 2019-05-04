using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace f
{
    public class Watcher : IDisposable
    {
        static List<Watcher> m_CallTree;

        static List<Watcher> CallTree
        {
            get { 
                if (m_CallTree == null) m_CallTree = new List<Watcher>();
                return m_CallTree;
            }
        }

        static void IncrementDeepCounter(Watcher watcher)
        {
            CallTree.Add(watcher);
        }

        Stopwatch m_Stopwatch = new Stopwatch();
        string m_text;
        string DeepLevel = "→";
        bool isWriteTagForParent = false;

        public Watcher(string text)
        {
            m_Stopwatch = new Stopwatch();
            m_Stopwatch.Start();
            m_text = text;
            for (int i = 0; i < CallTree.Count; ++i)
                DeepLevel += "→| ";
            if(CallTree.Count > 0)
                CallTree[CallTree.Count-1].WriteTagForParent();
            IncrementDeepCounter(this);
        }

        public void WriteTagForParent()
        {
            if (!isWriteTagForParent)
            {
                Console.WriteLine("{0} {1} → ↓ ", DeepLevel, m_text);
                isWriteTagForParent = true;
            }
        }

        public void Dispose()
        {
            m_Stopwatch.Stop();
            Console.WriteLine("{0} {1} : {2}", DeepLevel, m_text, m_Stopwatch.ElapsedMilliseconds);
            CallTree.Remove(this);
        }
    }
}

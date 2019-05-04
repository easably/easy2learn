using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace f
{
    class I : Hashtable
    {
        public override void Add(object key, object value)
        {
            if (base.Contains(key)) return;
            if (this.Count == MaxCount)
            {
                this.Remove(this.queue[0]);
                this.queue.Remove(this.queue[0]);
            }
            base.Add(key, value);
            queue.Add(key);
        }

        private uint m_MaxCount = 1000;
        ArrayList queue = new ArrayList();

        public uint MaxCount
        {
            get { return m_MaxCount; }
            set
            {
                m_MaxCount = value;
                while (queue.Count > m_MaxCount)
                    queue.Remove(queue[0]);
            }
        }

    }
}
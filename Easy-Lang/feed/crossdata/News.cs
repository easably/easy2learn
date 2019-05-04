using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class News
    {
        public News(string title, string description, string imgSrc, string videoSrc)
        {
            m_Title = title;
            m_Description = description;
            m_ImgSrc = imgSrc;
            m_VideoSrc = videoSrc;
        }

        public News(string title, string description, string imgSrc, string videoSrc, string htmlContent)
            : this(title, description, imgSrc, videoSrc)
        {
            m_HTMLContent = htmlContent;
        }

        string m_Title;
        public string Title { get { return m_Title; } }

        string m_Description;
        public string Description { get { return m_Description; } }

        string m_ImgSrc;
        public string ImgSrc { get { return m_ImgSrc; } }

        string m_VideoSrc;
        public string VideoSrc { get { return m_VideoSrc; } set { m_VideoSrc = value; } }

        string m_HTMLContent;
        public string HTMLContent { get { return m_HTMLContent; } }

        long m_AllLength = -1;
        public long AllLength { get { return m_AllLength; } set { m_AllLength = value; } }

        public long LengthForFirstSentence { get; set; }

        public string URL { get; set; }
    }
}

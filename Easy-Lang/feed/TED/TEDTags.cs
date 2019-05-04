using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace f
{
    public class TEDTags : DictionaryProvider
    {
       // public const string url = @"http://www.ted.com/talks/tags";
        public const string url = @"http://www.ted.com/topics";
        public const string urlTEDRoot = @"http://www.ted.com";

        WebParser m_Parser;
        public static string dlm = " ## ";
        public string JsSelector = WebParser.LoadResourceText("_4win.ted_topics.js");

        //public override string GetContent(string word, string codeForm, string codeTo)
        //{
        //    string contentFull = base.GetContent(word, codeForm, codeTo);
        //    FillTags(contentFull);
        //    return contentFull;
        //}

        public void FillTags()
        {
            string content = this.GetContent("empty", "", "");
            FillTags(content);
        }

        public void FillTags(string content)
        {
            m_Parser = new WebParser();
            m_Parser.LoadAndParse(content, this.JsSelector);
            if (!string.IsNullOrEmpty(m_Parser.Result))
            {
                string[] topics = m_Parser.Result.Split(new string[] { dlm + dlm }, StringSplitOptions.RemoveEmptyEntries);
                FillList(topics);
            }
            // TODO: только что делать непонятно когда нета нет
            //else throw new ApplicationException("Data from sever was not parsed");
            // поэтому заполним фейковыми данными
            else
            {
                string[] fakeData = new string[] { @"Activism (54);http://www.ted.com/topics/activism", @"Adventure (22);http://www.ted.com/topics/adventure", "Advertising (8);http://www.ted.com/topics/advertising", "Africa (72);http://www.ted.com/topics/Africa", "Aging (13);http://www.ted.com/topics/aging", "Agriculture (16);http://www.ted.com/topics/agriculture", "AI (5);http://www.ted.com/topics/AI", "AIDS (12);http://www.ted.com/topics/AIDS", "Aircraft (3);http://www.ted.com/topics/aircraft", "Algorithm (4);http://www.ted.com/topics/algorithm", "Alternative energy (23);http://www.ted.com/topics/alternative+energy", "Animals (63);http://www.ted.com/topics/animals", "Anthropology (11);http://www.ted.com/topics/anthropology", "Antidepressants (3);http://www.ted.com/topics/antidepressants", "Ants (2);http://www.ted.com/topics/ants", "Apes (3);http://www.ted.com/topics/apes", "Architecture (55);http://www.ted.com/topics/architecture", "Art (115);http://www.ted.com/topics/art", "Arts (182);http://www.ted.com/topics/arts", "Asia (12);http://www.ted.com/topics/Asia", "Astronomy (26);http://www.ted.com/topics/astronomy", "Atheism (4);http://www.ted.com/topics/atheism", "Bacteria (3);http://www.ted.com/topics/bacteria", "Beauty (20);http://www.ted.com/topics/beauty", "Bee (1);http://www.ted.com/topics/bee", "Behavioral economics (7);http://www.ted.com/topics/behavioral+economics", "Big bang (4);http://www.ted.com/topics/big+bang", "Biodiversity (29);http://www.ted.com/topics/biodiversity", "Biology (100);http://www.ted.com/topics/biology", "Biomechanics (8);http://www.ted.com/topics/biomechanics", "Biomimicry (7);http://www.ted.com/topics/biomimicry", "Biosphere (13);http://www.ted.com/topics/biosphere", "Biotech (20);http://www.ted.com/topics/biotech", "Birds (8);http://www.ted.com/topics/birds", "Blog (3);http://www.ted.com/topics/blog", "Book (28);http://www.ted.com/topics/book", "Botany (3);http://www.ted.com/topics/botany", "Bottom-up (4);http://www.ted.com/topics/bottom-up", "Brain (91);http://www.ted.com/topics/brain", "Buddhism (6);http://www.ted.com/topics/Buddhism", "Bullseye (1);http://www.ted.com/topics/bullseye", "Business (262);http://www.ted.com/topics/business", "Cancer (19);http://www.ted.com/topics/cancer", "Cars (16);http://www.ted.com/topics/cars", "Cello (3);http://www.ted.com/topics/cello", "Charter for compassion (8);http://www.ted.com/topics/charter+for+compassion", "Chautauqua (3);http://www.ted.com/topics/chautauqua", "Chemistry (11);http://www.ted.com/topics/chemistry", "Children (77);http://www.ted.com/topics/children", "China (15);http://www.ted.com/topics/china", "Choice (15);http://www.ted.com/topics/choice", "Christianity (3);http://www.ted.com/topics/Christianity", "Cities (87);http://www.ted.com/topics/cities", "Climate change (31);http://www.ted.com/topics/climate+change", "Cognitive science (15);http://www.ted.com/topics/cognitive+science", "Collaboration (67);http://www.ted.com/topics/collaboration", "Comedy (23);http://www.ted.com/topics/comedy", "Communication (48);http://www.ted.com/topics/communication", "Community (37);http://www.ted.com/topics/community", "Compassion (13);http://www.ted.com/topics/compassion", "Complexity (15);http://www.ted.com/topics/complexity", "Composing (3);http://www.ted.com/topics/composing", "Computers (53);http://www.ted.com/topics/computers", "Consciousness (12);http://www.ted.com/topics/consciousness", "Consumerism (12);http://www.ted.com/topics/consumerism", "Cooperation (5);http://www.ted.com/topics/cooperation", "Corruption (13);http://www.ted.com/topics/corruption", "Cosmos (7);http://www.ted.com/topics/cosmos", "Creativity (113);http://www.ted.com/topics/creativity", "Crime (22);http://www.ted.com/topics/crime", "Culture (432);http://www.ted.com/topics/culture", "Curiosity (5);http://www.ted.com/topics/curiosity", "Cyborg (2);http://www.ted.com/topics/cyborg", "Dance (19);http://www.ted.com/topics/dance", "Data (35);http://www.ted.com/topics/data", "Death (15);http://www.ted.com/topics/death", "Debate (1);http://www.ted.com/topics/Debate", "Deextinction (7);http://www.ted.com/topics/deextinction", "Demo (34);http://www.ted.com/topics/demo", "Depression (3);http://www.ted.com/topics/depression", "Design (319);http://www.ted.com/topics/design", "Development (41);http://www.ted.com/topics/development", "Disability (12);http://www.ted.com/topics/disability", "Disaster relief (18);http://www.ted.com/topics/disaster+relief", "Disease (30);http://www.ted.com/topics/disease", "DNA (14);http://www.ted.com/topics/DNA", "Drones (14);http://www.ted.com/topics/drones", "Economics (97);http://www.ted.com/topics/economics", "Education (145);http://www.ted.com/topics/education", "Empathy (2);http://www.ted.com/topics/empathy", "Energy (37);http://www.ted.com/topics/energy", "Engineering (39);http://www.ted.com/topics/engineering", "Entertainment (268);http://www.ted.com/topics/entertainment", "Entrepreneur (35);http://www.ted.com/topics/entrepreneur", "Environment (72);http://www.ted.com/topics/environment", "Epidemiology (3);http://www.ted.com/topics/epidemiology", "Evil (2);http://www.ted.com/topics/evil", "Evolution (47);http://www.ted.com/topics/evolution", "Exploration (46);http://www.ted.com/topics/exploration", "Extreme sports (4);http://www.ted.com/topics/extreme+sports", "Failure (5);http://www.ted.com/topics/failure", "Faith (14);http://www.ted.com/topics/faith", "Fashion (3);http://www.ted.com/topics/fashion", "Featured (23);http://www.ted.com/topics/Featured", "Feminism (2);http://www.ted.com/topics/feminism", "Film (41);http://www.ted.com/topics/film", "Finance (6);http://www.ted.com/topics/finance", "Fish (16);http://www.ted.com/topics/fish", "Flight (9);http://www.ted.com/topics/flight", "Food (43);http://www.ted.com/topics/food", "Foreign Policy (4);http://www.ted.com/topics/Foreign+Policy", "Future (44);http://www.ted.com/topics/future", "Gaming (24);http://www.ted.com/topics/gaming", "Gender (9);http://www.ted.com/topics/gender", "Genetics (20);http://www.ted.com/topics/genetics", "Geology (2);http://www.ted.com/topics/geology", "Glacier (2);http://www.ted.com/topics/glacier", "Global issues (384);http://www.ted.com/topics/global+issues", "God (12);http://www.ted.com/topics/God", "Google (7);http://www.ted.com/topics/Google", "Government (25);http://www.ted.com/topics/government", "Green (49);http://www.ted.com/topics/green", "Guitar (11);http://www.ted.com/topics/guitar", "Hack (6);http://www.ted.com/topics/hack", "Haiti (1);http://www.ted.com/topics/haiti", "Happiness (51);http://www.ted.com/topics/happiness", "Health (110);http://www.ted.com/topics/health", "Health care (71);http://www.ted.com/topics/health+care", "Heroism (4);http://www.ted.com/topics/heroism", "History (67);http://www.ted.com/topics/history", "Human origins (4);http://www.ted.com/topics/human+origins", "Humanity (30);http://www.ted.com/topics/humanity", "Humor (60);http://www.ted.com/topics/humor", "Illness (10);http://www.ted.com/topics/illness", "Illusion (15);http://www.ted.com/topics/illusion", "Industrial design (13);http://www.ted.com/topics/industrial+design", "Inequality (17);http://www.ted.com/topics/inequality", "Innovation (50);http://www.ted.com/topics/innovation", "Insects (20);http://www.ted.com/topics/insects", "Intelligence (10);http://www.ted.com/topics/intelligence", "Interface design (17);http://www.ted.com/topics/interface+design", "Internet (39);http://www.ted.com/topics/Internet", "Interview (6);http://www.ted.com/topics/interview", "Invention (77);http://www.ted.com/topics/invention", "Investment (15);http://www.ted.com/topics/investment", "Iran (4);http://www.ted.com/topics/Iran", "Iraq (8);http://www.ted.com/topics/iraq", "Islam (5);http://www.ted.com/topics/Islam", "Jazz (2);http://www.ted.com/topics/jazz", "Journalism (18);http://www.ted.com/topics/journalism", "Language (30);http://www.ted.com/topics/language", "Law (29);http://www.ted.com/topics/law", "Leadership (23);http://www.ted.com/topics/leadership", "Learning (1);http://www.ted.com/topics/learning", "LGBT (5);http://www.ted.com/topics/LGBT", "Library (10);http://www.ted.com/topics/library", "Life (51);http://www.ted.com/topics/life", "Literature (13);http://www.ted.com/topics/literature", "Live music (44);http://www.ted.com/topics/live+music", "Love (21);http://www.ted.com/topics/love", "MacArthur grant (12);http://www.ted.com/topics/MacArthur+grant", "Magic (13);http://www.ted.com/topics/magic", "Map (10);http://www.ted.com/topics/map", "Marketing (16);http://www.ted.com/topics/marketing", "Materials (14);http://www.ted.com/topics/materials", "Math (36);http://www.ted.com/topics/math", "Media (45);http://www.ted.com/topics/media", "Medical research (19);http://www.ted.com/topics/medical+research", "Medicine (92);http://www.ted.com/topics/medicine", "Meditation (1);http://www.ted.com/topics/meditation", "Meme (5);http://www.ted.com/topics/meme", "Memory (14);http://www.ted.com/topics/memory", "Men (5);http://www.ted.com/topics/men", "Mental health (18);http://www.ted.com/topics/mental+health", "Microbiology (10);http://www.ted.com/topics/microbiology", "Microfinance (2);http://www.ted.com/topics/microfinance", "Microsoft (2);http://www.ted.com/topics/microsoft", "Middle East (11);http://www.ted.com/topics/Middle+East", "Military (10);http://www.ted.com/topics/military", "Mind (18);http://www.ted.com/topics/mind", "Mindfulness (1);http://www.ted.com/topics/mindfulness", "Mining (2);http://www.ted.com/topics/mining", "Mission blue (13);http://www.ted.com/topics/mission+blue", "Mobility (1);http://www.ted.com/topics/mobility", "Money (16);http://www.ted.com/topics/money", "Moon (1);http://www.ted.com/topics/Moon", "Morality (9);http://www.ted.com/topics/morality", "Museums (9);http://www.ted.com/topics/museums", "Music (107);http://www.ted.com/topics/music", "Nanoscale (4);http://www.ted.com/topics/nanoscale", "NASA (6);http://www.ted.com/topics/NASA", "Nature (30);http://www.ted.com/topics/nature", "Neurology (10);http://www.ted.com/topics/neurology", "Neuroscience (24);http://www.ted.com/topics/neuroscience", "New York (5);http://www.ted.com/topics/New+York", "News (9);http://www.ted.com/topics/news", "Novel (3);http://www.ted.com/topics/novel", "Nuclear energy (4);http://www.ted.com/topics/nuclear+energy", "Nuclear weapons (2);http://www.ted.com/topics/nuclear+weapons", "Oceans (44);http://www.ted.com/topics/oceans", "Oil (4);http://www.ted.com/topics/oil", "One Laptop Per Child (4);http://www.ted.com/topics/One+Laptop+Per+Child", "Open-source (21);http://www.ted.com/topics/open-source", "Origami (2);http://www.ted.com/topics/origami", "Pain (1);http://www.ted.com/topics/pain", "Paleontology (6);http://www.ted.com/topics/paleontology", "Pandemic (2);http://www.ted.com/topics/pandemic", "Parenting (17);http://www.ted.com/topics/parenting", "Peace (33);http://www.ted.com/topics/peace", "Performance (65);http://www.ted.com/topics/performance", "Performance art (8);http://www.ted.com/topics/performance+art", "Personal growth (15);http://www.ted.com/topics/personal+growth", "Philanthropy (29);http://www.ted.com/topics/philanthropy", "Philosophy (42);http://www.ted.com/topics/philosophy", "Photography (57);http://www.ted.com/topics/photography", "Physics (47);http://www.ted.com/topics/physics", "Piano (13);http://www.ted.com/topics/piano", "Plastic (8);http://www.ted.com/topics/plastic", "Play (12);http://www.ted.com/topics/play", "Poetry (35);http://www.ted.com/topics/poetry", "Policy (2);http://www.ted.com/topics/policy", "Politics (137);http://www.ted.com/topics/politics", "Pollution (8);http://www.ted.com/topics/pollution", "Population (3);http://www.ted.com/topics/population", "Potential (9);http://www.ted.com/topics/potential", "Poverty (44);http://www.ted.com/topics/poverty", "Prediction (4);http://www.ted.com/topics/prediction", "Presentation (12);http://www.ted.com/topics/presentation", "Primates (5);http://www.ted.com/topics/primates", "Prison (8);http://www.ted.com/topics/prison", "Prodigy (2);http://www.ted.com/topics/prodigy", "Product design (11);http://www.ted.com/topics/product+design", "Productivity (7);http://www.ted.com/topics/productivity", "Prosthetics (11);http://www.ted.com/topics/prosthetics", "Psychology (73);http://www.ted.com/topics/psychology", "Race (9);http://www.ted.com/topics/race", "Relationships (13);http://www.ted.com/topics/relationships", "Religion (35);http://www.ted.com/topics/religion", "Robots (30);http://www.ted.com/topics/robots", "Rocket science (3);http://www.ted.com/topics/rocket+science", "Science (406);http://www.ted.com/topics/science", "Security (11);http://www.ted.com/topics/security", "Self (26);http://www.ted.com/topics/self", "Sex (25);http://www.ted.com/topics/sex", "Shopping (12);http://www.ted.com/topics/shopping", "Short talk (46);http://www.ted.com/topics/short+talk", "Sight (1);http://www.ted.com/topics/sight", "Simplicity (13);http://www.ted.com/topics/simplicity", "Singer (12);http://www.ted.com/topics/singer", "Singularity (1);http://www.ted.com/topics/singularity", "Skateboarding (1);http://www.ted.com/topics/skateboarding", "Slavery (4);http://www.ted.com/topics/Slavery", "Smell (6);http://www.ted.com/topics/smell", "Social change (66);http://www.ted.com/topics/social+change", "Social media (23);http://www.ted.com/topics/social+media", "Society (34);http://www.ted.com/topics/society", "Software (18);http://www.ted.com/topics/software", "Solar (2);http://www.ted.com/topics/solar", "Sound (5);http://www.ted.com/topics/sound", "South asia (2);http://www.ted.com/topics/south+asia", "Space (34);http://www.ted.com/topics/space", "Spoken word (7);http://www.ted.com/topics/spoken+word", "Sports (22);http://www.ted.com/topics/sports", "State-building (6);http://www.ted.com/topics/state-building", "Statistics (16);http://www.ted.com/topics/statistics", "Storytelling (89);http://www.ted.com/topics/storytelling", "Student (5);http://www.ted.com/topics/student", "Submarine (1);http://www.ted.com/topics/submarine", "Success (13);http://www.ted.com/topics/success", "Sustainability (41);http://www.ted.com/topics/sustainability", "Technology (533);http://www.ted.com/topics/technology", "TED Fellows (22);http://www.ted.com/topics/TED+Fellows", "TED Prize (23);http://www.ted.com/topics/TED+Prize", "TED-Ed (8);http://www.ted.com/topics/TED-Ed", "TEDBooks (6);http://www.ted.com/topics/TEDBooks", "TEDWomen (1);http://www.ted.com/topics/TEDWomen", "Tedx (35);http://www.ted.com/topics/tedx", "TEDxFeatured (63);http://www.ted.com/topics/TEDxFeatured", "Telecom (5);http://www.ted.com/topics/telecom", "Theater (10);http://www.ted.com/topics/theater", "Third world (20);http://www.ted.com/topics/third+world", "Time (1);http://www.ted.com/topics/time", "Toy (2);http://www.ted.com/topics/toy", "Trafficking (3);http://www.ted.com/topics/trafficking", "Transhuman (4);http://www.ted.com/topics/transhuman", "Transportation (27);http://www.ted.com/topics/transportation", "United States (7);http://www.ted.com/topics/United+States", "Universe (24);http://www.ted.com/topics/universe", "Urban planning (12);http://www.ted.com/topics/urban+planning", "Video (14);http://www.ted.com/topics/video", "Violence (25);http://www.ted.com/topics/violence", "Violin (6);http://www.ted.com/topics/violin", "Virus (5);http://www.ted.com/topics/virus", "Visualizations (34);http://www.ted.com/topics/visualizations", "Vocals (3);http://www.ted.com/topics/vocals", "War (62);http://www.ted.com/topics/war", "Water (13);http://www.ted.com/topics/water", "Web (32);http://www.ted.com/topics/web", "Wikipedia (6);http://www.ted.com/topics/wikipedia", "Women (51);http://www.ted.com/topics/women", "Work (27);http://www.ted.com/topics/work", "World cultures (9);http://www.ted.com/topics/world+cultures", "Writing (33);http://www.ted.com/topics/writing", "Wunderkind (5);http://www.ted.com/topics/wunderkind", "Youth (24);http://www.ted.com/topics/youth" };
                foreach(string vals in fakeData)
                    this.Tags.Add(new TitleURLPair(vals.Split(';')[0], vals.Split(';')[1])); ;
            }
        }

        public void FillList(string[] topics)
        {
          //  Console.WriteLine("Данные для фейка");
            foreach (string tpc in topics)
            {
                string[] vals = tpc.Split(new string[] { dlm }, StringSplitOptions.RemoveEmptyEntries);
                this.Tags.Add(new TitleURLPair(vals[1], urlTEDRoot + vals[0]));
              //  Console.Write("\"" + vals[1] + ";" + urlTEDRoot + vals[0] + "\", ");
            }
          //  Console.WriteLine("};");
        }


      //  public Dictionary<string, string> Tags = new Dictionary<string, string>() { };
        public List<TitleURLPair> Tags = new List<TitleURLPair>() { };

        #region old version
		//        public void FillTags()
//        {
//            this.GetContent("empty", "", "");        
//        }

//        void FillTags(string staff)
//        {
//            string[] _separators = new string[] { "<li><a href=\"" +  url, // <li><a href=\"http://www.ted.com/topics/topics
//                                                 @"</a>" };
////            string _delimeter = @"/tags/";
//            string _delimeter = @"/topics/";
//            Tags.Clear();
//            foreach (string val in staff.Split(_separators, StringSplitOptions.RemoveEmptyEntries))
//            {
//                // if (val.StartsWith(_delimeter)) // <a href="/topics/activism">Activism (55)</a>
//                //    if (val.StartsWith(_delimeter)) // <li><a href="http://www.ted.com/talks/tags/talks/tags/activism">Activism (55)</a></li>

//                if (val.StartsWith(_delimeter)) // <a href="/topics/activism">Activism (55)</a> 
//                {
//                    string[] pair = val.Split(new string[] { "\">" }, StringSplitOptions.RemoveEmptyEntries);
//                    if (pair.Length == 2)
//                    {
//                        //  Tags.Add(pair[1], url + pair[0].Substring(_delimeter.Length - 1));
//                        Tags.Add(new TitleURLPair(pair[1], url + pair[0].Substring(_delimeter.Length - 1)));
//                    }
//                }
//            }
//        } 
	#endregion

        #region service props
        public override bool ClearFromScript { get { return true; } }
        public override bool ClearFromIframe { get { return true; } }

        public override string URL
        {
            get { return url; }
        }

        public override string[] StartTags
        {
            get { return null; }
        }

        public override string Title
        {
            get { return null; }
        }

        public override string Copyright
        {
            get { return null; }
        }

        public override string[] Languages
        {
            get { return new string[] { DictionaryProvider.AllLanguages }; }
        }
        #endregion
    }

    public class TitleURLPair
    {
        string m_title, m_url;
        public TitleURLPair(string title, string url)
        {
            m_title = title;
            m_url = url;
        }

        public string Title { get { return m_title; } }
        public string URL { get { return m_url; } }

        public override string ToString()
        {
            return m_title;
        }
    }
}
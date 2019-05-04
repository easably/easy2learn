using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class E : Form
    {
        public E()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.MinimizeBox = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);

            this.tvWords.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvWords_NodeMouseClick);
            this.tvDictionaries.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvWords_NodeMouseClick);

            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            this.miFindCitations.Click += new System.EventHandler(this.miFindCitations_Click);
            this.miCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
            this.splitter1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitter1_Paint);
            this.SizeChanged += new System.EventHandler(this.EstimatorForm_SizeChanged);

            this.miFindCitations.Image = global::f.button_images.find;
        }

        string m_FullText = "";
        public string FullText { get { return m_FullText; } }

        public void AssignTextForEstimate(string text, string languageCode)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.tvWords.BeginUpdate();
                this.tvDictionaries.BeginUpdate();
                m_FullText = text;

                if (string.IsNullOrEmpty(text)) return;
                //foreach (string c in FooSymbol)
                //{
                //    text = text.Replace(c, " ").ToLower();
                //    text = Util.GetWord(c).ToLower();
                //}

                Dictionary<string, int> ht = new Dictionary<string, int> { };
                string[] allWords = text.ToLower().Split(' ');
                int countWords = 0;
                foreach (string s in allWords)
                {
//                    string word = Word.GetLetters(s); // .Trim().Trim(new char[] {'\''}); //"'" = (char)39
                    string word = s.Trim(TipTextBox.SymbolEndWord);
                    if (string.IsNullOrEmpty(word) || word.Length < 3) continue;

                    if (string.IsNullOrEmpty(word)) continue;
                    if (word.Length == 1) continue;
                    if (word == "the") continue;
                    if (ht.ContainsKey(word))
                        ht[word] = (int)ht[word] + 1;
                    else
                        ht.Add(word, 1);
                    ++countWords;
                }

                this.tvWords.Nodes.Clear();
                TreeNode tn = this.tvWords.Nodes.Add(string.Format("All words: {0} (word usages: {1})", ht.Count, countWords.ToString()));
                //Array.Sort(allWords);
                string[] ws = new string[ht.Count]; int i = -1;
                foreach (string w in ht.Keys)
                    ws[++i] = w;
                int[] counts = new int[ht.Count]; i = -1;
                foreach (int countValue in ht.Values)
                    counts[++i] = countValue;
                Array.Sort(counts, ws); // сортируем по количеству использований слова
                Array.Reverse(ws);
                foreach (string word in ws)
                {
                    TreeNode tnWord = tn.Nodes.Add(word); // Insert(0, word); // ломаетс€ сортировка

                    #region morfems
                    if (word.Length >= 4 && 
                        (word.Contains("'") && word.IndexOf("'") >=4 )) // избегаем he's и прочего
                        // то можно попробовать его использовать как морфему
                    {
                        string morpheme = D.GetMorpheme(word);
                        int nearCount = 0;
                        foreach (string s in ht.Keys)
                        {
                            if (s.Length > morpheme.Length && s.IndexOf(morpheme) > -1 && s != word) // т.е. это не корень самого стартового слова
                            {
                                tnWord.Nodes.Add(string.Format("{0} ({1})", s, ht[s]));
                                nearCount += (int)ht[s];
                            }
                        }
                        if (nearCount > 0)
                        {
                            tnWord.Nodes.Insert(0, string.Format("{0} ({1})", tnWord.Text, ht[tnWord.Text]));
                            tnWord.Text += string.Format(" ( {0}/{1} )", ht[word], (int)ht[word]+ nearCount);
                        }
                    }
                    #endregion
                    if (tnWord.Nodes.Count == 0) // is not morthem usages
                        tnWord.Text += string.Format(" ({0})", ht[tnWord.Text]); // usages
                }

                this.tvDictionaries.Nodes.Clear();
                if( languageCode == "en" ) {
                    EstimateVocabulare(text, ht, countWords, Thousand, "Common thousand");
                    EstimateVocabulare(text, ht, countWords, SecondThousand, "Second thousand");
                    EstimateVocabulare(text, ht, countWords, LDOCE, "Longman minimum");
                }
                List<string> _MyVocabulare = new List<string>();
                List<string> _UnderStudy = new List<string>();
                //foreach (Store.WordsRow row in Store.Instance.Words.Select("", Store.Instance.Words.NameColumn.ColumnName))
                //{
                //    if (row.Status == (short)WordStatus.Known)
                //        _MyVocabulare.Add(row.Name);
                //    if (row.Status == (short)WordStatus.Learn)
                //        _UnderStudy.Add(row.Name);
                //}
                EstimateVocabulare(text, ht, countWords, _MyVocabulare, "My vocabulary");
                EstimateVocabulare(text, ht, countWords, _UnderStudy, "Under study");
                if (this.tvWords.Nodes.Count > 0 )
                    this.tvWords.Nodes[0].Expand();
            }
            finally
            {
                this.tvWords.EndUpdate();
                this.tvDictionaries.EndUpdate();
                this.Cursor = Cursors.Default;
            }
        }

        #region Thousand
        string[] Thousand = new string[] {
 "a", "able", "about", "above", "act", "add", "afraid", "after", "again", "against", "age", "ago", "agree", "air", "all", "allow", "also", "always", "am", "among", "an", "and", "anger", "animal", "answer", "any", "appear", "apple", "are", "area",
 "arm", "arrange", "arrive", "art", "as", "as", "ask", "at", "atom", "baby", "back", "bad", "ball", "band", "bank", "bar", "base", "basic", "bat", "be", "bear", "beat", "beauty", "bed", "been", "began", "begin", "behind", "believe", "bell",
 "best", "better", "between", "big", "bird", "bit", "black", "block", "blood", "blow", "blue", "board", "boat", "body", "bone", "book", "born", "both", "bottom", "bought", "box", "branch", "bread", "break", "bright", "bring", "broad", "broke", "brother", "brought",
 "brown", "build", "burn", "busy", "but", "buy", "by", "call", "came", "camp", "can", "capital", "captain", "car", "card", "care", "carry", "case", "cat", "catch", "caught", "cause", "cell", "cent", "center", "century", "certain", "chair", "chance", "change",
 "character", "charge", "chart", "check", "chick", "chief", "child", "children", "choose", "chord", "circle", "city", "claim", "class", "clean", "clear", "climb", "clock", "close", "clothe", "cloud", "coast", "coat", "cold", "collect", "colony", "color", "column", "come", "common",
 "company", "compare", "complete", "condition", "connect", "consider", "consonant", "contain", "continent", "continue", "control", "cook", "cool", "copy", "corn", "corner", "correct", "cost", "cotton", "could", "count", "country", "course", "cover", "cow", "crease", "create", "crop", "cross", "crowd",
 "cry", "current", "cut", "dad", "dance", "danger", "dark", "day", "dead", "deal", "dear", "death", "decide", "decimal", "deep", "degree", "depend", "describe", "desert", "design", "determine", "develop", "dictionary", "did", "die", "differ", "difficult", "direct", "discuss", "distant",
 "divide", "division", "do", "doctor", "does", "dog", "dollar", "done", "don't", "door", "double", "down", "draw", "dream", "dress", "drink", "drive", "drop", "dry", "duck", "during", "each", "ear", "early", "earth", "ease", "east", "eat", "edge", "effect",
 "efore", "egg", "eight", "either", "electric", "element", "else", "end", "enemy", "energy", "engine", "enough", "enter", "equal", "equate", "especially", "even", "evening", "event", "ever", "every", "exact", "example", "except", "excite", "exercise", "expect", "experience", "experiment", "eye",
 "face", "fact", "fair", "fall", "family", "famous", "far", "farm", "fast", "fat", "father", "favor", "fear", "feed", "feel", "feet", "fell", "felt", "few", "field", "fig", "fight", "figure", "fill", "final", "find", "fine", "finger", "finish", "fire",
 "first", "fish", "fit", "five", "flat", "floor", "flow", "flower", "fly", "follow", "food", "foot", "for", "force", "forest", "form", "forward", "found", "four", "fraction", "free", "fresh", "friend", "from", "front", "fruit", "full", "fun", "game", "garden",
 "gas", "gather", "gave", "general", "gentle", "get", "girl", "give", "glad", "glass", "go", "gold", "gone", "good", "got", "govern", "grand", "grass", "gray", "great", "green", "grew", "ground", "group", "grow", "guess", "guide", "gun", "had", "hair",
 "half", "hand", "happen", "happy", "hard", "has", "hat", "have", "he", "head", "hear", "heard", "heart", "heat", "heavy", "held", "help", "her", "here", "high", "hill", "him", "his", "history", "hit", "hold", "hole", "home", "hope", "horse",
 "hot", "hot", "hour", "house", "how", "huge", "human", "hundred", "hunt", "hurry", "i", "ice", "idea", "if", "imagine", "in", "inch", "include", "indicate", "industry", "insect", "instant", "instrument", "interest", "invent", "iron", "is", "island", "it", "job",
 "join", "joy", "jump", "just", "keep", "kept", "key", "kill", "kind", "king", "knew", "know", "lady", "lake", "land", "language", "large", "last", "late", "laugh", "law", "lay", "lead", "learn", "least", "leave", "led", "left", "leg", "length",
 "less", "let", "letter", "level", "lie", "life", "lift", "light", "like", "line", "liquid", "list", "listen", "little", "live", "locate", "log", "lone", "long", "look", "lost", "lot", "loud", "love", "low", "machine", "made", "magnet", "main", "major",
 "make", "man", "many", "map", "mark", "market", "mass", "master", "match", "material", "matter", "may", "me", "mean", "meant", "measure", "meat", "meet", "melody", "men", "metal", "method", "middle", "might", "mile", "milk", "million", "mind", "mine", "minute",
 "miss", "mix", "modern", "molecule", "moment", "money", "month", "moon", "more", "morning", "most", "mother", "motion", "mount", "mountain", "mouth", "move", "much", "multiply", "music", "must", "my", "name", "nation", "natural", "nature", "near", "necessary", "neck", "need",
 "neighbor", "never", "new", "next", "night", "nine", "no", "noise", "noon", "nor", "north", "nose", "note", "nothing", "notice", "noun", "now", "number", "numeral", "object", "observe", "occur", "ocean", "of", "off", "offer", "office", "often", "oh", "oil",
 "old", "on", "once", "one", "only", "open", "operate", "opposite", "or", "order", "organ", "original", "other", "our", "out", "over", "own", "oxygen", "oy", "page", "paint", "pair", "paper", "paragraph", "parent", "part", "particular", "party", "pass", "past",
 "path", "pattern", "pay", "people", "perhaps", "period", "person", "phrase", "pick", "picture", "piece", "pitch", "place", "plain", "plan", "plane", "planet", "plant", "play", "please", "plural", "poem", "point", "poor", "populate", "port", "pose", "position", "possible", "post",
 "pound", "power", "practice", "prepare", "present", "press", "pretty", "print", "probable", "problem", "process", "produce", "product", "proper", "property", "protect", "prove", "provide", "pull", "push", "put", "quart", "question", "quick", "quiet", "quite", "quotient", "race", "radio", "rail",
 "rain", "raise", "ran", "range", "rather", "reach", "read", "ready", "real", "reason", "receive", "record", "red", "region", "remember", "repeat", "reply", "represent", "require", "rest", "result", "rich", "ride", "right", "ring", "rise", "river", "road", "rock", "roll",
 "room", "root", "rope", "rose", "round", "row", "rub", "rule", "run", "safe", "said", "sail", "salt", "same", "sand", "sat", "save", "saw", "say", "scale", "school", "science", "score", "sea", "search", "season", "seat", "second", "section", "see",
 "seed", "seem", "segment", "select", "self", "sell", "send", "sense", "sent", "sentence", "separate", "serve", "set", "settle", "seven", "several", "shall", "shape", "share", "sharp", "she", "sheet", "shell", "shine", "ship", "shoe", "shop", "shore", "short", "should",
 "shoulder", "shout", "show", "side", "sight", "sign", "silent", "silver", "similar", "simple", "since", "sing", "single", "sister", "sit", "six", "size", "skill", "skin", "sky", "slave", "sleep", "slip", "slow", "small", "smell", "smile", "snow", "so", "soft",
 "soil", "soldier", "solution", "solve", "some", "son", "song", "soon", "sound", "south", "space", "speak", "special", "speech", "speed", "spell", "spend", "spoke", "spot", "spread", "spring", "square", "stand", "star", "start", "state", "station", "stay", "stead", "steam",
 "steel", "step", "stick", "still", "stone", "stood", "stop", "store", "story", "straight", "strange", "stream", "street", "stretch", "string", "strong", "student", "study", "subject", "substance", "subtract", "success", "such", "sudden", "suffix", "sugar", "suggest", "suit", "summer", "sun",
 "supply", "support", "sure", "surface", "surprise", "swim", "syllable", "symbol", "system", "table", "tail", "take", "talk", "tall", "teach", "team", "teeth", "tell", "temperature", "ten", "term", "test", "than", "thank", "that", "the", "their", "them", "then", "there",
 "these", "they", "thick", "thin", "thing", "think", "third", "this", "those", "though", "thought", "thousand", "three", "through", "throw", "thus", "tie", "time", "tiny", "tire", "to", "together", "told", "tone", "too", "took", "tool", "top", "total", "touch",
 "toward", "town", "track", "trade", "train", "travel", "tree", "triangle", "trip", "trouble", "truck", "true.", "try", "tube", "turn", "twenty", "two", "type", "under", "unit", "until", "up", "us", "use", "usual", "valley", "value", "vary", "verb", "very",
 "view", "village", "visit", "voice", "vowel", "wait", "walk", "wall", "want", "war", "warm", "wash", "watch", "water", "wave", "way", "we", "wear", "weather", "week", "weight", "well", "went", "were", "west", "what", "wheel", "when", "where", "whether",
 "which", "while", "white", "who", "whole", "whose", "why", "wide", "wife", "wild", "will", "win", "wind", "window", "wing", "winter", "wire", "wish", "with", "woman", "women", "wonder", "won't", "wood", "word", "work", "world", "would", "write", "written",
 "wrong", "wrote", "yard", "year", "yellow", "yes", "yet", "you", "young", "your",}; // 1000
        #endregion Thousand

        #region SecondThousand
        string[] SecondThousand = new string[] {
 "ability", "aboard", "accept", "accident", "according", "account", "accurate", "acres", "across", "action", "active", "activity", "actual", "actually", "addition", "additional", "adjective", "adult", "adventure", "advice", "affect", "africa", "afternoon", "ahead", "aid", "airplane", "alaska", "alice", "alike", "alive",
 "almost", "alone", "along", "aloud", "alphabet", "already", "although", "america", "amount", "ancient", "andy", "angle", "angry", "ann", "announced", "another", "ants", "anybody", "anyone", "anything", "anyway", "anywhere", "apart", "apartment", "appearance", "applied", "appropriate", "april", "aren't", "army",
 "around", "arrangement", "arrow", "article", "asia", "aside", "asleep", "ate", "atlantic", "atmosphere", "atomic", "attached", "attack", "attempt", "attention", "audience", "august", "aunt", "australia", "author", "automobile", "autumn", "available", "average", "avoid", "aware", "away", "badly", "bag", "balance",
 "balloon", "bare", "bark", "barn", "baseball", "basis", "basket", "battle", "bay", "bean", "beautiful", "became", "because", "become", "becoming", "bee", "before", "beginning", "begun", "behavior", "being", "believed", "belong", "below", "belt", "ben", "bend", "beneath", "bent", "beside",
 "bet", "betsy", "beyond", "bicycle", "bigger", "biggest", "bill", "bill", "billy", "birds", "birth", "birthday", "bite", "blank", "blanket", "blew", "blind", "bob", "border", "bottle", "bound", "bow", "bowl", "boy", "brain", "brass", "brave", "breakfast", "breath", "breathe",
 "breathing", "breeze", "brick", "bridge", "brief", "british", "broken", "brush", "buffalo", "building", "built", "buried", "burst", "bus", "bush", "business", "butter", "cabin", "cage", "cake", "california", "calm", "camera", "canada", "canal", "cannot", "can't", "cap", "captured", "carbon",
 "careful", "carefully", "carlos", "carried", "casey", "cast", "castle", "cattle", "cave", "central", "certainly", "chain", "chamber", "changing", "chapter", "characteristic", "charles", "cheese", "chemical", "chest", "chicago", "chicken", "china", "chinese", "choice", "chose", "chosen", "christmas", "church", "circus",
 "citizen", "classroom", "claws", "clay", "clearly", "climate", "closely", "closer", "cloth", "clothes", "clothing", "club", "coach", "coal", "coffee", "college", "columbus", "combination", "combine", "comfortable", "coming", "command", "community", "compass", "completely", "complex", "composed", "composition", "compound", "concerned",
 "congress", "connected", "consist", "constantly", "construction", "continued", "contrast", "conversation", "cookies", "copper", "correctly", "couldn't", "couple", "courage", "court", "cowboy", "crack", "cream", "creature", "crew", "cup", "curious", "curve", "customs", "cutting", "daily", "damage", "dan", "dangerous", "daniel",
 "danny", "darkness", "date", "daughter", "david", "dawn", "declared", "deeply", "deer", "definition", "depth", "desk", "detail", "development", "diagram", "diameter", "dick", "didn't", "difference", "different", "difficulty", "dig", "dinner", "direction", "directly", "dirt", "dirty", "disappear", "discover", "discovery",
 "discussion", "disease", "dish", "distance", "doesn't", "doing", "doll", "don", "donkey", "dot", "doubt", "dozen", "dr.", "drawn", "drew", "dried", "driven", "driver", "driving", "dropped", "drove", "due", "dug", "dull", "dust", "dutch", "duty", "eager", "earlier", "earn",
 "easier", "easily", "easy", "eaten", "eddy", "education", "edward", "effort", "egypt", "electricity", "elephant", "eleven", "ellen", "empty", "engineer", "england", "enjoy", "entire", "entirely", "environment", "equally", "equator", "equipment", "escape", "essential", "establish", "etc", "europe", "european", "eventually",
 "everybody", "everyone", "everything", "everywhere", "evidence", "exactly", "examine", "excellent", "exchange", "excited", "excitement", "exciting", "exclaimed", "exist", "explain", "explanation", "explore", "express", "expression", "extra", "facing", "factor", "factory", "failed", "fairly", "fallen", "familiar", "farmer", "farther", "fastened",
 "faster", "favorite", "feathers", "feature", "fed", "fellow", "fence", "fewer", "fierce", "fifteen", "fifth", "fifty", "fighting", "film", "finally", "finest", "fireplace", "firm", "fix", "flag", "flame", "flew", "flies", "flight", "floating", "florida", "fog", "folks", "football", "foreign",
 "forget", "forgot", "forgotten", "former", "fort", "forth", "forty", "fought", "fourth", "fox", "frame", "france", "frank", "fred", "freedom", "french", "frequently", "friendly", "frighten", "frog", "frozen", "fuel", "fully", "function", "funny", "fur", "furniture", "further", "future", "gain",
 "garage", "gasoline", "gate", "generally", "gently", "george", "german", "germany", "getting", "giant", "gift", "given", "giving", "globe", "goes", "golden", "goose", "government", "grabbed", "grade", "gradually", "grain", "grandfather", "grandmother", "graph", "gravity", "greater", "greatest", "greatly", "greece",
 "greek", "grown", "growth", "guard", "gulf", "habit", "hadn't", "halfway", "hall", "handle", "handsome", "hang", "happened", "happily", "harbor", "harder", "hardly", "harry", "haven't", "having", "hay", "headed", "heading", "health", "hearing", "he'd", "height", "he'll", "hello", "helpful",
 "henry", "herd", "herself", "he's", "hidden", "hide", "higher", "highest", "highway", "himself", "hollow", "honor", "horn", "hospital", "however", "hung", "hungry", "hunter", "hurried", "hurt", "husband", "i'd", "identity", "ill", "i'll", "illinois", "i'm", "image", "immediately", "importance",
 "important", "impossible", "improve", "including", "income", "increase", "indeed", "independent", "india", "indian", "individual", "industrial", "influence", "information", "inside", "instance", "instead", "interior", "into", "introduced", "invented", "involved", "isn't", "italian", "italy", "its", "itself", "i've", "jack", "james",
 "jane", "january", "japan", "japanese", "jar", "jeff", "jet", "jim", "jimmy", "joe", "john", "johnny", "johnson", "joined", "jones", "journey", "judge", "july", "june", "jungle", "kids", "kitchen", "knife", "knowledge", "known", "label", "labor", "lack", "laid", "lamp",
 "larger", "largest", "later", "latin", "layers", "leader", "leaf", "leather", "leaving", "lee", "lesson", "let's", "library", "likely", "limited", "lincoln", "lion", "lips", "living", "load", "local", "location", "london", "lonely", "longer", "loose", "lose", "loss", "louis", "lovely",
 "lower", "luck", "lucky", "lunch", "lungs", "lying", "machinery", "mad", "magic", "mail", "mainly", "making", "mama", "managed", "manner", "manufacturing", "march", "maria", "married", "mars", "martin", "mary", "massage", "mathematics", "maybe", "meal", "means", "medicine", "melted", "member",
 "memory", "mental", "merely", "met", "mexico", "mice", "mighty", "mike", "military", "mill", "minerals", "mirror", "missing", "mission", "mississippi", "mistake", "mixture", "model", "molecular", "monkey", "mood", "mostly", "motor", "mouse", "movement", "movie", "moving", "mr.", "mrs.", "mud",
 "muscle", "musical", "myself", "mysterious", "nails", "national", "native", "naturally", "nearby", "nearer", "nearest", "nearly", "needed", "needle", "needs", "negative", "negro", "neighborhood", "nervous", "nest", "new york", "news", "newspaper", "nice", "nobody", "nodded", "none", "norway", "not", "noted",
 "nuts", "obtain", "occasionally", "october", "officer", "official", "ohio", "older", "oldest", "onto", "operation", "opinion", "opportunity", "orange", "orbit", "ordinary", "organization", "organized", "origin", "ought", "ourselves", "outer", "outline", "outside", "owner", "pacific", "pack", "package", "paid", "pain",
 "palace", "pale", "pan", "papa", "parallel", "paris", "park", "particles", "particularly", "partly", "parts", "passage", "paul", "peace", "pen", "pencil", "pennsylvania", "per", "percent", "perfect", "perfectly", "personal", "pet", "peter", "philadelphia", "physical", "piano", "pictured", "pie", "pig",
 "pile", "pilot", "pine", "pink", "pipe", "planned", "planning", "plastic", "plate", "plates", "pleasant", "pleasure", "plenty", "plus", "pocket", "poet", "poetry", "pole", "pole", "police", "policeman", "political", "pond", "pony", "pool", "popular", "population", "porch", "positive", "possibly",
 "pot", "potatoes", "pour", "powder", "powerful", "practical", "president", "pressure", "prevent", "previous", "price", "pride", "primitive", "principal", "principle", "printed", "private", "prize", "probably", "production", "program", "progress", "promised", "properly", "protection", "proud", "public", "pupil", "pure", "purple",
 "purpose", "putting", "quarter", "queen", "quickly", "quietly", "rabbit", "railroad", "ranch", "rapidly", "rate", "raw", "rays", "reader", "realize", "rear", "recall", "recent", "recently", "recognize", "refer", "refused", "regular", "related", "relationship", "religious", "remain", "remarkable", "remove", "replace",
 "replied", "report", "research", "respect", "return", "review", "rhyme", "rhythm", "rice", "richard", "riding", "rising", "roar", "robert", "rocket", "rocky", "rod", "roman", "rome", "roof", "rough", "route", "rubbed", "rubber", "ruler", "running", "rush", "russia", "russian", "sad",
 "saddle", "safety", "sale", "sally", "salmon", "sam", "sang", "satellites", "satisfied", "saturday", "saved", "scared", "scene", "scientific", "scientist", "screen", "secret", "seeing", "seems", "seen", "seldom", "selection", "series", "serious", "service", "sets", "setting", "settlers", "shade", "shadow",
 "shake", "shaking", "shallow", "sheep", "shelf", "shells", "shelter", "shinning", "shirt", "shoot", "shorter", "shot", "shown", "shut", "sick", "sides", "signal", "silence", "silk", "silly", "simplest", "simply", "sink", "sir", "sitting", "situation", "slabs", "slept", "slide", "slight",
 "slightly", "slipped", "slope", "slowly", "smaller", "smallest", "smith", "smoke", "smooth", "snake", "soap", "social", "society", "softly", "solar", "sold", "solid", "somebody", "somehow", "someone", "something", "sometime", "somewhere", "sort", "source", "southern", "spain", "species", "specific", "spent",
 "spider", "spin", "spirit", "spite", "split", "spoken", "sport", "st.", "stage", "stairs", "standard", "stared", "statement", "states", "steady", "steep", "stems", "stepped", "stiff", "stock", "stomach", "stopped", "storm", "stove", "stranger", "straw", "strength", "strike", "strip", "stronger",
 "struck", "structure", "struggle", "stuck", "studied", "studying", "successful", "suddenly", "sum", "sunday", "sunlight", "supper", "suppose", "surrounded", "swam", "sweet", "swept", "swimming", "swing", "swung", "taken", "tales", "tank", "tape", "task", "taste", "taught", "tax", "tea", "teacher",
 "tears", "telephone", "television", "tent", "terrible", "texas", "that's", "thee", "themselves", "theory", "therefore", "there's", "they're", "thirty", "thomas", "thou", "thread", "threw", "throat", "throughout", "thrown", "thumb", "thy", "tide", "tight", "tightly", "till", "tim", "tin", "tip",
 "tired", "title", "tobacco", "today", "tom", "tomorrow", "tongue", "tonight", "topic", "torn", "tower", "toy", "trace", "traffic", "trail", "transportation", "trap", "treated", "tribe", "trick", "tried", "troops", "tropical", "trunk", "truth", "tune", "tv", "twelve", "twice", "typical",
 "uncle", "underline", "understanding", "unhappy", "union", "united", "universe", "university", "unknown", "unless", "unusual", "upon", "upper", "upward", "useful", "using", "usually", "valuable", "vapor", "variety", "various", "vast", "vegetable", "vertical", "vessels", "victory", "virginia", "visitor", "volume", "vote",
 "voyage", "wagon", "warn", "was", "washington", "wasn't", "waste", "weak", "wealth", "weigh", "welcome", "we'll", "we're", "weren't", "western", "wet", "we've", "whale", "whatever", "what's", "wheat", "whenever", "wherever", "whispered", "whistle", "whom", "widely", "william", "willing", "wilson",
 "wise", "within", "without", "wolf", "won", "wonderful", "wooden", "wool", "wore", "worker", "worried", "worry", "worse", "worth", "wouldn't", "wrapped", "writer", "writing", "yesterday", "you'd", "you'll", "younger", "you're", "yourself", "youth", "you've", "zero", "zoo",}; // 1198
        #endregion SecondThousand

        #region LDOCE
        string[] LDOCE = new string[] {
 "ability", "about", "above", "abroad", "absence", "absent", "accept", "acceptable", "accident", "accordance", "according", "according", "account", "ache", "acid", "across", "act", "action", "active", "activity", "actor", "actress", "actual", "add", "addition", "addrees", "adjective", "admiration", "admire", "admit",
 "admittance", "adult", "advance", "advantage", "adventure", "adverb", "advertise", "advertisement", "advice", "advise", "affair", "afford", "afraid", "after", "afternoon", "afterwards", "again", "against", "age", "ago", "agree", "agreement", "ahead", "aim", "air", "aircraft", "airforce", "airport", "alcohol", "alike",
 "alive", "all", "allow", "almost", "alone", "along", "aloud", "alphabet", "already", "also", "although", "altogether", "always", "among", "amount", "amuse", "amusement", "amusing", "an", "ancient", "and", "anger", "angle", "angry", "animal", "ankle", "annoy", "annoyance", "another", "answer",
 "ant", "anxiety", "anxious", "any", "anyhow", "anyone", "anything", "anywhere", "apart", "apparatus", "appear", "appearance", "apple", "appoint", "approval", "approve", "arch", "area", "argue", "argument", "arm", "armour", "arms", "army", "around", "arrange", "arrangement", "arrival", "arrive", "art",
 "article", "artificial", "as", "ash", "ashamed", "aside", "ask", "asleep", "association", "at", "atom", "attack", "attempt", "attend", "attendance", "attention", "attract", "attractive", "aunt", "autumn", "average", "avoid", "awake", "away", "awkward", "baby", "back", "background", "backward", "backwards",
 "bacteria", "bad", "bag", "bake", "balance", "ball", "banana", "band", "bank", "bar", "bare", "barrel", "base", "basket", "bath", "bathe", "battle", "be", "beak", "beam", "bean", "bear", "beard", "beat", "beautiful", "beauty", "because", "become", "bed", "bee",
 "beer", "before", "beg", "begin", "beginning", "behave", "behaviour", "behind", "belief", "believe", "bell", "belong", "below", "belt", "bend", "beneath", "berry", "beside", "besides", "best", "better", "between", "beyond", "bicycle", "big", "bill", "bind", "bird", "birth", "birthday",
 "bit", "bite", "bitter", "black", "blade", "blame", "bleed", "bless", "blind", "block", "blood", "blow", "blue", "board", "boat", "body", "boil", "bomb", "bone", "book", "boot", "border", "born", "borrow", "both", "bottle", "bottom", "bowels", "bowl", "box",
 "boy", "brain", "branch", "brass", "brave", "bread", "breadth", "break", "breakfast", "breast", "breath", "breathe", "breed", "brick", "bridge", "bright", "bring", "broad", "broadcast", "brother", "brown", "brush", "bucket", "build", "building", "bullet", "bunch", "burial", "burn", "burst",
 "bury", "bus", "bush", "business", "busy", "but", "butter", "button", "buy", "by", "cage", "cake", "calculate", "calculator", "call", "calm", "camera", "camp", "can", "candle", "cap", "capital", "captain", "car", "card", "cardboard", "care", "careful", "careless", "carriage",
 "carry", "cart", "case", "castle", "cat", "catch", "cattle", "cause", "cell", "cement", "cent", "centimetre", "central", "centre", "century", "ceremony", "certain", "chain", "chair", "chairperson", "chalk", "chance", "change", "character", "charge", "charm", "chase", "cheap", "cheat", "cheek",
 "cheer", "cheerful", "cheese", "chemical", "chemistry", "cheque", "chest", "chicken", "chief", "child", "childhood", "children", "chimney", "chin", "chocolate", "choice", "choose", "church", "cigarette", "cinema", "circle", "circular", "citizen", "city", "civilization", "claim", "class", "clay", "clean", "clear",
 "clerk", "clever", "cliff", "climb", "clock", "clockwork", "close", "cloth", "clothes,", "cloud", "club", "coal", "coast", "coat", "coffee", "coin", "cold", "collar", "collect", "college", "colour", "comb", "combination", "combine", "come", "comfort", "comfortable", "command", "committee", "common",
 "companion", "company", "compare", "comparison", "compete", "competition", "competitor", "complain", "complaint", "complete", "compound", "computer", "concern", "concerning", "concert", "condition", "confidence", "confident", "confuse", "connect", "conscience", "conscious", "consider", "consist", "consonant", "contain", "contents", "continue", "continuous", "contract",
 "control", "convenient", "conversation", "cook", "cool", "copper", "copy", "cord", "corn", "corner", "correct", "cost", "cotton", "cough", "could", "council", "count", "country", "courage", "course", "court", "cover", "cow", "coward", "cowardly", "crack", "crash", "cream", "creature", "creep",
 "cricket", "crime", "criminal", "crop", "cross", "crowd", "cruel", "cruelty", "crush", "cry", "cultivate", "cup", "cupboard", "cure", "curl", "current", "curse", "curtain", "curve", "custom", "customer", "cut", "cycle", "daily", "damage", "dance", "danger", "dangerous", "dare", "daring",
 "dark", "date", "daughter", "day", "dead", "deal", "dear", "death", "debt", "decay", "deceit", "deceive", "decide", "decimal", "decision", "declaration", "declare", "decorate", "decoration", "decrease", "deep", "deer", "defeat", "defence", "defend", "degree", "delay", "delicate", "delight", "deliver",
 "demand", "department", "depend", "dependent", "depth", "descend", "describe", "description", "descriptive", "desert", "deserve", "desirable", "desire", "desk", "destroy", "destruction", "detail", "determination", "determined", "develop", "devil", "diamond", "dictionary", "die", "difference", "different", "difficult", "difficulty", "dig", "dinner",
 "dip", "direct", "direction", "dirt", "dirty", "disappoint", "discourage", "discouragement", "discover", "discovery", "dish", "dismiss", "distance", "distant", "ditch", "divide", "division", "do", "doctor", "dog", "dollar", "door", "doorway", "dot", "double", "doubt", "down", "drag", "draw", "drawer",
 "dream", "dress", "drink", "drive", "drop", "drown", "drug", "drum", "drunk", "dry", "duck", "dull", "during", "dust", "duty", "each", "eager", "ear", "early", "earn", "earth", "east", "eastern", "easy", "eat", "edge", "educate", "education", "effect", "effective",
 "effort", "egg", "eight", "eighth", "either", "elastic", "elbow", "elect", "election", "electric", "electricity", "elephant", "else", "employ", "employer", "employment", "empty", "enclose", "enclosure", "encourage", "encouragement", "end", "enemy", "engine", "engineer", "english", "enjoy", "enjoyment", "enough", "enter",
 "entertain", "entertainment", "entrance", "envelope", "equal", "equality", "escape", "especially", "establish", "establishment", "even", "evening", "event", "ever", "every", "everyone", "everything", "everywhere", "evil", "exact", "examination", "examine", "example", "excellent", "except", "exchange", "excite", "excited", "exciting", "excuse",
 "exercise", "exist", "existence", "expect", "expensive", "experience", "explain", "explanation", "explode", "explosion", "explosive", "express", "expression", "extreme", "eye", "eyelid", "face", "fact", "factory", "fail", "failure", "faint", "fair", "fairy", "faith", "faithful", "fall", "false", "fame", "familiar",
 "family", "famous", "fancy", "far", "farm", "farmer", "farmyard", "fashion", "fashionable", "fast", "fasten", "fat", "fate", "father", "fault", "favour", "favourable", "favourite", "fear", "feather", "feed", "feel", "feeling", "feelings", "fellow", "female", "fence", "fever", "few", "field",
 "fierce", "fifth", "fight", "figure", "fill", "film", "find", "fine", "finger", "finish", "fire", "fireplace", "firm", "first", "fish", "fisherman", "fit", "five", "fix", "flag", "flame", "flash", "flat", "flesh", "flight", "float", "flood", "floor", "flour", "flow",
 "flower", "fly", "fold", "follow", "fond", "food", "fool", "foolish", "foot", "football", "footpath", "footstep", "for", "forbid", "force", "forehead", "foreign", "foreigner", "forest", "forget", "forgive", "fork", "form", "formal", "former", "formerly", "fort", "fortunate", "fortune", "forward",
 "forwards", "four", "fourth", "fox", "frame", "free", "freedom", "freeze", "frequent", "fresh", "friend", "friendly", "frighten", "frightening", "from", "front", "fruit", "fulfil", "full", "fun", "funeral", "funny", "fur", "furnish", "furniture", "further", "future", "gain", "game", "garage",
 "garden", "garment", "gas", "gate", "gather", "general", "generous", "gentle", "gentleman", "get", "gift", "girl", "give", "glad", "glass", "glory", "glue", "go", "goat", "god", "god", "gold", "golden", "good", "goodbye", "goods", "govern", "government", "grace", "graceful",
 "gradual", "grain", "gram", "grammar", "grand", "grandfather", "grandmother", "grass", "grateful", "grave", "great", "green", "greet", "greeting", "grey", "grief", "grieve", "ground", "group", "grow", "growth", "guard", "guess", "guest", "guidance", "guide", "guilt", "gun", "habit", "habitual",
 "hair", "hairy", "half", "hall", "hammer", "hand", "handkerchief", "handle", "hang", "happen", "happy", "hard", "harden", "hardly", "hardship", "harm", "harmful", "harmless", "hasty", "hat", "hate", "hatred", "have", "he", "head", "health", "healthy", "hear", "heart", "heat",
 "heaven", "heavy", "heel", "height", "help", "helpful", "hen", "here", "hers", "hers", "herself", "hide", "high", "hill", "him", "himself", "hire", "his", "historical", "history", "hit", "hold", "holiday", "hollow", "holy", "home", "honest", "honesty", "honour", "honourable",
 "hook", "hope", "hopeful", "hopeless", "horizon", "horn", "horse", "hospital", "host", "hot", "hotel", "hour", "hourly", "house", "how", "human", "humorous", "humour", "hundred", "hundredth", "hunger", "hungry", "hunt", "hurry", "hurt", "husband", "hut", "i", "ice", "icy",
 "idea", "if", "ill", "image", "imaginary", "imagination", "imagine", "importance", "important", "improve", "improvement", "in", "include", "including", "income", "increase", "indoor", "indoors", "industrial", "industry", "infect", "infection", "infectious", "influence", "influential", "inform", "information", "ink", "inner", "inquire",
 "inquiry", "insect", "inside", "instead", "instruct", "instruction", "instrument", "insurance", "insure", "intend", "intention", "interest", "interesting", "international", "interrupt", "interruption", "into", "introduce", "introduction", "invent", "invention", "invitation", "invite", "inwards", "iron", "island", "it", "its", "itself", "jaw",
 "jealous", "jealousy", "jelly", "jewel", "jewellery", "job", "join", "joint", "joke", "journey", "joy", "judge", "judgment", "juice", "jump", "just", "justice", "keen", "keep", "key", "kick", "kill", "kilo", "kilogram", "kilometre", "kind", "king", "kingdom", "kiss", "kitchen",
 "knee", "kneel", "knife", "knock", "knot", "know", "knowledge", "labour", "lack", "ladder", "lady", "lake", "lamb", "lamp", "land", "language", "large", "last", "late", "lately", "laugh", "laughter", "law", "lawyer", "lay", "lazy", "lead", "lead", "leaf", "lean",
 "learn", "least", "leather", "leave", "left", "leg", "legal", "lend", "length", "less", "lesson", "let", "letter", "level", "library", "lid", "lie", "life", "lift", "light", "lightning", "like", "likely", "limb", "limit", "line", "lion", "lip", "liquid", "list",
 "listen", "literature", "litre", "little", "live", "load", "loaf", "local", "lock", "lodging", "lodgings", "log", "lonely", "long", "look", "loose", "lord", "lose", "loss", "lot", "loud", "love", "low", "lower", "loyal", "loyalty", "luck", "lump", "lung", "machine",
 "machinery", "mad", "magazine", "magic", "magician", "mail", "main", "make", "male", "man", "manage", "manager", "manner", "many", "map", "march", "mark", "market", "marriage", "marry", "mass", "master", "mat", "match", "material", "matter", "may", "me", "meal", "mean",
 "meaning", "means", "measure", "meat", "medical", "medicine", "meet", "meeting", "melt", "member", "memory", "mend", "mention", "merry", "message", "messenger", "metal", "method", "metre", "metric", "microscope", "middle", "might", "mile", "military", "milk", "million", "millionth", "mind", "mine",
 "mineral", "minister", "minute", "mirror", "miss", "mist", "mistake", "mix", "mixture", "model", "modern", "moment", "money", "monkey", "month", "monthly", "moon", "moral", "morals", "more", "morning", "most", "mother", "motor", "mountain", "mouse", "mouth", "move", "much", "mud",
 "multiply", "murder", "muscle", "music", "musician", "must", "my", "myself", "mysterious", "mystery", "nail", "name", "narrow", "nasty", "nation", "national", "nature", "naval", "navy", "near", "nearly", "neat", "necessary", "neck", "need", "needle", "neighbour", "neighbourhood", "neither", "nerve",
 "nervous", "nest", "net", "network", "never", "new", "news", "newspaper", "next", "nice", "night", "nine", "ninth", "no", "no", "noble", "nobleman", "noise", "none", "nonsense", "nor", "north", "northern", "nose", "not", "nothing", "notice", "noun", "now", "nowhere",
 "number", "nurse", "nut", "nylon", "oТclock", "obedience", "obedient", "obey", "object", "obtain", "occasion", "ocean", "odd", "of", "off", "offence", "offend", "offensive", "offer", "office", "officer", "official", "often", "oil", "old", "old-fashioned", "on", "once", "one", "oneself",
 "onion", "only", "open", "operate", "operation", "opinion", "opponent", "oppose", "opposite", "opposition", "or", "orange", "order", "ordinary", "organ", "organization", "origin", "other", "otherwise", "ought", "our", "ours", "ourselves", "out", "outdoor", "outdoors", "outer", "outside", "over", "owe",
 "owing", "own", "oxygen", "pack", "packet", "page", "pain", "painful", "paint", "painting", "pair", "palace", "pale", "pan", "paper", "parallel", "parcel", "parent", "park", "parliament", "part", "participle", "particular", "partner", "party", "pass", "passage", "passenger", "past", "pastry",
 "path", "patience", "patient", "pattern", "pause", "pay", "payment", "peace", "peaceful", "pen", "pence", "pencil", "people", "pepper", "per", "perfect", "perform", "perhaps", "period", "permission", "permit", "person", "personal", "persuade", "pet", "petrol", "photograph", "photography", "phrase", "physical",
 "piano", "pick", "picture", "piece", "pig", "pile", "pilot", "pin", "pink", "pipe", "pity", "place", "plain", "plan", "plane", "plant", "plastic", "plate", "play", "pleasant", "please", "pleased", "pleasure", "plenty", "plural", "pocket", "poem", "poet", "poetry", "point",
 "pointed", "poison", "poisonous", "pole", "police", "polish", "polite", "political", "politician", "politics", "pool", "poor", "popular", "popularity", "population", "port", "position", "possess", "possession", "possibility", "possible", "possibly", "post", "pot", "potato", "pound", "pour", "powder", "power", "powerful",
 "practical", "practice", "practise", "praise", "pray", "prayer", "precious", "preparation", "prepare", "presence", "present", "preserve", "president", "press", "pressure", "pretend", "pretty", "prevent", "price", "prickly", "pride", "priest", "prince", "principle", "print", "prison", "prisoner", "private", "prize", "probability",
 "probably", "problem", "process", "procession", "produce", "product", "production", "profession", "profit", "promise", "pronounce", "pronunciation", "proof", "proper", "property", "protect", "protection", "protective", "proud", "prove", "provide", "provision", "provisions", "public", "pull", "pump", "punish", "punishment", "pupil", "pure",
 "purple", "purpose", "push", "put", "quality", "quantity", "quarrel", "quarter", "queen", "question", "quick", "quiet", "quite", "rabbit", "race", "radio", "railway", "rain", "raise", "range", "rank", "rapid", "rare", "rat", "rate", "rather", "raw", "reach", "read", "ready",
 "real", "really", "reason", "reasonable", "receive", "recent", "recently", "recognition", "recognize", "record", "red", "reduce", "reduction", "refusal", "refuse", "regard", "regular", "related", "relation", "relative", "religion", "religious", "remain", "remark", "remember", "remind", "remove", "rent", "repair", "repeat",
 "reply", "report", "represent", "representative", "republic", "request", "respect", "respectful", "responsible", "rest", "restaurant", "result", "return", "reward", "rice", "rich", "rid", "ride", "right", "ring", "ripe", "rise", "risk", "river", "road", "rob", "rock", "rod", "roll", "roof",
 "room", "root", "rope", "rose", "rough", "round", "row", "royal", "rub", "rubber", "rude", "ruin", "rule", "ruler", "run", "rush", "sad", "safe", "safety", "sail", "sale", "salt", "same", "sand", "satisfaction", "satisfactory", "satisfy", "save", "say", "scale",
 "scatter", "scene", "scenery", "school", "science", "scientific", "scientist", "scissors", "screw", "sea", "search", "season", "seat", "second", "secrecy", "secret", "secretary", "see", "seed", "seem", "seize", "sell", "send", "sensation", "sense", "senseless", "sensible", "sensitive", "sentence", "separate",
 "serious", "servant", "serve", "service", "set", "settle", "seven", "seventh", "several", "severe", "sew", "sex", "sexual", "shade", "shadow", "shake", "shall", "shame", "shape", "share", "sharp", "she", "sheep", "sheet", "shelf", "shell", "shelter", "shield", "shine", "ship",
 "shirt", "shock", "shoe", "shoot", "shop", "shopkeeper", "shore", "short", "shot", "should", "shoulder", "shout", "show", "shut", "sick", "side", "sideways", "sight", "sign", "signal", "signature", "silence", "silent", "silk", "silly", "silver", "similar", "similarity", "simple", "since",
 "sincere", "sing", "single", "singular", "sink", "sister", "sit", "situation", "six", "sixth", "size", "skilful", "skill", "skin", "skirt", "sky", "slave", "sleep", "slide", "slight", "slip", "slippery", "slope", "slow", "small", "smell", "smile", "smoke", "smooth", "snake",
 "snow", "so", "soap", "social", "society", "sock", "soft", "soil", "soldier", "solemn", "solid", "some", "somehow", "someone", "something", "sometimes", "somewhere", "son", "song", "soon", "sore", "sorrow", "sorry", "sort", "soul", "sound", "soup", "sour", "south", "southern",
 "space", "spacecraft", "spade", "speak", "spear", "special", "specialist", "speech", "speed", "spell", "spend", "spin", "spirit", "spite", "splendid", "split", "spoil", "spoon", "sport", "spot", "spread", "spring", "square", "stage", "stair", "stamp", "stand", "standard", "star", "start",
 "state", "station", "stay", "steady", "steal", "steam", "steel", "steep", "stem", "step", "stick", "sticky", "stiff", "still", "sting", "stitch", "stomach", "stone", "stop", "store", "storm", "story", "straight", "strange", "stranger", "stream", "street", "strength", "stretch", "strike",
 "string", "stroke", "strong", "structure", "struggle", "student", "study", "stupid", "style", "subject", "substance", "subtract", "succeed", "success", "successful", "such", "suck", "sudden", "suffer", "sugar", "suggest", "suit", "suitable", "sum", "summer", "sun", "supper", "supply", "support", "suppose",
 "sure", "surface", "surprise", "surround", "swallow", "swear", "sweep", "sweet", "swell", "swim", "swing", "sword", "sympathetic", "sympathy", "system", "table", "tail", "take", "talk", "tall", "taste", "tax", "taxi", "tea", "teach", "team", "tear", "tear", "telephone", "television",
 "tell", "temper", "temperature", "temple", "tend", "tendency", "tender", "tennis", "tense", "tent", "terrible", "terror", "test", "than", "thank", "that", "the", "theatre", "their", "theirs", "them", "themselves", "then", "there", "therefore", "these", "they", "thick", "thief", "thin",
 "thing", "think", "third", "thirst", "thirsty", "this", "thorough", "those", "though", "thought", "thousand", "thousandth", "thread", "threat", "threaten", "three", "throat", "through", "throw", "thumb", "thunder", "thus", "ticket", "tidy", "tie", "tiger", "tight", "time", "timetable", "tin",
 "tire", "title", "to", "tobacco", "today", "toe", "together", "tomorrow", "tongue", "tonight", "too", "tool", "tooth", "top", "total", "touch", "tour", "tourist", "towards", "tower", "town", "toy", "track", "trade", "traffic", "train", "translate", "transparent", "trap", "travel",
 "treat", "treatment", "tree", "tremble", "tribe", "trick", "trip", "tropical", "trouble", "trousers", "true", "trunk", "trust", "truth", "try", "tube", "tune", "turn", "twice", "twist", "type", "typical", "tyre", "ugly", "uncle", "under", "understand", "undo", "uniform", "union",
 "unit", "unite", "universal", "universe", "university", "until", "up", "upper", "upright", "upset", "upside-down", "upstairs", "urge", "urgent", "us", "use", "useful", "useless", "usual", "valley", "valuable", "value", "variety", "various", "vary", "vegetable", "vehicle", "verb", "very", "victory",
 "view", "village", "violence", "violent", "visit", "voice", "vote", "vowel", "voyage", "wages", "waist", "wait", "waiter", "wake", "walk", "wall", "wander", "want", "war", "warm", "warmth", "warn", "wash", "waste", "watch", "water", "wave", "way", "we", "weak",
 "wealth", "weapon", "wear", "weather", "weave", "wedding", "week", "weekly", "weigh", "weight", "welcome", "well", "west", "western", "wet", "what", "whatever", "wheat", "wheel", "when", "whenever", "where", "whether", "which", "whichever", "while", "whip", "whisper", "whistle", "white",
 "who", "whoever", "whole", "why", "wicked", "wide", "widespread", "width", "wife", "wild", "will", "willing", "win", "wind", "wind", "window", "wine", "wing", "winter", "wire", "wisdom", "wise", "wish", "with", "within", "without", "witness", "woman", "wonder", "wood",
 "wooden", "wool", "woollen", "word", "work", "world", "worm", "worry", "worse", "worship", "worst", "worth", "worthy", "worthy", "would", "wound", "wrap", "wreck", "wrist", "write", "wrong", "wrongdoing", "yard", "year", "yearly", "yellow", "yes", "yesterday", "yet", "you",
 "young", "your", "yours", "yourself", "youth", "zero",}; // 2196
        #endregion LDOCE

        public static string[] FooSymbol = new string[] { "~", "!", @"""", "@", "#", "$", "%", ":", "&", "?", ".", ",", ";", "*", "\r", "\n", "(", ")" };

        public void EstimateVocabulare(string text, Dictionary<string, int> currentWords, int allWordCount, ICollection vocabular, string vocabularName)
        {
            TreeNode tn = this.tvDictionaries.Nodes.Add("xx");
            int allThousandWords = 0;
            int countThousandWords = 0;
            foreach (string s in vocabular)
            {
                if (currentWords.ContainsKey(s))
                {
                    ++countThousandWords;
                    allThousandWords += currentWords[s];
                    tn.Nodes.Add(s + " (" + currentWords[s].ToString() + ")");
                }
            }
            int precent = allThousandWords * 100 / allWordCount;
            tn.Text = string.Format("Words from '{0}': {1}.   Cover: {2}% ({3}/{4})",
                vocabularName, countThousandWords, precent, allWordCount, allThousandWords);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.tvWords.Nodes[0] == null) return;
            string key = this.textBox1.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(key))
            {
                this.tvWords.SelectedNode = null;
                return;
            }
            foreach (TreeNode tn in this.tvWords.Nodes[0].Nodes)
            {
                if (tn.Text.StartsWith(key))
                {
                    this.tvWords.SelectedNode = tn;
                    break;
                }
            }
        }

        private void EstimatorForm_SizeChanged(object sender, EventArgs e)
        {
            this.panelLeft.Width = this.Width / 2;
        }

        private void splitter1_Paint(object sender, PaintEventArgs e)
        {
            Ul.DrawVertical(sender as Splitter, e);
        }

        #region context menu
        private void menuItemCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(GetCurrentWord());
        }

        string GetCurrentWord()
        {
            TreeView tree = this.tvWords.Focused ? this.tvWords : this.tvDictionaries;
            if (tree.SelectedNode != null && tree.SelectedNode.Level > 0)
            {
                string text = tree.SelectedNode.Text;
                if (!text.Contains(" ("))
                    return text;
                else
                    return text.Substring(0, text.IndexOf(" ("));
            }
            return "";
        }

        private void miFindCitations_Click(object sender, EventArgs e)
        {
            string word = this.GetCurrentWord();
            if (string.IsNullOrEmpty(word)) return;
            FindForm searcher = new FindForm();
            searcher.InitAndSearch(this.FullText, word);
            searcher.Show(this);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            string word = GetCurrentWord();
            miCopy.Enabled =
            miFindCitations.Enabled = !string.IsNullOrEmpty(word);
            miFindCitations.Text = string.Format("&Find Citations for '{0}'", word);
        } 
        #endregion

        private void tvWords_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.TreeView.SelectedNode = e.Node;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
        //string[] MyVocabulare = new string[] { "casino", "money", "caviar", "vodka" };
        //string[] UnderStudy = new string[] { "rose", "heart", "nectar", "love" };

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace Chinese
{
    /// <summary>
    /// Class
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The default list.
        /// </summary>
        public const string defaultList = "wordlist.xml";

        public string WordListFileName = "wordlist.xml";
        private TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        public List<Word> wordList = new List<Word>();
        public List<Word> nextWordList = new List<Word>();

        private Random rnd = new Random();
        private int word_idx = 0;
        private int nextword_idx = 0;
        private Word word_curr;
        private string previous_fs = "";

        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            ReadFromXmlList();
            word_idx = 0;
            word_curr = (Word)wordList[word_idx];
            nextWordList = wordList.ToList();
            show_word();
        }

        // for the selected part of speech set the words in the list
        /// <summary>
        /// Filter the selected index changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Filters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filters.CheckedItems.Count > 0)
            {
                if (String.Compare(previous_fs, Filters.CheckedItems[0].ToString()) != 0)
                {
                    previous_fs = Filters.SelectedItem.ToString();
                    nextWordList = wordList.Where(w => w.PartOfSpeech.Contains(previous_fs)).Select(w => w).ToList();
                }

                previous_fs = Filters.SelectedItem.ToString();
                nextWordList = wordList.Where(w => w.PartOfSpeech.Contains(previous_fs)).Select(w => w).ToList();
            }
        }

        // from the selected part of speech get a word at random
        /// <summary>
        /// random word click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void rndWord_Click(object sender, EventArgs e)
        {
            if (String.Compare(previous_fs, Filters.CheckedItems[0].ToString()) != 0)
            {
                previous_fs = Filters.SelectedItem.ToString();
                nextWordList = wordList.Where(w => w.PartOfSpeech.Contains(previous_fs)).Select(w => w).ToList();
            }

            nextword_idx = rnd.Next(0, nextWordList.Count);

            word_curr = nextWordList.ElementAt(nextword_idx);
            word_curr.PartOfSpeech[0] = previous_fs;
            show_word();
        }

        // save word list to new XML file
        /// <summary>
        /// Saves the words to XML.
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        public void SaveWordsToXml(List<Word> list, string fileName)
        {
            string fn = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "data", fileName);
            using (XmlWriter writer = XmlWriter.Create(fn))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Words");
                foreach (var word in list)
                {
                    writer.WriteStartElement("Word");
                    writer.WriteElementString("Pinyin", word.Pinyin);
                    writer.WriteElementString("Character", word.Character);
                    writer.WriteElementString("Meaning", String.Join(",", word.Meaning));
                    writer.WriteElementString("PartOfSpeech", String.Join(",", word.PartOfSpeech));
                    writer.WriteElementString("Formality", word.Formality);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
        }

        // show_word: fill the Pinyin text box
        /// <summary>
        /// show_words the.
        /// </summary>
        private void show_word()
        {
            this.MeaningTextBox.Text = "";
            this.CharactersTextBox.Text = "";
            set_Filters();
            if (this.Pinyin.Checked)
            {
                this.PinYinTextBox.Text = textInfo.ToTitleCase(word_curr.Pinyin.ToString());
            }
            else
            {
                this.PinYinTextBox.Text = "";
            }

            if (this.Meaning.Checked)
            {
                add_Meaning();
            }
            if (this.Hanzi.Checked)
            {
                add_Hanzi();
            }
        }

        // determine which words to include in the list
        /// <summary>
        /// set_S the filters.
        /// </summary>
        private void set_Filters()
        {
            for (int gi = 0; gi < word_curr.PartOfSpeech.Length; gi++)
            {
                if (previous_fs == "")
                {
                    previous_fs = word_curr.PartOfSpeech[0];
                }
                for (int i = 0; i < Filters.Items.Count; i++)
                {
                    if (String.Equals(previous_fs, Filters.Items[i].ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        Filters.SetItemChecked(i, true);
                    }
                    else
                    {
                        Filters.SetItemChecked(i, false);
                    }
                }
            }
        }

        // here we add the Hanzi character to the field in the form
        /// <summary>
        /// add_S the hanzi.
        /// </summary>
        private void add_Hanzi()
        {
            this.CharactersTextBox.Text = word_curr.Character.ToString();
        }

        // the meaning of the words to the form
        /// <summary>
        /// add_S the meaning.
        /// </summary>
        private void add_Meaning()
        {
            this.MeaningTextBox.Text = String.Join(",", word_curr.Meaning);
        }

        // respond to the check-box on the form clear the pinyin text box redraw the form
        /// <summary>
        /// Pinyin_S the checked changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Pinyin_CheckedChanged(object sender, EventArgs e)
        {
            //this.PinYinTextBox.Text = "";
            show_word();
        }

        // respond to the check box on the form
        /// <summary>
        /// Meaning_S the checked changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Meaning_CheckedChanged(object sender, EventArgs e)
        {
            show_word();
        }

        // respond to the check box on the form
        /// <summary>
        /// Hanzi_S the checked changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Hanzi_CheckedChanged(object sender, EventArgs e)
        {
            show_word();
        }

        // respond to the Search Button on the form find all words from the list that match the
        // search criteria
        /// <summary>
        /// Search_S the click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Search_Click(object sender, EventArgs e)
        {
            foreach (var w in wordList)
            {
                for (int gi = 0; gi < w.Meaning.Length; gi++)
                    if (String.Equals(w.Meaning[0], this.SearchBox.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        word_curr = w;
                        show_word();
                        return;
                    }
            }
        }

        // read the master XML file
        /// <summary>
        /// Reads the from XML list.
        /// </summary>
        private void ReadFromXmlList()
        {
            XmlTextReader xmlReader;
            this.wordList = new List<Word>();

            if (WordListFileName.Equals(""))
            {
                xmlReader = new XmlTextReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\data", defaultList));
            }
            else
            {
                xmlReader = new XmlTextReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\data", WordListFileName));
            }

            DataSet ds = new DataSet();

            //read the XML data
            try
            {
                ds.ReadXml(xmlReader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
            {
                DataRow dr = ds.Tables[0].Rows[r];
                Word w = new Word();
                w.Pinyin = dr.ItemArray[0].ToString();
                w.Character = dr.ItemArray[1].ToString();
                w.Meaning = new string[] { String.Join(",", dr.ItemArray[2]) };
                w.PartOfSpeech = new string[] { String.Join(",", dr.ItemArray[3]) };
                w.Formality = dr.ItemArray[4].ToString();
                wordList.Add(w);
            }

            List<Word> sortedList = wordList.OrderBy(w => w.Pinyin).ToList();
            wordList = sortedList;
            this.bindingSource1.DataSource = ds.Tables[0];
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            xmlReader.Close();
        }

        /// <summary>
        /// News the tool strip menu item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddWordsForm f = new AddWordsForm(this, this.wordList);
            f.Show();
        }

        /// <summary>
        /// Opens the tool strip menu item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Application.StartupPath;
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                WordListFileName = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Deletes the tool strip menu item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult messageBoxResult = MessageBox.Show(this, "Are you sure?", "Delete Confirmation", MessageBoxButtons.YesNo);
            if (messageBoxResult == DialogResult.Yes) { }
        }

        /// <summary>
        /// Adds the book1 unit1 text1.
        /// </summary>
        /*private void AddBook1Unit1Text1()
        {
            List<Word> wordList = new List<Word>();

            //string P, string C, string M, string PS, string F, int B, int U, int K
            wordList.Add(new Word("Nǐ", "你", new string[] { "You" }, new string[] { "Pronoun" }, "", 1, 1, 1));
            wordList.Add(new Word("jiao", "叫", new string[] { "Call", "Shout", "be called", "make", "bray", "order" }, new string[] { "Verb" }, "", 1, 1, 1));
            wordList.Add(new Word("Shénme", "什么", new string[] { "What" }, new string[] { "Adjective" }, "", 1, 1, 1));
            wordList.Add(new Word("Míngzì", "名字", new string[] { "Name", "First Name" }, new string[] { "Noun" }, "", 1, 1, 1));
            wordList.Add(new Word("Hǎo", "好", new string[] { "Good", "Well", "Fine", "Okay", "Love", "Like" }, new string[] { "Adjective", "Adverb", "Verb" }, "", 1, 1, 1));
            wordList.Add(new Word("Wǒ", "我", new string[] { "I", "Me", "Myself" }, new string[] { "Pronoun" }, "", 1, 1, 1));
            wordList.Add(new Word("Shì", "是", new string[] { "Be", "Exist", "Right", "Correct" }, new string[] { "Auxillary Verb", "Verb", "Adjective" }, "", 1, 1, 1));
            wordList.Add(new Word("Zhè", "这", new string[] { "This", "These", "Now" }, new string[] { "Pronoun", "Adverb" }, "", 1, 1, 1));
            wordList.Add(new Word("De", "的", new string[] { "Of", "Aim", "Possessive Particle", "Really and truly", "Ablative Cause Suffix", "-self" }, new string[] { "Preposition", "Noun", "Particle", "Adverb", "Auxillary Verb", "Suffix" }, "", 1, 1, 1));
            wordList.Add(new Word("Zhōngwén", "中文", new string[] { "Chinese" }, new string[] { "Noun" }, "", 1, 1, 1));
            wordList.Add(new Word("Mǎ", "马", new string[] { "Horse", "Twenty-first" }, new string[] { "Noun", "Adjective" }, "", 1, 1, 1));
            wordList.Add(new Word("Yǒu", "有", new string[] { "Have", "Be", "Exist" }, new string[] { "Verb" }, "", 1, 1, 1));
            wordList.Add(new Word("Yě", "也", new string[] { "Also", "Too" }, new string[] { "Adverb" }, "", 1, 1, 1));
            wordList.Add(new Word("Hěn", "很", new string[] { "very", "quite", "extremely", "passing", "strong", "strongly", "mighty", "bitterly", "spanking", "parlous" }, new string[] { "Adverb" }, "", 1, 1, 1));
            wordList.Add(new Word("Gāoxìng", "高兴", new string[] { "Happy", "Glad", "Joy", "be willing to", "glee", "in a cherrful mood" }, new string[] { "Adjective", "Verb", "Noun", "Adverb" }, "false", 1, 1, 1));
            wordList.Add(new Word("Rènshì", "认识", new string[] { "understanding", "knowledge", "cognition", "recognize", "know", "acquaint", "be familiar", "be acquainted with" }, new string[] { "Noun", "Verb" }, "", 1, 1, 1));
            wordList.Add(new Word("Kǎ'ěr", "卡尔", new string[] { "Karl" }, new string[] { "Proper Noun" }, "", 1, 1, 1));
            wordList.Add(new Word("Kāng ài lǐ", "康爱李", new string[] { "a person's name" }, new string[] { "Proper Noun" }, "", 1, 1, 1));
            wordList.Add(new Word("Déguó", "德国", new string[] { "Germany" }, new string[] { "Proper Noun" }, "", 1, 1, 1));

            this.SaveWordsToXml(wordList, "book1-unit1-text1.xml");
        }*/

        /// <summary>
        /// Adds the book1 unit1 text2.
        /// </summary>
/*        private void AddBook1Unit1Text2()
        {
            List<Word> wordList = new List<Word>();

            //string P, string C, string M, string PS, string F, int B, int U, int K
            wordList.Add(new Word("Nín", "您", new string[] { "You" }, new string[] { "Pronoun" }, "Formal", 1, 1, 2));
            wordList.Add(new Word("Guìxìng", "贵姓", new string[] { "(honorable) Surname" }, new string[] { "Noun" }, "", 1, 1, 2));
            wordList.Add(new Word("Lǎoshī", "老师", new string[] { "Teacher" }, new string[] { "Noun" }, "", 1, 1, 2));
            wordList.Add(new Word("Xìng", "姓", new string[] { "Surname" }, new string[] { "Noun" }, "", 1, 1, 2));
            wordList.Add(new Word("Ne", "呢", new string[] { "Modal Particle" }, new string[] { "Adjective", "Particle", }, "", 1, 1, 2));
            wordList.Add(new Word("Huānyíng", "欢迎", new string[] { "Welcome", "Greeting", "Reception", "Compliment", "Complimentary" }, new string[] { "Noun", "Verb", "Adjective" }, "", 1, 1, 2));
            wordList.Add(new Word("Lái", "来", new string[] { "come", "arrive", "take place", "occur", "nigh", "crop up", "coming", "incoming" }, new string[] { "Verb", "Adjective" }, "", 1, 1, 2));
            wordList.Add(new Word("Xièxiè", "谢谢", new string[] { "Thanks" }, new string[] { "Noun" }, "", 1, 1, 2));
            wordList.Add(new Word("Zàijiàn", "再见", new string[] { "Goodbye" }, new string[] { "Verb" }, "", 1, 1, 2));
            wordList.Add(new Word("Jiàn", "见", new string[] { "See", "Meet", "Refer", "Catch sight of", "Be exposed to", "View", "Opinion", "Humble", "Bashful", "Blushful", "Blushing", "Retiring" }, new string[] { "Verb", "Noun", "Adjective" }, "", 1, 1, 2));
            wordList.Add(new Word("Wáng", "王", new string[] { "A surname", "King", "Monarch" }, new string[] { "Proper Noun", "Noun" }, "", 1, 1, 2));
            wordList.Add(new Word("Kāng", "康", new string[] { "A surname", "Peaceful", "Spongy" }, new string[] { "Proper Noun", "Adjective" }, "", 1, 1, 2));
            wordList.Add(new Word("Běijīng", "北京", new string[] { "Beijing", "Peking" }, new string[] { "Proper Noun" }, "", 1, 1, 2));

            this.SaveWordsToXml(wordList, "book1-unit1-text2.xml");
        }*/

        /// <summary>
        /// Handles the Click event of the bindingNavigatorMoveNextItem control.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <a onclick="return false;" href="EventArgs" originaltag="see"> EventArgs </a>
        /// instance containing the event data.
        /// </param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for bindingNavigatorMoveNextItem_Click
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (nextword_idx < nextWordList.Count - 1)
            {
                nextword_idx++;
            }
            else
            {
                nextword_idx = 0;
            }

            word_curr = nextWordList.ElementAt(nextword_idx);
            word_curr.PartOfSpeech[0] = previous_fs;
            show_word();
        }

        /// <summary>
        /// bindings the navigator add new item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddWordsForm addWordsForm = new AddWordsForm(this, this.wordList);
            addWordsForm.Show();
        }

        /// <summary>
        /// Handles the Click event of the bindingNavigatorDeleteItem control.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <a onclick="return false;" href="EventArgs" originaltag="see"> EventArgs </a>
        /// instance containing the event data.
        /// </param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for bindingNavigatorDeleteItem_Click
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult messageBoxResult = MessageBox.Show(this, "Are you sure?", "Delete Confirmation", MessageBoxButtons.YesNo);
            if (messageBoxResult == DialogResult.Yes) { }
        }

        /// <summary>
        /// export menu item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult messageBoxResult = MessageBox.Show(this, "Are you sure?", "Export Confirmation", MessageBoxButtons.YesNo);
            if (messageBoxResult == DialogResult.Yes)
            {
                openFileDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "data");
                //Application.StartupPath;
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    string importListFileName = openFileDialog.FileName;
                    this.ExportFromXmlList(wordList, importListFileName);
                }
            }
        }

        /// <summary>
        /// Exports the data from xml list.
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        private void ExportFromXmlList(List<Word> list, string fileName)
        {
            string fn = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "data", fileName);
            using (XmlWriter writer = XmlWriter.Create(fn))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Words");
                foreach (var word in list)
                {
                    writer.WriteStartElement("Word");
                    writer.WriteElementString("Pinyin", word.Pinyin);
                    writer.WriteElementString("Character", word.Character);
                    writer.WriteElementString("Meaning", String.Join(",", word.Meaning));
                    writer.WriteElementString("PartOfSpeech", String.Join(",", word.PartOfSpeech));
                    writer.WriteElementString("Formality", word.Formality);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
        }

        /// <summary>
        /// imports the tool strip menu item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult messageBoxResult = MessageBox.Show(this, "Are you sure?", "Import Confirmation", MessageBoxButtons.YesNo);
            if (messageBoxResult == DialogResult.Yes)
            {
                openFileDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "data");
                //Application.StartupPath;
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    string importListFileName = openFileDialog.FileName;
                    this.ImportFromXmlList(importListFileName);
                }
            }
        }

        /// <summary>
        /// Imports data from xml file.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        private void ImportFromXmlList(string fileName)
        {
            XmlTextReader xmlReader;
            xmlReader = new XmlTextReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\data", fileName));

            DataSet ds = new DataSet();

            //read the XML data
            try
            {
                ds.ReadXml(xmlReader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
            {
                DataRow dr = ds.Tables[0].Rows[r];
                Word w = new Word();
                w.Character = dr.ItemArray[0].ToString();
                w.Pinyin = dr.ItemArray[2].ToString();
                w.Meaning = new string[] { String.Join(",", dr.ItemArray[3]) };
                w.PartOfSpeech = new string[] { "" };
                w.Formality = "";
                wordList.Add(w);
            }

            this.bindingSource1.DataSource = ds.Tables[0];
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            xmlReader.Close();
            this.SaveWordsToXml(wordList, "wordlist.xml");
        }

        /// <summary>
        /// Delete_S the click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult messageBoxResult = MessageBox.Show(this, "Are you sure?", "Delete Confirmation", MessageBoxButtons.YesNo);
            if (messageBoxResult == DialogResult.Yes)
            {
                this.wordList.Remove(this.word_curr);
                this.SaveWordsToXml(wordList, "wordlist.xml");
                this.ReadFromXmlList();
            }
        }

        /// <summary>
        /// bindings the navigator move previous item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (nextword_idx > 0)
            {
                nextword_idx--;
            }
            else
            {
                nextword_idx = 0;
            }

            word_curr = nextWordList.ElementAt(nextword_idx);
            word_curr.PartOfSpeech[0] = previous_fs;
            show_word();
        }
    }
}
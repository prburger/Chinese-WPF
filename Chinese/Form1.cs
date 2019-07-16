using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Chinese
{

    public partial class Form1 : Form
    {
        public const string defaultList = "wordlist.xml";
        public string WordListFileName = "";
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        public List<Word> wordList = new List<Word>();
        public List<Word> nextWordList = new List<Word>();

        Random rnd = new Random();
        int word_idx = 0;
        int nextword_idx = 0;
        Word word_curr;
        string previous_fs = "";

        public Form1()
        {
            InitializeComponent();
            build_xml_list();
            word_idx = 0;
            word_curr = (Word)wordList[word_idx];
            nextWordList = wordList.ToList();
            show_word();
        }

        //
        // for the selected part of speech 
        // set the words in the list 
        //
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

        //
        // from the selected part of speech 
        // get the previous word in the list 
        //
        private void prevWord_Click(object sender, EventArgs e)
        {
            if (nextword_idx > 0)
            {
                nextword_idx--;
            }
            else
            {
                nextword_idx = nextWordList.Count - 1;
            }
            word_curr = nextWordList.ElementAt(nextword_idx);
            word_curr.PartOfSpeech[0] = previous_fs;
            show_word();

        }

        //
        // from the selected part of speech 
        // get the next word in the list 
        //
        private void nextWord_Click(object sender, EventArgs e)
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

        //
        // from the selected part of speech 
        // get a word at random
        //
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

        //
        // show_word: fill the Pinyin text box 
        //
        private void show_word()
        {
            this.PinYinTextBox.Text = textInfo.ToTitleCase(word_curr.Pinyin.ToString());
            this.MeaningTextBox.Text = "";
            this.CharactersTextBox.Text = "";
            set_Filters();
            if (this.Pinyin.Checked)
            {
                this.PinYinTextBox.Text = word_curr.Pinyin.ToString();
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

        // here we add the Hanzi character to form
        private void add_Hanzi()
        {
            this.CharactersTextBox.Text = word_curr.Character.ToString();
        }

        // the meaning of the words to the form
        private void add_Meaning()
        {
            this.MeaningTextBox.Text = word_curr.Meaning.ToString();
        }

        // respond to the checkbox on the form
        private void Pinyin_CheckedChanged(object sender, EventArgs e)
        {
            show_word();
        }

        // respond to the checkbox on the form
        private void Meaning_CheckedChanged(object sender, EventArgs e)
        {
            show_word();
        }

        // respond to the checkbox on the form
        private void Hanzi_CheckedChanged(object sender, EventArgs e)
        {
            show_word();
        }

        // respond to the Search Button on the form
        // find all words from the list that match the search criteria
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
        
        // read the master xml file
        private void build_xml_list()
        {
            XmlTextReader xmlReader;

            if (WordListFileName.Equals(""))
            {                
                xmlReader = new XmlTextReader(defaultList);
            }
            else
            {
                xmlReader = new XmlTextReader(WordListFileName);
            }

            DataSet ds = new DataSet();

            //read the xml data
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
                w.Meaning[0] = dr.ItemArray[2].ToString();
                w.PartOfSpeech[0] = dr.ItemArray[3].ToString();
                w.Formality = dr.ItemArray[4].ToString();
                wordList.Add(w);
            }
            xmlReader.Close();

        }
        
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddWordsForm f = new AddWordsForm(this);
            f.Show();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            openFileDialog.InitialDirectory = Application.StartupPath;
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                WordListFileName = openFileDialog.FileName;
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddBook1Text1() {
            //string P, string C, string M, string PS, string F, int B, int K
            wordList.Add(new Word("Nǐ", "你", new string[] { "You" }, new string[] { "Pronoun" }, "", 1, 1));
            wordList.Add(new Word("jiao", "叫", new string[] { "Call","Shout","be called", "make","bray","order" }, new string[] { "Verb" }, "", 1, 1));
            wordList.Add(new Word("Shénme", "什么", new string[] { "What" }, new string[] { "Adjective" }, "", 1, 1));
            wordList.Add(new Word("Míngzì", "名字", new string[] { "Name","First Name" }, new string[] { "Noun" }, "", 1, 1));
            wordList.Add(new Word("Hǎo", "好", new string[] { "Good","Well","Fine","Okay","Love","Like" }, new string[] { "Adjective","Adverb","Verb" }, "", 1, 1));
            wordList.Add(new Word("Wǒ", "我", new string[] { "I" ,"Me","Myself"}, new string[] { "Pronoun" }, "", 1, 1));
            wordList.Add(new Word("Shì", "是", new string[] { "Be","Exist","Right","Correct" }, new string[] { "Auxillary Verb","Verb","Adjective" }, "", 1, 1));
            wordList.Add(new Word("Zhè", "这", new string[] { "This","These","Now" }, new string[] { "Pronoun","Adverb" }, "", 1, 1));
            wordList.Add(new Word("De", "的", new string[] { "Of","Aim","Possessive Particle" ,"Really and truly", "Ablative Cause Suffix","-self"}, new string[] { "Preposition","Noun","Particle","Adverb","Auxillary Verb","Suffix" }, "", 1, 1));
            wordList.Add(new Word("Zhōngwén", "中文", new string[] { "Chinese" }, new string[] { "Noun" }, "", 1, 1));
            wordList.Add(new Word("Mǎ", "马", new string[] { "Horse","Twenty-first" }, new string[] { "Noun","Adjective" }, "", 1, 1));
            wordList.Add(new Word("Yǒu", "有", new string[] { "Have","Be","Exist" }, new string[] { "Verb" }, "", 1, 1));
            wordList.Add(new Word("Yě", "也", new string[] { "Also","Too" }, new string[] { "Adverb" }, "", 1, 1));
            wordList.Add(new Word("Hěn", "很", new string[] { "very", "quite", "extremely", "passing", "strong", "strongly", "mighty", "bitterly", "spanking", "parlous" }, new string[] { "Adverb" }, "", 1, 1));
            wordList.Add(new Word("Gāoxìng", "高兴", new string[] { "Happy", "Glad" ,"Joy","be willing to","glee","in a cherrful mood"},new string[] { "Adjective" ,"Verb", "Noun", "Adverb"}, "false", 1, 1));
            wordList.Add(new Word("Rènshì", "认识", new string[] { "understanding", "knowledge", "cognition", "recognize", "know", "acquaint", "be familiar", "be acquainted with" }, new string[] { "Noun","Verb" }, "", 1, 1));
            wordList.Add(new Word("Kǎ'ěr", "卡尔", new string[] { "Karl" }, new string[] { "Proper Noun" }, "", 1, 1));
            wordList.Add(new Word("Kāng ài lǐ", "康爱李", new string[] { "a person's name" }, new string[] { "Proper Noun" }, "", 1, 1));
            wordList.Add(new Word("Déguó", "德国", new string[] { "Germany" }, new string[] { "Proper Noun" }, "", 1, 1));      
        }

        private void AddBook1Text2() { }
        private void AddBook1Text3() { }
        private void AddBook2Text1() { }
        private void AddBook2Text2() { }
        private void AddBook2Text3() { }
        private void AddBook3Text1() { }
        private void AddBook3Text2() { }
        private void AddBook3Text3() { }
        private void AddBook4Text1() { }
        private void AddBook4Text2() { }
        private void AddBook4Text3() { }
        private void AddBook5Text1() { }
        private void AddBook5Text2() { }
        private void AddBook5Text3() { }

        private void BooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBook1Text1();
            AddBook1Text2();
            AddBook1Text3();
            AddBook2Text1();
            AddBook2Text2();
            AddBook2Text3();
            AddBook3Text1();
            AddBook3Text2();
            AddBook3Text3();
            AddBook4Text1();
            AddBook4Text2();
            AddBook4Text3();
            AddBook5Text1();
            AddBook5Text2();
            AddBook5Text3();
        }
    }    
}

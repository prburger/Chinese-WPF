using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Xml;
using System.Collections;
using System.Collections.Generic;

namespace Chinese
{
    public struct Word
    {
        public Word(string T, string C, string M, string PS, string F)
        {
            Pinyin = T;
            Character = C;
            Meaning = M;
            Formality = F;
            PartOfSpeech = PS;
        }

        public string Pinyin { get; set; }
        public string Character { get; set; }
        public string Meaning { get; set; }
        public string PartOfSpeech { get; set; }
        public string Formality { get; set; }
    }

    public partial class Form1 : Form
    {
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
            word_curr.PartOfSpeech = previous_fs;
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
            word_curr.PartOfSpeech = previous_fs;
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
            word_curr.PartOfSpeech = previous_fs;
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

        private void set_Filters()
        {
            for (int gi = 0; gi < word_curr.PartOfSpeech.Length; gi++)
            {
                if (previous_fs == "")
                {
                    previous_fs = word_curr.PartOfSpeech;
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

        private void add_Hanzi()
        {
            this.CharactersTextBox.Text = word_curr.Character.ToString();
        }

        private void add_Meaning()
        {
            this.MeaningTextBox.Text = word_curr.Meaning.ToString();
        }

        private void Pinyin_CheckedChanged(object sender, EventArgs e)
        {
            show_word();
        }

        private void Meaning_CheckedChanged(object sender, EventArgs e)
        {
            show_word();
        }

        private void Hanzi_CheckedChanged(object sender, EventArgs e)
        {
            show_word();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            foreach (var w in wordList)
            {
                for (int gi = 0; gi < w.Meaning.Length; gi++)
                    if (String.Equals(w.Meaning, this.SearchBox.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        word_curr = w;
                        show_word();
                        return;
                    }
            }
        }

        private void build_xml_list()
        {
            XmlTextReader xmlreader = new XmlTextReader("wordlist.xml");
            DataSet ds = new DataSet();

            //read the xml data
            try
            {
                ds.ReadXml(xmlreader);
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
                w.Meaning = dr.ItemArray[2].ToString();
                w.PartOfSpeech = dr.ItemArray[3].ToString();
                w.Formality = dr.ItemArray[4].ToString();
                wordList.Add(w);
            }
            xmlreader.Close();

        }
    }
}

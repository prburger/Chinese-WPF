using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Chinese
{
    /// <summary>
    /// The add words form.
    /// </summary>
    public partial class AddWordsForm : Form
    {
        private Form1 _parent;
        private List<Word> WordList = new List<Word>();

        /// <summary>
        /// Initializes a new instance of the <see cref="AddWordsForm" /> class.
        /// </summary>
        /// <param name="f">
        /// The f.
        /// </param>
        public AddWordsForm(Form1 f, List<Word> wordList)
        {
            InitializeComponent();
            this.WordList = wordList;
            this._parent = f;
        }

        // Write word list to XML
        /// <summary>
        /// Saves the button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string defaultList = "wordlist.xml";
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "data", defaultList);
            this.AddToWordList_Click(sender, e);
            /*    saveFileDialog.InitialDirectory = Application.StartupPath;
                DialogResult r = saveFileDialog.ShowDialog();
                if (r.Equals(true))
                {*/
            using (XmlWriter writer = XmlWriter.Create(fileName))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Words");
                foreach (var word in WordList)
                {
                    writer.WriteStartElement("Word");

                    writer.WriteElementString("Pinyin", word.Pinyin);
                    writer.WriteElementString("Character", word.Character);
                    writer.WriteElementString("Meaning", String.Concat(word.Meaning));
                    writer.WriteElementString("PartOfSpeech", String.Concat(word.PartOfSpeech));
                    writer.WriteElementString("Formality", word.Formality);
                    writer.WriteElementString("Book", word.Book.ToString());
                    writer.WriteElementString("Unit", word.Unit.ToString());
                    writer.WriteElementString("Kewen", word.Kewen.ToString());

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            this.Close();
            this._parent.Show();
        }

        //}

        // Close the form
        /// <summary>
        /// Cancels the button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this._parent.Show();
        }

        // Store the new word in the list
        /// <summary>
        /// Adds the to word list_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void AddToWordList_Click(object sender, EventArgs e)
        {
            Word w = new Word();
            w.Pinyin = this.Pinyin.Text;
            w.Character = this.Hanzi.Text;
            w.Meaning = new string[] { this.Meaning.Text };
            w.Formality = this.Formality.Text;
            w.PartOfSpeech = new string[] { this.PartOfSpeech.Text };
            if (this.Book.Text != "")
            {
                w.Book = Int32.Parse(this.Book.Text);
            }
            else
            {
                w.Book = 0;
            }
            if (this.Unit.Text != "")
            {
                w.Unit = Int32.Parse(this.Unit.Text);
            }
            else
            {
                w.Unit = 0;
            }
            if (this.Kewen.Text != "")
            {
                w.Kewen = Int32.Parse(this.Kewen.Text);
            }
            else
            {
                w.Kewen = 0;
            }
            WordList.Add(w);
        }
    }
}
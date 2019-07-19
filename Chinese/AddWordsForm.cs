using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Chinese
{
    public partial class AddWordsForm : Form
    {
        Form1 _parent;
        List<Word> WordList = new List<Word>();

        public AddWordsForm(Form1 f)
        {
            InitializeComponent();
            this._parent = f;
        }

        // Write word list to XML
        private void SaveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = Application.StartupPath;
            DialogResult r = saveFileDialog.ShowDialog();
            if (r.Equals(true))
            {
                using (XmlWriter writer = XmlWriter.Create(saveFileDialog.FileName))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Words");
                    foreach(var word in WordList)
                    {
                        writer.WriteStartElement("Word");

                        writer.WriteElementString("Pinyin", word.Pinyin);
                        writer.WriteElementString("Character", word.Character);
                        writer.WriteElementString("Meaning", word.Meaning.ToString());
                        writer.WriteElementString("PartOfSpeech", word.PartOfSpeech.ToString());
                        writer.WriteElementString("Formality", word.Formality);
                        writer.WriteElementString("Book", word.Book.ToString());
                        writer.WriteElementString("Kewen", word.Kewen.ToString());

                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }

            }               
        }
       
        // Close the form
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this._parent.Show();
        }

        // Store the new word in the list
        private void AddToWordList_Click(object sender, EventArgs e)
        {
            Word w = new Word();
            w.Pinyin = this.Pinyin.Text;
            w.Character = this.Hanzi.Text;
            w.Meaning = new string[] { this.Meaning.Text };
            w.Formality = this.Formality.Text;
            w.PartOfSpeech = new string[] { this.PartOfSpeech.Text };
            w.Book = Int32.Parse(this.Book.Text);
            w.Kewen = Int32.Parse(this.Kewen.Text);
            WordList.Add(w);
        }
    }
}

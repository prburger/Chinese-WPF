using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinese
{
    public class Word
    {
        public Word() { }

        public Word(string P, string C, string[] M, string[] PS, string F)
        {
            this.Pinyin = P;
            this.Character = C;
            this.Meaning = M;
            this.PartOfSpeech = PS;
            this.Formality = F;
            this.Book = 0;
            this.Unit = 0;
            this.Kewen = 0;
        }

        public Word(string P, string C, string[] M, string[] PS, string F, int B, int U, int K)
        {
            this.Pinyin = P;
            this.Character = C;
            this.Meaning = M;
            this.Formality = F;
            this.PartOfSpeech = PS;
            this.Book = B;
            this.Unit = U;
            this.Kewen = K;
        }

        public string Pinyin { get; set; }
        public string Character { get; set; }
        public string[] Meaning { get; set; }
        public string[] PartOfSpeech { get; set; }
        public string Formality { get; set; }
        public int Book { get; set; }
        public int Unit { get; set; }
        public int Kewen { get; set; }
    }
}

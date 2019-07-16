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

        public Word(string P, string C, string M, string PS, string F)
        {
            Pinyin = P;
            Character = C;
            Meaning = M;
            Formality = F;
            PartOfSpeech = PS;
            Book = 0;
            Kewen = 0;
        }

        public Word(string P, string C, string[] M, string[] PS, string F, int B, int K)
        {
            Pinyin = P;
            Character = C;
            Meaning = M;
            Formality = F;
            PartOfSpeech = PS;
            Book = B;
            Kewen = K;
        }

        public string Pinyin { get; set; }
        public string Character { get; set; }
        public string Meaning { get; set; }
        public string PartOfSpeech { get; set; }
        public string Formality { get; set; }
        public int Book { get; set; }
        public int Kewen { get; set; }
    }
}

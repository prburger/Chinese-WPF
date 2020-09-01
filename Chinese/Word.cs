namespace Chinese
{
    /// <summary>
    /// The word.
    /// </summary>
    public class Word
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Word" /> class.
        /// </summary>
        public Word() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Word" /> class.
        /// </summary>
        /// <param name="P">
        /// The p.
        /// </param>
        /// <param name="C">
        /// The c.
        /// </param>
        /// <param name="M">
        /// The m.
        /// </param>
        /// <param name="PS">
        /// The p s.
        /// </param>
        /// <param name="F">
        /// The f.
        /// </param>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Word" /> class.
        /// </summary>
        /// <param name="P">
        /// The p.
        /// </param>
        /// <param name="C">
        /// The c.
        /// </param>
        /// <param name="M">
        /// The m.
        /// </param>
        /// <param name="PS">
        /// The p s.
        /// </param>
        /// <param name="F">
        /// The f.
        /// </param>
        /// <param name="B">
        /// The b.
        /// </param>
        /// <param name="U">
        /// The u.
        /// </param>
        /// <param name="K">
        /// The k.
        /// </param>
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

        /// <summary>
        /// Gets or sets the pinyin.
        /// </summary>
        public string Pinyin { get; set; }

        /// <summary>
        /// Gets or sets the character.
        /// </summary>
        public string Character { get; set; }

        /// <summary>
        /// Gets or sets the meaning.
        /// </summary>
        public string[] Meaning { get; set; }

        /// <summary>
        /// Gets or sets the part of speech.
        /// </summary>
        public string[] PartOfSpeech { get; set; }

        /// <summary>
        /// Gets or sets the formality.
        /// </summary>
        public string Formality { get; set; }

        /// <summary>
        /// Gets or sets the book.
        /// </summary>
        public int Book { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        public int Unit { get; set; }

        /// <summary>
        /// Gets or sets the kewen.
        /// </summary>
        public int Kewen { get; set; }
    }
}
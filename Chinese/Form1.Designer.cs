

namespace Chinese
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// 


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PinYinTextBox = new System.Windows.Forms.TextBox();
            this.MeaningTextBox = new System.Windows.Forms.TextBox();
            this.CharactersTextBox = new System.Windows.Forms.TextBox();
            this.nextWord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rndWord = new System.Windows.Forms.Button();
            this.Filters = new System.Windows.Forms.CheckedListBox();
            this.Meaning = new System.Windows.Forms.CheckBox();
            this.Hanzi = new System.Windows.Forms.CheckBox();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.prevWord = new System.Windows.Forms.Button();
            this.Pinyin = new System.Windows.Forms.CheckBox();            
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();            
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PinYinTextBox
            // 
            this.PinYinTextBox.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PinYinTextBox.Location = new System.Drawing.Point(41, 33);
            this.PinYinTextBox.Name = "PinYinTextBox";
            this.PinYinTextBox.Size = new System.Drawing.Size(623, 86);
            this.PinYinTextBox.TabIndex = 0;
            // 
            // MeaningTextBox
            // 
            this.MeaningTextBox.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeaningTextBox.Location = new System.Drawing.Point(41, 143);
            this.MeaningTextBox.Name = "MeaningTextBox";
            this.MeaningTextBox.Size = new System.Drawing.Size(623, 40);
            this.MeaningTextBox.TabIndex = 1;
            // 
            // CharactersTextBox
            // 
            this.CharactersTextBox.Font = new System.Drawing.Font("DengXian", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharactersTextBox.Location = new System.Drawing.Point(41, 246);
            this.CharactersTextBox.Name = "CharactersTextBox";
            this.CharactersTextBox.Size = new System.Drawing.Size(623, 125);
            this.CharactersTextBox.TabIndex = 2;
            // 
            // nextWord
            // 
            this.nextWord.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextWord.Location = new System.Drawing.Point(745, 371);
            this.nextWord.Name = "nextWord";
            this.nextWord.Size = new System.Drawing.Size(34, 23);
            this.nextWord.TabIndex = 3;
            this.nextWord.Text = ">";
            this.nextWord.UseVisualStyleBackColor = true;
            this.nextWord.Click += new System.EventHandler(this.nextWord_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pinyin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Meaning";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hanzi";
            // 
            // rndWord
            // 
            this.rndWord.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rndWord.Location = new System.Drawing.Point(785, 371);
            this.rndWord.Name = "rndWord";
            this.rndWord.Size = new System.Drawing.Size(31, 23);
            this.rndWord.TabIndex = 9;
            this.rndWord.Text = "?";
            this.rndWord.UseVisualStyleBackColor = true;
            this.rndWord.Click += new System.EventHandler(this.rndWord_Click);
            // 
            // Filters
            // 
            this.Filters.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filters.FormattingEnabled = true;
            this.Filters.Items.AddRange(new object[] {
            "Adjective",
            "Adverb",
            "Article",
            "Conjunction",
            "Noun",
            "Particle",
            "Phrase",
            "Preposition",
            "Pronoun",
            "Verb"});
            this.Filters.Location = new System.Drawing.Point(708, 110);
            this.Filters.Name = "Filters";
            this.Filters.Size = new System.Drawing.Size(130, 212);
            this.Filters.TabIndex = 11;
            this.Filters.SelectedIndexChanged += new System.EventHandler(this.Filters_SelectedIndexChanged);
            // 
            // Meaning
            // 
            this.Meaning.AutoSize = true;
            this.Meaning.Checked = true;
            this.Meaning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Meaning.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Meaning.Location = new System.Drawing.Point(718, 348);
            this.Meaning.Name = "Meaning";
            this.Meaning.Size = new System.Drawing.Size(67, 17);
            this.Meaning.TabIndex = 12;
            this.Meaning.Text = "Meaning";
            this.Meaning.UseVisualStyleBackColor = true;
            this.Meaning.CheckedChanged += new System.EventHandler(this.Meaning_CheckedChanged);
            // 
            // Hanzi
            // 
            this.Hanzi.AutoSize = true;
            this.Hanzi.Checked = true;
            this.Hanzi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Hanzi.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hanzi.Location = new System.Drawing.Point(718, 329);
            this.Hanzi.Name = "Hanzi";
            this.Hanzi.Size = new System.Drawing.Size(52, 17);
            this.Hanzi.TabIndex = 13;
            this.Hanzi.Text = "Hanzi";
            this.Hanzi.UseVisualStyleBackColor = true;
            this.Hanzi.CheckedChanged += new System.EventHandler(this.Hanzi_CheckedChanged);
            // 
            // SearchBox
            // 
            this.SearchBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.Location = new System.Drawing.Point(708, 33);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(130, 27);
            this.SearchBox.TabIndex = 14;
            // 
            // Search
            // 
            this.Search.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search.Location = new System.Drawing.Point(708, 66);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(53, 24);
            this.Search.TabIndex = 15;
            this.Search.Text = "&Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(705, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Part of speech";
            // 
            // prevWord
            // 
            this.prevWord.Location = new System.Drawing.Point(708, 371);
            this.prevWord.Name = "prevWord";
            this.prevWord.Size = new System.Drawing.Size(31, 23);
            this.prevWord.TabIndex = 20;
            this.prevWord.Text = "<";
            this.prevWord.UseVisualStyleBackColor = true;
            this.prevWord.Click += new System.EventHandler(this.prevWord_Click);
            // 
            // Pinyin
            // 
            this.Pinyin.AutoSize = true;
            this.Pinyin.Checked = true;
            this.Pinyin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Pinyin.Location = new System.Drawing.Point(785, 329);
            this.Pinyin.Name = "Pinyin";
            this.Pinyin.Size = new System.Drawing.Size(54, 17);
            this.Pinyin.TabIndex = 21;
            this.Pinyin.Text = "Pinyin";
            this.Pinyin.UseVisualStyleBackColor = true;
            this.Pinyin.CheckedChanged += new System.EventHandler(this.Pinyin_CheckedChanged);
            // 
            // dataSet1
            // 
            // this.wordList.DataSetName = "WordList";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(877, 25);
            this.bindingNavigator1.TabIndex = 22;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(877, 445);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.Pinyin);
            this.Controls.Add(this.prevWord);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.Hanzi);
            this.Controls.Add(this.Meaning);
            this.Controls.Add(this.Filters);
            this.Controls.Add(this.rndWord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nextWord);
            this.Controls.Add(this.PinYinTextBox);
            this.Controls.Add(this.MeaningTextBox);
            this.Controls.Add(this.CharactersTextBox);
            this.Name = "Form1";
            //((System.ComponentModel.ISupportInitialize)(this.wordList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
                
        private System.Windows.Forms.TextBox PinYinTextBox;
        private System.Windows.Forms.TextBox MeaningTextBox;
        private System.Windows.Forms.TextBox CharactersTextBox;
        private System.Windows.Forms.Button nextWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button rndWord;
        private System.Windows.Forms.CheckedListBox Filters;
        private System.Windows.Forms.CheckBox Meaning;
        private System.Windows.Forms.CheckBox Hanzi;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button prevWord;
        private System.Windows.Forms.CheckBox Pinyin;
        //private System.Data.DataSet wordList;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
    }
}


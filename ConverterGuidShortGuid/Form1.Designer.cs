namespace ConverterGuidShortGuid
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GuidTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ShortGuidTextBox = new TextBox();
            ConverterButton = new Button();
            label3 = new Label();
            ChaveCriptografiaTextBox = new TextBox();
            label4 = new Label();
            SenhaTextBox = new TextBox();
            label5 = new Label();
            SenhaCriptografadaTextBox = new TextBox();
            button1 = new Button();
            button2 = new Button();
            GuidGeradoTextBox = new TextBox();
            GerarGuidButton = new Button();
            SuspendLayout();
            // 
            // GuidTextBox
            // 
            GuidTextBox.Location = new Point(20, 47);
            GuidTextBox.Name = "GuidTextBox";
            GuidTextBox.Size = new Size(221, 23);
            GuidTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 2;
            label1.Text = "Guid";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(259, 20);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 4;
            label2.Text = "ShortGuid";
            // 
            // ShortGuidTextBox
            // 
            ShortGuidTextBox.Location = new Point(259, 47);
            ShortGuidTextBox.Name = "ShortGuidTextBox";
            ShortGuidTextBox.Size = new Size(162, 23);
            ShortGuidTextBox.TabIndex = 3;
            // 
            // ConverterButton
            // 
            ConverterButton.Location = new Point(442, 48);
            ConverterButton.Name = "ConverterButton";
            ConverterButton.Size = new Size(149, 23);
            ConverterButton.TabIndex = 5;
            ConverterButton.Text = "Converter";
            ConverterButton.UseVisualStyleBackColor = true;
            ConverterButton.Click += ConverterButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(259, 108);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 9;
            label3.Text = "Chave criptografia";
            // 
            // ChaveCriptografiaTextBox
            // 
            ChaveCriptografiaTextBox.Location = new Point(259, 135);
            ChaveCriptografiaTextBox.Name = "ChaveCriptografiaTextBox";
            ChaveCriptografiaTextBox.Size = new Size(162, 23);
            ChaveCriptografiaTextBox.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 108);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 7;
            label4.Text = "Senha ";
            // 
            // SenhaTextBox
            // 
            SenhaTextBox.Location = new Point(20, 135);
            SenhaTextBox.Name = "SenhaTextBox";
            SenhaTextBox.Size = new Size(221, 23);
            SenhaTextBox.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(432, 108);
            label5.Name = "label5";
            label5.Size = new Size(113, 15);
            label5.TabIndex = 11;
            label5.Text = "Senha criptografada";
            // 
            // SenhaCriptografadaTextBox
            // 
            SenhaCriptografadaTextBox.Location = new Point(432, 135);
            SenhaCriptografadaTextBox.Name = "SenhaCriptografadaTextBox";
            SenhaCriptografadaTextBox.Size = new Size(162, 23);
            SenhaCriptografadaTextBox.TabIndex = 10;
            // 
            // button1
            // 
            button1.Location = new Point(20, 192);
            button1.Name = "button1";
            button1.Size = new Size(149, 23);
            button1.TabIndex = 12;
            button1.Text = "Criptografar senha";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(196, 192);
            button2.Name = "button2";
            button2.Size = new Size(149, 23);
            button2.TabIndex = 13;
            button2.Text = "Descriptografar senha";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // GuidGeradoTextBox
            // 
            GuidGeradoTextBox.Location = new Point(20, 263);
            GuidGeradoTextBox.Name = "GuidGeradoTextBox";
            GuidGeradoTextBox.Size = new Size(221, 23);
            GuidGeradoTextBox.TabIndex = 14;
            // 
            // GerarGuidButton
            // 
            GerarGuidButton.Location = new Point(20, 306);
            GerarGuidButton.Name = "GerarGuidButton";
            GerarGuidButton.Size = new Size(149, 23);
            GerarGuidButton.TabIndex = 15;
            GerarGuidButton.Text = "Gerar Guid";
            GerarGuidButton.UseVisualStyleBackColor = true;
            GerarGuidButton.Click += GerarGuidButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(GerarGuidButton);
            Controls.Add(GuidGeradoTextBox);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(SenhaCriptografadaTextBox);
            Controls.Add(label3);
            Controls.Add(ChaveCriptografiaTextBox);
            Controls.Add(label4);
            Controls.Add(SenhaTextBox);
            Controls.Add(ConverterButton);
            Controls.Add(label2);
            Controls.Add(ShortGuidTextBox);
            Controls.Add(label1);
            Controls.Add(GuidTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox GuidTextBox;
        private Label label1;
        private Label label2;
        private TextBox ShortGuidTextBox;
        private Button ConverterButton;
        private Label label3;
        private TextBox ChaveCriptografiaTextBox;
        private Label label4;
        private TextBox SenhaTextBox;
        private Label label5;
        private TextBox SenhaCriptografadaTextBox;
        private Button button1;
        private Button button2;
        private TextBox GuidGeradoTextBox;
        private Button GerarGuidButton;
    }
}
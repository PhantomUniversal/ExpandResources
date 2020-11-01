namespace Screen
{
    partial class Light
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.tbView = new System.Windows.Forms.TextBox();
            this.tbWord = new System.Windows.Forms.TextBox();
            this.lbBlinking = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(686, 412);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "학습종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(686, 327);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 34);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "지우기";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(686, 291);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(60, 30);
            this.btnInput.TabIndex = 9;
            this.btnInput.Text = "입력";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // tbView
            // 
            this.tbView.AcceptsReturn = true;
            this.tbView.BackColor = System.Drawing.Color.White;
            this.tbView.Location = new System.Drawing.Point(452, 15);
            this.tbView.Multiline = true;
            this.tbView.Name = "tbView";
            this.tbView.ReadOnly = true;
            this.tbView.Size = new System.Drawing.Size(293, 257);
            this.tbView.TabIndex = 8;
            // 
            // tbWord
            // 
            this.tbWord.Font = new System.Drawing.Font("굴림", 15F);
            this.tbWord.Location = new System.Drawing.Point(452, 291);
            this.tbWord.Name = "tbWord";
            this.tbWord.Size = new System.Drawing.Size(213, 30);
            this.tbWord.TabIndex = 7;
            this.tbWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbWord_KeyDown);
            // 
            // lbBlinking
            // 
            this.lbBlinking.AutoSize = true;
            this.lbBlinking.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbBlinking.Font = new System.Drawing.Font("휴먼엑스포", 40F);
            this.lbBlinking.Location = new System.Drawing.Point(39, 115);
            this.lbBlinking.Name = "lbBlinking";
            this.lbBlinking.Size = new System.Drawing.Size(81, 60);
            this.lbBlinking.TabIndex = 6;
            this.lbBlinking.Text = "\" \"";
            // 
            // Light
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.tbView);
            this.Controls.Add(this.tbWord);
            this.Controls.Add(this.lbBlinking);
            this.Name = "Light";
            this.Text = "light";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.TextBox tbView;
        private System.Windows.Forms.TextBox tbWord;
        private System.Windows.Forms.Label lbBlinking;
    }
}
namespace XO_Game
{
    partial class GameBoard
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.GameField = new System.Windows.Forms.Panel();
            this.Message = new System.Windows.Forms.Label();
            this.PlayerFirst = new System.Windows.Forms.RadioButton();
            this.ComputerFirst = new System.Windows.Forms.RadioButton();
            this.NewGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GameField
            // 
            this.GameField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GameField.Location = new System.Drawing.Point(12, 69);
            this.GameField.Name = "GameField";
            this.GameField.Size = new System.Drawing.Size(360, 360);
            this.GameField.TabIndex = 0;
            this.GameField.Paint += new System.Windows.Forms.PaintEventHandler(this.GameField_Paint);
            this.GameField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameField_MouseClick);
            // 
            // Message
            // 
            this.Message.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Message.AutoSize = true;
            this.Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Message.Location = new System.Drawing.Point(22, 18);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(84, 20);
            this.Message.TabIndex = 1;
            this.Message.Text = "Message";
            // 
            // PlayerFirst
            // 
            this.PlayerFirst.AutoSize = true;
            this.PlayerFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayerFirst.Location = new System.Drawing.Point(187, 12);
            this.PlayerFirst.Name = "PlayerFirst";
            this.PlayerFirst.Size = new System.Drawing.Size(72, 21);
            this.PlayerFirst.TabIndex = 2;
            this.PlayerFirst.TabStop = true;
            this.PlayerFirst.Text = "Player";
            this.PlayerFirst.UseVisualStyleBackColor = true;
            this.PlayerFirst.CheckedChanged += new System.EventHandler(this.PlayerFirst_CheckedChanged);
            // 
            // ComputerFirst
            // 
            this.ComputerFirst.AutoSize = true;
            this.ComputerFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ComputerFirst.Location = new System.Drawing.Point(187, 32);
            this.ComputerFirst.Name = "ComputerFirst";
            this.ComputerFirst.Size = new System.Drawing.Size(103, 21);
            this.ComputerFirst.TabIndex = 3;
            this.ComputerFirst.TabStop = true;
            this.ComputerFirst.Text = "Compucter";
            this.ComputerFirst.UseVisualStyleBackColor = true;
            this.ComputerFirst.CheckedChanged += new System.EventHandler(this.ComputerFirst_CheckedChanged);
            // 
            // NewGame
            // 
            this.NewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewGame.Location = new System.Drawing.Point(300, 5);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(54, 48);
            this.NewGame.TabIndex = 4;
            this.NewGame.Text = "New Game";
            this.NewGame.UseVisualStyleBackColor = true;
            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 441);
            this.Controls.Add(this.NewGame);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.ComputerFirst);
            this.Controls.Add(this.PlayerFirst);
            this.Controls.Add(this.GameField);
            this.Name = "GameBoard";
            this.Text = "XO Game";
            this.Load += new System.EventHandler(this.GameBoard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel GameField;
        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.RadioButton PlayerFirst;
        private System.Windows.Forms.RadioButton ComputerFirst;
        private System.Windows.Forms.Button NewGame;
    }
}


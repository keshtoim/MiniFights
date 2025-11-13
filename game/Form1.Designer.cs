namespace game
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gameStartBtn = new System.Windows.Forms.Button();
            this.infoAboutPlayer = new System.Windows.Forms.RichTextBox();
            this.infoAboutEnemy = new System.Windows.Forms.RichTextBox();
            this.labelAboutPlayer = new System.Windows.Forms.Label();
            this.labelAboutEnemy = new System.Windows.Forms.Label();
            this.attackBtn = new System.Windows.Forms.Button();
            this.blockBtn = new System.Windows.Forms.Button();
            this.potionBtn = new System.Windows.Forms.Button();
            this.labelMap = new System.Windows.Forms.Label();
            this.infoAboutNumberOfEnemies = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Location = new System.Drawing.Point(2, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(855, 550);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // gameStartBtn
            // 
            this.gameStartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gameStartBtn.Location = new System.Drawing.Point(485, 280);
            this.gameStartBtn.Name = "gameStartBtn";
            this.gameStartBtn.Size = new System.Drawing.Size(300, 80);
            this.gameStartBtn.TabIndex = 1;
            this.gameStartBtn.Text = "Начать игру";
            this.gameStartBtn.UseVisualStyleBackColor = true;
            this.gameStartBtn.Click += new System.EventHandler(this.gameStartBtn_Click);
            // 
            // infoAboutPlayer
            // 
            this.infoAboutPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoAboutPlayer.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.infoAboutPlayer.Location = new System.Drawing.Point(863, 27);
            this.infoAboutPlayer.Name = "infoAboutPlayer";
            this.infoAboutPlayer.ReadOnly = true;
            this.infoAboutPlayer.Size = new System.Drawing.Size(190, 245);
            this.infoAboutPlayer.TabIndex = 2;
            this.infoAboutPlayer.Text = "";
            this.infoAboutPlayer.Visible = false;
            // 
            // infoAboutEnemy
            // 
            this.infoAboutEnemy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoAboutEnemy.Location = new System.Drawing.Point(1069, 27);
            this.infoAboutEnemy.Name = "infoAboutEnemy";
            this.infoAboutEnemy.ReadOnly = true;
            this.infoAboutEnemy.Size = new System.Drawing.Size(190, 245);
            this.infoAboutEnemy.TabIndex = 3;
            this.infoAboutEnemy.Text = "";
            this.infoAboutEnemy.Visible = false;
            // 
            // labelAboutPlayer
            // 
            this.labelAboutPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAboutPlayer.AutoSize = true;
            this.labelAboutPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAboutPlayer.Location = new System.Drawing.Point(858, -1);
            this.labelAboutPlayer.Name = "labelAboutPlayer";
            this.labelAboutPlayer.Size = new System.Drawing.Size(172, 25);
            this.labelAboutPlayer.TabIndex = 4;
            this.labelAboutPlayer.Text = "Данные игрока:";
            this.labelAboutPlayer.Visible = false;
            // 
            // labelAboutEnemy
            // 
            this.labelAboutEnemy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAboutEnemy.AutoSize = true;
            this.labelAboutEnemy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelAboutEnemy.Location = new System.Drawing.Point(1064, -1);
            this.labelAboutEnemy.Name = "labelAboutEnemy";
            this.labelAboutEnemy.Size = new System.Drawing.Size(159, 25);
            this.labelAboutEnemy.TabIndex = 5;
            this.labelAboutEnemy.Text = "Данные врага:";
            this.labelAboutEnemy.Visible = false;
            // 
            // attackBtn
            // 
            this.attackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.attackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.attackBtn.Location = new System.Drawing.Point(957, 278);
            this.attackBtn.Name = "attackBtn";
            this.attackBtn.Size = new System.Drawing.Size(190, 45);
            this.attackBtn.TabIndex = 6;
            this.attackBtn.Text = "Атака";
            this.attackBtn.UseVisualStyleBackColor = true;
            this.attackBtn.Visible = false;
            this.attackBtn.Click += new System.EventHandler(this.attackBtn_Click);
            // 
            // blockBtn
            // 
            this.blockBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blockBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.blockBtn.Location = new System.Drawing.Point(957, 329);
            this.blockBtn.Name = "blockBtn";
            this.blockBtn.Size = new System.Drawing.Size(190, 45);
            this.blockBtn.TabIndex = 7;
            this.blockBtn.Text = "Блокирование";
            this.blockBtn.UseVisualStyleBackColor = true;
            this.blockBtn.Visible = false;
            this.blockBtn.Click += new System.EventHandler(this.blockBtn_Click);
            // 
            // potionBtn
            // 
            this.potionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.potionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.potionBtn.Location = new System.Drawing.Point(957, 380);
            this.potionBtn.Name = "potionBtn";
            this.potionBtn.Size = new System.Drawing.Size(190, 45);
            this.potionBtn.TabIndex = 8;
            this.potionBtn.Text = "Зелье";
            this.potionBtn.UseVisualStyleBackColor = true;
            this.potionBtn.Visible = false;
            this.potionBtn.Click += new System.EventHandler(this.potionBtn_Click);
            // 
            // labelMap
            // 
            this.labelMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMap.AutoSize = true;
            this.labelMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMap.Location = new System.Drawing.Point(-3, -1);
            this.labelMap.Name = "labelMap";
            this.labelMap.Size = new System.Drawing.Size(79, 25);
            this.labelMap.TabIndex = 9;
            this.labelMap.Text = "Карта:";
            this.labelMap.Visible = false;
            // 
            // infoAboutNumberOfEnemies
            // 
            this.infoAboutNumberOfEnemies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.infoAboutNumberOfEnemies.AutoSize = true;
            this.infoAboutNumberOfEnemies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.infoAboutNumberOfEnemies.Location = new System.Drawing.Point(970, 440);
            this.infoAboutNumberOfEnemies.Name = "infoAboutNumberOfEnemies";
            this.infoAboutNumberOfEnemies.Size = new System.Drawing.Size(167, 36);
            this.infoAboutNumberOfEnemies.TabIndex = 10;
            this.infoAboutNumberOfEnemies.Text = "Побеждено врагов: \r\n0 из 0";
            this.infoAboutNumberOfEnemies.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.infoAboutNumberOfEnemies.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.infoAboutNumberOfEnemies);
            this.Controls.Add(this.labelMap);
            this.Controls.Add(this.potionBtn);
            this.Controls.Add(this.blockBtn);
            this.Controls.Add(this.attackBtn);
            this.Controls.Add(this.labelAboutEnemy);
            this.Controls.Add(this.labelAboutPlayer);
            this.Controls.Add(this.infoAboutEnemy);
            this.Controls.Add(this.infoAboutPlayer);
            this.Controls.Add(this.gameStartBtn);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "MiniFights";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button gameStartBtn;
        private System.Windows.Forms.RichTextBox infoAboutPlayer;
        private System.Windows.Forms.RichTextBox infoAboutEnemy;
        private System.Windows.Forms.Label labelAboutPlayer;
        private System.Windows.Forms.Label labelAboutEnemy;
        private System.Windows.Forms.Button attackBtn;
        private System.Windows.Forms.Button blockBtn;
        private System.Windows.Forms.Button potionBtn;
        private System.Windows.Forms.Label labelMap;
        private System.Windows.Forms.Label infoAboutNumberOfEnemies;
    }
}


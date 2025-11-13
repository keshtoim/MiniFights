namespace game
{
    partial class BattleForm
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
            this.lblPlayer = new System.Windows.Forms.Label();
            this.lblEnemy = new System.Windows.Forms.Label();
            this.lblPotions = new System.Windows.Forms.Label();
            this.btnAttack = new System.Windows.Forms.Button();
            this.btnBlock = new System.Windows.Forms.Button();
            this.btnPotion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Location = new System.Drawing.Point(24, 9);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(60, 16);
            this.lblPlayer.TabIndex = 0;
            this.lblPlayer.Text = "lblPlayer";
            // 
            // lblEnemy
            // 
            this.lblEnemy.AutoSize = true;
            this.lblEnemy.Location = new System.Drawing.Point(169, 9);
            this.lblEnemy.Name = "lblEnemy";
            this.lblEnemy.Size = new System.Drawing.Size(63, 16);
            this.lblEnemy.TabIndex = 1;
            this.lblEnemy.Text = "lblEnemy";
            // 
            // lblPotions
            // 
            this.lblPotions.AutoSize = true;
            this.lblPotions.Location = new System.Drawing.Point(314, 9);
            this.lblPotions.Name = "lblPotions";
            this.lblPotions.Size = new System.Drawing.Size(66, 16);
            this.lblPotions.TabIndex = 2;
            this.lblPotions.Text = "lblPotions";
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(27, 149);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(80, 60);
            this.btnAttack.TabIndex = 3;
            this.btnAttack.Text = "Атака";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // btnBlock
            // 
            this.btnBlock.Location = new System.Drawing.Point(172, 149);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(80, 60);
            this.btnBlock.TabIndex = 4;
            this.btnBlock.Text = "Блок";
            this.btnBlock.UseVisualStyleBackColor = true;
            this.btnBlock.Click += new System.EventHandler(this.btnBlock_Click);
            // 
            // btnPotion
            // 
            this.btnPotion.Location = new System.Drawing.Point(317, 149);
            this.btnPotion.Name = "btnPotion";
            this.btnPotion.Size = new System.Drawing.Size(80, 60);
            this.btnPotion.TabIndex = 5;
            this.btnPotion.Text = "Зелье";
            this.btnPotion.UseVisualStyleBackColor = true;
            this.btnPotion.Click += new System.EventHandler(this.btnPotion_Click);
            // 
            // BattleForm
            // 
            this.ClientSize = new System.Drawing.Size(428, 221);
            this.Controls.Add(this.btnPotion);
            this.Controls.Add(this.btnBlock);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.lblPotions);
            this.Controls.Add(this.lblEnemy);
            this.Controls.Add(this.lblPlayer);
            this.Name = "BattleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Label lblEnemy;
        private System.Windows.Forms.Label lblPotions;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.Button btnBlock;
        private System.Windows.Forms.Button btnPotion;
    }
}
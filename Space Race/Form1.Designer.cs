namespace Space_Race
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
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.player1ScoreLabel = new System.Windows.Forms.Label();
            this.player2ScoreLabel = new System.Windows.Forms.Label();
            this.stopWatchLabel = new System.Windows.Forms.Label();
            this.gameLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.player1Info = new System.Windows.Forms.Label();
            this.player2Info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 10;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // player1ScoreLabel
            // 
            this.player1ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.player1ScoreLabel.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1ScoreLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.player1ScoreLabel.Location = new System.Drawing.Point(12, 671);
            this.player1ScoreLabel.Name = "player1ScoreLabel";
            this.player1ScoreLabel.Size = new System.Drawing.Size(100, 67);
            this.player1ScoreLabel.TabIndex = 0;
            this.player1ScoreLabel.Text = "0";
            this.player1ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player2ScoreLabel
            // 
            this.player2ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.player2ScoreLabel.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2ScoreLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.player2ScoreLabel.Location = new System.Drawing.Point(555, 671);
            this.player2ScoreLabel.Name = "player2ScoreLabel";
            this.player2ScoreLabel.Size = new System.Drawing.Size(100, 67);
            this.player2ScoreLabel.TabIndex = 1;
            this.player2ScoreLabel.Text = "0";
            this.player2ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stopWatchLabel
            // 
            this.stopWatchLabel.BackColor = System.Drawing.Color.Transparent;
            this.stopWatchLabel.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopWatchLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.stopWatchLabel.Location = new System.Drawing.Point(544, -5);
            this.stopWatchLabel.Name = "stopWatchLabel";
            this.stopWatchLabel.Size = new System.Drawing.Size(122, 67);
            this.stopWatchLabel.TabIndex = 2;
            this.stopWatchLabel.Text = "0";
            this.stopWatchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameLabel
            // 
            this.gameLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameLabel.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gameLabel.Location = new System.Drawing.Point(-1, 9);
            this.gameLabel.Name = "gameLabel";
            this.gameLabel.Size = new System.Drawing.Size(667, 67);
            this.gameLabel.TabIndex = 3;
            this.gameLabel.Text = "Space Race";
            this.gameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoLabel
            // 
            this.infoLabel.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.infoLabel.Location = new System.Drawing.Point(2, 76);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(667, 28);
            this.infoLabel.TabIndex = 4;
            this.infoLabel.Text = "Press Space Bar to Start or K for Controls ";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player1Info
            // 
            this.player1Info.BackColor = System.Drawing.Color.Transparent;
            this.player1Info.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Info.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.player1Info.Location = new System.Drawing.Point(1, 147);
            this.player1Info.Name = "player1Info";
            this.player1Info.Size = new System.Drawing.Size(332, 244);
            this.player1Info.TabIndex = 5;
            this.player1Info.Text = "Player 1 ";
            this.player1Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.player1Info.Visible = false;
            // 
            // player2Info
            // 
            this.player2Info.BackColor = System.Drawing.Color.Transparent;
            this.player2Info.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2Info.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.player2Info.Location = new System.Drawing.Point(334, 147);
            this.player2Info.Name = "player2Info";
            this.player2Info.Size = new System.Drawing.Size(332, 244);
            this.player2Info.TabIndex = 6;
            this.player2Info.Text = "Player 2";
            this.player2Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.player2Info.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::Space_Race.Properties.Resources.spacePhoto;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(667, 738);
            this.Controls.Add(this.player2Info);
            this.Controls.Add(this.player1Info);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.stopWatchLabel);
            this.Controls.Add(this.player2ScoreLabel);
            this.Controls.Add(this.player1ScoreLabel);
            this.Controls.Add(this.gameLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label player1ScoreLabel;
        private System.Windows.Forms.Label player2ScoreLabel;
        private System.Windows.Forms.Label stopWatchLabel;
        private System.Windows.Forms.Label gameLabel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Label player1Info;
        private System.Windows.Forms.Label player2Info;
    }
}


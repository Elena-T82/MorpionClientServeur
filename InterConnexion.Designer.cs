namespace Morpion
{
    partial class InterConnexion
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
            this.btnClient = new System.Windows.Forms.Button();
            this.BtnServer = new System.Windows.Forms.Button();
            this.TbAdresse = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClient
            // 
            this.btnClient.Location = new System.Drawing.Point(321, 49);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(81, 23);
            this.btnClient.TabIndex = 0;
            this.btnClient.Text = "Rejoindre";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // BtnServer
            // 
            this.BtnServer.Location = new System.Drawing.Point(126, 89);
            this.BtnServer.Name = "BtnServer";
            this.BtnServer.Size = new System.Drawing.Size(276, 25);
            this.BtnServer.TabIndex = 1;
            this.BtnServer.Text = "Créer serveur";
            this.BtnServer.UseVisualStyleBackColor = true;
            this.BtnServer.Click += new System.EventHandler(this.BtnServer_Click);
            // 
            // TbAdresse
            // 
            this.TbAdresse.Location = new System.Drawing.Point(126, 49);
            this.TbAdresse.Name = "TbAdresse";
            this.TbAdresse.Size = new System.Drawing.Size(189, 20);
            this.TbAdresse.TabIndex = 2;
            // 
            // InterConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 163);
            this.Controls.Add(this.TbAdresse);
            this.Controls.Add(this.BtnServer);
            this.Controls.Add(this.btnClient);
            this.Name = "InterConnexion";
            this.Text = "Connexion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button BtnServer;
        private System.Windows.Forms.TextBox TbAdresse;
    }
}
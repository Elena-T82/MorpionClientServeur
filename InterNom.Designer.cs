namespace Morpion
{
    partial class InterNom
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
            this.BtnValider = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNomJoueur = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnValider
            // 
            this.BtnValider.Location = new System.Drawing.Point(307, 60);
            this.BtnValider.Name = "BtnValider";
            this.BtnValider.Size = new System.Drawing.Size(75, 23);
            this.BtnValider.TabIndex = 0;
            this.BtnValider.Text = "Valider";
            this.BtnValider.UseVisualStyleBackColor = true;
            this.BtnValider.Click += new System.EventHandler(this.BtnValider_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Entrez votre nom :";
            // 
            // tbNomJoueur
            // 
            this.tbNomJoueur.Location = new System.Drawing.Point(136, 62);
            this.tbNomJoueur.Name = "tbNomJoueur";
            this.tbNomJoueur.Size = new System.Drawing.Size(154, 20);
            this.tbNomJoueur.TabIndex = 2;
            // 
            // InterNom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 132);
            this.Controls.Add(this.tbNomJoueur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnValider);
            this.Name = "InterNom";
            this.Text = "Nom du joueur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnValider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNomJoueur;
    }
}
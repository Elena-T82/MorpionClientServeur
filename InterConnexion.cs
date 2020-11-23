using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morpion
{
    public partial class InterConnexion : Form
    {
        public InterConnexion()
        {
            InitializeComponent();
        }

        private void BtnServer_Click(object sender, EventArgs e)
        {
            InfoJoueur.CaracJoueur = "X";
            InfoJoueur.Adresse = TbAdresse.Text;

            InterNom interNom = new InterNom();
            interNom.Owner = this;
            this.Hide();
            interNom.ShowDialog();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            InfoJoueur.CaracJoueur = "O";
            InfoJoueur.Adresse = TbAdresse.Text;


            InterNom interNom = new InterNom();
            interNom.Owner = this;
            this.Hide();
            interNom.ShowDialog();
        }

        
    }
}

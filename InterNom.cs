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
    public partial class InterNom : Form
    {
        public InterNom()
        {
            InitializeComponent();
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(tbNomJoueur.Text))
            {
                MessageBox.Show("Veuillez entrer un nom.");
            }
            else
            {
                InfoJoueur.nomJoueur = tbNomJoueur.Text;

                Jeu interJeu = new Jeu();
                interJeu.Owner = this;
                this.Hide();

                if(InfoJoueur.CaracJoueur == "X")
                    interJeu.ConnexionServer();
                else
                    interJeu.ConnexionClient();


                interJeu.ActuNom();

                interJeu.ShowDialog();

                //methode inserer nom;
            }
        }
    }
}

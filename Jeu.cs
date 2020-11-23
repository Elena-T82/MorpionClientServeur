using System;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Morpion
{
    public partial class Jeu : Form
    {
        private SoundPlayer music2;

        public Socket sktClient;
        public Socket sktServeur;

        IPAddress ipAddr;
        IPEndPoint ipEndPt;

        delegate void AfficherTexte(string p_Texte);

        string CaracJoueur = InfoJoueur.CaracJoueur;


        public Jeu()
        {
            
            InitializeComponent();
            music2 = new SoundPlayer("fond.wav");
            music2.PlayLooping();

        }

        public void ActuNom()
        {
            if(CaracJoueur == "X")
            {
                score1.Text = InfoJoueur.nomJoueur;
                score1.ForeColor = Color.Red;

            }
            else
            {
                score2.Text = InfoJoueur.nomJoueur;
                score2.ForeColor = Color.Red;

                byte[] msg = Encoding.Unicode.GetBytes(score2.Text);
                StateObject.workSocket.Send(msg);
            }
        }

        
       
        
        private void cmdQuite_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //On débloque les cases du morpion si il est encore possible de jouer dessus.
        public void DebloquerCase()
        {
            if (cmdCase1.Text == "")
                cmdCase1.Enabled = true;
            else
                cmdCase1.Enabled = false;

            if (cmdCase2.Text == "")
                cmdCase2.Enabled = true;
            else
                cmdCase2.Enabled = false;

            if (cmdCase3.Text == "")
                cmdCase3.Enabled = true;
            else
                cmdCase3.Enabled = false;

            if (cmdCase4.Text == "")
                cmdCase4.Enabled = true;
            else
                cmdCase4.Enabled = false;

            if (cmdCase5.Text == "")
                cmdCase5.Enabled = true;
            else
                cmdCase5.Enabled = false;

            if (cmdCase6.Text == "")
                cmdCase6.Enabled = true;
            else
                cmdCase6.Enabled = false;

            if (cmdCase7.Text == "")
                cmdCase7.Enabled = true;
            else
                cmdCase7.Enabled = false;

            if (cmdCase8.Text == "")
                cmdCase8.Enabled = true;
            else
                cmdCase8.Enabled = false;

            if (cmdCase9.Text == "")
                cmdCase9.Enabled = true;
            else
                cmdCase9.Enabled = false;

        }

        //On bloque les cases une fois que le joueur à jouer. Elles seront débloqués lorsque l'adversaire aura joué.
        public void BloquerCase()
        {
            cmdCase1.Enabled = false;
            cmdCase2.Enabled = false;
            cmdCase3.Enabled = false;
            cmdCase4.Enabled = false;
            cmdCase5.Enabled = false;
            cmdCase6.Enabled = false;
            cmdCase7.Enabled = false;
            cmdCase8.Enabled = false;
            cmdCase9.Enabled = false;


            //Si on a un vainqueur, on enregistre le résultat dans un fichier texte.
            if (vainqueur.Text != "")
            {
                //Comme il s'agit du chemin absolu, lorsque l'application tentera d'écrire dans le fichier texte les résultats, l'application va générer une erreur. J'ai essayé de mettre un chemin relatif, sans succès.
                
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"C:\Users\elena\OneDrive - Cégep de La Pocatière\Session 2\Structure de données\Morpion\Morpion JvJ - Fonctionne - Ip a la main\Morpion\bin\Debug\resultat.txt", true))
                {
                    file.WriteLine(vainqueur.Text + " (" + DateTime.Now.ToString() + ")");
                }
            }

        }

        //Méthode pour vérifier si un des 2 joueurs a gagné.
        public void VerifGagnant()
        {
            //gagnant ligne horizontale
            if ((cmdCase1.Text == cmdCase2.Text) && (cmdCase1.Text == cmdCase3.Text) && !String.IsNullOrWhiteSpace(cmdCase1.Text))
            {
                if (cmdCase1.Text == "X")
                    vainqueur.Text = score1.Text + " a gagné !";
                else
                    vainqueur.Text = score2.Text + " a gagné !";

                vainqueur.ForeColor = Color.Red;


                BloquerCase();
            }

            else if ((cmdCase4.Text == cmdCase5.Text) && (cmdCase4.Text == cmdCase6.Text) && !String.IsNullOrWhiteSpace(cmdCase4.Text))
            {
                if (cmdCase4.Text == "X")
                    vainqueur.Text = score1.Text + " a gagné !";
                else
                    vainqueur.Text = score2.Text + " a gagné !";

                vainqueur.ForeColor = Color.Red;

                BloquerCase();

            }

            else if ((cmdCase7.Text == cmdCase8.Text) && (cmdCase7.Text == cmdCase9.Text) && !String.IsNullOrWhiteSpace(cmdCase7.Text))
            {
                if (cmdCase7.Text == "X")
                    vainqueur.Text = score1.Text + " a gagné !";
                else
                    vainqueur.Text = score2.Text + " a gagné !";

                vainqueur.ForeColor = Color.Red;

                BloquerCase();

            }


            //gagnant ligne verticale
            else if ((cmdCase1.Text == cmdCase4.Text) && (cmdCase1.Text == cmdCase7.Text) && !String.IsNullOrWhiteSpace(cmdCase1.Text))
            {
                if (cmdCase1.Text == "X")
                    vainqueur.Text = score1.Text + " a gagné !";
                else
                    vainqueur.Text = score2.Text + " a gagné !";

                vainqueur.ForeColor = Color.Red;

                BloquerCase();

            }

            else if ((cmdCase2.Text == cmdCase5.Text) && (cmdCase2.Text == cmdCase8.Text) && !String.IsNullOrWhiteSpace(cmdCase2.Text))
            {
                if (cmdCase2.Text == "X")
                    vainqueur.Text = score1.Text + " a gagné !";
                else
                    vainqueur.Text = score2.Text + " a gagné !";

                vainqueur.ForeColor = Color.Red;

                BloquerCase();

            }

            else if ((cmdCase3.Text == cmdCase6.Text) && (cmdCase3.Text == cmdCase9.Text) && !String.IsNullOrWhiteSpace(cmdCase3.Text))
            {
                if (cmdCase3.Text == "X")
                    vainqueur.Text = score1.Text + " a gagné !";
                else
                    vainqueur.Text = score2.Text + " a gagné !";

                vainqueur.ForeColor = Color.Red;

                BloquerCase();

            }


            //gagnant diagonale
            else if ((cmdCase1.Text == cmdCase5.Text) && (cmdCase1.Text == cmdCase9.Text) && !String.IsNullOrWhiteSpace(cmdCase1.Text))
            {
                if (cmdCase1.Text == "X")
                    vainqueur.Text = score1.Text + " a gagné !";
                else
                    vainqueur.Text = score2.Text + " a gagné !";

                vainqueur.ForeColor = Color.Red;

                BloquerCase();

            }

            else if ((cmdCase3.Text == cmdCase5.Text) && (cmdCase3.Text == cmdCase7.Text) && !String.IsNullOrWhiteSpace(cmdCase3.Text))
            {
                if (cmdCase3.Text == "X")
                    vainqueur.Text = score1.Text + " a gagné !";
                else
                    vainqueur.Text = score2.Text + " a gagné !";

                vainqueur.ForeColor = Color.Red;

                BloquerCase();

            }
        }

        //A chaque click de case, on bloque toutes les cases jusqu'au coup de l'autre joueur. On actualise le texte sur lequel le joueur a joué puis envoie de coup à l'adversaire. Quand le joueur a joué, on verifie s'il a gagné. 
        private void cmdCase1_Click(object sender, EventArgs e)
        {
            BloquerCase();

            cmdCase1.Text = CaracJoueur;

            cmdCase1.Enabled = false;

            byte[] msg = Encoding.Unicode.GetBytes("1");
            StateObject.workSocket.Send(msg);

            VerifGagnant();
        }

        private void cmdCase2_Click(object sender, EventArgs e)
        {
            BloquerCase();

            cmdCase2.Text = CaracJoueur;

            cmdCase2.Enabled = false;

            byte[] msg = Encoding.Unicode.GetBytes("2");
            StateObject.workSocket.Send(msg);
            VerifGagnant();

        }

        private void cmdCase3_Click(object sender, EventArgs e)
        {
            BloquerCase();

            cmdCase3.Text = CaracJoueur;

            cmdCase3.Enabled = false;

            byte[] msg = Encoding.Unicode.GetBytes("3");
            StateObject.workSocket.Send(msg);
            VerifGagnant();

        }

        private void cmdCase4_Click(object sender, EventArgs e)
        {
            BloquerCase();

            cmdCase4.Text = CaracJoueur;

            cmdCase4.Enabled = false;

            byte[] msg = Encoding.Unicode.GetBytes("4");
            StateObject.workSocket.Send(msg);
            VerifGagnant();

        }

        private void cmdCase5_Click(object sender, EventArgs e)
        {
            BloquerCase();

            cmdCase5.Text = CaracJoueur;

            cmdCase5.Enabled = false;

            byte[] msg = Encoding.Unicode.GetBytes("5");
            StateObject.workSocket.Send(msg);
            VerifGagnant();

        }

        private void cmdCase6_Click(object sender, EventArgs e)
        {
            BloquerCase();

            cmdCase6.Text = CaracJoueur;

            cmdCase6.Enabled = false;

            byte[] msg = Encoding.Unicode.GetBytes("6");
            StateObject.workSocket.Send(msg);
            VerifGagnant();

        }

        private void cmdCase7_Click(object sender, EventArgs e)
        {
            BloquerCase();

            cmdCase7.Text = CaracJoueur;

            cmdCase7.Enabled = false;

            byte[] msg = Encoding.Unicode.GetBytes("7");
            StateObject.workSocket.Send(msg);
            VerifGagnant();

        }

        private void cmdCase8_Click(object sender, EventArgs e)
        {
            BloquerCase();

            cmdCase8.Text = CaracJoueur;

            cmdCase8.Enabled = false;

            byte[] msg = Encoding.Unicode.GetBytes("8");
            StateObject.workSocket.Send(msg);
            VerifGagnant();

        }

        private void cmdCase9_Click(object sender, EventArgs e)
        {
            BloquerCase();

            cmdCase9.Text = CaracJoueur;

            cmdCase9.Enabled = false;

            byte[] msg = Encoding.Unicode.GetBytes("9");
            StateObject.workSocket.Send(msg);
            VerifGagnant();

        }

       

        //Méthode de connexion pour devenir server
        public void ConnexionServer()
        {

            this.Text += " - En Mode Serveur";

            ipAddr = IPAddress.Parse(InfoJoueur.Adresse);
            ipEndPt = new IPEndPoint(ipAddr, 4510);
            sktServeur = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sktServeur.Bind(ipEndPt);

            sktServeur.Listen(1);
            sktServeur.BeginAccept(new AsyncCallback(AcceptCallback), sktServeur);

        }

        //Méthode de connexion pour rejoindre le server
        public void ConnexionClient()
        {

            this.Text += " - En Mode Client";

            ipAddr = IPAddress.Parse(InfoJoueur.Adresse);
            ipEndPt = new IPEndPoint(ipAddr, 4510);
            sktClient = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sktClient.Connect(ipEndPt);

            StateObject state = new StateObject();
            StateObject.workSocket = sktClient;

            sktClient.BeginReceive(StateObject.buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), state);

        }


        private void AcceptCallback(IAsyncResult ar)
        {
            Socket handler = (Socket)ar.AsyncState;
            sktClient = handler.EndAccept(ar);

            StateObject state = new StateObject();
            StateObject.workSocket = sktClient;

            sktClient.BeginReceive(StateObject.buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), state);

        }
        
        private void ReceiveCallback(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = StateObject.workSocket;

            int read = handler.EndReceive(ar);

            if (read > 0)
            {
                state.sb.Append(Encoding.Unicode.GetString(StateObject.buffer, 0, read));


                if (state.sb.Length == 1)
                {
                    string msg = state.sb.ToString();

                    cmdCase1.Invoke(new AfficherTexte(ChangerTexte), msg);

                }
                else if (state.sb.Length > 1)
                {
                    string msg = state.sb.ToString();

                    score1.Invoke(new AfficherTexte(ChangerTexte), msg);

                }

                state.sb.Clear();
                handler.BeginReceive(StateObject.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);

                VerifGagnant();

            }
            else
            {
                handler.Close();
            }
        }

        //On actualise le texte des cases jouer par les joueurs.
        public void ChangerTexte(string p_Texte)
        {
            string message = "";

            if (CaracJoueur == "O")
            {
                message = "X";
            }
            else
            {
                message = "O";
            }

            if (p_Texte == "1")
                cmdCase1.Text = message;
            else if (p_Texte == "2")
                cmdCase2.Text = message;
            else if (p_Texte == "3")
                cmdCase3.Text = message;
            else if (p_Texte == "4")
                cmdCase4.Text = message;
            else if (p_Texte == "5")
                cmdCase5.Text = message;
            else if (p_Texte == "6")
                cmdCase6.Text = message;
            else if (p_Texte == "7")
                cmdCase7.Text = message;
            else if (p_Texte == "8")
                cmdCase8.Text = message;
            else if (p_Texte == "9")
                cmdCase9.Text = message;

            else
            {
                //Une fois que le server a recu le nom du client, il peut envoyer son nom au client.
                if (CaracJoueur == "X")
                {
                    score2.Text = p_Texte;
                    score2.ForeColor = Color.Red;

                    byte[] msg = Encoding.Unicode.GetBytes(score1.Text);
                    StateObject.workSocket.Send(msg);
                }

                if (CaracJoueur == "O")
                {
                    score1.Text = p_Texte;
                    score1.ForeColor = Color.Red;

                }
            }

            DebloquerCase();

        }

    }
}

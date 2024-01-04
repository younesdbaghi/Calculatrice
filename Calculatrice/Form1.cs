using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculatrice
{
    public partial class Calculatrice : Form
    {
        //------------------ Mes Méthodes --------------------//
        char op;
        float memo;
        private void Ecrire(string valeur)
        {
            if (TxtBox.Text == "0" || TxtBox.Text== "Div par 0 impossible" || TxtBox.Text == "Erreur 404 de rac")
            {
                TxtBox.Text = valeur;
            }
            else
            {
                TxtBox.Text += valeur;
            }
            Activer();
        }
        private void Desactiver()
        {  
              string[] vecteur = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" ,"coma" ,"ce" ,"c"};
              foreach(Control ctl in this.Controls)
              {
                    string x;
                    ctl.Enabled = false;
                    x = ctl.Name.Substring(3);
                    foreach(string y in vecteur)
                    {
                        if (y == x)
                        {
                            ctl.Enabled = true;
                        }
                    }
              }
        }
        private void Activer()
        {
            foreach(Control ctl in this.Controls)
            {
                if (ctl is Button && ctl.Enabled == false)
                {
                    ctl.Enabled = true;
                }
            }
        }

        private void operation(char oper)
        {
            op = oper;
            memo = float.Parse(TxtBox.Text);
            TxtBox.Text = "0";
        }
        //---------------------------------------------------//

        public Calculatrice()
        {
            InitializeComponent();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            Ecrire("0");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Ecrire("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Ecrire("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Ecrire("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Ecrire("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Ecrire("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            Ecrire("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Ecrire("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            Ecrire("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            Ecrire("9");
        }

        private void plusbtn_Click(object sender, EventArgs e)
        {
            operation('+');
        }

        private void moinsbtn_Click(object sender, EventArgs e)
        {
            operation('-');
        }

        private void divbtn_Click(object sender, EventArgs e)
        {
            operation('/');
        }

        private void multiplybtn_Click(object sender, EventArgs e)
        {
            operation('*');
        }

        private void equalbtn_Click(object sender, EventArgs e)
        {
            if (op == '+')
            {
                memo = memo + float.Parse(TxtBox.Text);
                TxtBox.Text = memo.ToString();
            }
            if (op == '-')
            {
                memo = memo - float.Parse(TxtBox.Text);
                TxtBox.Text = memo.ToString();
            }
            if (op == '*')
            {
                memo = memo * float.Parse(TxtBox.Text);
                TxtBox.Text = memo.ToString();
            }
            if (op == '/')
            {
                if (float.Parse(TxtBox.Text)==0)
                {
                    TxtBox.Text = "Div par 0 impossible";
                    // Désactiver Les Buttons Sauf 0-9
                    Desactiver();
                }
                else
                {
                    memo = memo / float.Parse(TxtBox.Text);
                    TxtBox.Text = memo.ToString();
                }
            }
            if (op == 'p')
            {
                memo = (float)(Math.Pow(memo,float.Parse(TxtBox.Text)));
                TxtBox.Text = memo.ToString();
            }
            if(op=='%')
            {
                float y = float.Parse(TxtBox.Text);
                memo = memo % y;
                TxtBox.Text = memo.ToString();
            }
        }

        private void plusmoinsbtn_Click(object sender, EventArgs e)
        {
            memo = float.Parse(TxtBox.Text);
            memo = memo * (-1);
            TxtBox.Text = memo.ToString();
        }

        private void inversebtn_Click(object sender, EventArgs e)
        {
            float x = float.Parse(TxtBox.Text);
            if (x == 0)
            {
                TxtBox.Text = "Div par 0 impossible";
                Desactiver();
            }
            else
            {
                memo = 1 / x;
                TxtBox.Text = memo.ToString();
            }
        }

        private void carrebtn_Click(object sender, EventArgs e)
        {
            memo = float.Parse(TxtBox.Text);
            memo = (float)(Math.Pow(memo, 2));
            TxtBox.Text = memo.ToString();
        }

        private void racinebtn_Click(object sender, EventArgs e)
        {
            if (memo >= 0)
            {
                memo = float.Parse(TxtBox.Text);
                memo = (float)(Math.Sqrt(memo));
                TxtBox.Text = memo.ToString();
            }
            else
            {
                TxtBox.Text = "Erreur 404 de rac";
                Desactiver();
            }
            
        }

        private void btnce_Click(object sender, EventArgs e)
        {
            TxtBox.Text = "0";
        }

        private void btnc_Click(object sender, EventArgs e)
        {
            TxtBox.Text = "0";
            memo = 0;
        }

        private void effacerbtn_Click(object sender, EventArgs e)
        {
            string x = TxtBox.Text;
            x = x.Substring(0, x.Length - 1);
            if (x.Length == 0)
            {
                TxtBox.Text = "0";
            }
            else
            {
                TxtBox.Text = x;
            }
        }

        private void btncoma_Click(object sender, EventArgs e)
        {
            string x=TxtBox.Text;
            if (x.Contains(",") == false)
            {
                TxtBox.Text = TxtBox.Text + ",";
            }
        }

        private void pourcentbtn_Click(object sender, EventArgs e)
        {
            memo = float.Parse(TxtBox.Text) / 100;
            TxtBox.Text = memo.ToString();
        }
        private void scientifiqueToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Width = 590;
            TxtBox.Width = 549;
        }

        private void standardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Width = 326;
            TxtBox.Width = 291;
        }



        private void Calculatrice_Load_1(object sender, EventArgs e)
        {
            this.Width = 326;
            TxtBox.Width = 291;
        }

        private void btnfact(object sender, EventArgs e)
        {
            memo = float.Parse(TxtBox.Text);
            float F = 1;
            for (int i = 1; i <= memo; i++)
            {
                F = F * i;
            }
            memo = F;
            TxtBox.Text = memo.ToString();
        }

        private void absbtn(object sender, EventArgs e)
        {
            float x = float.Parse(TxtBox.Text);
            memo = Math.Abs(x);
            TxtBox.Text = memo.ToString();
        }

        private void btnpw10(object sender, EventArgs e)
        {
            float x = float.Parse(TxtBox.Text);
            memo = (float)(Math.Pow(10, x));
            TxtBox.Text = memo.ToString();
        }

        private void btnxpowy(object sender, EventArgs e)
        {
            operation('p');
        }

        private void btnlog10(object sender, EventArgs e)
        {
            float x = float.Parse(TxtBox.Text); // le nombre dont on veut calculer le logarithme
            memo = (float)(Math.Log(x, 10.0)); // calcul du logarithme base 10
            TxtBox.Text = memo.ToString();
        }

        private void btnln(object sender, EventArgs e)
        {
            float x = float.Parse(TxtBox.Text); // le nombre dont on veut calculer le logarithme naturel
            memo = (float)(Math.Log(x)); // calcul du logarithme naturel
            TxtBox.Text = memo.ToString();
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            operation('%');
        }

        private void btnexp_Click(object sender, EventArgs e)
        {
            memo = float.Parse(TxtBox.Text);
            float exp = (float)(Math.Exp(memo));
            TxtBox.Text=exp.ToString();
        }
    }
}

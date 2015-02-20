using _1_4_gissa_det_hemliga_talet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1_4_gissa_det_hemliga_talet
{
    public partial class Default : System.Web.UI.Page
    {
        private SecretNumber SecretNumber
        {
            get { return Session["SecretNumber"] as SecretNumber; }
            set { Session["SecretNumber"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SecretNumber == null)
            {
                SecretNumber = new SecretNumber();
            }
        }

        protected void Send_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var input = SecretNumber.MakeGuess(int.Parse(GuessTextBox.Text));

                PrevguessLiteral.Text = String.Join(", ", SecretNumber.PreviosGuesses);

                if (input == Outcome.High)
                {
                    Message.Text = "Gissningen var för hög.";
                }
                else if (input == Outcome.Low)
                {
                    Message.Text = "Gissningen var för låg.";
                }
                else if (input == Outcome.Correct)
                {
                    Message.Text = "Du gissade rätt!";
                }
                else if (input == Outcome.PreviousGuess)
                {
                    Message.Text = "Du har redan gissat på det talet.";
                }

                if (!SecretNumber.CanMakeGuess)
                {
                    if (input != Outcome.Correct)
                    {
                        Message.Text += string.Format(" Du har använt upp dina gissningar. Det hemltiga talet är {0} , för att spela igen tryck på Slumpa ett nytt tal", SecretNumber.Number);
                        Randomize.Focus();
                    }
                    GuessTextBox.Enabled = false;
                    Send.Enabled = false;
                }

                GuessTextBox.Focus();
                Result.Visible = true;
            }
        }

        protected void Randomize_Click(object sender, EventArgs e)
        {
            GuessTextBox.Enabled = true;
            Send.Enabled = true;
            SecretNumber.Initialize();
        }
    }
}
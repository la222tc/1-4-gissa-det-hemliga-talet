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
                SecretNumber _secretNumber = new SecretNumber();
                SecretNumber = _secretNumber;
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
                    Message.Text = "Gissningen var för hög";
                    GuessTextBox.Focus();
                    Result.Visible = true;
                }
                else if (input == Outcome.Low)
                {
                    Message.Text = "Gissningen var för låg";
                    GuessTextBox.Focus();
                    Result.Visible = true;
                }
                else if (input == Outcome.Correct)
                {
                    Message.Text = "Du gissade rätt!";
                    Result.Visible = true;
                    GuessTextBox.Enabled = false;
                    Send.Enabled = false;
                }
                else if (input == Outcome.PreviousGuess)
                {
                    Message.Text = "Du har redan gissat på det talet";
                    GuessTextBox.Focus();
                    Result.Visible = true;
                }
                else if (input == Outcome.NoMoreGuesses)
                {
                    Message.Text = string.Format("Du har använt upp dina gissningar. Det hemltiga talet är {0} , för att spela igen tryck på Slumpa ett nytt tal", SecretNumber.Number);
                    Randomize.Focus();
                    Result.Visible = true;
                    GuessTextBox.Enabled = false;
                    Send.Enabled = false;
                }
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
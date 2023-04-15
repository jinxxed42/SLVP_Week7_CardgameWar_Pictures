using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Security.Claims;

namespace SLVP_Week7_CardgameWar_Pictures
{
    public partial class Form1 : Form
    {
        Game g = new Game();

        public Form1()
        {
            InitializeComponent();
            pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            pb2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {

            if (btnPlay.Text == "Start game!")
            {
                g.FillDeck();
                btnPlay.Text = "Play";
            }

            g.PlayRound();
            Update();
        }


        public void Update()
        {
            rtbGame.Text = "Player 1 drew a " + g.Player1Card.Value.ToString() + " of " + g.Player1Card.Suit.ToString() + "\n";
            rtbGame.Text += "Player 2 drew a " + g.Player2Card.Value.ToString() + " of " + g.Player2Card.Suit.ToString() + "\n";
            tbPlayer1.Text = g.Player1Score.ToString();
            tbPlayer2.Text = g.Player2Score.ToString();

            string p1CardString = CardImageFileName(g.Player1Card);
            string p2CardString = CardImageFileName(g.Player2Card);

            Image? p1Image = Properties.Resources.ResourceManager.GetObject(p1CardString) as Image; // We know it exists since it's in the resources.
            Image? p2Image = Properties.Resources.ResourceManager.GetObject(p2CardString) as Image; // We know it exists since it's in the resources.

            pb1.Image = p1Image;
            pb2.Image = p2Image;

            if (g.GameOver)
            {
                btnPlay.Text = "Start game!";
                rtbGame.Text += "\n";
                if (g.GameWinner == "Draw")
                {
                    MessageBox.Show("The game is over and it was a draw!");
                }
                else
                {
                    MessageBox.Show("The game is over and the winner is: " + g.GameWinner + "!");
                }
            }
        }

        internal string CardImageFileName(Card card)
        {
            string valueCode;
            switch (card.Value)
            {
                case CardValue.Two:
                    valueCode = "_2";
                    break;
                case CardValue.Three:
                    valueCode = "_3";
                    break;
                case CardValue.Four:
                    valueCode = "_4";
                    break;
                case CardValue.Five:
                    valueCode = "_5";
                    break;
                case CardValue.Six:
                    valueCode = "_6";
                    break;
                case CardValue.Seven:
                    valueCode = "_7";
                    break;
                case CardValue.Eight:
                    valueCode = "_8";
                    break;
                case CardValue.Nine:
                    valueCode = "_9";
                    break;
                case CardValue.Ten:
                    valueCode = "_10";
                    break;
                case CardValue.Jack:
                    valueCode = "J";
                    break;
                case CardValue.Queen:
                    valueCode = "Q";
                    break;
                case CardValue.King:
                    valueCode = "K";
                    break;
                case CardValue.Ace:
                    valueCode = "A";
                    break;
                default:
                    throw new ArgumentException("Invalid card value");
            }

            string suitCode;
            switch (card.Suit)
            {
                case CardSuit.Clubs:
                    suitCode = "C";
                    break;
                case CardSuit.Diamonds:
                    suitCode = "D";
                    break;
                case CardSuit.Hearts:
                    suitCode = "H";
                    break;
                case CardSuit.Spades:
                    suitCode = "S";
                    break;
                default:
                    throw new ArgumentException("Invalid card suit");
            }
            return valueCode + suitCode;
        }
    }
}
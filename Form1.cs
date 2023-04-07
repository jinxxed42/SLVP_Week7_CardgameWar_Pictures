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

            string cardFolder = @"C:\Users\claus\source\repos\SLVP_Week7_CardgameWar_Pictures\Cards\";

            Image p1Image = Image.FromFile(cardFolder + p1CardString);
            Image p2Image = Image.FromFile(cardFolder + p2CardString);

            pb1.Image = p1Image;
            pb2.Image = p2Image;

            pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            pb2.SizeMode = PictureBoxSizeMode.StretchImage;

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
                    valueCode = "2";
                    break;
                case CardValue.Three:
                    valueCode = "3";
                    break;
                case CardValue.Four:
                    valueCode = "4";
                    break;
                case CardValue.Five:
                    valueCode = "5";
                    break;
                case CardValue.Six:
                    valueCode = "6";
                    break;
                case CardValue.Seven:
                    valueCode = "7";
                    break;
                case CardValue.Eight:
                    valueCode = "8";
                    break;
                case CardValue.Nine:
                    valueCode = "9";
                    break;
                case CardValue.Ten:
                    valueCode = "10";
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

            return valueCode + suitCode + ".png";
        }
    }
}
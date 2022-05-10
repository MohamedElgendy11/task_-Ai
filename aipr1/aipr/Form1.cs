using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoe
{
    public partial class Form1 : Form
    {
        
        public enum Player
        {
            X, O
        }

        Player currentPlayer; //اللاعب اللى عليه الدور

        List<Button> buttons; 
        Random rand = new Random();
        int playerWins = 0; //بدايه اللاعب صفر
        int computerWins = 0; //الكمبيوتر

        public Form1()
        {
            InitializeComponent();
            resetGame(); 
        }

        private void playerClick(object sender, EventArgs e)
        {
            var button = (Button)sender; 
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString(); 
            button.Enabled = false; // غير متااح
            button.BackColor = System.Drawing.Color.Cyan; // لون x
            buttons.Remove(button); 
            Check(); 
            AImoves.Start(); // دور ai
        }

        private void AImove(object sender, EventArgs e)
        {
            //  CPU اختيار رقم عشوائى 
            // لو كبر من 0 هيلعب 
            // لو فاضيه هيقف 
            if (buttons.Count > 0)
            {
                int index = rand.Next(buttons.Count); // حط رقم عشوائى ف الاندكس
                buttons[index].Enabled = false; 

                currentPlayer = Player.O; 
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = System.Drawing.Color.DarkSalmon; 
                buttons.RemoveAt(index); 
                Check(); // لو aiكسب 
                AImoves.Stop(); 
            }
        }

        private void restartGame(object sender, EventArgs e)
        {
            
            resetGame();
        }

        private void loadbuttons()
        {
           
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button9, button8 };
        }

        private void resetGame()
        {
          
            foreach (Control X in this.Controls)
            {
                if (X is Button && X.Tag == "play")
                {
                    ((Button)X).Enabled = true; 
                    ((Button)X).Text = "?"; 
                    ((Button)X).BackColor = default(Color); 
                }
            }

            loadbuttons(); 
        }

        private void Check()
        {
            
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
               || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
               || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
               || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
               || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
               || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
               || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                
                AImoves.Stop(); 
                MessageBox.Show("Player Wins"); 
                playerWins++;  
                label1.Text = "Player Wins- " + playerWins;
                resetGame(); 
            }
           //فوز ai
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
            || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
            || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
            || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
            || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
            || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
            || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
            || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {

               
                AImoves.Stop(); 
                MessageBox.Show("Computer Wins"); 
                computerWins++; 
                label2.Text = "AI Wins- " + computerWins; 
                resetGame(); 
            }
        }
    }
}
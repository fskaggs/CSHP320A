//CSHP320A
//Frederick J. Skaggs - Homework 5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Homework5
{
    /// <summary>
    ///    Implements a simple two player game of Tic Tac Toe
    ///    
    ///    The basic algorithm is a user presses a button on their turn which records a point value of -1 or 1
    ///    for player O and X, respectively.  Points are stored in a 4x4 matrix which represents the game board
    ///    and provides for a column and row sum.  The winner is identified as the player where the 
    ///    value of one of the summary values is -3 or 3. A winning score of -3 indicates player O has won. Likewise
    ///    a winning score of 3 indicates player X has won.
    /// </summary>
    public partial class MainWindow : Window
    {
        const int SUMMARYINDEX = 3;        // Game board matrix row or column where summary score is stored
        const int WINNER_NONE = 0;         // Indicates no winner yet
        const int WINNER_PLAYER_O = -3;    // Indicates player O is the winner
        const int MAX_TURNS = 9;           // Maximum possible number of turns playable
        const int WINNING_TOTAL = 3;       // Absolute value of summary row or column indicating someone has one

        int[,] gameBoard;                  // Matrix used to track points and summery to determine winner
        int turn;                          // Counter of number of elapsed turns
        int[] playerPoint = { 1, -1 };     // Each player's tracking point value indexed as turn mod 2
        char[] playerChar = { 'X', 'O' };  // Player character to display indexed as turn mod 2
        int trace, antitrace;              // diagonal point sum left to right and right to left

        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
        }

        /// <summary>
        ///   Reset the buttons, game board and diagonal summaries. Also indicate player X is starting player.
        /// </summary>
        void InitializeGame()
        {
            ResetButtons();
            gameBoard = new int[4, 4];  // 0,0 - 3,3 represents the board. Row 4,0 and Col 0,4 represents the sum
            turn = 0;
            trace = 0;
            antitrace = 0;
            uxTurn.Text = "Player X's turn";
        }

        /// <summary>
        ///   Clear any button text and ensure all buttons are enabled.
        /// </summary>
        void ResetButtons()
        {
            List<Button> btnList = uxGrid.Children.OfType<Button>().ToList();

            foreach(Button btn in btnList)
            {
                btn.Content = string.Empty;
                btn.IsEnabled = true;
            }
        }

        /// <summary>
        ///   Disable all buttons in the game grid.
        /// </summary>
        void DisableButtons()
        {
            List<Button> btnList = uxGrid.Children.OfType<Button>().ToList();

            foreach (Button btn in btnList)
            {
                btn.IsEnabled = false;
            }
        }

        /// <summary>
        ///     Determines the winner based on the row, column and diagonal sums.  If any
        ///     of the sums equals -3 or 3 a player has one.  The winning player is indicated
        ///     by the sign of the sum. Negative for player O and positive for player X.
        /// </summary>
        /// <returns>
        ///     Returns -1 if winner is player O, 0 for no winner, 1 if winner is player X 
        /// </returns>
        int CheckForWinner()
        {
            // 
            int winner = WINNER_NONE;

            for(int i = 0; i < 3; i++)
            {
                // Check the column and row sums. If the Abs(sum) == 3 there is a winner
                if (Math.Abs(gameBoard[SUMMARYINDEX, i]) == WINNING_TOTAL) winner = gameBoard[SUMMARYINDEX, i];
                if (Math.Abs(gameBoard[i, SUMMARYINDEX]) == WINNING_TOTAL) winner = gameBoard[i, SUMMARYINDEX];
            }

            // Check the diagonals too
            if (Math.Abs(trace) == WINNING_TOTAL) winner = trace;
            if (Math.Abs(antitrace) == WINNING_TOTAL) winner = antitrace;

            return winner;
        }

        /// <summary>
        ///   Quit the current game and start over.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            InitializeGame();
        }

        /// <summary>
        ///   Exit the game application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        ///   Play the game. Determine which button was pressed then update the game board matrix and
        ///   summary information.  Check for a draw, a winner or indicate its the next player's turn.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the button and mark the player to pressed it
            Button btn = sender as Button;
            
            // Illegal press if button already used
            if (btn.Content.ToString() != string.Empty)
                return;
                
            // Mark the button for the player who pressed it
            btn.Content = playerChar[turn % 2];

            // Get the row and column of the button and update the game board tracking matrix
            string[] temp = btn.Tag.ToString().Split(',');
            int row = int.Parse(temp[0]);
            int col = int.Parse(temp[1]);

            // Update tracking matrix by putting the current player's point in the selected row and column
            gameBoard[row, col] = playerPoint[turn % 2];

            // Do this on each turn, greatly reduces need for for-loops
            UpdateTrackingSums(row,col);

            // Increment the turn MOD 2 - this is a simple index into the message table to show who's turn it is
            turn++;

            // Did anyone win?
            int winner = CheckForWinner();
            if (winner == WINNER_NONE)
            {
                // No winner, check for a Draw
                if (turn == MAX_TURNS)
                {
                    // Declare a draw and disable further inputs
                    uxTurn.Text = "Game Over: Draw";
                    DisableButtons();
                }
                else
                {
                    // Notify next player of turn (player is always 0 or 1 so using turn mod 2 as index for which character to show)
                    uxTurn.Text = $"Player {playerChar[turn % 2]}'s turn";
                }
            }
            else
            {
                // Declare the winner and disable further inputs
                if (winner == WINNER_PLAYER_O)
                    uxTurn.Text = "Player O is the winner";
                else
                    uxTurn.Text = "Player X is the winner";

                DisableButtons();
            }
        }

        /// <summary>
        /// This method keeps a running tally of the total points for each row, column and
        /// diagonal. If any of these sum to -3 or 3 a winner exists.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        void UpdateTrackingSums(int row, int col)
        {
            // Update row sum
            gameBoard[row, SUMMARYINDEX] = gameBoard[row, 0] + gameBoard[row, 1] + gameBoard[row, 2];

            // Update column sum
            gameBoard[SUMMARYINDEX, col] = gameBoard[0, col] + gameBoard[1, col] + gameBoard[2, col];

            // Update diagonal sums (matrix trace)
            trace = gameBoard[0, 0] + gameBoard[1, 1] + gameBoard[2, 2];
            antitrace = gameBoard[2, 0] + gameBoard[1, 1] + gameBoard[0, 2];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe_lib
{
    public class Game
    {
        internal Table table { get; set;  }
        public bool IsGameRunning { get; set; }
        public char CurrentPlayer { get; set; }
        public string Msg { get; set; }
        public Game()
        {
            table = new Table();
            IsGameRunning = true;
            CurrentPlayer = 'X';
        }
        
        public int ConvertInputToIndex(string input)
        {
            int[] value = Array.ConvertAll(input.Split(" "), int.Parse);
            int index = (value[0]-1)*3+(value[1]-1);
            return index;
        }
        public string PrintTable()
        {
            return table.PrintTable();
        }
        public void PutTable(string index)
        {
            bool isValid = table.PutTable(ConvertInputToIndex(index), CurrentPlayer);
            if(CurrentPlayer == 'O' && isValid)
            {
                CurrentPlayer = 'X';
            }
            else if(isValid)
            {
                CurrentPlayer = 'O';
            }
        }
        public (bool, char) CheckWin()
        {
            List<int[]> winConditions = new List<int[]>
            {
                new int[] {0, 1, 2},
                new int[] {3, 4, 5},
                new int[] {6, 7, 8},
                new int[] {0, 3, 6},
                new int[] {1, 4, 7},
                new int[] {2, 5, 8},
                new int[] {0, 4, 8},
                new int[] {2, 4, 6}
            };
            foreach (var condition in winConditions)
            {
                if (table[condition[0]] != '_' &&
                    table[condition[0]] == table[condition[1]] &&
                    table[condition[1]] == table[condition[2]])
                {
                    IsGameRunning = false;
                    Msg = $"Player {table[condition[0]]} wins!";
                    return (true, table[condition[0]]);
                }
            }
            return (false, '_');
        }
        public bool CheckDraw()
        {
            if (table.IsFull())
            {
                IsGameRunning = false;
                Msg = "The game is a draw!";
                return true;
            }
            return false;
        }
    }
}

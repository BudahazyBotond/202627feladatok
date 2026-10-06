using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace EletjatekGUI.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        class MyCommand : ICommand
        {
            Action action;
            public event EventHandler? CanExecuteChanged;
            public MyCommand(Action action)
            {
                this.action = action;
            }
            public bool CanExecute(object? parameter) => true;

            public void Execute(object? parameter) => action();
        }
        public int[] Meretek { get; init; } = Enumerable.Range(5, 16).ToArray();
        public int Rows { get; init; } = 20;
        public int Columns { get; init; } = 20;
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand CreateNew { get; init; }
        public ICommand Save { get; init; }
        public MainWindow Context { get; set; }
        void CreateNewTable()
        {
            Context.CheckBoxGrid.Children.Clear();
            Context.CheckBoxGrid.Rows = Rows;
            Context.CheckBoxGrid.Columns = Columns;
            PropertyChanged?.Invoke(Context, new PropertyChangedEventArgs(nameof(Rows)));
            PropertyChanged?.Invoke(Context, new PropertyChangedEventArgs(nameof(Columns)));
            for (int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < Columns; j++)
                {
                    var cb = new CheckBox();
                    Context.CheckBoxGrid.Children.Add(cb);
                }
            }
        }
        void SaveTable()
        {
            if(Context.CheckBoxGrid.Rows==0 || Context.CheckBoxGrid.Columns == 0)
            {
                return;
            }
            using var output = new StreamWriter($"Eletjatek_{Context.CheckBoxGrid.Rows}x{Context.CheckBoxGrid.Columns}.txt");
            for (int i = 0; i < Context.CheckBoxGrid.Rows; i++)
            {
                for (int j = 0; j < Context.CheckBoxGrid.Columns; j++)
                {
                    var cb = (Context.CheckBoxGrid.Children[i * Context.CheckBoxGrid.Columns + j] as CheckBox)!;
                    output.Write(cb.IsChecked ?? true ? "1" : "0");
                }
                output.WriteLine();
            }
        }
        public MainViewModel()
        {
            CreateNew = new MyCommand(CreateNewTable);
            Save = new MyCommand(SaveTable);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace theSafeOfThePilotBrothers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Safe _safe;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {           

            Button btn = (Button)sender;

            int i = int.Parse(btn.Tag.ToString()[0].ToString());
            int j = int.Parse(btn.Tag.ToString()[1].ToString());

            _safe.ClickOnelement(i, j);

            if (_safe.CheckArray())
            {
                MessageBox.Show("Вы выйграли");

            }
        }

        private async void StartTheGameBtn_Click(object sender, RoutedEventArgs e)
        {         

            if (int.TryParse(InputN.Text,out int result))
            {
                _safe = new Safe(result, ChangeButton);

                await ShowTheSafe();
            }
            else
            {
                MessageBox.Show("Введите число");
            }
        }

        private async Task ShowTheSafe()
        {
            GameGrid.Children.Clear();
            GameGrid.ColumnDefinitions.Clear();
            GameGrid.RowDefinitions.Clear();
            for (int i = 0; i < _safe.Length; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
                for (int j = 0; j < _safe.Length; j++)
                {
                    GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
                    Button button = _safe.Array[i, j].Button;
                    button.Tag = $"{i}{j}";
                    if (_safe.Array[i, j].Num == 0)
                        button.Style = (Style)this.Resources["HorisontalBtn"];
                    else
                        button.Style = (Style)this.Resources["VerticalBtn"];

                    button.Click += Button_Click;                    

                    Grid.SetRow(button,i);
                    Grid.SetColumn(button, j);

                    GameGrid.Children.Add(button);
                }
            }

            await Task.CompletedTask;
        }

        private void ChangeButton(int i, int j)
        {
            if (_safe.Array[i,j].Num == 0)
            {
                _safe.Array[i, j].Button.Style = (Style)this.Resources["HorisontalBtn"];              
            }
            else 
            {
                _safe.Array[i, j].Button.Style = (Style)this.Resources["VerticalBtn"];
            }
            
        }    
    }
}

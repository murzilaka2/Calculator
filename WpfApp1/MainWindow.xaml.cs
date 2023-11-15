using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await CSharpScript.EvaluateAsync("1 + 1", ScriptOptions.Default.WithImports("System.Math"));
        }

        private void CeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(InputTextBox.Text))
            {
                int index = InputTextBox.Text.LastIndexOfAny(new char[] {'+','/','*','-'});
                InputTextBox.Text = InputTextBox.Text.Substring(0, index + 1);
            }
        }

        private void RemoveButon_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(InputTextBox.Text))
            {
                InputTextBox.Text = InputTextBox.Text.Substring(0, InputTextBox.Text.Length - 1);
            }
        }

        private void NumpadButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            InputTextBox.Text += button.Content;
        }

        private async void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(InputTextBox.Text))
            {
                var result = await CSharpScript.EvaluateAsync(InputTextBox.Text, ScriptOptions.Default.WithImports("System.Math"));
                ResultTextBox.Text = result.ToString();
            }
        }

        private void CButton_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.Clear();
            ResultTextBox.Clear();
        }
    }
}

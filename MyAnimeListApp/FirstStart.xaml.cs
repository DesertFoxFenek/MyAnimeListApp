using System;
using System.IO;
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
using System.Windows.Shapes;

namespace MyAnimeListApp
{
    /// <summary>
    /// Logika interakcji dla klasy FirstStart.xaml
    /// </summary>
    ///
    

    public partial class FirstStart : Window
    {
        readonly string directory = MainWindow.directory;
        readonly string infotext = MainWindow.infotext;
        readonly string FStPL = "Dziękujemy za pierwsze uruchomienie tejże aplikacji.\nNa twoim dysku C powstanie teraz folder gdzie będziemy trzymać wszystkie informacje.\nJeżeli nie zgadzasz się na to prosimy o zamknięcie aplikacji.\n\nPo potwierdzeniu uruchom ponownie.";
        public FirstStart()
        {
            InitializeComponent();
            FStext.Text = FStPL;
        }

        private void Enter(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory(directory);
            _ = File.CreateText(infotext);
            this.Close();
            Environment.Exit(1);
        }

        private void ChangeEN(object sender, RoutedEventArgs e)
        {

        }
    }
}

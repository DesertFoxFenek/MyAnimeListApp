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
    /// Logika interakcji dla klasy AddTitle.xaml
    /// </summary>
    public partial class AddTitle : Window
    {
        public AddTitle()
        {
            InitializeComponent();
            StartListy();
        }

        private void StartListy()
        {
            List<string> list_stat = new List<string>();
            list_stat.Add("Oczekuje");
            list_stat.Add("W trakcie");
            list_stat.Add("Zakończono");

            statussel.ItemsSource = list_stat;
        }

        private void AddToFile(object sender, RoutedEventArgs e)
        {
            string TitleToSave = EntryTitle.Text;
            int StatusToSave = statussel.SelectedIndex;
            
            string ToSave = TitleToSave + "\t" + StatusToSave + "\n";

            File.AppendAllText(MainWindow.infotext,ToSave);

            AddInfo.Text = "Dodano: " + TitleToSave;
            AddInfo.Visibility = Visibility.Visible;
        }
    }
}

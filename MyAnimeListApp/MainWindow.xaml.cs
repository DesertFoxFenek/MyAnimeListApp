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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyAnimeListApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public static string directory = @"c:\MyAnimeListApp";
        public static string infotext = @"c:\MyAnimeListApp\list.txt";

        List<Anime> animes = new List<Anime>();
        public MainWindow()
        {
            InitializeComponent();
            Startup();

            textstatusoflist.Visibility = Visibility.Hidden;
        }

        private void Startup()
        {
            if (!Directory.Exists(directory))
            {
                FirstStart FS_W = new FirstStart();
                FS_W.Show();
                this.Close();
            }
            if (Directory.Exists(directory)) ReadFile();
        }

        private void ReadFile()
        {
            string[] FileC = File.ReadAllLines(infotext);

            foreach (string line in FileC)
            {
                string Name = "";
                int Status = 0;

                for (int i = 0; i < line.Length - 1; i++)
                {
                    if (line[i] == '\t')
                    {
                        char s = line[i + 1];
                        Status = int.Parse(s.ToString());
                    }
                    else Name += line[i];
                }

                animes.Add(new Anime(Name, Status));

                //listofAnime.Items.Add(Name+"\t\t"+Status);
            }

            listofAnime.Items.Clear();

            foreach (Anime anime in animes)
            {
                listofAnime.Items.Add(anime.name);
            }
        }

        private void SelTitel(object sender, MouseButtonEventArgs e)
        {

            int Status = 0;
            string MsgStatus;
            string SelectedName = listofAnime.SelectedItem.ToString();

            var Result = from anime in animes
                         where anime.name == SelectedName
                         select anime;


            foreach (var result in Result)
            {
                Status = result.status;
            }


            if (Status == 0) MsgStatus = "Oczekuje";
            else if (Status == 1) MsgStatus = "W trakcie";
            else if (Status == 2) MsgStatus = "Zakończono";
            else MsgStatus = "Błędny odczyt";

            textstatusoflist.Text = MsgStatus;
            textstatusoflist.Visibility = Visibility.Visible;
        }

        private void AddPosition(object sender, RoutedEventArgs e)
        {
            AddTitle addTitle = new AddTitle();
            addTitle.Show();
        }

        private void RefContent(object sender, RoutedEventArgs e)
        {
            animes.Clear();
            ReadFile();
        }

        private void Del_pos(object sender, RoutedEventArgs e)
        {
            int index = listofAnime.SelectedIndex;

            animes.RemoveAt(index);
            listofAnime.SelectedItem = null;
            listofAnime.Items.Clear();

            File.Delete(infotext);

            StreamWriter sw = new StreamWriter(infotext);

            foreach (Anime anime in animes)
            {
                string ToSave = anime.name + "\t" + anime.status;

                sw.WriteLine(ToSave);
            }

            sw.Close();

            RefContent(sender, e);
            textstatusoflist.Visibility = Visibility.Hidden;
        }

        private void Chanage_Stat(object sender, RoutedEventArgs e)
        {
            int index = listofAnime.SelectedIndex;

            if (animes[index].status < 2)
            {
                animes[index].status += 1;

                File.Delete(infotext);

                StreamWriter sw = new StreamWriter(infotext);

                foreach (Anime anime in animes)
                {
                    string ToSave = anime.name + "\t" + anime.status;

                    sw.WriteLine(ToSave);
                }

                sw.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnimeListApp
{
    internal class Anime
    {
        string Name;
        int Status;

        public Anime(string N,int S)
        {
            this.Name = N;
            this.Status = S;
        }

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        public int status
        {
            get { return Status; }
            set { Status = value; }
        }
    }
}

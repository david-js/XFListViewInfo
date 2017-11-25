using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListInfoDemo
{
    public class MovieRating
    {
        public string Name { get; set; }
        public int Rating { get; set; }
    }

    public partial class MainPage : ContentPage
    {
        public static List<MovieRating> Movies { get; set; } =
            new List<MovieRating>()
            {
                new MovieRating() { Name = "Star Wars, Ep 1", Rating = 3 },
                new MovieRating() { Name = "Star Wars, Ep 2", Rating = 2 },
                new MovieRating() { Name = "Star Wars, Ep 3", Rating = 1 },
                new MovieRating() { Name = "Star Wars, Ep 4", Rating = 5 },
                new MovieRating() { Name = "Star Wars, Ep 5", Rating = 5 },
                new MovieRating() { Name = "Star Wars, Ep 6", Rating = 5 },
                new MovieRating() { Name = "Star Trek: The Motion Picture", Rating = 3 },
                new MovieRating() { Name = "Star Trek II: The Wrath of Khan", Rating = 4 },
                new MovieRating() { Name = "Star Trek III: The Search for Spock", Rating = 3 },
                new MovieRating() { Name = "Star Trek IV: The Voyage Home", Rating = 5 },
                new MovieRating() { Name = "Star Trek V: The Final Frontier", Rating = 3 },
                new MovieRating() { Name = "Star Trek VI: The Undiscovered Country", Rating = 3 },
                new MovieRating() { Name = "Star Trek: Generations", Rating = 4 },
                new MovieRating() { Name = "Star Trek (2009)", Rating = 2 },
                new MovieRating() { Name = "Star Trek Into Darkness", Rating = 2 },
                new MovieRating() { Name = "Star Wars, Ep 1", Rating = 3 },
                new MovieRating() { Name = "Star Wars, Ep 2", Rating = 2 },
                new MovieRating() { Name = "Star Wars, Ep 3", Rating = 1 },
                new MovieRating() { Name = "Star Wars, Ep 4", Rating = 5 },
                new MovieRating() { Name = "Star Wars, Ep 5", Rating = 5 },
                new MovieRating() { Name = "Star Wars, Ep 6", Rating = 5 },
                new MovieRating() { Name = "Star Trek: The Motion Picture", Rating = 3 },
                new MovieRating() { Name = "Star Trek II: The Wrath of Khan", Rating = 4 },
                new MovieRating() { Name = "Star Trek III: The Search for Spock", Rating = 3 },
                new MovieRating() { Name = "Star Trek IV: The Voyage Home", Rating = 5 },
                new MovieRating() { Name = "Star Trek V: The Final Frontier", Rating = 3 },
                new MovieRating() { Name = "Star Trek VI: The Undiscovered Country", Rating = 3 },
                new MovieRating() { Name = "Star Trek: Generations", Rating = 4 },
                new MovieRating() { Name = "Star Trek (2009)", Rating = 2 },
                new MovieRating() { Name = "Star Trek Into Darkness", Rating = 2 },
                new MovieRating() { Name = "Star Wars, Ep 1", Rating = 3 },
                new MovieRating() { Name = "Star Wars, Ep 2", Rating = 2 },
                new MovieRating() { Name = "Star Wars, Ep 3", Rating = 1 },
                new MovieRating() { Name = "Star Wars, Ep 4", Rating = 5 },
                new MovieRating() { Name = "Star Wars, Ep 5", Rating = 5 },
                new MovieRating() { Name = "Star Wars, Ep 6", Rating = 5 },
                new MovieRating() { Name = "Star Trek: The Motion Picture", Rating = 3 },
                new MovieRating() { Name = "Star Trek II: The Wrath of Khan", Rating = 4 },
                new MovieRating() { Name = "Star Trek III: The Search for Spock", Rating = 3 },
                new MovieRating() { Name = "Star Trek IV: The Voyage Home", Rating = 5 },
                new MovieRating() { Name = "Star Trek V: The Final Frontier", Rating = 3 },
                new MovieRating() { Name = "Star Trek VI: The Undiscovered Country", Rating = 3 },
                new MovieRating() { Name = "Star Trek: Generations", Rating = 4 },
                new MovieRating() { Name = "Star Trek (2009)", Rating = 2 },
                new MovieRating() { Name = "Star Trek Into Darkness", Rating = 2 },
            };

        public MainPage()
        {
            InitializeComponent();
        }
    }
}

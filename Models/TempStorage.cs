using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Assignment3.Models
{
    public static class TempStorage
    {
        private static List<EnterMovie> movies = new List<EnterMovie>();

        public static IEnumerable<EnterMovie> Movies => movies;

        public static void AddMovie(EnterMovie movie)
        {
            movies.Add(movie);
        }
    }
}


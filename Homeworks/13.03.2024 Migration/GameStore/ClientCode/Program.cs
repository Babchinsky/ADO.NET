using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using GameContext;
using GameLib;
using System.Collections;

namespace CodeFirstManyToMany
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (GameContextDB db = new GameContextDB())
                {
                    // First migration
                    List<Game> games = db.Games.ToList();

                    if (games == null || games.Count == 0 )
                    {
                        db.Genres.Add(new Genre { Title = "Adventure" });
                        db.Genres.Add(new Genre { Title = "Simulation" });
                        db.Genres.Add(new Genre { Title = "Strategy" });

                        Studio studio1 = new Studio { Title = "Ubisoft" };
                        Studio studio2 = new Studio { Title = "Bethesda Softworks" };
                        db.Studios.Add(studio1);
                        db.Studios.Add(studio2);

                        Game game1 = new Game { Title = "Assassin's Creed Valhalla", Studio=studio1,Genres = new List<Genre> { new Genre { Title = "Adventure" }, new Genre { Title = "Strategy" } } , ReleaseDate = new DateTime(2020,11,10) };
                        Game game2 = new Game { Title = "The Elder Scrolls V: Skyrim", Studio=studio2,Genres = new List<Genre> { new Genre { Title = "Adventure" }, new Genre { Title = "Simulation" }, new Genre { Title = "Strategy" } } , ReleaseDate = new DateTime(2011,11,11) };
                        Game game3 = new Game { Title = "Cities: Skylines", Studio = studio1, Genres = new List<Genre> { new Genre { Title = "Simulation" }, new Genre { Title = "Strategy" } }, ReleaseDate = new DateTime (2015,3,10) };
                        db.Games.Add(game1);
                        db.Games.Add(game2);
                        db.Games.Add(game3);
                    }
                    db.SaveChanges();

                    games = db.Games.ToList();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("First output\n");
                    Console.ResetColor();
                    foreach (var g in games)
                    {
                        Console.WriteLine("Title: "+g.Title);
                        Console.WriteLine("Studio: " + g.Studio.Title);
                        Console.Write("Genre: ");
                        foreach (var s in g.Genres)
                        {
                            Console.Write(" " + s.Title);
                        }
                        Console.WriteLine("\nRelease Date: "+ g.ReleaseDate);
                        Console.WriteLine();
                    }


                    // Second migration

                    games = db.Games.ToList();

                    if (games.Count < 4)
                    {
                        foreach (var g in games)
                        {
                            g.Mode = GameMode.SinglePlayer;
                        }
                        Studio studio3 = new Studio { Title = "Capcom" };
                        db.Add(studio3);

                        Genre genre4 = new Genre { Title = "Horror" };
                        db.Genres.Add(genre4);

                        Game game4 = new Game { Title = "Resident Evil Village", Studio = studio3, Genres = new List<Genre> { new Genre { Title = "Adventure" }, genre4 }, Mode = GameMode.SinglePlayer, ReleaseDate = new DateTime(2021, 5, 7) };
                        db.Games.Add(game4);
                        db.SaveChanges();

                    }

                    games = db.Games.ToList();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Second output\n");
                    Console.ResetColor();
                    foreach (var g in games)
                    {
                        Console.WriteLine("Title: " + g.Title);
                        Console.WriteLine("Studio: " + g.Studio.Title);
                        Console.Write("Genre: ");
                        foreach (var s in g.Genres)
                        {
                            Console.Write(" " + s.Title);
                        }
                        Console.WriteLine("\nRelease Date: " + g.ReleaseDate);
                        Console.WriteLine("Game Mode: " + g.Mode);
                        Console.WriteLine();
                    }




                    // Third migration

                    games = db.Games.ToList();

                    if (games.Count < 5)
                    {
                        Random random = new Random();
                        foreach (var g in games)
                        {
                            g.SaledCopies = random.Next(1000,10001);
                        }
                        Studio studio4 = new Studio { Title = "CD Projekt Red" };
                        db.Add(studio4);

                        Genre genre5 = new Genre { Title = "Role-Playing" };
                        db.Genres.Add(genre5);

                        Game game5 = new Game { Title = "Cyberpunk 2077", Studio = studio4, Genres = new List<Genre> { new Genre { Title = "Adventure" }, genre5 }, Mode = GameMode.SinglePlayer, ReleaseDate = new DateTime(2020, 12, 10), SaledCopies=8000};
                        db.Games.Add(game5);
                        db.SaveChanges();

                    }

                    games = db.Games.ToList();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Third output\n");
                    Console.ResetColor();
                    foreach (var g in games)
                    {
                        Console.WriteLine("Title: " + g.Title);
                        Console.WriteLine("Studio: " + g.Studio.Title);
                        Console.Write("Genre: ");
                        foreach (var s in g.Genres)
                        {
                            Console.Write(" " + s.Title);
                        }
                        Console.WriteLine("\nRelease Date: " + g.ReleaseDate);
                        Console.WriteLine("Game Mode: " + g.Mode);
                        Console.WriteLine("Number of Sold Copies: " + g.SaledCopies);
                        Console.WriteLine();
                    }

                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

﻿using FinalTask.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FinalTask.Data.Initialization
{
    public class MovieAppDbInitialization : DropCreateDatabaseIfModelChanges<MovieAppContext>
    {
        protected override void Seed(MovieAppContext context)
        {
            var directors = new List<Director>()
            {
                new Director()
                {
                    Name = "Toma Puljak"
                },
                new Director()
                {
                    Name = "Mario Ceprnja"
                },
                new Director()
                {
                    Name = "Ivo Sanader"
                }
            };

            var actors = new List<Actor>()
            {
                new Actor()
                {
                    Name = "Prvi Glumac"
                },
                new Actor()
                {
                    Name = "Drugi Glumac"
                },
                new Actor()
                {
                    Name = "Treci Glumac"
                },
                new Actor()
                {
                    Name = "Cetvrti Glumac"
                },
                new Actor()
                {
                    Name = "Peti Glumac"
                },
                new Actor()
                {
                    Name = "Sesti Glumac"
                }
            };

            var hashtags = new List<Hashtag>()
            {
                new Hashtag()
                {
                    Text = "#predobro"
                },
                new Hashtag()
                {
                    Text = "#pomalo"
                },
                new Hashtag()
                {
                    Text = "#show"
                },
                new Hashtag()
                {
                    Text = "#vrh"
                }
            };

            var genres = new List<Genre>()
            {
                new Genre()
                {
                    Name = "Akcija"
                },
                new Genre()
                {
                    Name = "Komedija"
                },
                new Genre()
                {
                    Name = "Drama"
                }
            };

            var movieLists = new List<MovieList>()
            {
                new MovieList()
                {
                    Name = "Prva lista"
                }
            };

            context.Directors.AddRange(directors);
            context.Actors.AddRange(actors);
            context.Genres.AddRange(genres);
            context.Hashtags.AddRange(hashtags);
            context.MovieLists.AddRange(movieLists);
            context.SaveChanges();

            var movies = new List<Movie>()
            {
                new Movie()
                {
                    Name = "Film1",
                    Director = directors[0],
                    Actors = context.Actors.Where(actor => actor.Id <= 3).ToList(),
                    Hashtags = hashtags,
                    Genre = genres[0],
                    MovieLists = movieLists
                },
                new Movie()
                {
                    Name = "Film2",
                    Director = directors[1],
                    Actors = context.Actors.Where(actor => actor.Id >= 3).ToList(),
                    Hashtags = hashtags,
                    Genre = genres[1],
                    MovieLists = context.MovieLists.ToList()
                },
                new Movie()
                {
                    Name = "Film3",
                    Director = directors[2],
                    Actors = context.Actors.Where(actor => actor.Id % 2 == 0).ToList(),
                    Genre = genres[2]
                }
            };
            
            context.Movies.AddRange(movies);
            context.SaveChanges();
            base.Seed(context); 
        }
    }
}

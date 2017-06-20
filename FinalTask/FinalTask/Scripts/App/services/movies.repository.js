angular.module('app').service('moviesRepository', function ($http, actorsRepository, directorsRepository, genresRepository, hashtagsRepository, movieListsRepository) {
    function getAllMovies() {
        return $http.get('/movies/get-all');
    }

    function getSpecificMovie(id) {
        return $http.get('/movies/get/', {
            params: {
                id: id
            }
        });
    }

    function createMovie(name, actorIds, directorId, genreId, movieListsIds, hashtagIds) {
        var actors = new Array();
        for (actorId in actorIds)
            actors.push(actorsRepository.getSpecific(actorId));

        var hashtags = new Array();
        for (hashtagId in hashtagIds)
            hashtags.push(hashtagsRepository.getSpecific(hashtagId));

        var movieLists = new Array();
        for (movieListId in movieListIds)
            movieLists.push(movieListsRepository.getSpecific(movieListId));

        var newMovie = {
            Name: name,
            Director: directorsRepository.getSpecific(directorId),
            Actors: actors,
            Genre: genresRepository.getSpecific(genreId),
            MovieLists: movieLists,
            Hashtags: hashtags
        }

        return $http.post('/movies/create/', newMovie);
    }

    function deleteMovie(id) {
        return $http.delete('/movies/delete/', {
            params: {
                id: id
            }
        });
    }

    return {
        getAll: getAllMovies,
        getSpecific: getSpecificMovie,
        create: createMovie,
        delete: deleteMovie
    }
})
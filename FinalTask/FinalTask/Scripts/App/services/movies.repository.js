angular.module('app').service('moviesRepository', function ($http, actorsRepository, directorsRepository, genresRepository, hashtagsRepository, localStorageService) {
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

    function createMovie(newMovie) {
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
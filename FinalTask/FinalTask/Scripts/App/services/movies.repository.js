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

    function searchMovies(searchText, searchBy) {
        return $http.get('/movies/search/', {
            params: {
                searchText: searchText,
                searchBy: searchBy
            }
        });
    }

    return {
        getAll: getAllMovies,
        getSpecific: getSpecificMovie,
        create: createMovie,
        delete: deleteMovie,
        search: searchMovies
    }
})
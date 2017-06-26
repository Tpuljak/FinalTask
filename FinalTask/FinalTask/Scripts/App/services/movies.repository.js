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

    function createMovie(newMovie, movies) {
        return $http.post('/movies/create/', newMovie, movies);
    }

    function deleteMovie(id) {
        return $http.delete('/movies/delete/', {
            params: {
                id: id
            }
        });
    }

    function searchMovies(searchText, searchBy) {
        return $http.get('/movies/search/', {
            params: {
                searchText: searchText,
                searchBy: searchBy
            }
        });
    }

    function getMovieDTOs() {
        return $http.get('/movies/get-dto');
    }

    function editMovie(changedMovie) {
        return $http.post('/movies/edit/', changedMovie);
    }

    return {
        getAll: getAllMovies,
        getSpecific: getSpecificMovie,
        create: createMovie,
        delete: deleteMovie,
        search: searchMovies,
        getDTOs: getMovieDTOs,
        edit: editMovie
    }
})
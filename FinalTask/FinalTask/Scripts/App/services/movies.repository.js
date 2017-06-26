angular.module('app').service('moviesRepository', function ($http, actorsRepository, directorsRepository, genresRepository, hashtagsRepository, localStorageService) {
    function getAllMovies() {
        return $http.get('/movies/get-all');
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

    function searchMovies(searchText, searchBy) {
        return $http.get('/movies/search/', {
            params: {
                searchText: searchText,
                searchBy: searchBy
            }
        });
    }

    function editMovie(changedMovie) {
        return $http.post('/movies/edit/', changedMovie);
    }

    return {
        getAll: getAllMovies,
        create: createMovie,
        delete: deleteMovie,
        search: searchMovies,
        edit: editMovie
    }
})
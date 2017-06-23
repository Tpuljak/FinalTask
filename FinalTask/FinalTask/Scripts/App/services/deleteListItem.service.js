angular.module('app').service('DeleteListItemService', function (localStorageService, SetStorageService, moviesRepository, movieListsRepository) {
    this.deleteMovie = function (id) {
        moviesRepository.delete(id).then(function (response) {
            moviesRepository.getAll()
                .then(function (response) {
                    SetStorageService.setLocalStorage(response.data, "movies");
                });
        });
    }

    this.deleteMovieList = function (id) {
        movieListsRepository.delete(id).then(function (response) {
            movieListsRepository.getAll()
                .then(function (response) {
                    SetStorageService.setLocalStorage(response.data, "movieLists");
                });
        });
    };
});
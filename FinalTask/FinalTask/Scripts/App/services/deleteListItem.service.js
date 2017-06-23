angular.module('app').service('DeleteListItemService', function (localStorageService, SetStorageService, moviesRepository, movieListsRepository, RefreshListService) {
    this.deleteMovie = function (id) {
        return moviesRepository.delete(id);
    }

    this.deleteMovieList = function (id) {
        movieListsRepository.delete(id).then(function () {
            movieListsRepository.getAll()
                .then(function (response) {
                    SetStorageService.setLocalStorage(response.data, "movieLists");
                    return RefreshListService.refresh("movieLists");
                });
        });
    };
});
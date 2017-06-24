angular.module('app').controller('MovieListsController', function (localStorageService, SetStorageService, $scope, movieListsRepository, RefreshListService) {
    $scope.movieLists = angular.fromJson(localStorageService.get("movieLists"));

    $scope.deleteMovieList = function (id) {
        movieListsRepository.delete(id)
            .then(function (response) {
                movieListsRepository.getAll()
                    .then(function (response) {
                        SetStorageService.setLocalStorage(response.data, "movieLists");
                        $scope.movieLists = RefreshListService.refresh("movieLists");
                    });
            });
    }
});
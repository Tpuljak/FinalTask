angular.module('app').controller('MoviesController', function (moviesRepository, localStorageService, $http, $scope, SetStorageService) {
    $scope.movies = angular.fromJson(localStorageService.get("movies"));

    $scope.deleteMovie = function (id) {
        moviesRepository.delete(id);
        var movies;
        moviesRepository.getAll().then(function (response) {
            movies = response.data;
        });
        SetStorageService.setLocalStorage(movies, "movies");
    }
});
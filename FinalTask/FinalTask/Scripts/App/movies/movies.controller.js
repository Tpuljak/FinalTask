angular.module('app').controller('MoviesController', function (moviesRepository, localStorageService, $http, $scope, SetStorageService, RefreshListService) {
    $scope.movies = angular.fromJson(localStorageService.get("movies"));
});
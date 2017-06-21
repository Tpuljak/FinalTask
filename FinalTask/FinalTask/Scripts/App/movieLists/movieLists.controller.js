angular.module('app').controller('MovieListsController', function (localStorageService, $scope) {
    $scope.movieLists = angular.fromJson(localStorageService.get("movieLists"));
});
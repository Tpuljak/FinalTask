angular.module('app').controller('MovieListDetailsController', function ($stateParams, $scope, localStorageService) {
    $scope.movieList = _.find(angular.fromJson(localStorageService.get("movieLists")), movieList => movieList.Id == $stateParams.movieListId);
});
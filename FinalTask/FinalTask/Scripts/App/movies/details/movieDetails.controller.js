angular.module('app').controller('MovieDetailsController', function (localStorageService, $scope, $stateParams) {
    $scope.movie = _.find(angular.fromJson(localStorageService.get("movies")), movie => movie.Id == $stateParams.movieId);

});
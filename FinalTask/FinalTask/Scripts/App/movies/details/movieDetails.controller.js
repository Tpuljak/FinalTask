angular.module('app').controller('MovieDetailsController', function ($scope, $stateParams, RefreshListService) {
    $scope.movie = _.find(RefreshListService.refresh("movies"), movie => movie.Id == $stateParams.movieId);
    $scope.editMode = false;

    $scope.editModeSwitch = function () {
        $scope.editMode = true;
    }

    $scope.cancel = function () {
        $scope.editMode = false;
    }
});
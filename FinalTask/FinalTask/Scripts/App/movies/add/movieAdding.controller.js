angular.module('app').controller('MovieAddingController', function ($filter, localStorageService, $scope, SetStorageService, RefreshListService) {
    $scope.directors = RefreshListService.refresh("directors");
    $scope.genres = RefreshListService.refresh("genres");
    $scope.actors = RefreshListService.refresh("actors");
    $scope.hashtags = RefreshListService.refresh("hashtags");
    $scope.movieLists = RefreshListService.refresh("movieLists");

    $scope.getSelected = function (listToCheck) {
        var selected = $filter("filter")(listToCheck, {
            checked: true
        });
        return selected;
    }

    $scope.addNewMovie = function () {
        if (!$scope.directorRadioBtn) {
            alert("All * fields are required!")
            return;
        }
    };
})
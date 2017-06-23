angular.module('app').controller('MovieListsController', function (localStorageService, $scope, DeleteListItemService, RefreshListService) {
    $scope.movieLists = angular.fromJson(localStorageService.get("movieLists"));

    $scope.deleteMovieList = function (id) {
        DeleteListItemService.deleteMovieList(id);
        $scope.movieLists = RefreshListService.refresh("movieLists");
    }
});
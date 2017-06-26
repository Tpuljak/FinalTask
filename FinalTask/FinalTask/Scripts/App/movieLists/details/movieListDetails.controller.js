angular.module('app').controller('MovieListDetailsController', function ($stateParams, $scope, $filter, RefreshListService, SetStorageService, moviesRepository, movieListsRepository) {
    $scope.movieList = _.find(RefreshListService.refresh("movieLists"), movieList => movieList.Id == $stateParams.movieListId);
    $scope.editMode = false;
    $scope.nameEditInput = $scope.movieList.Name;
    $scope.movies = RefreshListService.refresh("movies");
    $scope.refreshTrigger = 0;

    $scope.getSelected = function (listToCheck) {
        var selected = $filter("filter")(listToCheck, {
            checked: true
        });

        return selected;
    }

    $scope.editModeSwitch = function () {
        $scope.editMode = true;
    }

    $scope.cancel = function () {
        $scope.editMode = false;
    }

    $scope.saveChanges = function () {
        var changedMovieList = {
            Id: $scope.movieList.Id,
            Name: $scope.nameEditInput,
            Movies: $scope.getSelected($scope.movies)
        }

        movieListsRepository.edit(changedMovieList).then(function () {
            movieListsRepository.getAll().then(function (response) {
                SetStorageService.setLocalStorage(response.data, "movieLists");
            });
            moviesRepository.getAll().then(function (response) {
                SetStorageService.setLocalStorage(response.data, "movies");
                $scope.movieList = _.find(RefreshListService.refresh("movieLists"), movieList => movieList.Id === changedMovieList.Id);
                $scope.editMode = false;
                $scope.refreshTrigger++;
                alert("Movie list successfully edited!");
            });
        });

    }
});
angular.module('app').controller('MovieListAddingController', function ($filter, $scope, RefreshListService, SetStorageService, movieListsRepository) {
    $scope.movies = RefreshListService.refresh("movies");
    $scope.movieListAdded = false;

    $scope.getSelected = function (listToCheck) {
        var selected = $filter("filter")(listToCheck, {
            checked: true
        });
        return selected;
    }

    $scope.addNewMovieList = function () {
        if (!$scope.newMovieListName || !$scope.getSelected($scope.movies)) {
            alert("All * fields are required!");
            return;
        }

        var newMovieList = {
            Name: $scope.newMovieListName,
            Movies: $scope.getSelected($scope.movies)
        }
        console.log(newMovieList);
        movieListsRepository.create(newMovieList).then(function () {
            movieListsRepository.getAll().then(function (response) {
                SetStorageService.setLocalStorage(response.data, "movieLists");
                $scope.newMovieListName = "";
                angular.forEach($scope.movies, movie => movie.checked = false);
                $scope.movieListAdded = true;
                $scope.movies = RefreshListService.refresh("movies");
            })
        })
    }
});
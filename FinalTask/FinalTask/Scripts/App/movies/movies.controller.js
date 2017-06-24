angular.module('app').controller('MoviesController', function ($filter, moviesRepository, localStorageService, $http, $scope, SetStorageService, RefreshListService) {
    $scope.movies = angular.fromJson(localStorageService.get("movies"));

    $scope.filters = [
        {
            Name: "All",
            Filter: "all",
            checked: true
        },
        {
            Name: "Name",
            Filter: "name"
        },
        {
            Name: "Director",
            Filter: "director"
        },
        {
            Name: "Movie lists",
            Filter: "movieList"
        }
    ];

    $scope.getSelected = function (listToCheck) {
        var selected = $filter("filter")(listToCheck, {
            checked: true
        });

        return _.flatMap(selected, selection => selection.Filter);
    }

    $scope.search = function () {
        moviesRepository.search($scope.searchInput, $scope.getSelected($scope.filters))
            .then(function (response) {
                $scope.movies = response.data;
            })
    }
});
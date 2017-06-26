angular.module('app').controller('MoviesController', function ($filter, moviesRepository, localStorageService, $http, $scope, SetStorageService, RefreshListService, MovieSearchService) {
    $scope.noMovies = false;

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

    $scope.sentFilters = "all";
    $scope.getFilters = function () {
        var selected = $filter("filter")($scope.filters, {
            checked: true
        });

        $scope.sentFilters = _.flatMap(selected, selection => selection.Filter);
    }

    $scope.clearFilters = function (filter) {
        if (filter === "all")
            for (var i = 1; i < $scope.filters.length; i++) {
                $scope.filters[i].checked = false;
            }
        else
            $scope.filters[0].checked = false;
        $scope.getFilters();
    }
});
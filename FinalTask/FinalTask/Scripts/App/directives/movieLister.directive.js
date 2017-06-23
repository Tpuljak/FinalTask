angular.module('app').directive('movieLister', function (localStorageService) {
    return {
        restrict: 'AE',
        scope: {
            showMovieLists: '@',
            expanded: '@',
            movieListId: '@'
        },
        templateUrl: 'Scripts/App/directives/movieLister.template.html',
        controller: function ($scope, moviesRepository, DeleteListItemService, RefreshListService) {
            if ($scope.expanded === "true")
                $scope.expand = true;
            else
                $scope.expand = false;

            if ($scope.showMovieLists === "true")
                $scope.showLists = true;
            else
                $scope.showLists = false;

            if (!$scope.movieListId)
                $scope.movies = RefreshListService.refresh("movies");

            else
                $scope.movies = _.filter(angular.fromJson(localStorageService.get("movies")), movie => _.find(movie.MovieLists, movieList => movieList.Id == parseInt($scope.movieListId)));

            $scope.deleteMovie = function (id) {
                /*moviesRepository.delete(id).then(function (response) {
                    moviesRepository.getAll()
                        .then(function (response) {
                            SetStorageService.setLocalStorage(response.data, "movies");
                            $scope.movies = angular.fromJson(localStorageService.get("movies"));
                        });
                });
                */
                setTimeout(function () {
                    DeleteListItemService.deleteMovie(id);

                }, 1);
                setTimeout(function () {
                    $scope.movies = RefreshListService.refresh("movies");

                }, 10);
            }
        }
    }
});
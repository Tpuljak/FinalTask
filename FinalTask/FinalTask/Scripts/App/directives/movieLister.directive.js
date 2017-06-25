angular.module('app').directive('movieLister', function (localStorageService, RefreshListService) {
    return {
        restrict: 'AE',
        scope: {
            showMovieLists: '@',
            expanded: '@',
            movieListId: '@',
            searchResault: '='
        },
        link: function ($scope, element, attrs) {
            $scope.$watch('searchResault', function (newVal, oldVal) {
                if ($scope.searchResault)
                    $scope.movies = $scope.searchResault;
                else
                    $scope.movies = RefreshListService.refresh("movies");
                console.log($scope.movies);
            })  
        },
        templateUrl: 'Scripts/App/directives/movieLister.template.html',
        controller: function ($scope, moviesRepository, RefreshListService, SetStorageService) {
            if (!$scope.movieListId || !$scope.movies)
                $scope.movies = RefreshListService.refresh("movies");

            else if ($scope.movieListId)
                $scope.movies = _.filter(RefreshListService.refresh("movies"), movie => _.find(movie.MovieLists, movieList => movieList.Id === parseInt($scope.movieListId)));

            $scope.deleteMovie = function (id) {
                moviesRepository.delete(id)
                    .then(function (response) {
                        moviesRepository.getAll()
                            .then(function (response) {
                                SetStorageService.setLocalStorage(response.data, "movies");
                                $scope.movies = RefreshListService.refresh("movies");
                            });
                });
            }
        }
    }
});
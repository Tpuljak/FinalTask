angular.module('app').directive('movieLister', function (RefreshListService, moviesRepository) {
    return {
        restrict: 'AE',
        scope: {
            showMovieLists: '@',
            expanded: '@',
            movieListId: '@',
            searchInput: '@',
            filters: '=',
            refresh: '@'
        },
        link: function ($scope) {
            $scope.$watch('filters', function (newVal, oldVal) {
                if($scope.searchInput)
                    moviesRepository.search($scope.searchInput, $scope.filters)
                        .then(function (response) {
                            $scope.movies = response.data;
                            if (!$scope.movies.length) {
                                $scope.noMovies = true;
                            }
                            else
                                $scope.noMovies = false;
                        });
            });

            $scope.$watch('searchInput', function (newVal, oldVal) {
                if ($scope.searchInput) {
                    moviesRepository.search($scope.searchInput, $scope.filters)
                        .then(function (response) {
                            $scope.movies = response.data;
                            if (!$scope.movies.length) {
                                $scope.noMovies = true;
                            }
                            else
                                $scope.noMovies = false;
                        });
                }
                else if (!$scope.searchInput && !$scope.movieListId) {
                    $scope.movies = RefreshListService.refresh("movies");
                    $scope.noMovies = false;
                }
            });

            $scope.$watch('refresh', function (newVal, odlVal) {
                if (!$scope.movies)
                    $scope.movies = RefreshListService.refresh("movies");

                if ($scope.movieListId) {
                    $scope.movies = _.filter(RefreshListService.refresh("movies"), movie => _.find(movie.MovieLists, movieList => movieList.Id == $scope.movieListId));
                }
            })
        },
        templateUrl: 'Scripts/App/directives/movieLister.template.html',
        controller: function ($scope, SetStorageService) {
            if (!$scope.movies)
                $scope.movies = RefreshListService.refresh("movies");

            if ($scope.movieListId) {
                $scope.movies = _.filter(RefreshListService.refresh("movies"), movie => _.find(movie.MovieLists, movieList => movieList.Id == $scope.movieListId));
            }

            $scope.deleteMovie = function (id) {
                moviesRepository.delete(id).then(function () {
                    moviesRepository.getAll().then(function (response) {
                        SetStorageService.setLocalStorage(response.data, "movies");
                        $scope.movies = RefreshListService.refresh("movies");
                    });
                });
            }
        }
    }
});
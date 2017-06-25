angular.module('app').controller('MovieListsController', function (localStorageService, SetStorageService, $scope, movieListsRepository, RefreshListService) {
    $scope.movieLists = RefreshListService.refresh("movieLists");
    $scope.movies = RefreshListService.refresh("movies");

    for (movieList in $scope.movieLists) {
        movieList.Movies = _.filter($scope.movies, movie => _.find(movie.MovieLists, movieList => movieList.Id === movieList.Id));
    }

    $scope.deleteMovieList = function (id) {
        movieListsRepository.delete(id)
            .then(function (response) {
                movieListsRepository.getAll()
                    .then(function (response) {
                        SetStorageService.setLocalStorage(response.data, "movieLists");
                        $scope.movieLists = RefreshListService.refresh("movieLists");
                    });
            });
    }
});
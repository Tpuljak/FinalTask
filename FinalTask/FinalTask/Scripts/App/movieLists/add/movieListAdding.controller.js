angular.module('app').controller('MovieListAddingController', function ($filter, $scope, RefreshListService, SetStorageService, movieListsRepository, moviesRepository) {
    $scope.movies = RefreshListService.refresh("movies");
    $scope.genres = RefreshListService.refresh("genres");
    $scope.movieListAdded = false;
    $scope.selectedGenre = "random";

    $scope.getSelected = function (listToCheck) {
        var selected = $filter("filter")(listToCheck, {
            checked: true
        });
        return selected;
    }

    $scope.addNewMovieList = function () {
        if (!$scope.newMovieListName) {
            alert("Movie list name required");
            return;
        }

        if ($scope.movieGeneration === "manual") {
            if (!$scope.getSelected($scope.movies)) {
                alert("Movie list has to contain at least one movie!");
                return;
            }
            var newMovieList = {
                Name: $scope.newMovieListName,
                Movies: $scope.getSelected($scope.movies)
            }
        }
        
        else {
            if (!$scope.selectedGenre) {
                alert("Genre choice must be selected!");
                return;
            }

            if ($scope.selectedGenre !== "random")
                var movies = _.filter($scope.movies, movie => movie.GenreId == $scope.selectedGenre);
            else
                var movies = $scope.movies;

            if ($scope.numberOfMovies)
                movies = _.sampleSize(movies, parseInt($scope.numberOfMovies));

            var newMovieList = {
                Name: $scope.newMovieListName,
                Movies: movies
            }
        }

        movieListsRepository.create(newMovieList).then(function () {
            movieListsRepository.getAll().then(function (response) {
                SetStorageService.setLocalStorage(response.data, "movieLists");
                $scope.newMovieListName = "";
                $scope.numberOfMovies = "";
                angular.forEach($scope.movies, movie => movie.checked = false);
                $scope.movieListAdded = true;
                moviesRepository.getAll().then(function (response) {
                    SetStorageService.setLocalStorage(response.data, "movies");
                    $scope.movies = RefreshListService.refresh("movies");
                })
            })
        })
    }
});
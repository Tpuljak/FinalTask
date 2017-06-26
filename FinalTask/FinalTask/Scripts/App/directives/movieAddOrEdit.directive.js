angular.module('app').directive('movieAddEdit', function () {
    return {
        restrict: 'AE',
        scope: {
            mode: '@',
            movieId: '@'
        },
        templateUrl: '/Scripts/App/directives/movieAddOrEdit.template.html',
        controller: function ($scope, $filter, RefreshListService, SetStorageService, directorsRepository, actorsRepository, hashtagsRepository, genresRepository, movieListsRepository, moviesRepository) {
            $scope.loadData = function () {
                $scope.directors = RefreshListService.refresh("directors");
                $scope.genres = RefreshListService.refresh("genres");
                $scope.actors = RefreshListService.refresh("actors");
                $scope.hashtags = RefreshListService.refresh("hashtags");
                $scope.movieLists = RefreshListService.refresh("movieLists");
                $scope.selectedDirectorId = null;
                $scope.selectedGenreId = null;
            }

            $scope.loadData();

            if ($scope.mode === 'add') {
                $scope.nameText = "Movie name: *";
                $scope.directorText = "Choose a director: *";
                $scope.genreText = "Choose a genre: *";
                $scope.actorsText = "Choose actors: *";
                $scope.hashtagsText = "Choose hashtags: ";
                $scope.movieListsText = "Choose movie lists: ";
            }
            else if ($scope.mode === 'edit') {
                $scope.nameText = "Edit name: *";
                $scope.directorText = "Edit director: *";
                $scope.genreText = "Edit genre: *";
                $scope.actorsText = "Edit actors: *";
                $scope.hashtagsText = "Edit hashtags: ";
                $scope.movieListsText = "Edit movie lists: ";

                $scope.movie = _.find(RefreshListService.refresh("movies"), movie => movie.Id == $scope.movieId);
                $scope.newMovieName = $scope.movie.Name;
            }

            $scope.getSelected = function (listToCheck) {
                var selected = $filter("filter")(listToCheck, {
                    checked: true
                });
                return selected;
            }

            $scope.resetForm = function () {
                $scope.newMovieName = "";
                $scope.selectedDirectorId = null;
                $scope.selectedGenreId = null;
                angular.forEach($scope.actors, actor => actor.checked = false);
                angular.forEach($scope.hashtags, hashtag => hashtag.checked = false);
                angular.forEach($scope.movieLists, movieList => movieList.checked = false);
            }

            $scope.addDirector = function (newDirectorName) {
                directorsRepository.create(newDirectorName).then(function () {
                    directorsRepository.getAll().then(function (response) {
                        SetStorageService.setLocalStorage(response.data, "directors");
                        $scope.directors = RefreshListService.refresh("directors");
                        $scope.newDirectorName = "";
                    })
                });
            }

            $scope.addActor = function (newActorName) {
                actorsRepository.create(newActorName).then(function () {
                    actorsRepository.getAll().then(function (response) {
                        SetStorageService.setLocalStorage(response.data, "actors");
                        $scope.actors = RefreshListService.refresh("actors");
                        $scope.newActorName = "";
                    })
                });
            }

            $scope.addGenre = function (newGenreName) {
                genresRepository.create(newGenreName).then(function () {
                    genresRepository.getAll().then(function (response) {
                        SetStorageService.setLocalStorage(response.data, "genres");
                        $scope.genres = RefreshListService.refresh("genres");
                        $scope.newGenreName = "";
                    })
                });
            }

            $scope.addHashtag = function (newHashtagText) {
                hashtagsRepository.create(newHashtagText).then(function () {
                    hashtagsRepository.getAll().then(function (response) {
                        SetStorageService.setLocalStorage(response.data, "hashtags");
                        $scope.hashtags = RefreshListService.refresh("hashtags");
                        $scope.newHashtagText = "";
                    })
                });
            }

            $scope.addMovieList = function (newMovieListName) {
                movieListsRepository.create({ Name: newMovieListName }).then(function () {
                    movieListsRepository.getAll().then(function (response) {
                        SetStorageService.setLocalStorage(response.data, "movieLists");
                        $scope.movieLists = RefreshListService.refresh("movieLists");
                        $scope.newMovieListName = "";
                    })
                });
            }

            $scope.addOrEditMovie = function () {
                if (!$scope.newMovieName || !$scope.selectedDirectorId || !$scope.selectedGenreId || !$scope.getSelected($scope.actors)) {
                    alert("All * fields are required!")
                    return;
                }

                var newMovie = {
                    Name: $scope.newMovieName,
                    DirectorId: $scope.selectedDirectorId,
                    GenreId: $scope.selectedGenreId,
                    Actors: $scope.getSelected($scope.actors),
                    Hashtags: $scope.getSelected($scope.hashtags),
                    MovieLists: $scope.getSelected($scope.movieLists)
                }

                if ($scope.mode === 'add')
                    moviesRepository.create(newMovie).then(function () {
                        moviesRepository.getAll().then(function (response) {
                            SetStorageService.setLocalStorage(response.data, "movies");
                            $scope.resetForm();
                            $scope.loadData();
                            alert("Movie successfully added!");
                        })
                    })

                else if ($scope.mode === 'edit')
                    newMovie.Id = $scope.movie.Id;
                    moviesRepository.edit(newMovie).then(function () {
                        moviesRepository.getAll().then(function (response) {
                            SetStorageService.setLocalStorage(response.data, "movies");
                            $scope.resetForm;
                            $scope.loadData();
                            $scope.$apply();
                        })
                    })
            };
        }
    }
})
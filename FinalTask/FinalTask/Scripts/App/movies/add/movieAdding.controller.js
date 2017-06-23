angular.module('app').controller('MovieAddingController', function ($filter, localStorageService, $scope, SetStorageService, RefreshListService, moviesRepository, actorsRepository, hashtagsRepository, directorsRepository, movieListsRepository, genresRepository) {
    $scope.movieAdded = false;

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

    $scope.addNewMovie = function () {
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

        moviesRepository.create(newMovie).then(function () {
            moviesRepository.getAll().then(function (response) {
                SetStorageService.setLocalStorage(response.data, "movies");
                $scope.movieAdded = true;
                $scope.resetForm();
                $scope.loadData();
            })
        })

    };
})
angular.module('app').config(function ($locationProvider, $urlRouterProvider) {
    $locationProvider.html5Mode(true);
    $urlRouterProvider.otherwise('/');
});

angular.module('app').run(function (localStorageService, moviesRepository, movieListsRepository, hashtagsRepository, genresRepository, actorsRepository, directorsRepository) {
    if (!angular.fromJson(localStorageService.get("movies"))) {
        moviesRepository.getAll()
            .then(function (response) {
                localStorageService.set("movies", angular.toJson(response.data));
            });
    }
            
    if (!angular.fromJson(localStorageService.get("movieLists"))) {
        movieListsRepository.getAll()
            .then(function (response) {
                localStorageService.set("movieLists", angular.toJson(response.data));
            });
    }
        
    if (!angular.fromJson(localStorageService.get("hashtags"))) {
        hashtagsRepository.getAll()
            .then(function (response) {
                localStorageService.set("hashtags", angular.toJson(response.data));
            });
    }
        
    if (!angular.fromJson(localStorageService.get("genres"))) {
        genresRepository.getAll()
            .then(function (response) {
                localStorageService.set("genres", angular.toJson(response.data));
            });
    }
        
    if (!angular.fromJson(localStorageService.get("actors"))) {
        actorsRepository.getAll()
            .then(function (response) {
                localStorageService.set("actors", angular.toJson(response.data));
            });
    }
        
    if (!angular.fromJson(localStorageService.get("directors"))) {
        directorsRepository.getAll()
            .then(function (response) {
                localStorageService.set("directors", angular.toJson(response.data));
            });
    }
});
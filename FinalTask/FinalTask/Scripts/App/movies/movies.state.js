angular.module('app').config(function ($stateProvider) {
    $stateProvider
        .state('movies', {
            url: '/movies',
            controller: 'MoviesController',
            templateUrl: '/Scripts/App/movies/movies.template.html'
        });
})
angular.module('app').config(function ($stateProvider) {
    $stateProvider
        .state('movieAdding', {
            url: '/add-movie',
            templateUrl: '/Scripts/App/movies/add/movieAdding.template.html'
        });
});
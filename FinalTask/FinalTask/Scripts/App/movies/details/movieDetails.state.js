angular.module('app').config(function ($stateProvider) {
    $stateProvider
        .state('movieDetails', {
            url: '/movieDetails/:movieId',
            controller: 'MovieDetailsController',
            templateUrl: '/Scripts/App/movies/details/movieDetails.template.html'
        });
});
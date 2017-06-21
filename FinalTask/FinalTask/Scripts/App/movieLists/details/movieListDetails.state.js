angular.module('app').config(function ($stateProvider) {
    $stateProvider
        .state('movieListDetails', {
            url: '/movieListDetails/:movieListId',
            controller: 'MovieListDetailsController',
            templateUrl: '/Scripts/App/movieLists/details/movieListDetails.template.html'
        });
});
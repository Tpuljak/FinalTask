angular.module('app').config(function ($stateProvider) {
    $stateProvider
        .state('movieLists', {
            url: '/movieLists',
            controller: 'MovieListsController',
            templateUrl: 'Scripts/App/movieLists/movieLists.template.html'
        });
});
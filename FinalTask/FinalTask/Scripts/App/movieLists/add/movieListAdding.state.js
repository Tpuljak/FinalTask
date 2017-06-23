angular.module('app').config(function ($stateProvider) {
    $stateProvider
        .state('movieListAdding', {
            url: '/add-movieList',
            controller: 'MovieListAddingController',
            templateUrl: '/Scripts/App/movieLists/add/movieListAdding.template.html'
        });
});
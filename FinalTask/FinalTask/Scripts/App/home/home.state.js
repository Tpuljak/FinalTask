angular.module('app').config(function ($stateProvider) {
    $stateProvider
        .state('home', {
            url: '/home',
            controller: 'HomeController',
            templateUrl: '/Scripts/App/home/home.template.html'
        });
})
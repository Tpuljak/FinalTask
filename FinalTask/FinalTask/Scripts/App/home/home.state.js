angular.module('app').config(function ($stateProvider) {
    $stateProvider
        .state('home', {
            url: '/',
            templateUrl: '/Scripts/App/home/home.template.html'
        });
})
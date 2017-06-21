angular.module('app').directive('movieLister', function (localStorageService) {
    return {
        restrict: 'AE',
        scope: {
            showMovieLists: '@',
            expanded: '@'
        },
        templateUrl: 'Scripts/App/directives/movieLister.template.html',
        controller: function ($scope) {
            if ($scope.expanded === "true")
                $scope.expand = true;
            else
                $scope.expand = false;

            if ($scope.showMovieLists === "true")
                $scope.showLists = true;
            else
                $scope.showLists = false;

            $scope.movies = angular.fromJson(localStorageService.get("movies"));
        }
    }
});
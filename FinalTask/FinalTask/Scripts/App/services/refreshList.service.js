angular.module('app').service('RefreshListService', function (localStorageService) {
    this.refresh = function (listName) {
        if (angular.fromJson(localStorageService.get(listName)))
            return angular.fromJson(localStorageService.get(listName));
        else
            return null;
    }
});
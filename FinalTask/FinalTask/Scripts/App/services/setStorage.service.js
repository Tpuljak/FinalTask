angular.module('app').service('SetStorageService', function (localStorageService) {
    this.setLocalStorage = function (dataSet, dataSetName) {
        localStorageService.set(dataSetName, angular.toJson(dataSet));
    }
});
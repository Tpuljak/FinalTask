angular.module('app').service('MovieSearchService', function (RefreshListService, moviesRepository) {
    this.search = function (searchText, searchBy) {
        moviesRepository.search(searchText, searchBy).then(function (response) {
            return response.data;       
        })
    }
})
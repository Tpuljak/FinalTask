angular.module('app').service('genresRepository', function ($http) {
    function getAllGenres() {
        return $http.get('/genres/get-all');
    }

    function createGenre(name) {
        var newGenre = {
            Name: name
        }

        return $http.post('/genres/create/', newGenre);
    }

    return {
        getAll: getAllGenres,
        create: createGenre
    }
})
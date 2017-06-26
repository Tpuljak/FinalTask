angular.module('app').service('directorsRepository', function ($http) {
    function getAllDirectors() {
        return $http.get('/directors/get-all');
    }

    function createDirector(name) {
        var newDirector = {
            Name: name
        }

        return $http.post('directors/create/', newDirector);
    }

    return {
        getAll: getAllDirectors,
        create: createDirector
    };
})
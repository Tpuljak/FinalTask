angular.module('app').service('directorsRepository', function ($http) {
    function getAllDirectors() {
        return $http.get('/directors/get-all');
    }

    function getSpecificDirector(id) {
        return $http.get('/directors/get/', {
            params: {
                id: id
            }
        });
    }

    function createDirector(name) {
        var newDirector = {
            Name: name
        }

        return $http.post('directors/create/', newDirector);
    }

    return {
        getAll: getAllDirectors,
        getSpecific: getSpecificDirector,
        create: createDirector
    };
})
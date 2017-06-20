angular.module('app').service('actorsRepository', function ($http) {
    function getAllActors() {
        return $http.get('/actors/get-all');
    }

    function getSpecificActor(id) {
        return $http.get('/actors/get', {
            params: {
                id: id
            }
        });
    }

    function createActor(name) {
        var newActor = {
            Name: name
        };
        return $http.post('/actors/create/', newActor);
    }

    return {
        getAll: getAllActors,
        getSpecific: getSpecificActor,
        create: createActor
    };
})
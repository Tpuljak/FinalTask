angular.module('app').service('actorsRepository', function ($http) {
    function getAllActors() {
        return $http.get('/actors/get-all');
    }

    function createActor(name) {
        var newActor = {
            Name: name
        };
        return $http.post('/actors/create/', newActor);
    }

    return {
        getAll: getAllActors,
        create: createActor
    };
})
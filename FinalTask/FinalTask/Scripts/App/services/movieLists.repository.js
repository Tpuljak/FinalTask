angular.module('app').service('movieListsRepository', function ($http, moviesRepository) {
    function getAllMovieLists() {
        return $http.get('movieLists/get-all');
    }

    function createMovieList(newMovieList) {
        return $http.post('/movieLists/create/', newMovieList);
    }

    function deleteMovieList(id) {
        return $http.delete('/movieLists/delete/', {
            params: {
                id: id
            }
        });
    }

    function editMovieList(changedMovieList) {
        return $http.post('/movieLists/edit/', changedMovieList);
    }

    return {
        getAll: getAllMovieLists,
        create: createMovieList,
        delete: deleteMovieList,
        edit: editMovieList
    };
})
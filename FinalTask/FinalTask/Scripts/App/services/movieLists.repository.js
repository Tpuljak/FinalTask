angular.module('app').service('movieListsRepository', function ($http, moviesRepository) {
    function getAllMovieLists() {
        return $http.get('movieLists/get-all');
    }

    function getSpecificMovieList(id) {
        return $http.get('/movieLists/get/', {
            params: {
                id: id
            }
        });
    }

    function createMovieList(name, movieIds) {
        var movies = new Array();
        for (movieId in movieIds) {
            movies.push(moviesRepository.getSpecific(movieId));
        }

        var newMovieList = {
            Name: name,
            Movies: movies
        }

        return $http.post('/movieLists/create/', newMovieList);
    }

    function deleteMovieList(id) {
        return $http.delete('/movieLists/delete/', {
            params: {
                id: id
            }
        });
    }

    return {
        getAll: getAllMovieLists,
        getSpecific: getSpecificMovieList,
        create: createMovieList,
        delete: deleteMovieList
    };
})
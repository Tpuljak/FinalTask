angular.module('app').service('hashtagsRepository', function ($http) {
    function getAllHashtags() {
        return $http.get('/hashtags/get-all');
    }

    function getSpecificHashtag(id) {
        return $http.get('/hashtags/get', {
            params: {
                id: id
            }
        });
    }

    function createHashtag(text) {
        var newHashtag = {
            Text: text
        }
        return $http.post('/hashtags/create/', newHashtag);
    }

    return {
        getAll: getAllHashtags,
        getSpecific: getSpecificHashtag,
        create: createHashtag
    };
})
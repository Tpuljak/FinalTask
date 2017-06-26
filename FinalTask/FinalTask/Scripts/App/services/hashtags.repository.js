angular.module('app').service('hashtagsRepository', function ($http) {
    function getAllHashtags() {
        return $http.get('/hashtags/get-all');
    }

    function createHashtag(text) {
        if (text[0] != '#')
            text = '#' + text;

        var newHashtag = {
            Text: text
        }

        return $http.post('/hashtags/create/', newHashtag);
    }

    return {
        getAll: getAllHashtags,
        create: createHashtag
    };
})
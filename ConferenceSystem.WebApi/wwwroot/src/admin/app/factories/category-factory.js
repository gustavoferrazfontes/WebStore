(function () {
    angular.module('confsys').factory('CategoryFactory', CategoryFactory);

    CategoryFactory.$inject = ['$http', 'SETTINGS']

    function CategoryFactory($http, SETTINGS) {

        return {
            create: _create,
            remove: _delete,
            update: _update,
            get:_getAll

        };

        function _create(newCategory) {

            var url = SETTINGS.SERVICE_URL + 'api/register/categories';
            var header = { headers: { 'Content-Type': 'application/json' } };
            return $http.post(url, newCategory, header);
        };

        function _delete(params) {
            console.log(params);
            var url = SETTINGS.SERVICE_URL + 'api/register/categories/'+params.id;
            var header = { headers: { 'Content-Type': 'application/json' } };
            return $http.delete(url, header);
        };

        function _update(updatedCategory) {
            var url = SETTINGS.SERVICE_URL + 'api/register/categories';
            var header = { headers: { 'Content-Type': 'application/json' } };
            return $http.put(url, updatedCategory, header);
        }
        function _getAll() {
            var url = SETTINGS.SERVICE_URL + 'api/register/categories';
            var header = { headers: { 'Content-Type': 'application/json' } };
            return $http.get(url, header);
        }



    };

})();
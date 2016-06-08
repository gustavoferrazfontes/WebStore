(function () {
    'use strict';

    angular.module('confsys').factory('LoadingInterceptor', LoadingInterceptor);

    function LoadingInterceptor($q, $rootScope) {
        return {
            request: function (config) {
                $rootScope.$emit('LOAD');
                return config;
            },
            requestError: function (rejection) {
                $rootScope.$emit('UNLOAD');
                return $q.reject(rejection);
            },
            response: function (response) {
                $rootScope.$emit('UNLOAD');
                return response;
            },
            responseError: function (rejection) {
                $rootScope.$emit('UNLOAD');
                return $q.reject(rejection);
            }
        }
    };

})();
(function () {
    angular.module('confsys').factory('AccountFactory', AccountFactory);

    AccountFactory.$inject = ['$http', 'SETTINGS']

    function AccountFactory($http, SETTINGS) {

        return {
            login: login,
            signIn: signIn
        };
        function login(data) {
            var dt = "grant_type=password&username=" + data.username + "&password=" + data.password;
            var url = SETTINGS.SERVICE_URL + 'api/security/token';
            var header = { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } };
            return $http.post(url, dt, header);
        };

        function signIn(data) {
            var newUser = {
                email: data.username,
                password: data.password
            };
            var url = SETTINGS.SERVICE_URL + 'api/account/users'
            var header = { headers: { 'Content-Type': 'application/json' } };
            return $http.post(url, newUser, header);
        }
    };

})();
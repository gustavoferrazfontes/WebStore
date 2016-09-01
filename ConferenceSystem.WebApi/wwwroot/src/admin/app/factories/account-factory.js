(function () {
    angular.module('confsys').factory('AccountFactory', AccountFactory);

    AccountFactory.$inject = ['$http', 'SETTINGS']

    function AccountFactory($http, SETTINGS) {

        return {
            login: _login,
            signIn: _signIn,
            getAccessToken: _getAccessToken,
            externalAuthData: _externalAuthData,
            registerExternal: _registerExternal

        };

        var _externalAuthData = {
            provider: "",
            userName: "",
            externalAccessToken: ""
        };

        function _login(data) {
            var dt = "grant_type=password&username=" + data.username + "&password=" + data.password;
            var url = SETTINGS.SERVICE_URL + 'api/security/token';
            var header = { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } };
            return $http.post(url, dt, header);
        };

        function _signIn(data) {
            var newUser = {
                email: data.username,
                password: data.password
            };
            var url = SETTINGS.SERVICE_URL + 'api/account/users'
            var header = { headers: { 'Content-Type': 'application/json' } };
            return $http.post(url, newUser, header);
        };

        function _getAccessToken(externalData) {

            var dt = { params: { provider: externalData.provider, externalAccessToken: externalData.externalAccessToken } }
            var header = { headers: { 'Content-Type': 'application/json' } };
            var url = SETTINGS.SERVICE_URL + 'api/account/ObtainLocalAccessToken';
           return $http.get(url, dt, header);
        };

        function _registerExternal(data) {
            var url = SETTINGS.SERVICE_URL + 'api/account/RegisterExternal';
            var header = { headers: { 'Content-Type': 'application/json' } };
            return $http.post(url, data, header);
        };
    };

})();
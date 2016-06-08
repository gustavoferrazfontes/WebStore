(function () {
    'use strict';
    angular.module('confsys').controller('LoginCtrl', LoginCtrl);

    LoginCtrl.$inject = ['$location', '$rootScope', 'AccountFactory', 'SETTINGS'];

    function LoginCtrl($location, $rootScope, AccountFactory, SETTINGS) {
        var vm = this;

        vm.login = {
            username: '',
            password: ''
        };
        vm.submit = login;
        vm.externalLogin = loginWithFacebook;
        function login() {
            AccountFactory.login(vm.login)
            .success(success)
            .catch(fail);

            function success(response) {

                $rootScope.user = vm.login.username;
                $rootScope.token = response.access_token;
                sessionStorage.setItem(SETTINGS.AUTH_TOKEN, response.access_token);
                sessionStorage.setItem(SETTINGS.AUTH_USER, $rootScope.user);
                $location.path('/');
                toastr.success('Autenticado com sucesso!');

            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha n autenticação');
            }
        }

        function loginWithFacebook() {

            var redirectUri = location.protocol + '//' + location.host + '/wwwroot/src/admin/Public/dev/Index.html#/';
            var externalProviderUrl = SETTINGS.SERVICE_URL + "api/account/ExternalLogin?provider=Facebook&response_type=token&client_id=ConferenceSystem&redirect_uri="+redirectUri;
            var oauthWindow = window.open(externalProviderUrl, "Authenticate Account", "location=0,status=0,width=600,height=750");
            console.log(externalProviderUrl);
        }
    };


})();
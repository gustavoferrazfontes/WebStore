(function () {
    'use strict';
    angular.module('confsys').controller('LoginCtrl', LoginCtrl);

    LoginCtrl.$inject = ['$location', '$rootScope', 'AccountFactory', 'SETTINGS', '$scope'];

    function LoginCtrl($location, $rootScope, AccountFactory, SETTINGS, $scope) {
        var vm = this;

        vm.login = {
            username: '',
            password: ''
        };
        vm.submit = login;
        vm.externalLogin = ExternalLogin;

        vm.authCompletedCB = AuthCompletedCB;
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

        function ExternalLogin() {

            var redirectUri = location.protocol + '//' + location.host + '/wwwroot/src/admin/public/dev/authcomplete.html';
            var externalProviderUrl = SETTINGS.SERVICE_URL + "api/account/ExternalLogin?provider=Facebook&response_type=token&client_id=ConferenceSystem&redirect_uri=" + redirectUri;

            window.$windowScope = vm;
            var oauthWindow = window.open(externalProviderUrl, "Authenticate Account", "location=0,status=0,width=600,height=750");


        }

        function AuthCompletedCB(fragment) {

            $scope.$apply(function () {
                if (fragment.haslocalaccount == 'False') {

                    AccountFactory.externalAuthData = {
                        provider: fragment.provider,
                        userName: fragment.external_user_name,
                        externalAccessToken: fragment.external_access_token
                    };

                    $location.path('/associate');
                    
                    alert(" local host account false")

                }
                else {
                    //Obtain access token and redirect
                    var externalData = { provider: fragment.provider, externalAccessToken: fragment.external_access_token };
                    AccountFactory.getAccessToken(externalData)
                    .success(success)
                    .catch(fail);

                    function success(response) {
                        alert(" local host account True")
                        $rootScope.user = null;
                        $rootScope.token = null;

                        $rootScope.user = fragment.external_user_name;
                        $rootScope.token = fragment.external_access_token;
                        sessionStorage.setItem(SETTINGS.AUTH_TOKEN, $rootScope.token);
                        sessionStorage.setItem(SETTINGS.AUTH_USER, $rootScope.user);
                        toastr.success("Bem vindo " + $rootScope.user + "!")
                    }

                    function fail(error) {
                        toastr.error("Ocorreu um erro ao tentar logar pelo facebook: " + error.data.message);
                    }
                }

            });
        }
    };


})();
(function () {
    'use strict';
    angular.module('confsys').controller('SignInCtrl', SignInCtrl);

    SignInCtrl.$inject = ['$location', '$rootScope', 'AccountFactory'];

    function SignInCtrl($location, $rootScope, AccountFactory) {

        var vm = this;

        vm.signIn = {
            username: '',
            password: '',
            confirmPassword: ''
        };

        vm.submit = signIn;

        vm.submit = signIn;

        function signIn() {
            $rootScope.$emit('LOAD');
            AccountFactory.signIn(vm.signIn)
            .success(success)
            .catch(fail);
        };

        function success(response) {
            $rootScope.$emit('UNLOAD');
            toastr.success("Cadastro realizado com sucesso!");
            $location.path('/login');
        };

        function fail(error) {
            $rootScope.$emit('UNLOAD');
            toastr.error(error.data.error_description, 'Falha n autenticação');
        };

    };
})();
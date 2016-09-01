(function () {
    'use strict';

    angular.module('confsys').controller("AssociateCtrl", AssociateCtrl);

    AssociateCtrl.$inject = ['$location', 'AccountFactory', '$rootScope'];

    function AssociateCtrl($location, AccountFactory, $scope) {

        var vm = this;

        vm.registerData = {
            userName: AccountFactory.externalAuthData.userName,
            provider: AccountFactory.externalAuthData.provider,
            externalAccessToken: AccountFactory.externalAuthData.externalAccessToken
        };

        vm.registerExternal = registerExternal;


        function registerExternal() {
            AccountFactory.registerExternal(vm.registerData)
            .success(success)
            .catch(fail);


            function success(response) {
                console.log(response)
            }

            function fail(error) {
                console.log(error);
            }
        }
    };

})();
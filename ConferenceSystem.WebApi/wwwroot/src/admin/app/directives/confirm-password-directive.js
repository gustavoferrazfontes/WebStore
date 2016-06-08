(function () {
    'use strict';
    angular.module('confsys').directive('confirmPassword', ConfirmPassword);

    function ConfirmPassword() {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope,elem,attrs,ctrl) {
                var firstPassword = '#' + attrs.confirmPassword;
                elem.add(firstPassword).on('keyup', function () {
                    scope.$apply(function () {
                        var isEqual = elem.val() === $(firstPassword).val();
                        ctrl.$setValidity('passwordMatch', isEqual);
                    });
                });
            }
        }
    };
})();
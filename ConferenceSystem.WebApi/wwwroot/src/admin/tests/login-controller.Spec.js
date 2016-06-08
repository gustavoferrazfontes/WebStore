describe('Dado um usuario', function () {

    var myScope = null;
    var accountFactory = null;
    var loginCtrl = null;
    beforeEach(module('confsys'));

    beforeEach(inject(function ($rootScope,$controller, _AccountFactory_) {
        var rootScope = $rootScope;
        accountFactory = _AccountFactory_;
        myScope = rootScope.$new();

        loginCtrl = $controller('LoginCtrl',{ $rootScope: myScope, AccountFactory: accountFactory });
    }));

    describe('Quando for autenticar-se', function () {

      
    });
});
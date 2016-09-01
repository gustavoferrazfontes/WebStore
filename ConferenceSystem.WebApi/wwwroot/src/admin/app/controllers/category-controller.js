(function () {
    'use strict';
    angular.module('confsys').controller('CategoryCtrl', CreateCategoryCtrl);

    CreateCategoryCtrl.$inject = ['$scope', 'CategoryFactory'];

    function CreateCategoryCtrl($scope, CategoryFactory) {
        var vm = this;

        vm.category = {
            id: 0,
            name: ''
        }

        vm.categories = [];

        vm.update = Update;

        vm.delete = Delete;

        vm.submit = addNew;

        activate();

        function activate() {
            getAll();
        }

        function getAll() {
            CategoryFactory.get()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.categories = response;
                console.log(vm.categories);
            }

            function fail(error) {
                toastr.error('Erro ao obter as categorias cadastradas' + error.value);
            }
        }

        function addNew() {
            CategoryFactory.create(vm.category)
            .success(success)
            .catch(fail);

            function success(response) {
                toastr.success('Categoria criada com sucesso!');
                activate();
            }

            function fail(error) {
                toastr.error('Erro ao criar a nova categoria! ' + error.value);
            }
        };


        function Delete(category) {
            vm.category = {
                id: category.id,
                name:category.name
            };
            CategoryFactory.remove(vm.category)
            .success(success)
            .catch(fail);

            function success(response) {
                toastr.success('Categoria "'+vm.category.name+'" excluida com sucesso!');
                activate();
            }

            function fail(error) {
                toastr.error('Erro ao deletar a categoria: ' + error.value);
            }
        }


        function Update(category) {
            CategoryFactory.update(category)
            .success(success)
            .catch(fail);

            function success(response) {
                toastr.success('Categoria foi Alterada');
            }

            function fail(error) {
                toastr.error('Erro ao alterar a categoria: ' + error.value);
            }
        }

    };

})();
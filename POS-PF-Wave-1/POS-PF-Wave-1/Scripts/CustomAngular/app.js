angular.module('myApp', ['ngAnimate','ngMaterial', 'ngMessages'])

.controller('ctrl', function ($scope, $mdDialog, $mdMedia) {
    $scope.status = '  ';
    $scope.customFullscreen = $mdMedia('xs') || $mdMedia('sm');

    $scope.productos = ['a', 'b', 'c', 'd', 'e', 'f'];
    
    $scope.showPrompt = function (ev,index) {
        // Appending dialog to document.body to cover sidenav in docs app
        var confirm = $mdDialog.prompt()
              .title('Confirmacion de eliminacion de producto')
              .textContent('Instroduzca la contrasenia de administrador.')
              .placeholder('Contrasena')
              .ariaLabel('contra')
              .targetEvent(ev)
              .ok('Eliminar!')
              .cancel('No eliminar');
        $mdDialog.show(confirm).then(function (result) {
            $scope.productos.splice(index,1);
            $scope.status = 'You decided to name your dog ' + result + '.';
        }, function () {
            $scope.status = 'You didn\'t name your dog.';
        });
    };
    
});
function DialogController($scope, $mdDialog) {
    $scope.hide = function () {
        $mdDialog.hide();
    };
    $scope.cancel = function () {
        $mdDialog.cancel();
    };
    $scope.answer = function (answer) {
        $mdDialog.hide(answer);
    };
}
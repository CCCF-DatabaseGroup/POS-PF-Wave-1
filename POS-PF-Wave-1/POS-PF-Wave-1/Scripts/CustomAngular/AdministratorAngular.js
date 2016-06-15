myApp.controller('AdministratorController',function($scope,$http){

    //======================================================================================================
    //=================== Administrar Productos ============================================================
    //======================================================================================================


    // Esta funcion se encarga de inicializar o resetear el valor del producto a un valor "default"
    $scope.cleanProduct = function () {
        $scope.product =
        {
            Id_producto: 1,
            Nombre_producto: '',
            Id_proveedor_producto: 1,
            EAN: "",
            Descripcion: "",
            DETALLES_FACTURA: null,
            PRODUCTOS_SUCURSAL: null,
            PROVEEDOR: null
        };
        if ($scope.providers != null && $scope.providers.length > 0) $scope.providerSelected = $scope.providers[0];
    }
    $scope.cleanProduct();

    $scope.setProviderId = function(){
        $scope.product.Id_proveedor_producto = $scope.providerSelected.Id_proveedor;
    }

    $scope.setActiveProvider = function (id) {
        console.log("Se quiere activar el proovedor ", id);
        for (var x = 0; x < $scope.providers.length; x++) {
            var active = $scope.providers[x];
            if (active.Id_proveedor == id) {
                console.log("Se llama a activar proveedor!");
                $scope.providerSelected = active;
                break;
            }
        }
    }



    //Esta funcion se encarga de buscar el producto
    $scope.findProduct = function () {
        console.log($scope.product.Id_producto);
        $http({
            url: '/Administrador/FindProduct/',
            method: 'GET',
            params: { id: $scope.product.Id_producto }
        })
        .success(function (result) {
            result.EAN = parseInt(result.EAN);
            console.log(result);
            $scope.product = result;
            $scope.setActiveProvider(result.Id_proveedor_producto);
            $scope.setProviderId();
        })
        .error(function (data) {
            alert("No de pudo encontrar el producto! con el Identificador: " + $scope.product.Id_producto);
        });
    }


    //Esta funcion se encarga de buscar el producto
    $scope.updateProduct = function () {
        console.log($scope.product.Id_producto);
        $http({
            url: '/Administrador/UpdateProduct/',
            method: 'POST',
            params: { product: $scope.product}
        })
        .success(function (result) {
            alert("se ha actualizado el producto con exito!");
            $scope.cleanProduct();
        })
        .error(function (data) {
            alert("No de pudo encontrar el producto! con el Identificador: " + $scope.product.Id_producto);
        });
    }

    
    



    //======================================================================================================
    //=================== Administrar Prooveedores =========================================================
    //======================================================================================================

    //Esta funcion se encarga de buscar los Proovedores
    $scope.getProviders = function () {
        console.log("Function getProvider is called");
        $http({
            url: '/Administrador/GetProviders/',
            method: 'GET',
        })
        .success(function (result) {
            console.log(result);
            $scope.providers = result;
            if ($scope.providers.length > 0) $scope.providerSelected = result[0];
        })
        .error(function (data) {
            alert("No de pudo encontrar el producto! con el Identificador: " + $scope.product.Id_producto);
        });
    }


});
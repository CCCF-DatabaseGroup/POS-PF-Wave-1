function clone(obj) {
    if (null == obj || "object" != typeof obj) return obj;
    var copy = obj.constructor();
    for (var attr in obj) {
        if (obj.hasOwnProperty(attr)) copy[attr] = obj[attr];
    }
    return copy;
}

myApp.controller('AdministratorController', function ($scope, $http) {

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
            DETALLES_FACTURA: [],
            PRODUCTOS_SUCURSAL: [],
            PROVEEDOR: []
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
            if (result != null && result.Nombre_producto != null) {
                result.EAN = parseInt(result.EAN);
                console.log(result);
                $scope.product = result;
                $scope.setActiveProvider(result.Id_proveedor_producto);
                $scope.setProviderId();
            }
            else {
                alert("No existe el producto con el codigo: " + $scope.product.Id_producto);
            }
        })
        .error(function (data) {
            alert("No de pudo encontrar el producto! con el Identificador: " + $scope.product.Id_producto);
        });
    };

    //Esta funcion se encarga de hacer los preparativos al objeto product
    var prepareProduct = function () {
        $scope.setProviderId();
        var productcp = clone($scope.product);
        productcp.EAN = productcp.EAN.toString();
        console.log(productcp);
        
        return productcp;
    }


    //Esta funcion se encarga de actualizar el producto
    $scope.updateProduct = function () {
        var productcp = prepareProduct();
        $http.post('/Administrador/UpdateProduct/', { product: productcp })
        .success(function (result) {
            alert("se ha actualizado el producto con exito!");
            $scope.cleanProduct();
        })
        .error(function (data) {
            alert("No de pudo encontrar el producto! con el Identificador: " + $scope.product.Id_producto);
        });
    }

    
    //Esta funcion se encarga de buscar el producto
    $scope.removeProduct = function () {
        console.log($scope.product.Id_producto);
        $http({
            url: '/Administrador/RemoveProduct',
            method: 'POST',
            params: { id: $scope.product.Id_producto }
        })
        .success(function (result) {
            alert("se ha eliminado el producto con exito!");
            $scope.cleanProduct();
        })
        .error(function (data) {
            alert("No de pudo eliminar el producto: " + $scope.product.Id_producto);
        });
    };

    //Esta funcion se encarga de buscar el producto
    $scope.addProduct = function () {
        var productcp = prepareProduct();
        $http.post('/Administrador/AddProduct/', { product: productcp })
        .success(function (result) {
            alert("se ha creado el producto con exito!");
            $scope.cleanProduct();
        })
        .error(function (data) {
            alert("Ha ocurrido un error :(");
        });
    };



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
            alert("No hay sistema, por favor comuniquese con su administrador mas cercano" );
        });
    }

    //providerSelected
    
    //Esta funcion se encarga de buscar el producto
    $scope.addProvider = function () {
        $http.post('/Administrador/AddProvider/', { provider: $scope.providerSelected })
        .success(function (result) {
            alert("se ha creado , con exito, el proveedor!");
            $scope.cleanProduct();
        })
        .error(function (data) {
            alert("Ha ocurrido un error! :(");
        });
    };





    //Esta funcion se encarga de buscar el producto
    $scope.UpdateProvider = function () {
        $http.post('/Administrador/UpdateProvider/', { provider: $scope.providerSelected })
        .success(function (result) {
            alert("se ha actualizado el proveedor con exito!");
            $scope.getProviders();
        })
        .error(function (data) {
            alert("Ha ocurrido un error! :(");
        });
    };
    //Esta funcion se encarga de buscar el producto
    $scope.RemoveProvider = function () {
        $http.post('/Administrador/RemoveProvider',{ provider: $scope.providerSelected })
        .success(function (result) {
            alert("se ha removido el proveedor con exito!");
            $scope.getProviders();
        })
        .error(function (data) {
            alert("Ha ocurrido un error! :(");
        });
    };


    //======================================================================================================
    //=================== Administrar Sucursales ===========================================================
    //======================================================================================================
    $scope.cleanBranchOffice = function () {
        $scope.branchOfficeSelected = {
            Id_sucursal: 1,
            Id_farmacia_sucursal: 1,
            Nombre_sucursal: "",
            Telefono_sucursal: 1,
            Direccion_sucursal: "",
            CAJA: [],
            FARMACIA: [],
            PRODUCTOS_SUCURSAL: []
        }
    }

    $scope.cleanBranchOffice();



    //Esta funcion se encarga de buscar los Proovedores
    $scope.getBranchOffices = function () {
        console.log("Function getProvider is called");
        $http({
            url: '/Administrador/GetBranchOffice/',
            method: 'GET',
        })
        .success(function (result) {
            console.log(result);
            $scope.branchOffices = result;
            if ($scope.branchOffices.length > 0) $scope.branchOfficeSelected= result[0];
        })
        .error(function (data) {
            alert("No hay sistema, por favor comuniquese con su administrador mas cercano");
        });
    }

    //Esta funcion se encarga de buscar el producto
    $scope.addBranchOffice = function () {
        $http.post('/Administrador/AddBranchOffice/', { branchOffice: $scope.branchOfficeSelected})
        .success(function (result) {
            alert("se ha creado , con exito, la sucursal!");
            $scope.cleanBranchOffice();
        })
        .error(function (data) {
            alert("Ha ocurrido un error! :(");
        });
    };

    //Esta funcion se encarga de buscar el producto
    $scope.UpdateBranchOffice = function () {
        $http.post('/Administrador/UpdateBranchOffice/', { branchOffice: $scope.branchOfficeSelected })
        .success(function (result) {
            alert("se ha actualizado la sucursal con exito!");
            $scope.getBranchOffices();
        })
        .error(function (data) {
            alert("Ha ocurrido un error! :(");
        });
    };
    //Esta funcion se encarga de buscar el producto
    $scope.RemoveBranchOffice = function () {
        $http.post('/Administrador/RemoveBranchOffice', { branchOffice: $scope.branchOfficeSelected })
        .success(function (result) {
            alert("se ha removido la sucursal con exito!");
            $scope.getBranchOffices();
        })
        .error(function (data) {
            alert("Ha ocurrido un error! :(");
        });
    };
});
//(function () {
//    "use strict";

//    // Crear el módulo de usuarios
//    angular.module("app-usuarios", ['angularModalService'])
//})();

var app = angular.module("app-usuarios", ['angularModalService']);

app.controller("usuariosController", function ($scope, $http, ModalService) {
    // Lista de usuarios en el sistema
    $scope.usuarios = {};
    // Mensaje de error
    $scope.error = "";
    // Opcion del usuario (sí/no)
    $scope.opcion = null;
    // Roles de usuario
    $scope.roles = {}

    $scope.obtenerUsuarios = function () {
        $http.get("/API/Usuarios")
        .then(function (response) {
            $scope.usuarios = response.data;
        }, function (error) {
            $scope.error = "Error al obtener usuarios: " + error;
        });
    }

    $scope.obtenerRoles = function () {
        $http.get("/API/Roles")
        .then(function (response) {
            $scope.roles = response.data;
        }, function (error) {
            $scope.error = "Error al obtener roles: " + error;
        });
    }

    $scope.editarUsuario = function (usuario, listaRoles) {
        $scope.error = "";
        ModalService.showModal({
            templateUrl: "views/editarUsuario.html",
            controller: "EditarController",
            inputs: {
                rol: usuario.rol,
                roles: listaRoles
            }
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function (result) {
                if (usuario.rol.nombre == result.nombre) {
                    console.log(result);
                } else {
                    usuario.rolId = result.id;
                    $http.post("/API/Editar", usuario)
                    .then(function (response) {
                        console.log(response);
                    }, function (error) {
                        $scope.error = "Error al editar usuario: " + error;
                    });
                }
            });
        });
    }

    $scope.borrarUsuario = function (usuario) {
        $scope.error = "";
        console.log("Quieres borrar usuario:" + usuario.correo);
        ModalService.showModal({
            templateUrl: "views/borrarUsuario.html",
            controller: "BorrarController"
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function (result) {
                $scope.opcion = result;
                console.log(usuario);
                if (result) {
                    $http.post("/API/Borrar", usuario)
                        .then(function (response) {
                            console.log(response);
                        }, function (error) {
                            $scope.error = "Error al borrar usuario: " + error;
                        });
                }
            });
        });
    }

    $scope.obtenerUsuarios();
    $scope.obtenerRoles();
});

app.controller('BorrarController', function ($scope, close) {

    $scope.close = function (result) {
        close(result, 500);
    };
});

app.controller('EditarController', function ($scope, $element, rol, roles, close) {
    console.log("Rol actual: " + rol.nombre)

    $scope.rolActual = rol;
    $scope.listaRoles = roles;
    $scope.rolSeleccionado = $scope.rolActual;

    $scope.accept = function () {
        console.log("Escogiste rol: " + $scope.rolSeleccionado.nombre);
        close($scope.rolSeleccionado, 500);
    };

    $scope.cancel = function () {
        console.log("Escogiste rol: " + $scope.rolSeleccionado.nombre);
        close($scope.rolActual, 500);
    };
});
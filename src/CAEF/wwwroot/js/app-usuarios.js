//(function () {
//    "use strict";

//    // Crear el módulo de usuarios
//    angular.module("app-usuarios", ['angularModalService'])
//})();

var app = angular.module("app-usuarios", ['angularModalService']);

app.controller("usuariosController", function ($scope, $location, $window, $http, ModalService) {
    // Lista de usuarios en el sistema
    $scope.usuarios = {};
    // Mensaje de error
    $scope.error = "";
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
                usuario: usuario,
                roles: listaRoles
            }
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function (result) {
                if (usuario.rol.nombre != result.nombre) {
                    console.log(result);
                    usuario.rolId = result.id;
                    $http.post("/API/Editar", usuario)
                    .then(function (response) {
                        ModalService.showModal({
                            templateUrl: "views/mensajeGenerico.html",
                            controller: "MensajeController",
                            inputs: {
                                mensaje: "El usuario fue modificado exitosamente"
                            }
                        }).then(function (modal) {
                            modal.element.modal();
                            modal.close.then(function () {
                                $window.location = "/Usuarios";
                            });
                        });
                        
                    }, function (error) {
                        ModalService.showModal({
                            templateUrl: "views/mensajeGenerico.html",
                            controller: "MensajeController",
                            inputs: {
                                mensaje: "Ocurrió un error al modificar usuario"
                            }
                        }).then(function (modal) {
                            modal.element.modal();
                            modal.close.then(function () {
                                $window.location = "/Usuarios";
                            });
                        });
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

app.controller('EditarController', function ($scope, $element, usuario, roles, close) {
    console.log(usuario);

    $scope.usuario = usuario;
    $scope.rolActual = usuario.rol;
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

app.controller('MensajeController', function ($scope, mensaje, close) {
    $scope.mensaje = mensaje;

    $scope.close = function () {
        close(true, 500);
    };
});
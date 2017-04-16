//(function () {
//    "use strict";

//    angular.module("app-usuarios")
//        .controller("usuariosController", usuariosController);

//    function usuariosController($http, ModalService) {

//        //ModalService.showModal({
//        //    templateUrl: "views/borrarUsuario.html",
//        //    controller: "usuariosController"
//        //}).then(function (modal) {

//        //    //it's a bootstrap element, use 'modal' to show it
//        //    modal.element.modal();
//        //    modal.close.then(function (result) {
//        //        console.log(result);
//        //    });
//        //});


//        var vm = this;

//        // Usuario a eliminar o editar
//        vm.usuario = "Usuario";
//        // Lista de usuarios en el sistema
//        vm.usuarios = {};
//        // Mensaje de error
//        vm.error = "";
//        // Opcion del usuario (sí/no)
//        vm.opcion = null;

//        vm.obtenerUsuarios = function () {
//            $http.get("/API/Usuarios")
//            .then(function (response) {
//                vm.usuarios = response.data;
//                //console.log(response);
//            }, function (error) {
//                vm.error = "Error al obtener usuarios: " + error;
//            });
//        }

//        vm.editarUsuario = function (usuario) {
//            vm.error = "";
//            //$http.post("/API/Editar", vm.usuario)
//            //    .then(function (response) {
//            //        vm.obtenerUsuarios();
//            //    }, function () {
//            //        vm.error = "Error al editar usuario";
//            //    });
//            console.log("Quieres editar usuario:" + usuario.correo);
//        }

//        vm.borrarUsuario = function (usuario) {
//            vm.error = "";
//            console.log("Quieres borrar usuario:" + usuario.correo);
//            ModalService.showModal({
//                templateUrl: "views/borrarUsuario.html",
//                controller: "usuariosController"
//            }).then(function (modal) {
//                modal.element.modal();
//                modal.close.then(function (result) {
//                    vm.opcion = result;
//                    console.log(result);
//                });
//            });
//            //$http.post("/API/Borrar", usuario)
//            //    .then(function (response) {
//            //        console.log(response);
//            //    }, function (error) {
//            //        vm.error = "Error al borrar usuario: " + error;
//            //    });
//        }

//        vm.obtenerUsuarios();
//    }
//})();
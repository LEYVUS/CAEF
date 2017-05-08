appController.controller("loginCtrl", function ($scope, $location, $rootScope, $http, ModalService, localStorageService, utileria) {
    $scope.mensajeDTO = {}
    $scope.usuarioDTO = {
        "Id": "",
        "Correo": "",
        "Rol":{"Id":"","Nombre":""},
        "Nombre": "",
        "Apellido": "",
        "Contrasenia": "",
        "Numero_Empleado":""
    }
    
    //


    ///
    $scope.IniciarSesion = function () {

        if (localStorageService.get('user') == null) {
            $http.post(utileria.ObtenerURL() + 'Login', $scope.usuarioDTO)
           .then(
               function (respuestaExito) {
                   $scope.mensajeDTO = angular.copy(respuestaExito.data.Respuesta);

                   if ($scope.mensajeDTO.Entidad != null) {
                       localStorageService.set('user', angular.copy(angular.copy($scope.mensajeDTO.Entidad)));
                       $location.path('/SS/Inicio');
                   } else {
                       mostrarModal($scope.mensajeDTO.Mensaje, 'Login');
                   }
               }
           );
        }
    }


    ///


    ///
    function mostrarModal(mensaje, URL) {
      
        if ($rootScope.modal) {
            $rootScope.modal = false;
            ModalService.showModal({
                templateUrl: '../../Content/views/mensaje.html',
                controller: "MensajeControlador",
                inputs: {
                    mensaje: mensaje
                }
            }).then(function (modal) {
                modal.element.modal();
                modal.close.then(function (resultado) {
                    $rootScope.modal = true;
                });
            });
        }
        
    }

});
///


///
appController.controller('MensajeControlador', function ($scope, close, mensaje, $rootScope) {
    $scope.message = mensaje;
     console.log('asda')
    $scope.close = function (resultado) {
        close(resultado, 400); 
    };

    $scope.activarModal = function (){
        $rootScope.modal = true;
    }

});
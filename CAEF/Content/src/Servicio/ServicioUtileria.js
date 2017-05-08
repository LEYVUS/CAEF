app.factory('utileria', function ($http) {
    var URL = 'http://localhost:49807/CAEF/'
    function ObtenerRol(id) {

        return $http.get(URL + 'Rol/' + id).then(function (response) {
            
            return response.data;
        });

    }
    function ObtenerCarrera(id) {
        console.log(id)
        return $http.get(URL + 'Carrera/' + id).then(function (response) {
            return response.data;
        });
    }


    function ObtenerURL() {
        return URL;
    }
   



    return {
        ObtenerRol: ObtenerRol,
        ObtenerURL: ObtenerURL,
        ObtenerCarrera, ObtenerCarrera
    };


});
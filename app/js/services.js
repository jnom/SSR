'use strict';

angular.module('myApp.services', [])
.factory('APIFactory', ['$http', '$httpParamSerializer', function ($http, $httpParamSerializer) {
    var api = {  
        authUser : function (data) {
            var UserDetails = {UserDetails: {userName: data.userName, password: data.password}}; 
            return $http.post('WebService.asmx/userLogin', UserDetails);
        },
        addNIR : function (data) {
        	var NIRdata = {Header: data, dtl: {}};
        	return $http.post('WebService.asmx/saveGRNData', NIRdata);
        } 
    };
    return api;
}])
.factory('LSFactory', [function() {
 
        var LSAPI = {
            clear: function() {
                return localStorage.clear();
            },
            get: function(key) {
                return JSON.parse(localStorage.getItem(key));
            },
            set: function(key, data) {
                return localStorage.setItem(key, JSON.stringify(data));
            },
            setArray: function(key, data) {
                return localStorage.setItem(key, JSON.stringify([data]));
            },
            delete: function(key) {
                return localStorage.removeItem(key);
            },
            getAll: function() {
            }
        };
        return LSAPI;
}])
.factory('Loader', function ($rootScope) { 
    return {
        show: function () { 
            $rootScope.$broadcast("loader_show"); 
        },
        hide: function () {
                $rootScope.$broadcast("loader_hide");
        }
         
    };
})
.directive("loaderHtml", function ($rootScope) {
    return function ($scope, element, attrs) {
        $scope.$on("loader_show", function () {
            return element.show();
        });
        return $scope.$on("loader_hide", function () {
            return element.hide();
        });
    };
});

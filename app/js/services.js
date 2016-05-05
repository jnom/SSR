'use strict';

angular.module('myApp.services', [])
.factory('APIFactory', ['$http', '$httpParamSerializer', function ($http, $httpParamSerializer) {
    var api = {  
        authUser : function (data) {
            var UserDetails = {UserDetails: {userName: data.userName, password: data.password}}; 
            return $http.post('WebService.asmx/userLogin', UserDetails);
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
.factory('httpInterceptor', function ($q, $rootScope, $log) {
    var numLoadings = 0;
    return {
        request: function (config) {
            numLoadings++;
            // Show loader
            $rootScope.$broadcast("loader_show");
            return config || $q.when(config)
        },
        response: function (response) {
            if ((--numLoadings) === 0) {
                // Hide loader
                $rootScope.$broadcast("loader_hide");
            }
            return response || $q.when(response);
        },
        responseError: function (response) {
            if (!(--numLoadings)) {
                // Hide loader
                $rootScope.$broadcast("loader_hide");
            }
            return $q.reject(response);
        }
    };
})
.directive("loader", function ($rootScope) {
    return function ($scope, element, attrs) {
        $scope.$on("loader_show", function () {
            return element.show();
        });
        return $scope.$on("loader_hide", function () {
            return element.hide();
        });
    };
});

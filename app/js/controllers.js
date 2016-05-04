'use strict';

/* Controllers */

angular.module('myApp.controllers', [])
    .controller('AppCtrl', ['$scope', function ($scope) { 
    }])
    .controller('LoginCtrl', ['$scope', '$rootScope', function ($scope, $rootScope) {
    	 $scope.$on("$destroy", function() {
        $('.modal-backdrop').css('display', 'none'); 
    });
       $rootScope.title = 'Login';  
    }])
    
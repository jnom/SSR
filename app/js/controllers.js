'use strict';

/* Controllers */

angular.module('myApp.controllers', [])
    .controller('AppCtrl', ['$scope', function ($scope) { 
    }])
    .controller('LoginCtrl', ['$scope', '$rootScope', function ($scope, $rootScope) {
       $rootScope.title = 'Login'; 
    }])
    
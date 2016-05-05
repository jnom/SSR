'use strict';

/* Controllers */

angular.module('myApp.controllers', [])
    .controller('AppCtrl', ['$scope', function ($scope) {
    } ])
    .controller('LoginCtrl', ['$scope', '$rootScope', '$http', '$state', 'APIFactory', 'LSFactory',
      function ($scope, $rootScope, $http, $state, APIFactory, LSFactory) {
        $rootScope.title = 'Login';
        $scope.errorLogin = false;
        $scope.authenticateUser = function (data) {
           APIFactory.authUser(data).then(function (response) { 
                if (response.data.d.userID) {
                  LSFactory.set('authUser', response.data.d)
                  $state.go('app.add');
                } else {
                  $scope.errorLogin = true;
                }
            }, function (error) {
                console.log(error);
            });
         }
        $scope.$on("$destroy", function () {
            $('.modal-backdrop').css('display', 'none');
        });
    } ]);
    
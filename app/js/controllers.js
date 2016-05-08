'use strict';

/* Controllers */

angular.module('myApp.controllers', [])
    .controller('AppCtrl', ['$scope', function ($scope) {
    } ])
    .controller('LoginCtrl', ['$scope', '$rootScope', '$http', '$state', 'APIFactory', 'LSFactory', 'Loader',
      function ($scope, $rootScope, $http, $state, APIFactory, LSFactory, Loader) {
        $rootScope.title = 'Login'; 
        $scope.authenticateUser = function (data) {
          Loader.show();
           APIFactory.authUser(data).then(function (response) { 
                if (response.data.d.userID) {
                  LSFactory.set('authUser', response.data.d)
                  $state.go('app.add');
                } else {
                  $scope.errorLogin = true;
                }
          Loader.hide(); 
            }, function (error) {
              $scope.errorServer = true;
               Loader.hide(); 

            });
         }
        $scope.$on("$destroy", function () {
            $('.modal-backdrop').css('display', 'none');
        });
    } ])
    .controller('AddNirCtrl', ['$scope', '$rootScope', '$http', '$state', 'APIFactory', 'LSFactory', 
      function ($scope, $rootScope, $http, $state, APIFactory, LSFactory) {
        $rootScope.title = 'NIR (NOTA DE INTREARE)'; 
    }])
    .controller('GrnViewCtrl', ['$scope', '$rootScope', '$http', '$state', 'APIFactory', 'LSFactory', 
      function ($scope, $rootScope, $http, $state, APIFactory, LSFactory) {
        $rootScope.title = 'GRN View'; 
    }])
    
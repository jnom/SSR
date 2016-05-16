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
    .controller('AddNirCtrl', ['$scope', '$rootScope', '$http', '$state', 'APIFactory', 'LSFactory', 'Loader', 
      function ($scope, $rootScope, $http, $state, APIFactory, LSFactory, Loader) {
        // $scope.itemObj = {ItemID:'',uomID:'',DisPer:'', AcceptedQty:'', rate:'', TotalPrice:''};
        $scope.itemsArray = [];
        // $scope.itemsArray = [{ItemID:'1',uomID:'1',DisPer:'10', AcceptedQty:'50', rate:'10', TotalPrice:'100'}]
        $rootScope.title = 'NIR (NOTA DE INTREARE)'; 
        $scope.saveNIR = function (data) {
          Loader.show();
          APIFactory.addNIR(data).then(function (response) {
            console.log('successs');
            Loader.hide();
          }, function (error) {
            console.log(error);
            Loader.hide();
          })
          
        }
        $scope.getDiscountedPrice = function (price, qty, discount) {
          if (!price || !qty) {
            return 0;
          }
          var price = price * qty;
          var discountedPrice = ((price * discount || 0)/100);
          return (price - discountedPrice);
        }
        $scope.addItem = function (data) {
          data.totalPrice = $scope.getDiscountedPrice(data.rate, data.AcceptedQty, data.DisPer);
          data.storeStock = 120;
          $scope.itemsArray.push(data);
          $scope.newItem = {};
        }
        $scope.removeItem = function (index) { 
          $scope.itemsArray.splice(index, 1);
        }
         jQuery( "#city" ).autocomplete({
          var tableName;
          if(jQuery(this).hasClass('ourCode')) tableName = 'ourCode'
          else tableName = 'ourName' 
      source: function( request, response ) {
        jQuery.ajax({
          type: "POST",
          url: "WebService.asmx/getItemDetails", 
          data: {
            pStoreID: '2',
            vStrWork: request.term,
            tableName: tableName
          },
          dataType: "json",
          success: function (data) {
             var temp = data.responseText.replace('<?xml version="1.0" encoding="utf-8"?>', '');
            var temp = temp.replace('<string xmlns="http://tempuri.org/" />', ''); 
            response(jQuery.parseJSON(temp));
          },
          error: function (data) {
            var temp = data.responseText.replace('<?xml version="1.0" encoding="utf-8"?>', '');
            var temp = temp.replace('<string xmlns="http://tempuri.org/" />', ''); 
            response(jQuery.parseJSON(temp));
          }
        });
      }, 
      select: function(event, ui) {
        // alert( ui.item ? "Selected: " + ui.item.ourName :  "Nothing selected, input was " + this.value);
        console.log(ui); 
        $scope.newItem = {itemID: ui.item.itemID, uomID: ui.item.uomID, disPer: ui.item.disPer, acceptedQty: ui.item.acceptedQty, rate: ui.item.rate, totalPrice: ui.item.totalPrice, remarks: ui.item.remarks}
        console.log($scope.newItem);
      }
    })
          .autocomplete( "instance" )._renderItem = function( ul, item ) {
      return $( "<li>" )
        .append( "<a>" + item.itemName + "<br><small>" + item.ourName + "</small></a>" )
        .appendTo( ul );
    };
    }])
    .controller('GrnViewCtrl', ['$scope', '$rootScope', '$http', '$state', 'APIFactory', 'LSFactory', 
      function ($scope, $rootScope, $http, $state, APIFactory, LSFactory) {
        $rootScope.title = 'GRN View'; 
    }])
    
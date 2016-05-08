'use strict';


// Declare app level module which depends on filters, and services
angular.module('myApp', ['ui.router', 'myApp.services', 'myApp.controllers']). 
config(function($stateProvider, $urlRouterProvider, $httpProvider) {  
   $stateProvider
    .state('app', {
      url: "/app",
      abstract: true,
      templateUrl: "app/templates/menu.html",
      controller: "AppCtrl"
    })
    .state('app.login', {
      url: "/login", 
        templateUrl: 'app/templates/login.html',
        controller: 'LoginCtrl' 
    })
    .state('app.add', {
      url: "/add", 
        templateUrl: 'app/templates/add-inventry.html',
        controller: 'AddNirCtrl' 
    })
    .state('app.grn-view', {
      url: "/grn-view", 
        templateUrl: 'app/templates/grn-view.html',
        controller: 'GrnViewCtrl' 
    })
    .state('app.material-request', {
      url: "/material-request", 
        templateUrl: 'app/templates/material-request.html' 
    })
    $urlRouterProvider.otherwise('/app/add'); 
});
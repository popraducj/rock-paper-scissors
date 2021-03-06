﻿'use strict';


angular.module('app.controllers', []);
angular.module('app.services', [])
    .value('battleWeapons', { 0: 'rock', 1: 'paper', 2: 'scissors' })
    .value('battleResult', {0 : 'win', 1:'draw', 2: 'lose'})
    .value('apiBattleResultMessage', { 0: 'You have WON, now I have another strategy in mind. Double or nothing?', 1: "This for now is a DRAW. Let's try another.", 2: 'Unfortunately you lost but I am sure you will be better next time. Game?' });
// Declares how the application should be bootstrapped. See: http://docs.angularjs.org/guide/module
angular.module('app', ['ngRoute', 'ui.router', 'app.controllers', 'app.services', 'angular-loading-bar', 'LocalStorageModule'])
    // Gets executed during the provider registrations and configuration phase. Only providers and constants can be
    // injected here. This is to prevent accidental instantiation of services before they have been fully configured.
    .config(['$stateProvider', '$locationProvider', 'cfpLoadingBarProvider', '$httpProvider', function ($stateProvider, $locationProvider, cfpLoadingBarProvider, $httpProvider) {

        // UI States, URL Routing & Mapping. For more info see: https://github.com/angular-ui/ui-router
        // ------------------------------------------------------------------------------------------------------------

        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/views/index',
                controller: 'HomeController'

            })
            .state('inverseGame', {
                url: '/rock-paper-scissors-inverse-game',
                templateUrl: '/views/RockPaperScissorsInverse',
                controller: 'RockPaperScissorsInverseController'

            })
            .state('advancedGame', {
                url: '/advanced-game',
                templateUrl: '/views/AdvancedGame',
                controller: 'AdvancedGameController'

            })
            .state('about', {
                url: '/about',
                templateUrl: '/views/about',
                controller: 'AboutController'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/views/login',
                controller: 'LoginController'
            })
            .state('signup', {
                url: '/signup',
                templateUrl: '/views/signup',
                controller: 'SignupController'
            })
            .state('otherwise', {
                url: '*path',
                templateUrl: '/views/404',
                controller: 'Error404Ctrl'
            });

        $httpProvider.interceptors.push('authInterceptorService');
        cfpLoadingBarProvider.includeSpinner = false;
        $locationProvider.html5Mode(true);
    }])

    // Gets executed after the injector is created and are used to kickstart the application. Only instances and constants
    // can be injected here. This is to prevent further system configuration during application run time.
    .run(['$templateCache', '$rootScope', '$state', '$stateParams', '$location', 'authService', function ($templateCache, $rootScope, $state, $stateParams, $location, authService) {
       
        // <ui-view> contains a pre-rendered template for the current view
        // caching it will prevent a round-trip to a server at the first page load
        var view = angular.element('#ui-view');
        $templateCache.put(view.data('tmpl-url'), view.html());
       
        // Allows to retrieve UI Router state information from inside templates
        $rootScope.$state = $state;
        $rootScope.$stateParams = $stateParams;

        $rootScope.$on('$locationChangeStart', function (event) {
            if (!authService.authentication.isAuth) {
                $location.path('/login');
            }
        });

        $rootScope.$on('$stateChangeSuccess', function (event, toState) {

            // Sets the layout name, which can be used to display different layouts (header, footer etc.)
            // based on which page the user is located
            $rootScope.layout = toState.layout;
        });
    }])
    .value('baseUrl', 'http://api.rock-paper-scissors.org/api/')
    .value('clientId', 'ngAuthApp');
'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers')

    // Path: /
    .controller('LoginController', ['$scope', '$location', '$window', 'authService', function ($scope, $location, $window,  authService) {
        $scope.$root.title = 'Rock Paper Scissors - Login';
        $scope.loginData = {
            userName: '',
            password: ''
        };

        $scope.message = '';
        $scope.login = function () {

            authService.login($scope.loginData).then(function (response) {

                $location.path('/advanced-game')
            }, function (response) {
                $scope.message = response.error_description;
            });
        }


        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])
;
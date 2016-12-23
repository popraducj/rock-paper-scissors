'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers')

    // Path: /
    .controller('SignupController', ['$scope', '$location', '$window', '$timeout', 'authService', function ($scope, $location, $window, $timeout, authService) {
        $scope.$root.title = 'Rock Paper Scissors - Signup';

        $scope.savedSuccessfully = false;
        $scope.message = '';

        $scope.registration = {
            userName: '',
            password: '',
            confirmPassword: ''
        };

        $scope.signUp = function () {
            authService.saveRegistration($scope.registration).then(function (response) {
                $scope.savedSuccessfully = true;
                $scope.message = 'User has been registered successfully, you will be redicted to login page in 2 seconds.';
                startTimer();
            }, function (response) {
                var errors = [];
                for (var key in response.data.modelState) {
                    for (var i = 0; i < response.data.modelState[key].length; i++) {
                        errors.push(response.data.modelState[key][i]);
                    }
                }
                $scope.message = 'Failed to register user due to: ' + errors.join(' ');
            });
        };

        var startTimer = function () {
            var timer =$timeout(function () {
                $timeout.cancel(timer);
                $location.path('/login');
            }, 2000);
        }


        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])
;
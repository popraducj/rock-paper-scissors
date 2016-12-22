'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers').controller('indexController', ['$scope', '$location', '$window', 'authService', function ($scope, $location, $window, authService) {
 
    $scope.logOut = function () {
        authService.logOut();
        $location.path('/login');
    }
    $scope.$on('$viewContentLoaded', function () {
        $window.ga('send', 'pageview', { 'page': $location.path()});
    });

    $scope.authentication = authService.authentication;
 
}]);

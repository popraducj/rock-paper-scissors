'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers')

    // Path: /
    .controller('HomeController', ['$scope', '$location', '$window', 'generatorService', function ($scope, $location, $window, generatorService) {
        $scope.$root.title = 'Rock Paper Scissors';
        generatorService.get().then(function (response) {
            $scope.somethingGenerated = response;
        });
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])      
;
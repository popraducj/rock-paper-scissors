'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers')

    // Path: /
    .controller('HomeController', ['$scope', '$location', '$window', 'gameService', function ($scope, $location, $window, GameService) {
        $scope.$root.title = 'Rock Paper Scissors';
        GameService.get().then(function (response) {
            $scope.somethingGenerated = response;
        }, function (error) {
            $scope.somethingGenerated = "Something is worng with our server. Please be patient."
        });
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])      
;
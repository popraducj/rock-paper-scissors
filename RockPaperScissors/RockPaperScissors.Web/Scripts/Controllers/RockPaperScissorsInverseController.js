'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers')

    // Path: /
    .controller('RockPaperScissorsInverseController', ['$scope', '$location', '$window', 'gameService', function ($scope, $location, $window, GameService) {
        $scope.$root.title = 'Rock Paper Scissors Inverse';
        $scope.fight = function () {
            $scope.isLoading = true;
            $scope.result = {};
            GameService.get($scope.weapon, "rock-paper-scissors-inverse").then(function (response) {
                $scope.result = response;
                $("html, body").animate({ scrollTop: $(document).height() }, 2000);
                $scope.isLoading = false;
            }, function (error) {
                $scope.error = "Something is worng with our server. Please be patient."
                $scope.isLoading = false;
            });
        }
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])      
;
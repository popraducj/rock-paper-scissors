'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers')

    // Path: /
    .controller('AdvancedGameController', ['$scope', '$location', '$window', 'advancedGameService', 'authService', function ($scope, $location, $window, AdvancedGameService, authService) {
        $scope.$root.title = 'Rock Paper Scissors';
        $scope.userName = "";
        $scope.fight = function () {
            $scope.isLoading = true;
            $scope.result = {};
            AdvancedGameService.get($scope.weapon, "rock-paper-scissors", authService.authentication.userName).then(function (response) {
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
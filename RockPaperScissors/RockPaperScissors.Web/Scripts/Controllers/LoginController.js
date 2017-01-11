﻿'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers')

    // Path: /
    .controller('LoginController', ['$scope', '$location', '$window', 'authService', 'baseUrl', 'clientId', function ($scope, $location, $window, authService, baseUrl, clientId) {
        $scope.$root.title = 'Rock Paper Scissors - Login';
        $scope.loginData = {
            userName: 'radupop',
            password: '123456',
            rememberMe: true
        };

        $scope.message = '';
        $scope.login = function () {

            authService.login($scope.loginData).then(function (response) {

                $location.path('/advanced-game')
            }, function (response) {
                $scope.message = response.error_description;
            });
        }
        $scope.authExternalProvider = function (provider) {

            var redirectUri = location.protocol + '//' + location.host + '/authcomplete.html';

            var externalProviderUrl = baseUrl + "Account/ExternalLogin?provider=" + provider
                                                                        + "&response_type=token&client_id=" + clientId
                                                                        + "&redirect_uri=" + redirectUri;
            window.$windowScope = $scope;

            var oauthWindow = window.open(externalProviderUrl, "Authenticate Account", "location=0,status=0,width=600,height=750");
        };

        $scope.authCompletedCB = function (fragment) {

            $scope.$apply(function () {

                if (fragment.haslocalaccount == 'False') {

                    authService.logOut();

                    authService.externalAuthData = {
                        provider: fragment.provider,
                        userName: fragment.external_user_name,
                        externalAccessToken: fragment.external_access_token
                    };

                    $location.path('/associate');

                }
                else {
                    //Obtain access token and redirect to orders
                    var externalData = { provider: fragment.provider, externalAccessToken: fragment.external_access_token };
                    authService.obtainAccessToken(externalData).then(function (response) {

                        $location.path('/orders');

                    },
                 function (err) {
                     $scope.message = err.error_description;
                 });
                }

            });
        }


        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])
;
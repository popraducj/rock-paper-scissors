'use strict';
angular.module('app.services').factory('authInterceptorService', ['$injector', '$q', '$location', 'localStorageService', function ($injector, $q, $location, localStorageService) {
    var inFlightAuthRequest = null;
    var authInterceptorService = {};

    var _request = function (config) {
        config.headers = config.headers || {};
        var authData = localStorageService.get('authorizationData');

        if (authData) {
            config.headers.Authorization = 'Bearer ' + authData.token;
        }
        return config;
    };

    var _responseError = function (rejection) {
        var deferred = $q.defer();
        if (rejection.status === 401) {
            var authService = $injector.get('authService');
            var deferred = $q.defer();
            if (!inFlightAuthRequest) {
                inFlightAuthRequest = authService.refreshToken();
            }
            inFlightAuthRequest.then(function () {
                inFlightAuthRequest = null;
                var authData = localStorageService.get('authorizationData');
                if (authData) {
                    rejection.config.headers.Authorization = 'Bearer ' + authData.token;
                }
                $injector.get("$http")(rejection.config).then(function (resp) {
                    deferred.resolve(resp);
                }, function (resp) {
                    authService.logOut();
                    $location.path('/login');
                    deferred.reject();
                });
            }, function () {
                authService.logOut();
                $q.reject(rejection);
                inFlightAuthRequest = null;
                $location.path('/login');
            })
        }

        return deferred.promise;
    };

    authInterceptorService.request = _request;
    authInterceptorService.responseError = _responseError;

    return authInterceptorService;

}]);
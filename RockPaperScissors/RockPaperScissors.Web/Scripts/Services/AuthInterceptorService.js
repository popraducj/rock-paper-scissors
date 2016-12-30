﻿'use strict';
angular.module('app.services').factory('authInterceptorService', ['$q', '$location', 'localStorageService', function ($q, $location, localStorageService) {

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
        if (rejection.status === 401) {
            $location.path('/login');
        }

        return $q.reject(rejection);
    };

    authInterceptorService.request = _request;
    authInterceptorService.responseError = _responseError;

    return authInterceptorService;

}]);
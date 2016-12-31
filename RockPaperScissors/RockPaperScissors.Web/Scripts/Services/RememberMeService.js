'use strict';
angular.module('app.services').factory('rememberMeService', ['$q', 'localStorageService', 'authService', function ($q, localStorageService, authService) {

    var rememberMeService = {};

    var _authenticate = function () {
        var deferred = $q.defer();
        if (authService.authentication && authService.authentication.expireDate < new Date()) {
            authService.refreshToken().then(function () {
                deferred.resolve();
            }, function () {
                deferred.reject();
            });
        } else {
            deferred.resolve();
        }
        return deferred.promise;
    }

    rememberMeService.loginIfNeeded = _authenticate;

    return rememberMeService;

}]);
'use strict'
angular.module('app.services').factory('authService', ['$http', '$q', 'localStorageService', 'baseUrl', 'clientId', function ($http, $q, localStorageService, baseUrl, clientId) {
    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        userName: "",
        rememberMe: false,
        expireDate : new Date()
    };

    var _saveRegistration = function (registration) {
        _logOut();

        return $http.post(baseUrl + "account/register", registration).then(function (response) {
            return response;
        });
    }

    var _login = function (loginData) {

        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password,
            deferred = $q.defer();

        if (loginData.rememberMe) {
            data = data + "&client_id=" + clientId;
        }

        $http.post(baseUrl + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {
            _authentication.isAuth = true;
            _authentication.userName = loginData.userName;
            _authentication.token = response.access_token;
            _authentication.rememberMe = loginData.rememberMe;

            if (loginData.rememberMe) {
                _authentication.refreshToken = response.refresh_token;
            }
            localStorageService.set('authorizationData', _authentication);
            deferred.resolve(response);

        }).error(function (err) {
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;
    }

    var _logOut = function () {

        localStorageService.remove('authorizationData');

        _authentication.isAuth = false;
        _authentication.userName = "";
    };

    var _fillAuthData = function () {
        var authData = localStorageService.get('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
        }
    }

    var _refreshToken = function () {
        var deferred = $q.defer();

        var authData = localStorageService.get('authorizationData');

        if (authData && authData.rememberMe) {
            var data = "grant_type=refresh_token&refresh_token=" + authData.refreshToken + "&client_id=" + clientId;

            localStorageService.remove('authorizationData');

            $http.post(baseUrl + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {
                _authentication.isAuth = true;
                _authentication.userName = response.userName;
                _authentication.token = response.access_token;
                _authentication.rememberMe = true;
                _authentication.refreshToken = response.refresh_token;

                localStorageService.set('authorizationData', _authentication);
                deferred.resolve(response);

            }).error(function (err, status) {
                _logOut();
                deferred.reject(err);
            });
        } else {
            _logOut();
            deferred.reject();
        }

        return deferred.promise;
    };

    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = -_fillAuthData;
    authServiceFactory.authentication = _authentication;
    authServiceFactory.refreshToken = _refreshToken;

    return authServiceFactory;

}]);
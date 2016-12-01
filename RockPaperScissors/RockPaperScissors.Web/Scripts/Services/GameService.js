'use strict'

angular.module('app.services')
   .factory('gameService', ['$http', '$q', 'baseUrl', function ($http, $q, baseUrl) {
       var gameService = {};
       gameService.get = function () {
           var deferred = $q.defer();
           $http({
               url: baseUrl + "Game/battle?selection=2",// +selection,
               method: "GET"
           }).success(function (data) {
               deferred.resolve(data);
           }).error(function (data, status, headers, config) {
               deferred.reject(status);
           });
           return deferred.promise;
       };
       return gameService;
   }]);
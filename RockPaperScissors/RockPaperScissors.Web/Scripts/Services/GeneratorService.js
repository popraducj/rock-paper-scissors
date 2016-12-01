'use strict'

angular.module('app.services')
   .factory('generatorService', ['$http', '$q', function ($http, $q) {
       var generatorService = {};
       generatorService.get = function () {
           var deferred = $q.defer();

           $http({
               url: "http://api.rock-paper-scissors.org/api/RockPaperScissorsGenerator/get",
               method: "GET"
           }).success(function (data) {
               deferred.resolve(data);
           }).error(function (data, status, headers, config) {

           });
           return deferred.promise;
       };
       return generatorService;
   }]);
'use strict'

angular.module('app.services')
   .factory('advancedGameService', ['$http', '$location', '$q', 'baseUrl', 'apiBattleResultMessage', 'battleResult', 'battleWeapons', 'rememberMeService', function ($http, $location, $q, baseUrl, apiBattleResult, battleResult, battleWeapons, rememberMeService) {
       var gameService = {};
       gameService.get = function (choise, gameType, playerName) {
           var deferred = $q.defer();
           rememberMeService.loginIfNeeded().then(function (response) {
               $http({
                   url: baseUrl + "AdvancedGame/battle?weaponType=" + choise + "&playerName=" + playerName + "&gameType=" + gameType,
                   method: "GET"
               }).success(function (data) {
                   var result = {
                       battleResultMessage: data.result.message,
                       enemyWeapon: battleWeapons[data.enemeyWeapon]
                   };
                   deferred.resolve(result);
               }).error(function (data, status, headers, config) {
                   deferred.reject({ error: status });
               });
           }, function () {
               $location.path('/login');
           })
           return deferred.promise;
       };

       return gameService;
   }]);
'use strict'

angular.module('app.services')
   .factory('advancedGameService', ['$http', '$q', 'baseUrl', 'apiBattleResultMessage', 'battleResult', 'battleWeapons', function ($http, $q, baseUrl, apiBattleResult, battleResult, battleWeapons) {
       var gameService = {};
       gameService.get = function (choise, gameType, playerName) {
           var deferred = $q.defer();
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
           return deferred.promise;
       };
       return gameService;
   }]);
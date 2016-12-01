/// <reference path="../Scripts/_references.js" />
/// <reference path="../Scripts/Controllers/HomeController.js" />

'use strict';

describe('Controllers: HomeController', function () {
    var $scope, ctrl;

    beforeEach(module('app.controllers'));

    beforeEach(inject(function ($rootScope, $controller) {
        $scope = $rootScope.$new();
        ctrl = $controller('HomeController', { $scope: $scope });
    }));

    it('should set a page title', function () {
        expect($scope.$root.title).toBe('Rock Paper Scissors');
    });
});
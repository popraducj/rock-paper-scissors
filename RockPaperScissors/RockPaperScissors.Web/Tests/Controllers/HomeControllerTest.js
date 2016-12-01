/// <reference path="../../Scripts/_references.js" />
/// <reference path="../../Scripts/Controllers/HomeController.js" />

'use strict';

describe('Controllers: RaduController', function () {
    var $scope, ctrl, generatorService;

    beforeEach(module('app.controllers'));

    beforeEach(inject(function ($rootScope, $controller) {
        generatorService = jasmine.createSpyObj('generatorService', ['get']);
        $scope = $rootScope.$new();
        ctrl = $controller('HomeController', { $scope: $scope, generatorService: generatorService });
    }));

    it('should set a page title', function () {
        expect($scope.$root.title).toBe('Rock Paper Scissors');
    });
});
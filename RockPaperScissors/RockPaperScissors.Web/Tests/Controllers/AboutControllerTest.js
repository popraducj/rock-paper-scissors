/// <reference path="../../Scripts/_references.js" />
/// <reference path="../../Scripts/Controllers/AboutController.js" />

'use strict';

describe('Controllers: AboutController', function () {
    var $scope, ctrl;

    beforeEach(module('app.controllers'));

    beforeEach(inject(function ($rootScope, $controller) {
        $scope = $rootScope.$new();
        ctrl = $controller('AboutController', { $scope: $scope });
    }));

    it('should set a page title', function () {
        expect($scope.$root.title).toBe('Rock Paper Scissors - About');
    });
});
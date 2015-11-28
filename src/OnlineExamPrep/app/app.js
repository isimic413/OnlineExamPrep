angular.module('onlineExamPrep', [
    'ui.bootstrap',
    'ui.router',
    'onlineExamPrep.common',
    'onlineExamPrep.components',
    'onlineExamPrep.pages'
]).config(function ($locationProvider, $stateProvider, $urlRouterProvider, Roles, Paths) {
    'use strict';

    $stateProvider.state('public', {
        name: 'public',
        template: '<oep-public-layout></oep-public-layout>'
    })
    .state('main', {
        name: 'main',
        template: '<oep-main-layout></oep-main-layout>'
    });

    var routes = {
        // public routes
        'public.home': {
            url: '/',
            directive: 'home'
        },
        // account
        'public.account/registration': {
            url: '/registracija', // registration
            title: 'Registracija', // Registration
            directive: 'register'
        },
        'public.account/login': {
            url: '/prijava', // login
            title: 'Prijava', // User login
            directive: 'login'
        }
    };

    for (var route in routes) {
        var state = {
            name: route,
            parent: route.split('.')[0],
            template: '<oep-' + routes[route].directive + '></oep-' + routes[route].directive + '>',
            url: routes[route].url ? routes[route].url : '/' + route.split('.')[1],
            params: routes[route].params ? routes[route].params : {}
        };
        if (routes[route].roles) {
            state.params = angular.extend({ roles: routes[route].roles }, state.params);
        }

        $stateProvider.state(route, state);
    }

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });

}).run(function ($rootScope) {
    $rootScope.routes = {};
});

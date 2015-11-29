angular.module('onlineExamPrep', [
    'ngAnimate',
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
        },
        'public.testing-areas': {
            url: '/podrucja-ispitivanja',
            title: 'Područja ispitivanja',
            directive: 'testing-area-list',
            params: {
                entityRoutePrefix: 'public.testing-area/'
            }
        },
        'public.testing-area/add': {
            url: '/podrucja-ispitivanja/novo',
            title: 'Novo područje ispitivanja',
            directive: 'testing-area-edit'
        },
        'public.testing-area/edit': {
            url: '/podrucja-ispitivanja/uredi/:id',
            title: 'Uredi područje ispitivanja',
            directive: 'testing-area-edit'
        }
    };

    for (var route in routes) {
        var stateParams = routes[route].params ? routes[route].params : {};
        var state = {
            name: route,
            parent: route.split('.')[0],
            title: routes[route].title,
            template: '<oep-' + routes[route].directive + '></oep-' + routes[route].directive + '>',
            url: routes[route].url ? routes[route].url : '/' + route.split('.')[1],
            params: routes[route].params ? angular.extend(stateParams, { roles: routes[route].params }) : stateParams
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
}).run(function ($rootScope, $state) {
    $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
        var a = 3;
    });

    $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
        $rootScope.title = toState.title ? toState.title : null;
    });
});

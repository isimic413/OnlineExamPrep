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
            url: '/podrucja-ispitivanja', // testing-areas
            title: 'Područja ispitivanja', // Testing Area List
            directive: 'testing-area-list',
            params: {
                entityRoutePrefix: 'public.testing-area/'
            }
        },
        'public.testing-area/add': {
            url: '/podrucja-ispitivanja/novo', // testing-area/add
            title: 'Novo područje ispitivanja', // Add Testing Area
            directive: 'testing-area-edit'
        },
        'public.testing-area/edit': {
            url: '/podrucja-ispitivanja/uredi/:id', // testing-area/edit/id
            title: 'Uredi područje ispitivanja', // Edit Testing Area
            directive: 'testing-area-edit'
        },
        'public.roles': {
            url: '/tipovi-korisnika', // roles
            title: 'Tipovi korisnika', // Role list
            directive: 'role-list',
            params: {
                entityRoutePrefix: 'public.role/'
            }
        },
        'public.role/add': {
            url: '/tipovi-korisnika/novo', // role/add
            title: 'Novi tip korisnika', // Add Role
            directive: 'role-edit'
        },
        'public.role/edit': {
            url: '/tipovi-korisnika/uredi/:id', // role/edit/id
            title: 'Uredi tip korisnika', // Edit Role
            directive: 'role-edit'
        },
        'public.question-types': {
            url: '/tipovi-zadataka', // roles
            title: 'Tipovi zadataka', // Role list
            directive: 'question-type-list',
            params: {
                entityRoutePrefix: 'public.question-type/'
            }
        },
        'public.question-type/add': {
            url: '/tipovi-zadataka/novo', // question-type/add
            title: 'Novi tip zadatka', // Add Question Type
            directive: 'question-type-edit'
        },
        'public.question-type/edit': {
            url: '/tipovi-zadataka/uredi/:id', // question-type/edit/id
            title: 'Uredi tip zadatka', // Edit Question Type
            directive: 'question-type-edit'
        },
        'public.questions': {
            url: '/zadaci', // questions
            title: 'Zadaci', // Question list
            directive: 'question-list',
            params: {
                entityRoutePrefix: 'public.question/'
            }
        },
        'public.question/add': {
            url: '/zadatak/novo', // question/add
            title: 'Novi zadatak', // Add Question
            directive: 'question-edit'
        },
        'public.question/edit': {
            url: '/zadatak/uredi/:id', // question/edit/id
            title: 'Uredi zadatak', // Edit Question
            directive: 'question-edit'
        },
        'public.exams': {
            url: '/ispiti', // exams
            title: 'Ispiti', // Exam list
            directive: 'exam-list',
            params: {
                entityRoutePrefix: 'public.exam/'
            }
        },
        'public.exam/add': {
            url: '/exam/novo', // exam/add
            title: 'Novi ispit', // Add Exam
            directive: 'exam-edit'
        },
        'public.exam/edit': {
            url: '/exam/uredi/:id', // exam/edit/id
            title: 'Uredi ispit', // Edit Exam
            directive: 'exam-edit'
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

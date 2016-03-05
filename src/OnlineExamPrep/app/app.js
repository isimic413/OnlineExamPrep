angular.module('onlineExamPrep', [
    'ngAnimate',
    'ui.bootstrap',
    'ui.router',
    'onlineExamPrep.common',
    'onlineExamPrep.components',
    'onlineExamPrep.pages'
]).config(function ($httpProvider, $locationProvider, $stateProvider, $urlRouterProvider, Roles, Paths) {
    'use strict';

    $httpProvider.interceptors.push('Interceptor');

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
            url: '/prijava', // login
            directive: 'home'
        },
        'main.home': {
            url: '/',
            title: '',
            directive: 'home',
            roles: Roles.allRoles
        },
        'main.testing-areas': {
            url: '/podrucja-ispitivanja', // testing-areas
            title: 'Područja ispitivanja', // Testing Area List
            directive: 'testing-area-list',
            params: {
                entityRoutePrefix: 'main.testing-area/'
            },
            roles: Roles.admin
        },
        'main.testing-area/add': {
            url: '/podrucja-ispitivanja/novo', // testing-area/add
            title: 'Novo područje ispitivanja', // Add Testing Area
            directive: 'testing-area-edit',
            roles: Roles.admin
        },
        'main.testing-area/edit': {
            url: '/podrucja-ispitivanja/uredi/:id', // testing-area/edit/id
            title: 'Uredi područje ispitivanja', // Edit Testing Area
            directive: 'testing-area-edit',
            roles: Roles.admin
        },
        'main.roles': {
            url: '/tipovi-korisnika', // roles
            title: 'Tipovi korisnika', // Role list
            directive: 'role-list',
            params: {
                entityRoutePrefix: 'main.role/'
            },
            roles: Roles.admin
        },
        'main.role/add': {
            url: '/tipovi-korisnika/novo', // role/add
            title: 'Novi tip korisnika', // Add Role
            directive: 'role-edit',
            roles: Roles.admin
        },
        'main.role/edit': {
            url: '/tipovi-korisnika/uredi/:id', // role/edit/id
            title: 'Uredi tip korisnika', // Edit Role
            directive: 'role-edit',
            roles: Roles.admin
        },
        'main.question-types': {
            url: '/tipovi-zadataka', // roles
            title: 'Tipovi zadataka', // Role list
            directive: 'question-type-list',
            params: {
                entityRoutePrefix: 'main.question-type/'
            },
            roles: Roles.admin
        },
        'main.question-type/add': {
            url: '/tipovi-zadataka/novo', // question-type/add
            title: 'Novi tip zadatka', // Add Question Type
            directive: 'question-type-edit',
            roles: Roles.admin
        },
        'main.question-type/edit': {
            url: '/tipovi-zadataka/uredi/:id', // question-type/edit/id
            title: 'Uredi tip zadatka', // Edit Question Type
            directive: 'question-type-edit',
            roles: Roles.admin
        },
        'main.questions': {
            url: '/zadaci', // questions
            title: 'Zadaci', // Question list
            directive: 'question-list',
            params: {
                entityRoutePrefix: 'main.question/'
            },
            roles: Roles.admin
        },
        'main.question/add': {
            url: '/zadatak/novo', // question/add
            title: 'Novi zadatak', // Add Question
            directive: 'question-edit',
            roles: Roles.admin
        },
        'main.question/edit': {
            url: '/zadatak/uredi/:id', // question/edit/id
            title: 'Uredi zadatak', // Edit Question
            directive: 'question-edit',
            roles: Roles.admin
        },
        'main.exams': {
            url: '/ispiti', // exams
            title: 'Ispiti', // Exam list
            directive: 'exam-list',
            params: {
                entityRoutePrefix: 'main.exam/'
            },
            roles: Roles.admin
        },
        'main.exam/add': {
            url: '/ispit/novo', // exam/add
            title: 'Novi ispit', // Add Exam
            directive: 'exam-edit',
            roles: Roles.admin
        },
        'main.exam/edit': {
            url: '/ispit/uredi/:id', // exam/edit/id
            title: 'Uredi ispit', // Edit Exam
            directive: 'exam-edit',
            roles: Roles.admin
        },
        'main.exam/questions': {
            url: '/ispiti/zadaci/:id', // exam/questions/id
            title: 'Zadaci s ispita',
            directive: 'exam-question-order-edit',
            roles: Roles.admin
        },
        'main.simulator': {
            url: '/simulator/odabir-ispita', // simulator/menu
            title: 'Simulator',
            directive: 'simulator-exam-list',
            roles: Roles.allRoles
        },
        'main.simulator/exam': {
            url: '/simulator/ispit/:id', // simulator/exam/:id
            title: 'Ispit',
            directive: 'exam-simulator',
            params: {
                examTitle: null
            },
            roles: Roles.allRoles
        },
        'main.simulator/results': {
            url: '/simulator/ispit/rezultat', // simulator/exam/result
            title: 'Rezultat ispita',
            directive: 'exam-result',
            params: {
                examTitle: null
            },
            roles: Roles.allRoles
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
            params: stateParams,
            data: routes[route]
        };

        $stateProvider.state(route, state);
    }

    $urlRouterProvider.otherwise('/prijava'); // login

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
}).run(function ($injector, $rootScope, $state) {
    $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
        var principal = $injector.get('Principal');
        if (!principal.getCurrent() && toState.name !== 'public.home') {
            event.preventDefault();

            $state.go('public.home');
        }
        else {
            $rootScope.title = toState.title ? toState.title : null;
            $rootScope.subtitle = null;
        }
    });

    $rootScope.getRouteUrl = function (route, params) {
        return $state.href(route, params, { inherit: false });
    };
});

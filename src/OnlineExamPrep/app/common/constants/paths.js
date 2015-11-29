angular.module('onlineExamPrep.common')
    .constant('Paths', {
        token: 'http://localhost:2514/token',
        api: {
            endpoint: 'http://localhost:2514/api',
            paths: {
                account: '/account',
                testingArea: '/testingArea',
                role: '/role'
            }
        },
        app: {
            common: 'app/common/',
            components: 'app/components/',
            pages: 'app/pages/'
        },
        templates: {
            account: 'account/',
            testingArea: 'testing-area/',
            role: 'role/'
        }
    });
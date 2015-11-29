angular.module('onlineExamPrep.common')
    .constant('Paths', {
        token: 'http://localhost:2514/token',
        api: {
            endpoint: 'http://localhost:2514/api',
            paths: {
                account: '/account',
                questionType: '/questionType',
                role: '/role',
                testingArea: '/testingArea'
            }
        },
        app: {
            common: 'app/common/',
            components: 'app/components/',
            pages: 'app/pages/'
        },
        templates: {
            account: 'account/',
            questionType: 'question-type/',
            role: 'role/',
            testingArea: 'testing-area/'
        }
    });
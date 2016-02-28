angular.module('onlineExamPrep.common')
    .constant('Paths', {
        token: 'http://localhost:2514/token',
        api: {
            endpoint: 'http://localhost:2514/api',
            paths: {
                account: '/account',
                exam: '/exam',
                question: '/question',
                questionType: '/questionType',
                role: '/role',
                testingArea: '/testingArea',
                user: '/user',
                simulator: '/simualtor'
            }
        },
        app: {
            common: '/app/common/',
            components: '/app/components/',
            pages: '/app/pages/'
        },
        templates: {
            account: 'account/',
            exam: 'exam/',
            question: 'question/',
            questionType: 'question-type/',
            role: 'role/',
            testingArea: 'testing-area/',
            simulator: 'simulator/'
        }
    });
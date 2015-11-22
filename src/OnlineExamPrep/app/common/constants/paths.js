angular.module('onlineExamPrep.common')
    .constant('Paths', {
        token: 'http://localhost:2514/token',
        api: {
            endpoint: 'http://localhost:2514/api',
            paths: {
                account: '/account'
            }
        },
        app: {
            common: 'app/common/',
            components: 'app/components/',
            pages: 'app/pages/'
        },
        templates: {
            account: 'account/'
        }
    });
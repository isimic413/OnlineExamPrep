angular.module('onlineExamPrep.common')
    .constant('Paths', {
        api: {
            endpoint: 'http://http://localhost:2514/api',
            account: '/account'
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
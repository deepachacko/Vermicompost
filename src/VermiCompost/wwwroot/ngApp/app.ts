namespace VermiCompost {

    angular.module('VermiCompost', ['ui.router', 'ngResource', 'ui.bootstrap', 'angular-filepicker'])
        .config((
            $stateProvider: ng.ui.IStateProvider,
            $urlRouterProvider: ng.ui.IUrlRouterProvider,
            $locationProvider: ng.ILocationProvider,
            filepickerProvider
        ) => {
            filepickerProvider.setKey('AYgYUakx0TCogpWE3FqiMz');
            // Define routes
            $stateProvider
                .state('composters', {
                    url: '/composters',
                    templateUrl: '/ngApp/views/composters.html',
                    controller: VermiCompost.Controllers.CompostersController,
                    controllerAs: 'controller'
                })
                .state('compostersDetail', {
                    url: '/composters/detail/:id',
                    templateUrl: '/ngApp/views/compostersDetail.html',
                    controller: VermiCompost.Controllers.CompostersDetailController,
                    controllerAs: 'controller'
                })
                .state('compostersCreate', {
                    url: '/composters/create',
                    templateUrl: '/ngApp/views/compostersCreate.html',
                    controller: VermiCompost.Controllers.CompostersCreateController,
                    controllerAs: 'controller'
                })
                .state('compostersEdit', {
                    url: '/composters/edit/:id',
                    templateUrl: '/ngApp/views/composterEdit.html',
                    controller: VermiCompost.Controllers.CompostersEditController,
                    controllerAs: 'controller'
                })
                .state('compostersDelete', {
                    url: '/composters/delete/:id',
                    templateUrl: '/ngApp/views/composterDelete.html',
                    controller: VermiCompost.Controllers.CompostersDetailController,
                    controllerAs: 'controller'
                })
                .state('products', {
                    url: '/products',
                    templateUrl: '/ngApp/views/products.html',
                    controller: VermiCompost.Controllers.ProductsController,
                    controllerAs: 'controller'
                })
                .state('productsDetail', {
                    url: '/products/detail/:id',
                    templateUrl: '/ngApp/views/productsDetail.html',
                    controller: VermiCompost.Controllers.ProductsDetailController,
                    controllerAs: 'controller'
                })
                .state('productsEdit', {
                    url: '/products/edit/:id',
                    templateUrl: '/ngApp/views/productEdit.html',
                    controller: VermiCompost.Controllers.ProductsDetailController,
                    controllerAs: 'controller'
                })
                .state('productsDelete', {
                    url: '/products/delete/:id',
                    templateUrl: '/ngApp/views/productDelete.html',
                    controller: VermiCompost.Controllers.ProductsDetailController,
                    controllerAs: 'controller'
                })
                .state('home', {
                    url: '/',
                    templateUrl: '/ngApp/views/home.html',
                    controller: VermiCompost.Controllers.HomeController,
                    controllerAs: 'controller'
                })
                .state('secret', {
                    url: '/secret',
                    templateUrl: '/ngApp/views/secret.html',
                    controller: VermiCompost.Controllers.SecretController,
                    controllerAs: 'controller'
                })
                .state('login', {
                    url: '/login',
                    templateUrl: '/ngApp/views/login.html',
                    controller: VermiCompost.Controllers.LoginController,
                    controllerAs: 'controller'
                })
                .state('register', {
                    url: '/register',
                    templateUrl: '/ngApp/views/register.html',
                    controller: VermiCompost.Controllers.RegisterController,
                    controllerAs: 'controller'
                })
                .state('externalRegister', {
                    url: '/externalRegister',
                    templateUrl: '/ngApp/views/externalRegister.html',
                    controller: VermiCompost.Controllers.ExternalRegisterController,
                    controllerAs: 'controller'
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/ngApp/views/about.html',
                    controller: VermiCompost.Controllers.AboutController,
                    controllerAs: 'controller'
                })
                .state('notFound', {
                    url: '/notFound',
                    templateUrl: '/ngApp/views/notFound.html'
                }) ;

            // Handle request for non-existent route
            $urlRouterProvider.otherwise('/notFound');

            // Enable HTML5 navigation
            $locationProvider.html5Mode(true);
        });


    angular.module('VermiCompost').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('VermiCompost').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });



}

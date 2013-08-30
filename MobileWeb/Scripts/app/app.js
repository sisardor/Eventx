'use strict';

console.log('script loaded');

angular.module('myApp', ['myApp.controllers', 'myApp.services'])
.config(['$httpProvider', '$locationProvider', function ($httpProvider, $locationProvider) {
}])
.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
        when('/', { templateUrl: 'templates/event-list', controller: 'MainCTRL' }).
        when('/movies', { templateUrl: 'templates/event-list', controller: 'MoviesCTRL' }).
        when('/meetup', { templateUrl: 'templates/event-list', controller: 'MeetupCTRL' }).
        when('/movies/:id', { templateUrl: 'templates/event-detail', controller: 'SingleMovieCTRL' }).
        when('/meetup/:id', { templateUrl: 'templates/event-detail', controller: 'SingleMeetupCTRL' }).
        otherwise({ redirectTo: '/' });
}])
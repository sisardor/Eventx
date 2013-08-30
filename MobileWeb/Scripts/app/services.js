'use strict';

angular.module('myApp.services', ['ngResource'])
    .value('value', '0.1')
    .factory('EventsFactory', function ($resource) {
        return $resource('/api/events/:id', {
            id: '@_id'
        }, {
            query: {
                method: 'GET',
                params: {},
                isArray: true
            }
        }, {
            get: {
                method: 'GET',
                params: {},
                isArray: false
            }
        });
    })
'use strict';

angular.module('myApp.controllers', [])
        .controller('MainCTRL', ['$scope', 'EventsFactory', function ($scope, EventsFactory) {
            console.log(document.cookie);
            $scope.test = "Hello this is test";
            $scope.events = [
                { "category": "movies", "id": 1, "name": "Hello this is text", "time": "Aug 13, 2013", "description": "This is long text about nothing" },
                { "category": "movies", "id": 2, "name": "Blah blah blah", "time": "Sept 10, 2013", "description": "This is second text about nothing also" },
                { "category": "movies", "id": 3, "name": "Hello this is text", "time": "Aug 13, 2013", "description": "This is long text about nothing" },
                { "category": "movies", "id": 4, "name": "Blah blah blah", "time": "Sept 10, 2013", "description": "This is second text about nothing also" }
            ];
            console.log('MainCTRL loaded..');
        }])
        .controller('MoviesCTRL', ['$scope', 'EventsFactory', function ($scope, EventsFactory) {
            $scope.events = [
                { "category": "movies", "id": 11, "name": "Hello this is text", "time": "Aug 13, 2013", "description": "This is long text about nothing" },
                { "category": "movies", "id": 12, "name": "Blah blah blah", "time": "Sept 10, 2013", "description": "This is second text about nothing also" },
                { "category": "movies", "id": 13, "name": "Hello this is text", "time": "Aug 13, 2013", "description": "This is long text about nothing" },
                { "category": "movies", "id": 14, "name": "Blah blah blah", "time": "Sept 10, 2013", "description": "This is second text about nothing also" },
                { "category": "movies", "id": 15, "name": "Hello this is text", "time": "Aug 13, 2013", "description": "This is long text about nothing" },
                { "category": "movies", "id": 16, "name": "Blah blah blah", "time": "Sept 10, 2013", "description": "This is second text about nothing also" },
                { "category": "movies", "id": 17, "name": "Hello this is text", "time": "Aug 13, 2013", "description": "This is long text about nothing" },
                { "category": "movies", "id": 18, "name": "Blah blah blah", "time": "Sept 10, 2013", "description": "This is second text about nothing also" }
            ];

            console.log('MoviesCTRL loaded..');
        }])
        .controller('MeetupCTRL', ['$scope', 'EventsFactory', function ($scope, EventsFactory) {
            $scope.events = [
                { "category": "meetup", "id": 21, "name": "Hello this is text", "time": "Aug 13, 2013", "description": "This is long text about nothing" },
                { "category": "meetup", "id": 22, "name": "Blah blah blah", "time": "Sept 10, 2013", "description": "This is second text about nothing also" }
            ];
            var params = {
                start_date: '8/21/2013',
                end_date: '8/22/2013'
            }
            EventsFactory.query(params, function (data) {
                console.log(data[0].events);
                $scope.events = data[0].events;
            }, function (er) {
                console.log(er);
            });

            console.log('MeetupCTRL loaded..');
        }])
        .controller('SingleMovieCTRL', ['$scope', '$route', 'EventsFactory', function ($scope, $route, EventsFactory) {
            $scope.event =
                { "category": "movie", "id": 11, "name": "Hello this is text", "time": "Aug 13, 2013", "description": "This is long text about nothing" };

            var params = {
                id: $route.current.params.id
            }; // request parameter e.g. { id : 123456 }

            EventsFactory.get(params,
                function (data) {
                    $scope.event = data;
                    console.log(data);
                }, function (error) {

                });

            console.log('SingleMovieCTRL loaded..');
        }])
        .controller('SingleMeetupCTRL', ['$scope', 'EventsFactory', function ($scope, EventsFactory) {
            $scope.event =
                { "category": "movie", "id": 11, "name": "Hello this is text", "time": "Aug 13, 2013", "description": "This is long text about nothing" }

            console.log('SingleMeetupCTRL loaded..');
        }])
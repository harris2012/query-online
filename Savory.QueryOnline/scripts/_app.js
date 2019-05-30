var app = angular.module('app', ['ngResource', 'ui.router']);

app.config(route);

app.service('WebSqlService', ['$resource', '$q', WebSqlService]);

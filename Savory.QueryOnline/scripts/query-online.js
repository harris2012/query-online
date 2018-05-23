function WelcomeController($scope) {

    var myTextarea = $('#requestContent')[0];

    $scope.thisEditor = CodeMirror.fromTextArea(myTextarea, {
        mode: 'text/x-mssql',
        styleActiveLine: true,
        lineNumbers: true,
        lineWrapping: true
    });
    $scope.thisEditor.setValue('SELECT * from Student(nolock)');
    //$scope.thisEditor.setSize('auto', 'auto');

    $scope.time = 1;

    function getCmd() {

        var selection = $scope.thisEditor.getSelection();
        if (selection) {
            return selection.trim();
        } else {
            return $scope.thisEditor.getValue().trim();
        }
    }

    $scope.run = function () {

        var cmd = getCmd();
        console.log(cmd);

        var header = [{ title: "zhang" }, { title: "hai" }, { title: "cheng" }, { title: "harris" }];
        var body = [];
        for (var i = 0; i < 100; i++) {

            body.push([i * $scope.time, i * $scope.time * 2, i * $scope.time * 3, i * $scope.time * 4]);
        }

        $scope.time = $scope.time + 1;
        $('#example').dataTable({
            destroy: true,
            columns: header,
            data: body
        });
    }
}
var route = function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.when('', '/welcome').when('/', '/welcome');

    $stateProvider.state('app', {
        url: '/'
    });

    $stateProvider.state('app.welcome', {
        url: 'welcome',
        templateUrl: 'scripts/views/view_welcome.html?v=' + window.version,
        controller: WelcomeController
    });
}
var app = angular.module('app', ['ngResource', 'ui.router']);

app.config(route);

app.controller(WelcomeController);
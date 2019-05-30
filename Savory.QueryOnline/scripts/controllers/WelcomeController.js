function WelcomeController($scope, WebSqlService) {

    var myTextarea = $('#requestContent')[0];

    $scope.thisEditor = CodeMirror.fromTextArea(myTextarea, {
        mode: 'text/x-mssql',
        styleActiveLine: true,
        lineNumbers: true,
        lineWrapping: true
    });
    $scope.thisEditor.setValue('SELECT * from Student(nolock)');
    //$scope.thisEditor.setSize('auto', 'auto');

    $scope.run = function () {

        var command = $scope.thisEditor.getSelection().trim();
        if (!command) {
            command = $scope.thisEditor.getValue().trim();
        }

        WebSqlService.execution_execute({ command: command }).then(execution_service_callback);
    }

    server_items_callback = function (response) {
        $scope.servers = response.servers;
        $scope.serverName = response.servers[0].serverName;
        $scope.setServer($scope.serverName);
    }

    table_items_callback = function (response) {
        $scope.tables = response.tables;
    }

    execution_service_callback = function (response) {
        console.log(response);

        $('#example').dataTable({ destroy: true, columns: response.headers, data: response.rows });
    }

    $scope.setServer = function (serverName) {
        $scope.serverName = serverName;
        WebSqlService.table_items({ serverName: serverName }).then(table_items_callback);
    }

    WebSqlService.server_items().then(server_items_callback);
}
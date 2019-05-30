function WebSqlService($resource, $q) {

    var resource = $resource('/api', {}, {

        server_items: { method: 'POST', url: '/api/server/items' },
        table_items: { method: 'POST', url: '/api/table/items' },
        execution_execute: { method: 'POST', url: '/api/execution/execute' }
    });

    return {

        server_items: function (request) { var d = $q.defer(); resource.server_items({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        table_items: function (request) { var d = $q.defer(); resource.table_items({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        execution_execute: function (request) { var d = $q.defer(); resource.execution_execute({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; }
    };
}

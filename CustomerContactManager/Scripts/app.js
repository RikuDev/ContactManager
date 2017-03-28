var ContactManagerApp = angular.module("ContactManagerApp", ["ngResource", "ngRoute"])

.config(function ($routeProvider)
{
    $routeProvider.
        when('/list.html', { templateUrl: 'list.html', controller: ListCtrl }).
        when('/new', { templateUrl: 'details.html', controller: CreateCtrl }).
        otherwise({ redirectTo: '/' });
}); //We have told angular 3 things, when you go to some path, what controller and what template to use 

ContactManagerApp.factory('Contacts', function ($resource) {
    return $resource('/api/ContactInfo/:id', { id: '@id' }, { update: { method: 'PUT' } });
});

ContactManagerApp.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.hashPrefix('');
}]);

var CreateCtrl = function ($scope, $location, ContactInfo) {
    $scope.save = function ()
    {
        ContactInfo.save($scope.item, function ()
        {
            $location.path('/');
        });
    };
};



//ContactManagerApp.run(function ($rootScope) {
//    $('[ng-app]').on('click', 'a', function () {
//        window.location.href = $(this).attr('href');
//    });
//});

var ListCtrl = function ($scope, $location, ContactInfo) {
    $scope.search = function () {
        ContactInfo.query({
            q: $scope.query,
            sort: $scope.sort_order,
            desc: $scope.is_desc,
            offset: $scope.offset,
            limit: $scope.limit
        },
            function (data) {
                $scope.more = data.length === 20;
            $scope.items = $scope.items.concat(data);
        });
    };

    $scope.delete = function()
    {
        var id = this.item.ID;
        ContactInfo.delete({ id: id }, function () //on success callback
        {
            $('#item_' + id).fadeOut();
        }); 
    }

    $scope.sort = function (col) {
        if ($scope.sort_order === col) {
            $scope.is_desc = !$scope.is_desc;
        } else {
            $scope.sort_order = col;
            $scope.is_desc = false;
        }
        $scope.reset();
    };
    
    $scope.show_more = function ()
    {
        $scope.offset += $scope.limit;
        $scope.search();
    }

    $scope.has_more = function () {
        return $scope.more;
    };

    $scope.reset = function () {
        $scope.limit = 20;
        $scope.offset = 0;
        $scope.items = [];
        $scope.more = true;
        $scope.search();
    };

    $scope.sort_order = "ID";
    $scope.is_desc = false;

    $scope.reset();
};

//var ListCtrl = function ($scope, $location, ContactInfo) {
//    $scope.items = ContactInfo.query();
//};

//var ListCtrl = function ($scope, $location) {
//    $scope.test = "testing";
//}

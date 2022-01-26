(function () {
    var app = angular.module('sabahatApp');
    app.controller('UserController', ['$scope', '$http', '$uibModal', function ($scope, $http, $uibModal) {
        //pager props
        $scope.currentPage = 1;
        $scope.itemsPerPage = 6;
        $scope.maxSize = 3;

        $scope.getUsers = function () {
            $scope.onLoading = true;
            $scope.message = "";

            $http.get('/User/GetUsers').then(function (result) {
                if (result != null && result.data.length > 0)
                    $scope.lists = JSON.parse(result.data);

                $scope.onLoading = false;
            }, function (error) {
                $scope.onLoading = false;
                $scope.message = "Fehler beim Laden"
            });

        }

        $scope.getUsers();

        $scope.addUser = function () {
            var modalInstance = $uibModal.open({
                templateUrl: '/User/New',
                controller: 'NewUserController',
                size: 'md'
            });

            modalInstance.result.then(function () {
                $scope.getUsers();
            });
        };
    }
    ]);
})();
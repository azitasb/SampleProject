(function () {
    var app = angular.module('sabahatApp');
    app.controller('NewUserController', ['$scope', '$http', '$uibModalInstance', function ($scope, $http, $uibModalInstance) {

        $scope.newModel = {};
        $scope.message = "";

        $scope.$on('modal.closing', (event, reason, closed) => {
            if (!closed) {
                event.preventDefault();
                $scope.$close("Closing");
            }

        });

        $scope.saveUser = function () {
            var input = $scope.newModel;
            $http.post('/User/Insert', input).then(function (result) {
                var res = result.data;
                if (!res.hasError) {
                    if (result != null && res.data.length > 0)
                        $uibModalInstance.close();
                    else
                        $scope.message = 'Kein Benutzer hinzugefügt';
                }
                else
                    $scope.message = res.data;
            });
        }

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
    }
    ]);
})();
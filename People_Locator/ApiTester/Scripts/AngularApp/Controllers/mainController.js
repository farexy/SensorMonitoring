var app = angular.module('RequestApp');

app.controller('main', function ($scope, $http) {

    $scope.url = null;

    $scope.parameters = [];

    $scope.parameter = new RequestParameter();

    $scope.requests = new ReqestStorage();
    $scope.RequestName = null;
    var requests = $scope.requests.getRequests();
    $scope.names = requests != null ? requests.map(function (value) { return value.saveName;  }) : [];

    $scope.Type = "GET";

    $scope.Response = null;

    $scope.checkUrl = function () {
        if ($scope.url == null) { return false; }

        $scope.url = $scope.url.trim();

        if ($scope.url == "") { return false; }

        var pattern = /(https?:\/\/)?([a-zA-Z]+(\.)?)+(:[1-9]\d+)?(\/\w+)*/g;

        return $scope.url.match(pattern) != null;
    }

    $scope.addParameter = function () {

        var index = $scope.parameters.findIndex(function (value) { return value.Name == $scope.parameter.Name; });

        if (index == -1) {
            $scope.parameters.push($scope.parameter);
        }
        else {
            $scope.parameters[index].Value = $scope.parameter.Value;
        }

        $scope.parameter = new RequestParameter();
    };

    $scope.sendRequest = function () {
        var url = "/Home/MakeRequest?url=" + $scope.url + "&type=" + $scope.Type;

        for (var i = 0; i < $scope.parameters.length; i++) {
            var parameter = $scope.parameters[i];

            url += "&data=" + parameter.Name + "&data=" + parameter.Value;
        }

        $http.get(url).then(function (res) {
            console.log(res);
            $scope.Response = res.data;

            setTimeout(function () {
                $scope.$apply();
            }, 1);

        });
    };

    $scope.editParameter = function (param) {
        $scope.parameter = param;
    };

    $scope.deleteParameter = function (param) {
        var nameIndex = $scope.parameters.findIndex(function (value) { return value.Name == param.Name; });
        $scope.parameters.splice(nameIndex, 1);
    };

    $scope.saveRequest = function () {
        if (!$scope.checkUrl() || $scope.RequestName == null) { return; }

        var request = new Request($scope.RequestName, $scope.url, $scope.parameters.slice(0), $scope.Type);

        $scope.requests.addRequest(request);
        $scope.names.push($scope.RequestName);
    }

    $scope.loadRequest = function () {
        var requests = $scope.requests.getRequests();
        var request = requests.find(function (value) { return value.saveName == $scope.RequestName; });

        if (request == null) {
            return false;
        }

        $scope.url = request.url;
        $scope.parameters = request.parameters.slice(0); // clone
        $scope.Type = request.type;
        $scope.parameter = new RequestParameter();
    };
});
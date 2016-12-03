var ReqestStorage = function () {
    var requests = JSON.parse(localStorage.getItem("api-requests"));

    if (requests == null || typeof (requests) != typeof ([])) {
        requests = [];
    }

    this.addRequest = function (request) {
        var currentIndex = requests.findIndex(function (value) { return value.saveName == request.saveName; });

        if (currentIndex != -1) {
            requests.splice(currentIndex, 1);
        }

        requests.push(request);
        localStorage.setItem('api-requests', JSON.stringify(requests));
    };

    this.getRequests = function () {
        return requests;
    }
};

var Request = function (name, url, parameters, type) {
    this.saveName = name;
    this.url = url;
    this.parameters = parameters;
    this.type = type;
};
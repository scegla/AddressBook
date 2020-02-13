(function () {
        app.controller('TestMy', function($scope, $http) {
                $scope.TestMethod = function() {
                    $http.get('/Home/About').then(function (response) {
                        alert("This is my JSON data read from controller" + response.data);
                    });
            }

            $scope.GetData = function () {
                $http.get('/api/contacts').then(function (response) {
                    $scope.items2 = response.data;
                    //alert("This is my JSON data read from api contacts");
                }).catch(function (e) { alert('Response: ' + JSON.stringify(e.data.ExceptionMessage)) });
            }

            $scope.delete = function (item) {
                $http.delete('/api/contacts/Delete/?id=' + item.Id).then(function (response) {
                    alert("Contact with id was deleted: " + item.Id);
                }).catch(function (e) { alert('Response: ' + JSON.stringify(e.data.ExceptionMessage)) });
            }

            $scope.editSave = function () {
                var data = {
                    Id: $scope.editId,
                    PhoneNum: $scope.editPhoneNum,
                    FirstName: $scope.editFirstName,
                    LastName: $scope.editLastName,
                    Address: $scope.editAddress
                };
                $http.post('/api/contacts/EditContact/', data).then(function (response) {
                    alert("Contact succesfully updated\nId:" + response.data.Id + "\nFirstName: " + response.data.FirstName + ".\nLastName: " + response.data.LastName + "\nAddress: " + response.data.Address + "\nPhoneNum: " + response.data.PhoneNum);
                }).catch(function (e) { alert('Response: ' + JSON.stringify(e.data.ExceptionMessage))});
            }

            $scope.view = function (item) {
                $http.get('/api/contacts/' + item.Id).then(function (response) {
                    alert("Contact data\nId: " + response.data.Id + "\nFirstName: " + response.data.FirstName + "\nLastName: " + response.data.LastName + "\nAddress: " + response.data.Address + "\nPhoneNum: " + response.data.PhoneNum);
                }).catch(function (e) { alert('Response: ' + JSON.stringify(e.data.ExceptionMessage)) });
            }

            $scope.search = function () {
                var data1 = {
                    Id: $scope.searchId,
                    PhoneNum: $scope.searchPhoneNum,
                    FirstName: $scope.searchFirstName,
                    LastName: $scope.searchLastName,
                    Address: $scope.searchAddress
                };

                $http({
                    url: '/api/contacts/SearchContact/',
                    method: "POST",
                    data: data1,
                    dataType: "json"
                }).then(function (response) {
                    $scope.items2 = response.data;
                    //alert("Search successfull! ");
                }).catch(function (e) { alert('Response: ' + JSON.stringify(e.data.ExceptionMessage)) });
            }

            $scope.add = function () {
                var data1 = {
                    Id: 9999,
                    PhoneNum: $scope.addPhoneNum,
                    FirstName: $scope.addFirstName,
                    LastName: $scope.addLastName,
                    Address: $scope.addAddress
                };

                $http({
                    url: '/api/contacts/AddContact/',
                    method: "POST",
                    data: data1,
                    dataType: "json"
                }).then(function (response) {
                    alert("Contact added\nFirstName: " + response.data.FirstName + ".\nLastName: " + response.data.LastName + "\nAddress: " + response.data.Address + "\nPhoneNum: " + response.data.PhoneNum);
                }).catch(function (e) { alert('Response: ' + JSON.stringify(e.data.ExceptionMessage)) });
            }

            $scope.removeClient = function (id) {
                if (confirm('Are you sure you want to delete contact?')) {
                    $scope.delete(id);
                }
            };
    });
}).call(angular);
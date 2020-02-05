var ViewModel = function () {
    var self = this;
    self.contacts = ko.observableArray();
    self.error = ko.observable();

    var contactsUri = '/api/contacts/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllContacts() {
        ajaxHelper(contactsUri, 'GET').done(function (data) {
            self.contacts(data);
        });

    }

    // Fetch the initial data.
    getAllContacts();

    self.detail = ko.observable();

    self.getContactDetail = function (item) {
        ajaxHelper(contactsUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }
};

ko.applyBindings(new ViewModel());
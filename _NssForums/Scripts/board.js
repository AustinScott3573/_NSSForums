var post = function (id, message, username, date) {
    this.id = id;
    this.message = message;
    this.username = username;
    this.date = date;
    this.comments = ko.observableArray([]);

    this.addComment = function (context) {
        var comment = $('input[name="comment"]', context).val();
        if (comment.lengh > 0) {
            $.connection.boardHub.server.addComment(this.id, comment, vm.username())
            .done(function () {
                $('input[name="comment"]', conext).val('');
            });
        }
    };
}

var comment = function (id, message, unsername, date) {
    this.id = id;
    this.message = message;
    this.username = username;
    this.date = date;
}

var vm = {
    posts: ko.observableArray([]),
    notifications: ko.observableArray([]),
    username: ko.observableArray(),
    signedIn:  ko.observable(false),
    signIn: function () {
        vm.username($('#username').val());
        vm.signedIn(true);
    },
    writePost: function () {
        $.connection.boardHub.server.writePost(vm.username(), $('#message'). val()).done(function () {
            $('#message').val('');
        });
    },
  }

ko.applyBindings(vm);
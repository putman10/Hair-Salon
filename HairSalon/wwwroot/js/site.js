$(document).ready(function() {
                var $fields = $('#fields');
                $('#btnAddField').click(function(e) {
                    e.preventDefault();
                    $('<input type="text" class="form-control" name="specialtyFields" /><br/>').appendTo($fields);
                });
});
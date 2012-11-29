var b = b || {
	address: "http://localhost:3425/",
	testConnection: function (success) {
        $.get(b.address + "test", function (data)
		{
			if (data.TestResult) {
				success(data.TestResult);
			}
		});
    },
	bill: function (invoice, success) {
		$.ajax({
		    url: b.address + "bill",
		    type: "POST",
		    data: JSON.stringify({ invoice: invoice }),
	  	    contentType: "application/json; charset=utf-8",
		    dataType: "json",
		    success: success
		});
	},
	dailyCashBalance: function (success) {
		$.post(b.address + "dailyCashBalance", success);
	},
	cashDeskClosing: function (success) {
		$.post(b.address + "cashDeskClosing", success);
	}
}
Windows Service
================

Service allow cross domain calls. Exposes three methods to bill with tax biller printers.
Printer services must be implemented as logic services in different assemblies.

Here is an example to a call for the service:

`var sampleInvoice = { "Name": "nombre", "Address": "direccion", Items: [ { Quantity: 3, Description: "testdesc", Price: 1.5 } ] };
b.bill(sampleInvoice, function(data) { alert("Status: " + data.Status + "\nMessage: " + data.Message); });`
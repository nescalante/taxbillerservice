Tax Biller Service
================

A service to call tax biller printers.
Supports:

 - EPSONFP

Proyect contains:

 - a Windows Forms proyect that can be used to bill invoices
 - a [Windows Service Cross Domain](https://github.com/nescalante/taxbillerservice/wiki/Using-WindowsService) that exposes the tax biller printer functions
 - a [javascript file](https://github.com/nescalante/taxbillerservice/wiki/Using-taxbiller.js) to be used on a web proyect to call Windows Service

Service allow cross domain calls. Exposes three methods to bill with tax biller printers.

Printer services must be implemented as logic services in different assemblies.

##js calls

Here is an example to a call for the service from a web using taxbiller.js script:

    var sampleInvoice = { "Name": "nom", "Address": "dir", Items: [ { Quantity: 3, Description: "des", Price: 1.5 } ] };
    b.bill(sampleInvoice, function(data) { alert("Status: " + data.Status + "\nMessage: " + data.Message); });

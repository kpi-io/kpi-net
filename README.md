KPI.IO
=======
## Introduction
[KPI.IO](http://kpi.io) is a custom analytics backend.
You can easily send, analyse and visualize your data.

## .Net API
The example below shows you how to send data in your .Net application.

	// Prepare your configuration
	KPIConfiguration config = new KPIConfiguration();
	config.ProjectId = "project-id";
	config.WriteKey = "write-key";

	// Create factory object using config
	KPIDispatcher dispatcher = new KPIDispatcher(config);

	// Prepare your event data
	Order data = new Order {
			user = new User {
			id = 23592,
			name = "Zane Hopkins",
			country = "Finland",
			region = "Europe"
		},
		product = new Product {
			id = 23592,
			name = "Zane Hopkins",
			country = "Finland",
			region = "Europe"
		},
		salesChannel = "Online",
		unitPrice = 3.99,
		quantity = 2,
		totalPrice = 7.98
	};
	
	dispatcher.AddData("sales", data);



For more, please visit [KPI.IO](http://kpi.io)

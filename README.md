
Employee Verification Project
------------------------------

#Overview

	This project implements a simple employee verification system using the following technologies:
	-Frontend: HTML and JavaScript.
	-Backend: ASP.NET Core Web API.  version .Net 7.0
	The application allows users to verify employment details for a given employee by submitting an Employee ID, Company Name, and Verification Code through a web form. The backend validates this information and responds with the verification result.

#Approach

	-Frontend:

		-A plain HTML form with fields for Employee ID, Company Name, and Verification Code.	
		-JavaScript handles form submission, input validation, and communicates with the backend API via fetch.	
		-Displays the verification result dynamically below the form.

	-Backend:
	
		-ASP.NET Core Web API provides an endpoint at /api/verify-employment.	
		-The API validates input, checks the employee record against a predefined data store (in-memory or SQLite), and returns a JSON response.
		-I used CORS (Cross-Origin Resource Sharing) for frontend is served from a different origin (e.g., file:// for a local HTML file), the browser may block the request due to CORS policies.
	
	-Communication:
	
		-The frontend sends a POST request to the backend with the input details.	
		-Backend processes the request and responds with either Verified or Not Verified status.
	
	-Assumptions:
	
		-Employee data is preloaded into an in-memory data store or SQLite for testing purposes.
		-Frontend and backend communicate over HTTP (not HTTPS) for simplicity during development.
	


#Prerequisites

	  Backend: .NET SDK installed on your system.	
	  Frontend: A browser and an HTTP server for serving the HTML file (to avoid CORS issues).	
    -	Backend Setup	
	Navigate to the backend project folder.	
	Restore dependencies and run the application:
 
	The API will start at https://localhost:7283/api/verify-employment.
	
    -	Frontend Setup	
	    Place the index.html and EmploymentVerificationForm.js in same folder.	
	    Open the served HTML file in your browser (e.g., https://localhost:7283).

#Usage

	1. Run the project
	2.Open the frontend(index.html) in your browser.
	
	3.Fill in the following fields:
	
		-Employee ID: A numeric value (e.g., 101).		
		-Company Name: Name of the company.		
		-Verification Code: A valid code provided for verification.
	
	4.Click the Submit button.
	
	5.View the verification result below the form.

#Note

    - I Enable CORS in ASP.NET Core  in  Program.cs

			builder.Services.AddCors(options =>
			{
			options.AddDefaultPolicy(policy =>
			{
			    policy.AllowAnyOrigin()
			          .AllowAnyMethod()
			          .AllowAnyHeader();
			});
			});

			var app = builder.Build();
			
			app.UseCors();

    This allows requests from any origin, which is useful for development.


    - I used In-Memory data structure.
    Table content:
	  private static readonly List<Employee> Employees = new()
    {
        new Employee { EmployeeId = 101, CompanyName = "Ishank Corp", VerificationCode = "Emp1234" },
        new Employee { EmployeeId = 102, CompanyName = "Verma Corp", VerificationCode = "Emp12345678" }
    };



		EmployeeId | CompanyName    | VerificationCode
		----------------------------------------------
		101        | Ishank Corp	| Emp1234
		102        | Verma Corp		| Emp12345678

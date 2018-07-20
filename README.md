# Hair Salon

#### Epicodus C# Independent Project #3, July 13 2018

#### By Ryan Putman

## Description

Create an app for a hair salon. The owner should be able to add a list of the stylists, and for each stylist, add clients who see that stylist. The stylists work independently, so each client only belongs to a single stylist.

## Specs

| Behavior | Input | Output |
| As a salon employee, I need to be able to see a list of all our stylists. | click on view all stylists | list of stylists |
| As an employee, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist. | click on stylist name | view contact details and all clients |
| As an employee, I need to add new stylists to our system when they are hired. | fill out form and submit | new stylist is added to the database and viewable in stylist list |
| As an employee, I need to be able to add new clients to a specific stylist. I should not be able to add a client if no stylists have been added | add new clients | client assigned stylist if stylists exist |
| Client can be deleted from the system | delete client | click on delete button |

* As an employee, I need to be able to add new clients to a specific stylist. I should not be able to add a client if no stylists have been added.
* As an employee, I need to be able to delete stylists (all).
* As an employee, I need to be able to delete clients (all).
* As an employee, I need to be able to add a specialty and view all specialties that have been added.
* As an employee, I need to be able to add a specialty to a stylist.
* As an employee, I need to be able to click on a specialty and see all of the stylists that have that specialty.
* As an employee, I need to see the stylist's specialties on the stylist's details page.
* As an employee, I need to be able to add a stylist to a specialty.



## Setup on OSX

* Download and install .Net Core 1.1.4
* Download and install Mono
* Download and install MAMP
* Clone the repo
* Using MAMP and PHPMYADMIN import ryan_putman and ryan_putman_tests MySql databases into local server
* Run `dotnet restore` from project directory and test directory to install packages
* Run `dotnet build` from project directory and fix any build errors
* Run `dotnet test` from the test directory to run the testing suite
* Run `dotnet run` to start the server
* Navigate to localhost supplied in browser of choice

## Contribution Requirements

1. Clone the repo
1. Make a new branch
1. Commit and push your changes
1. Create a PR

## Technologies Used

* .Net Core 1.1.4
* MAMP

## Links

* [Here](https://github.com/putman10/Hair-Salon.git) is the link to Ryan's repository.

## License

This software is licensed under the MIT license.

Copyright (c) 2018 **Ryan Putman**

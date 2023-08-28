# Automated prestashop UI tests
This solution is a set of automatic smoke tests performed on the website of the online store http://prestashop.qatestlab.com
## Authors and Collaborators ##
* Autor: [Mishchenko Denis](https://github.com/Denis-SPb1980)
* Reviewer: [Volkov Vladimir](https://github.com/VladimirVolkovD)
## Test Set ##
### e2e Tests ###
|Parameter|Description|
|:-|:-|
|PurchaseDress|Purchase of one product with registration of a new user and payment by bank transfer|
|PurchaseTShirts|Purchase of one product by a standard user and payment by check|
|PurchaseTShirtsAndBlouse|Purchase of several products by a new user with the choice of the USA country and receiving an error on the payment page|
### Other Tests ###
|Parameter|Description|
|:-|:-|
|LoginStandartUser|Log in to your account as a standard user|
|LoginUnknownUser|Log in to an account by an unknown user|
|CreateAccount|Creating an account|
|CreateAccountTestWithOutName|Create an account without specifying a name|
|AddAddressNewUser|Adding an address to a new user|
|LoginAndLogoutOfAccount|Log in as a new user and log out of the account|

## Used approaches to building a framework / tests

- Driver Factory
- Browser
- Page Object
- Wrappers
- Builder for model
- Chain of invocation
- Bogus

  ## Tech Stack

- Test framework:  - [NUnit](https://www.nuget.org/packages/NUnit)
- Logging: - [NLog](https://www.nuget.org/packages/NLog)
- Reporting - [Allure](https://www.nuget.org/packages/Allure.NUnit)
- Browser automation - [Selenium](https://www.nuget.org/packages/Selenium.WebDriver)
- Generator fake data - [Faker.Net](https://www.nuget.org/packages/Faker.Net)

  ## Installation

Register in [Prestashop](http://prestashop.qatestlab.com.ua/en/) using any random email and random password. Account verification is not required.

Clone repository Prestashop UI tests - [Diplom](https://github.com/Denis-SPb1980/Diplom) repository.

Open solution in Visual studio (or other for C#).

Create solution build configurations Debug. 

Edit BrowserSetup.runsettings. Set your values.
Buid solution.

## Run Tests

To run the test, run the following command
```bash
   Dotnet test
```
## Generate Allure report
Firstly save a path where running tests data for a report saved.

 - Download and extract Allure.
 - Open folder with Allure bin, for example Х:\Allure\allure-x.xx.x\bin.
 - Run CMD in this folder.
 - Run command
 ```bash
   allure serve
```
- Allure report will be opened in your web browser.

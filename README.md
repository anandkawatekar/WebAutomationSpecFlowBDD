# Web Automation using SpecFlow, NUnit and Selenium Webdriver
## Prerequisites
- Microsoft Visual Studio 2017 or above
- chromedriver
- geckodriver

## Browsers
The test framework currently supports two browsers

- Google Chrome
- Mozilla Firefox

In order to run automation on these browsers it is required to download their corresponding driver using below links.
- Chromedriver [https://chromedriver.chromium.org/](https://chromedriver.chromium.org/)
- Geckodriver [https://github.com/mozilla/geckodriver/releases](https://github.com/mozilla/geckodriver/releases)

Extract both drivers to the desired folder and add it to the [System Environment variables in Windows `PATH`.](https://zwbetz.com/download-chromedriver-binary-and-add-to-your-path-for-automated-functional-testing/)

## Configuration
Some settings are required to be setup for the project to function properly. These are configured using a config.json file under project.
The following is the list of options that can be configured

- `BaseUrl`  
It is the URL of Application Under Test

- `Browser`  
Here you can mention browser type on which you want to run tests. Currently you can specify only 'CHROME' or 'FIREFOX'

## How to Run
- Open the project in Visual Studio.
- Go to solution explorer and right click on project name - Clean solution Then - Build
- Open Test Explorer from Menu Test --> Windows --> Test explorer (you can shortcut key Ctrl+E,T)
- Once you open Test Explorer you can right click on any test case and select run
- If you want to Run all test cases then in Test Explorer click 'Run All'

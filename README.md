#   JobSity QA Challenge

This repo contains my take on the Jobsity QA challenge. It is divided into 2 exercises, the fist one being a manual test challenge, and the second one being an autoation test challenge.

For more details you can check [the challenge document](https://drive.google.com/file/d/1rjr3gBM2KTlG8L48kkQpy4bMCfvzCg01/view?usp=sharing) saved on my Google Drive.

##  Exercise 1
For this excercise I think I completed all of the requirements. The requested deliverables are:

1. A Google [spreadsheet](https://docs.google.com/spreadsheets/d/1gSY-25xvhlYIuUHByprNL9204zfndYU0gjBrW6D5g8A/edit?usp=sharing) containing:
    1. Smoke test results.
    2. Feedback's test case list, this being both a test case list and a test run report (you can use the list to get to the individual test cases, since it has links to the individual sheets).
2. [A Trello board](https://trello.com/invite/b/w0A4PsUo/c75f2554abd4ae35b27ede464ea0ce8b/manual-test-board) with the structure for bug solving life cycle and bugs reported (same than the failed test cases listed in the spreadsheet).

Not much to add about this one.

##  Exercise 2
Now about this one I created this repo, it is an automation test on .Net Core 3.1 and XUnit. Created using Visual Studio 2019 (latest version I think). And There are a couple additional things to know in order to run it:
1.  There is a config file (appsettings.json) with values **you must** change in order to make this work. These values are:
    -   A local route to find the webdriver (WebDriverLocation)
    -   A directory used to take screenshots while testing
2. I used this [Chrome Driver](https://drive.google.com/file/d/1gdaXGeI5GKDz2stZsA4vW8q1OzmOohKC/view?usp=sharing) since it is the one compatible with my local setup, you might want to change it if it is not your same case.

Now, as of right now I **couldn't complete** all of the requirements for this test. Here is what I couldn't make:
-   Pixel perfect test (I actually have no idea what this test is, and couldn't find enough clarification on internet)
-   Multi-browser support (I think is easy to add, but ran out of time before I could try it)
And for what **I did complete**:
1.   Created test cases for the search, add to cart and contact functionalities/sections (didn't realize I had to document them on a spreadsheet, [here](https://docs.google.com/spreadsheets/d/1tL9HE6k7DuOYy4OKwBbgDXsp6zyz2Qs4Uj-d53wxcYQ/edit?usp=sharing) I documented just a few of them, since the documentation is the same style than the previous exercise and I have provided other types of documentation I guess this error might be sorted)
2.   Executed an acceptance test for those test cases ([here the results](https://drive.google.com/file/d/1XLFnPIEuYGcwNdQtOLpgq-l0VyalXjtA/view?usp=sharing))
3.   [A Trello board](https://trello.com/invite/b/2nEGQpaX/e361f5f4683246098e5493e80b8ba50e/automation-board) with the structure for bug solving life cycle and bugs reported (same test cases that failed in the result showed above)

##  Things to improve
-   Change the screenshot strategy: As of right now we can take screenshots, but they might not be capturing the important part of the screen.
-   I need to encapsulate some methods not related to the page object to a general use class in the helpers folder
-   Of course include what I didn't have time to complete
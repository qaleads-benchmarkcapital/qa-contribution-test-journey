# qa-contribution-test-journey :robot:

## Technical Test Brief

### Overview :telescope:
We would like to invite you to submit a response to our technical test, this is an opportunity for you to show us how you use your test automation skills to implement good, reliable automated tests.

We think this document will provide you with all the information you should need to attempt our technical test, in the following sections:

| Section                                                       | Description                                                  |
| ------------------------------------------------------------- | ------------------------------------------------------------ |
| [Application Under Test](#application-under-test)             | What we would like you to test                               |
| [Code in GitHub](#code-in-github)                             | What framework has been provided by us                       |
| [Toolbox](#toolbox)                                           | What tools you will need to use                              |
| [Existing Scenarios](#existing-scenarios)                     | What scenarios have been implemented by us                   |
| [Tasks](#tasks)                                               | What tasks we would like you to attempt                      |
| [Submitting your test response](#submitting-your-test-response) | What you need to do to submit your attempt at the task to us |

If you have any queries, please reach out to your agent who will pass queries on to us.

### Application Under Test
For this technical test,  a Contact Form that many users should be familiar with has been chosen as the Application Under Test.
Please see the Feature File <name> there are

![contactUs](/contactUs.png "Contact Us user interface")

#### Address :houses:
https://automationintesting.online/

### Code in GitHub
We have provided an automation solution in a GitHub repository that provides you with:
- A basic framework implementation that follows the Page Object Model to model the Application Under Test
- A set of implemented scenarios in a Feature File with step definitions for the Application Under Test that utilise the Page Object Model

The solution as is will allow you to run the Existing Scenarios from within the Test Explorer in Visual Studio.

#### Address :houses:
https://github.com/qaleads-benchmarkcapital/qa-contribution-test-journey 

### Toolbox
The solution uses `Selenium`, `Specflow`, `SpecFlow runner` and `C# / .net core 3.1`.
We think it will be best if you use a version of `Visual Studio 2019/2022` together with `SpecFlow for Visual Studio 2019/2022` extension to complete this technical test.
We recommend using `GitHub Desktop` to work with the Code in `GitHub`.

### Existing Scenarios
The solution contains the Feature File `ContactUs.feature`

![glossaryDescription](/glossaryDescription.PNG "Screenshot of glossary and description")

The Feature File contains not only the scenarios but also a Description as well as a Glossary. 
Please examine the Feature File carefully, you need to understand not just the scenarios in the Feature File, pay close attention to both the Description and the Glossary.

### Tasks

#### Task 1: Add Additional Scenarios to the Feature File :floppy_disk:
We have omitted to add all scenario(s) in the Feature File `ContactUs.feature`
We would like you to add **as many** additional Scenario(s) **as you can think of or would test yourself in your day job**.  The tests you would conduct manuallay tag with `@manual` & `@ignore`, the tests that are feasible to write test automation code for please implement. Please add **as much code as you can** to demonstrate your skills & knowledge. Its important that you give us insight into your overall experience & understanding of the feature under test!

In adding your additional scenario(s) we encourage you to re-use any existing Steps / Step Implementations, but if you do re-use (and refactor) any existing Steps / Step Implementations please make sure that in doing so that all of the existing Scenarios still Pass!
If you can’t re-use any of the existing Steps / Step Implementations, you will need to add your own Steps / Step Implementations, in doing so please follow the patterns in the existing Scenarios / Steps / Step Implementations as closely as you can. 
Consistency is important to readability which in turn help keep the maintenance costs down (as well as driving up reliability).

Please consider these [guidelines](https://techbeacon.com/app-dev-testing/better-behavior-driven-development-4-rules-writing-good-gherkin?utm_content=buffer3bd8d&utm_medium=social&utm_source=twitter.com&utm_campaign=buffer) 

#### Task 2: Refactor an Existing Scenario in the Feature File :hammer_and_wrench:
In the Feature File `ContactUs.feature` there are a number of tests already implemented:

![featureFile](/featureFile.PNG "Screenshot of feature file")

If you take a look at the scenario with the tag `@refactor` you should notice that the Gherkin doesn’t quite look like the other scenarios in the Feature file.
We would like you to refactor the Gherkin in the scenario so that it follows the same patterns as the other scenarios that are in the Feature file.
In refactoring this scenario, we encourage you to re-use any existing Steps / Step Implementations, but if you do re-use (and refactor) any existing Steps / Step Implementations please make sure that in doing so that all of the existing scenarios still Pass!

#### Task 3 : Fix a Failing Scenario in the Feature File :adhesive_bandage:
The scenario with the tag `@failing` currently runs as is provided in the solution, but when the scenario is ran, the scenario completes but the outcome is that it Fails in the Then step implementation (pay attention to the locator).

![failingScenario](/failingScenario.PNG "Screenshot of failing scenario")

We would like you to fix this scenario so that when the scenario is ran after your changes, the outcome of the scenario changes so that it Passes.
Please make sure that after you have fixed this scenario, all of the other scenarios in the Feature File (either existing or any you have added) still run correctly and have Pass as their outcome.
 
#### Task 4 : Reflecting on Your Changes :speech_balloon:
Please edit `README.md` with answers to the following questions:

1. How long did each of the tasks take you to complete, roughly :question:

```
Task 1 - ~20mins
Task 2 - ~30mins
Task 3 - ~30mins
```

2. In reviewing the base solution provided to you by us, is there anything you would have done differently :question:

```
I initially began task 3 by fixing the existing steps to include the "contactpage.clicksend". I also built the additional tests from test 1 in this manner. Whilst the tests passed I realised that it would be clearer to use the existing step for clicking send.
I also added to the glossary in the feature as a way of defining the intention but I wasn't sure if I was supposed to do this.
When considering Task 1, I noticed that the feature description only mentioned email and message as mandatory. It also mentions the customer sending a 'valid' phone number but doesn't state whether it (or other fields like 'subject' should be mandatory or have any extra validation. I wasn't sure if this was intentional, in that perhaps I was supposed to edit the description?
```

3.  Which of the tasks did you find was the easiest for you to complete, why :question:

```
Task 1 - I think I would come up with some more scenarios with more time however I tried to keep the tests in keeping with what was already there whilst considering the main feature requirement. I found it the easiest as it's similar to what I know and do currently.
```

4. Which of the tasks did you find was the most difficult for you to complete, why :question:
 
```
In truth I didn't find any task particularly difficult. The difficult part for me was the initial setup and familiarising myself with what each step was doing. Despite feeling a little lost initially I really enjoyed working it out.
```

### Submitting your test response
We would like you to demonstrate your ability to use `GIT` when submitting your changes in completing The Tasks in this Technical Brief.
It is very important that you demonstrate your competency in using `GIT` and you should treat how you submit your changes as an **important** part of the test.

In order for you to submit  your changes,  you will need to :
1.	Clone the repository mentioned in Code in `GitHub`
2.	Create a new branch in the repository for your changes, name the branch you create using the [this](#branch-name) naming convention 
3.	Commit all changes you make in completing The Tasks to the new branch you have created
4. Push your commited changes to a **new** remote branch that you have created
5. Raise a **new** Pull Request in `GitHub` so that **your** technical test submission can be reviewed :tada:

#### Branch name 

Kebab case :meat_on_bone:
```
Kebab case combines words by replacing each space with a dash (-), as follows:
Raw: user login count
Kebab Case: user-login-count
```

Branch name template 
```
feature/your-branch-name

e.g. 

feature/account-access-journey 
```

**Notes:** :black_nib:
- We would like you to use the conventional commits approach to commit comments when committing changes [Convential commits](https://www.conventionalcommits.org/en/v1.0.0/#summary)
- We encourage you to commit changes little and often, at the minimum we would like to see different commits with appropriate commit messages using _conventional_ _commits_ for each of the tasks you undertake

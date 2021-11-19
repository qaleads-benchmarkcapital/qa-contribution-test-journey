import { Given, Then, When } from "cypress-cucumber-preprocessor/steps";
import navigateGoogle  from "../../models/navigateGoogle";
import searchGoogle from "../../models/searchGoogle";
import checkVideoContainer from "../../models/checkVideoContainer"

Given('user is on Google landing page', () => {
  navigateGoogle();
})

When('user attempts to search', () => {
  searchGoogle("cats");
})

Then('user can see results', () => {
  expect(checkVideoContainer()).to.equal(true);
})
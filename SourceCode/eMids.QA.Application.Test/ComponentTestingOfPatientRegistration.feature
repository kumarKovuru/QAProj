Feature: Component testing of patient registration
Description:  The purpose of this feature is to create the new patient successfully

@mytag
  Scenario: New Patient Registration created successfully with valid data for all the fields
    Given user provides First Name as "Jojo"
    And user provides Last Name as "John"
    And user provides Member Id as "456" 
	When  User Calls NewPatientRegistration method	
    Then NewPatientRegistration is successful

Scenario: New Patient Registration created successfully using API with valid data for all the fields
    Given user provides First Name as "Moso"
    And user provides Last Name as "Peter"
    And user provides Member Id as "987" 
	When  User Calls NewPatientRegistrationUsingAPI method	
    Then NewPatientRegistrationUsingAPI is successful

Feature: API testing of patient
Description:  The purpose of this feature is to create, Read, Update and Delete the patient using API calls.

@mytag
  Scenario:1 CREATE - New Patient created successfully with valid data for all the fields using API
    Given user provides First Name as "Jojo"
    And user provides Last Name as "John"
    And user provides Member Id as "456" 
	And user provides Date of Birth as "03-04-20" 
	And user provides Height Id as "170.12" 
	And user provides PhoneNumber Id as "1234567890" 
	And user provides Gender Id as "Male" 
	And user provides Weight Id as "56.67" 
	When  User Calls NewPatientRegistrationAPI method	
    Then NewPatientRegistrationAPI is successful

	@mytag
	Scenario:2 GET - Get newly created Patient using API.
    When user Calls GetPatientByIdAPI method
	Then GetPatientByIdAPI is successful

	@mytag
  Scenario:3 UPDATE - Patient Updated successfully with valid data for all the fields using API
    Given user provides First Name as "Jojo Updated"
    And user provides Last Name as "John Updated"
    And user provides Member Id as "123" 
	And user provides Date of Birth as "03-03-20" 
	And user provides Height Id as "175.12" 
	And user provides PhoneNumber Id as "1234567" 
	And user provides Gender Id as "female" 
	And user provides Weight Id as "50.67" 
	When  User Calls UpdatePatientAPI method	
   Then UpdatePatientAPI is successful

   @mytag
   Scenario:4 GET - Get newly Updated Patient using API
    When user Calls GetPatientByIdAPI method
	Then GetPatientByIdAPI is successful

	@mytag
    Scenario:5 DELETE - Patient Deleted successfully with Patient Id using API
     When user Calls DeletePatientAPI method
	Then DeletePatientAPI is successful

	@mytag
	Scenario:6 GET - Get newly Deleted Patient using API
    When user Calls GetPatientByIdAPI method
	Then GetPatientByIdAPI is successful with null

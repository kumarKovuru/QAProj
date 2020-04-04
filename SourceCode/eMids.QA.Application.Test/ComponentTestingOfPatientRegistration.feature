Feature: Component testing of patient
Description:  The purpose of this feature is to create, Update and Delete the patient.

@mytag
  Scenario:1 New Patient created successfully with valid data for all the fields
    Given user provides First Name as "Jojo"
    And user provides Last Name as "John"
    And user provides Member Id as "456" 
	And user provides Date of Birth as "03-04-20" 
	And user provides Height Id as "170.12" 
	And user provides PhoneNumber Id as "1234567890" 
	And user provides Gender Id as "Male" 
	And user provides Weight Id as "56.67" 
	When  User Calls NewPatientRegistration method	
    Then NewPatientRegistration is successful

	@mytag
	Scenario:2 Get newly created Patient
    When user Calls LastCreatedPatient method
	Then GetLastCreatedPatient is successful

	@mytag
  Scenario:3 Patient Updated successfully with valid data for all the fields
    Given user provides First Name as "Jojo Updated"
    And user provides Last Name as "John Updated"
    And user provides Member Id as "123" 
	And user provides Date of Birth as "03-03-20" 
	And user provides Height Id as "175.12" 
	And user provides PhoneNumber Id as "1234567" 
	And user provides Gender Id as "female" 
	And user provides Weight Id as "50.67" 
	When  User Calls UpdatePatient method	
   Then UpdatePatient is successful

   @mytag
   Scenario:4 Get newly Updated Patient
    When user Calls LastUpdatedPatient method
	Then GetLastUpdatedPatient is successful

	@mytag
    Scenario:5 Patient Deleted successfully with Patient Id
     When user Calls DeletePatient method
	Then DeletePatient is successful

	@mytag
	Scenario:6 Get newly Deleted Patient
    When user Calls LastDeletedPatient method
	Then GetLastDeletedPatient is successful

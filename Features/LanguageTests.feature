Feature: LanguageTests

This feature tests create, edit and delete language functionality of Mars

@tag1
Scenario: Verify user is able to create a language record
	Given user logs into Mars portal
	And user navigates to Languages page
	When user creates a new language record 'French' 'Fluent'
	Then verify language record is created

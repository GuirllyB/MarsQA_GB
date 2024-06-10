Feature: LanguageTests

This feature tests create, edit and delete language functionality of Mars


Scenario Outline: A. Create a new language record
Given user logs into Mars portal
And user navigates to Languages page
When user creates a new language record <Language> <Language Level>
Then verify language record is created <index> <Language>

Examples: 
| index | Language    | Language Level     |
| '1'   | 'Mandarin'  | 'Native/Bilingual' |
| '2'   | '.....@123' | 'Conversational'   |
| '3'   | 'French'    | 'Basic'            |
| '4'   | 'English'  | 'Fluent' |

Scenario Outline: B. Edit an existing Language record
Given user logs into Mars portal
And user navigates to Languages page
When user edits an existing language record <index> <newLanguage> <newLanguageLevel>
Then verify language record is updated <index> <newLanguage>

Examples: 
| index | newLanguage | newLanguageLevel |
| '1' | 'Cantonese' | 'Basic'  |
| '2' | 'Filipino' | 'Fluent' |
| '3' | '----abce' | 'Conversational' |
| '4' | '$same' | 'Native/Bilingual' |

Scenario Outline: C. Delete an existing language record
Given user logs into Mars portal
And user navigates to Languages page
When user deletes an existing language record <index>
Then verify language record is deleted <index>

Examples: 
| sequence | index |
| 1 | '19'  |
| 2 | '17'  |
| 3 | '15'  |
| 4 | '13'  |
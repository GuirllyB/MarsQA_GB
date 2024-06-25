Feature: SkillTests

This feature tests create, edit and delete skill functionality of Mars


Scenario Outline: A. Create a new skill record
Given user logs into Mars Website
And user navigates to Skills page
When user creates a new skill record <skill> <skillLevel>
Then verify skill record is created <index> <skill>

Examples: 
| index | skill | skillLevel |
| '1'   | 'Baking'  | 'Beginner' |
| '2'   | '.......' | 'Intermediate' |
| '3'   | 'Cooking'    | 'Expert' |
| '4'   | '$leep1ng-'  | 'Expert' |

Scenario Outline: B. Edit an existing Skill record
Given user logs into Mars Website
And user navigates to Skills page
When user edits an existing skill record <index> <newSkill> <newSkillLevel>
Then verify skill record is updated <index> <newSkill>

Examples: 
| index | newSkill | newSkillLevel |
| '1' | 'Singing' | 'Intermediate'  |
| '2' | 'Dancing$123' | 'Expert' |
| '3' | '----cutting' | 'Beginner' |
| '4' | '$playing' | 'Intermediate' |

Scenario Outline: C. Delete an existing skill record
Given user logs into Mars Website
And user navigates to Skills page
When user deletes an existing skill record <index>
Then verify skill record is deleted <index>

Examples: 
| sequence | index |
| 1 | '19'  |
| 2 | '17'  |
| 3 | '15'  |
| 4 | '13'  |
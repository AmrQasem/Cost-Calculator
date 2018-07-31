[Baseline] Script Description:
##############################

- This script contains a DB Create Script for all DB Objects of the application 
along with the basic data needed to launch the Application successfully on a successful sprint.

- This Baseline script will serve as a single source of work to refer to safely 
when there is a conflict on any team member machine or when a new member joins this project
can use this script to get an updated db version to start working on.

[Demo Data] Script Description:
###############################
This script will contain a demonstration data needed to quickly launch and present the application for users.
It should contain only dummy data that can be represented to public for User Testing and Sprint Review.

Script Update Frequency:
#####################################
- [Baseline] Once before sprint end, only if the sprint work contains Database Update (to start new sprint with new baseline)
- [Demo Data] Once before sprint end, only if this sprint is going to be reviewed to public users.

How to Update [Baseline] Script (choose one):
###########################################
- Choose a reliable team member machine to be the source of an up-to-date DB,
extract "DB Create" Script from this machine, then replace it with current Baseline script
and update the script name/version.

- Append all the "Update" scripts under "[Updates] Baseline Update Scripts" folder
to the current Baseline script and update the script name/version.

***Insert the Version Number of [Baseline] in "__DBVersion" Table (the last section inside script file)
File Naming Format:
#################
[x.y_dbCreate.sql]
[x.y_dbDemoData.sql] (DemoData is up-to-date if create and demo script has the same version numbers)

Variables:
==========
- x = release number, value >=0, variable digit length
- y = update number, value >=1, 2 digits fixed length
Ex: 
===
1.02_dbCreate.sql
1.02_dbDemoData.sql

Notes:
######
- [Baseline] Script file must not be modified after it has been commited and pushed
on remote repository (check the file very well before committing to remote repository)
- If a change is needed, add it to a script update and wait until this update is appended
to new Baseline script with new version.
- [Demo Data] Script, don't leave this script out-dated for long time as the manual data entry will consume more time over time.

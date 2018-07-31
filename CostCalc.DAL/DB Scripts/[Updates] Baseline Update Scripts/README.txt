Update Script Description:
############################

- This update script contains all db objects that has been modified (added/deleted/updated)
since last successful commit (version control commit) along with its basic data needed (if exists)
to launch the Application update successfully on the new commit.

- This update script should be created by any team member who have done work that requires
modification to current db scheme, the member creates an update script that contains all the
modifications made and save that script in the update scripts folder.

When to Create the Update Script:
#################################
- Once before committing to version control (to maintain db changes synced with code changes)

How to Create the Update Script (choose one):
#############################################
- Manually, by writing all the db changes yourself in one update script and adjust it to ensure 
its integrity and that the update runs successfully on the Baseline script,
name the script file and increment its update number to be unique.

- Semi Automatically, by auto generating scripts from all db objects that have been modified 
with their data (if exists) and merging these generated scripts in one update script and 
adjust it to ensure its integrity and that the update runs successfully on the Baseline script,
name the script file and increment its update number to be unique.

File Naming Format:
###################

[x_DecriptiveName.sql]

Variables:
==========
- x = update number (incremental), value >=0, 2-3 fixed digit length
Ex: 
===
001_ResourceTables.sql
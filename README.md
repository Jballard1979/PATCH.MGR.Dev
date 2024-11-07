PATCH MGR allows Adminis to migrate, install, verify, & purge (*exe, *.cab, *.msi, *.msp, & *.msu) application file types onto Remote Systems.:

To install a new patch &/or application, follow the below procedure:
     1.) Click on the "LOAD PATCHE(S)" Button & navigate to the desired directory where the installation files reside:
     2.) Click the "LOAD SYSTEM(S):" Button & navigate to the desired directory where the (*.jeb or *.txt) files containing the list(s) of Remote Systems:
     3.) Click the desired "OPTIONS / MODES" you'd like to use [DEFAULT=NO REBOOT]; [FORCE REBOOT]; [DEFAULT=QUIET]; [PURGE-KB's]:
     4.) Click the "MIGRATE PATCHE(S)" Button to copy all the loaded patches to the desired Remote Systems:
     5.) Click the "START INSTALL PROCESS" Button to deploy the desired patch(es) &/or application(s) to desired Remote Systems:

OPTIONS / MODES:
     1.) The default [Options / Modes] are set with [NO REBOOT] & [QUIET] checked:
     2.) The [NO REBOOT] option Suppresses the systems from restarting or prompting the user to reboot:
     3.) The [FORCE REBOOT] option is only supported by the [*.msp & *.cab] installation methods:
     4.) The [QUIET] Checkbox option enables VERBOSE logging & progress output to the console. If Disabled, only errors are logged:
     5.) The [PURGE-KB's] Checkbox option purges all files within the Remote Systems "C$\TEMP\PATCHES\*.*" directory after installation:

TASKS:
     1.) The [CLEAR-LISTS] Button resets the LISTS & OPTIONS / MODES settings back to default & clears out all the List Boxes:
     2.) The [PURGE-KB's] Button deletes the patch files located on the remote system "C$\TEMP\PATCHES\*.*" directory:
     3.) The [REBOOT-SYS's] Button forces the loaded "SYSTEMS LIST" to reboot:
     4.) The [ENTER-CREDS] Button allows the user to enter custom user credentials:
     5.) The [OPEN-LOG] Button opens the notification log file in the default text editor:

LIST BOXES:
     1.) LEFT-CLICK to highlight desired PATCH & then RIGHT-CLICK to show menu, select "DELETE" to remove PATCH from PATCH LIST:
          1a.) CTRL+CLICK or SHIFT-CLICK the desired PATCH(es), RIGHT-CLICK & select "DELETE" to remove PATCH(es) from the PATCH LIST:
     2.) LEFT-CLICK to highlight desired SYSTEM & then RIGHT-CLICK to show menu, select "DELETE" to remove SYSTEM from SYSTEMS LIST:
           2a.) CTRL+CLICK/SHIFT+CLICK the desired SYSTEM(es), RIGHT-CLICK & select "DELETE" to remove SYSTEM(es) from the SYSTEMS LIST:

This "PATCH MGR" application allows users to migrate & install *exe, *.cab, *.msi, *.msp, & *.msu file typs on Remote Systems.:

To install a new patch &/or application, follow the below procedure:
     1.) Click on the "LOAD PATCHES:" Button & navigate to the desired installation files:
     2.) Click the "LOAD SYSTEMS:" Button & navigate to the desired *.jeb or *.txt containing the list of Remote Systems:
     3.) Click the desired options you'd like to use [DEFAULT=NO REBOOT]; [CONFORM REBOOT]; [FORCE REBOOT]; [UNINSTALL]:
     4.) Click the "MIGRATE PATCHES" Button to copy the selected patches to the desired Remote Systems:
     5.) Lastly, click the "EXECUTE PROCESS" Button to Install the desired patch &/or application to desired Remote Systems:

OPTIONS / MODES:
     1.) The default [Options / Modes] are set with [NO REBOOT] & [QUIET] checked:
     2.) The [NO REBOOT] option Suppresses the systems from restarting or prompting the user to reboot via the console:
     3.) The [CONFIRM REBOOTS] option is only supported by the [*.msp & *.cab] installation methods:
     4.) The [FORCE REBOOT] option is only supported by the [*.msp & *.cab] installation methods:
     5.) The [UNINSTALL] option is only supported by the [*.msp] installation method:
     6.) The [QUIET] Checkbox option enables VERBOSE logging & progress output to the console. If Disabled, only errors are logged:
     7.) The [PURGE-KB's] Checkbox option purges all files within the Remote Systems "C$\TEMP\PATCHES\*.*" directory after installation:

TASKS:
     1.) The [CLEAR-LISTS] Button resets the LISTS & OPTIONS / MODES settings back to default & clears out all the List Boxes:
     2.) The [PURGE-KB's] Button deletes the patch files located on the remote system "C$\TEMP\PATCHES\*.*" directory:
     3.) The [OPEN-LOG] Button opens the notification log file in the default text editor::

LIST BOXES::
     1.) You can RIGHT-CLICK in the "PATCH LIST" & "SYSTEM LIST" boxes to DELETE individual or multiple patches &/or systems:

Please report any bugs or improvement suggestions to JBallard@expl.com:
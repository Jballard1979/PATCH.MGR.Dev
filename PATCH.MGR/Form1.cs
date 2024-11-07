//
// *************************************************************************************************************:
// ****************************************** REMOTE PATCH MANAGEMENT ******************************************:
// *************************************************************************************************************:
// Author:  JBallard (JEB)                                                                                      :
// Date:    2023.6.10                                                                                           :
// Project: MS PATCH MANAGER                                                                                    :
// Dir:     C:\0_SCRIPTS\PATCH.MGR\PATCH.MGR.exe                                                                :
// Effort:  A C# project used for managing MS patches & applications on remote WIN Systems.                     :
// Ver:     2.5                                                                                                 :
// *************************************************************************************************************:
// *************************************************************************************************************:
//
// ********************************************************:
// DEFINE PARAMS, CONSTANTS, CONFIG PATHS, CLASSES, & LIBS :
// ********************************************************:
using System;
using PATCH.MGR;
using SCADA.PATCHING;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
//
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private const string LOCPATCHDir = @"C:\TEMP\PATCHES";
        private const string LOCSYSDir   = @"C:\0_SCRIPTS\SCADA-PATCHING\SYS";
        private const string PSEXECPath  = @"C:\PSTOOLS\PSEXEC64.exe";
        private readonly string LOGPath  = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PATCH.MGR.LOG.jeb");
        private readonly string PATCHLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PATCH.MGR.PATCH.RPT.csv");
        private List<string> PATCHPaths  = new List<string>();
        private List<string> REMSYSNames = new List<string>();

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ContextMenu contextMenu = new ContextMenu();
            MenuItem menuItemDelete = new MenuItem("DELETE");
            menuItemDelete.Click += (s, ev) => DELETEPATCHAction();
            contextMenu.MenuItems.Add(menuItemDelete);
            LstPatches.ContextMenu = contextMenu;
            LstLoadSystems.ContextMenu = contextMenu;
        }

        // CALL CREDS FORM:
        private void BtnEnrCreds_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        private void BtnClrLstOptions_Click(object sender, EventArgs e)
        {
            CLEARLists();
        }

        private void BtnOpenLog_Click(object sender, EventArgs e)
        {
            OPENLOGFile();
        }

        private void TSRebootSystems_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("WARNING - PROCEED WITH SYSTEM REBOOTS?", "PATCH MGR v2.5", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                REBOOTSys();
            }
            else
            {
                AddToNotification($"NOTE - USER CANCELED SYSTEM REBOOTS!:", Color.Red);
                return;
            }
        }

        private void BtnNoteLog_Click(object sender, EventArgs e)
        {
            OPENLOGFile();
        }

        private void BtnLoadPatches_Click(object sender, EventArgs e)
        {
            LOADPatches();
        }

        private void BtnLoadSys_Click(object sender, EventArgs e)
        {
            LOADREMOTESys();
        }

        private void LstPatches_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                DELETEPATCHAction();
            }
        }

        private void LstLoadSystems_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                DELETEPATCHAction();
            }
        }

        // METHOD TO DELETE SELECTED LIST ITEMS:
        private void DELETEPATCHAction()
        {
            foreach (var item in LstPatches.SelectedItems.OfType<string>().ToList())
            {
                PATCHPaths.Remove(item);
            }
            PATCHList();
            foreach (var item in LstLoadSystems.SelectedItems.OfType<string>().ToList())
            {
                REMSYSNames.Remove(item);
            }
            UPDATEREMOTESYSList();
        }

        // CONNECT TO REMOTE SERVER USING USER PROVIDED CREDS:
        private void ConnectToServer()
        {
            using (var credentialForm = new Form3())
            {
                if (credentialForm.ShowDialog() == DialogResult.OK)
                {
                    string username = credentialForm.Username;
                    string password = credentialForm.Password;
                    ConnectToServerWithCredentials(username, password);
                }
                else
                {
                    MessageBox.Show("NOTE - CONNECTION CANCELLED:", "PATCH MGR v2.5");
                }
            }
        }

        private void BtnCopyPatches_Click(object sender, EventArgs e)
        {
            if (LstPatches.Items.Count == 0 || LstLoadSystems.Items.Count == 0)
            {
                AddToNotification($"ERROR - FAILED TO LOAD SYSTEMS LIST:", Color.Red);
                MessageBox.Show("ERROR - FAILED TO LOAD SYSTEMS LIST:", "PATCH MGR v2.5");
            }
            else
            {
                INSTALLPATCHAsync();
            }
        }

        // USER DEFINED OPTION TO PURGE ALL FILES ON THE REMOTE SYSTEMS:
        private void BtnDeleteFiles_Click(object sender, EventArgs e)
        {
            if (LstLoadSystems.Items.Count == 0)
            {
                AddToNotification($"ERROR - FAILED TO LOAD SYSTEMS LIST:", Color.Red);
                MessageBox.Show("ERROR - FAILED TO LOAD SYSTEMS LIST:", "PATCH MGR v2.5");
            }
            else
            {
                DELREMFiles();
            }
        }

        // USER CHOSE TO PURGE REMOTE PATCHES DIRECTORY:
        private void CBCleanRemDir_CheckedChanged(object sender, EventArgs e)
        {
            if (CBCleanRemDir.Checked == true)
            {
                AddToNotification($"ALERT - WILL PURGE PATCHES AFTER INSTALLATION PROCESS:", Color.Coral);
                CBCleanRemDir.ForeColor = System.Drawing.Color.MistyRose;
            }
            else
            {
                CBCleanRemDir.ForeColor = System.Drawing.Color.White;
            }
        }

        // USER SELECTED TO REBOOT AFTER PATCHING PROCESS:
        private void RbtnForceReboot_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtnForceReboot.Checked == true)
            {
                RbtnForceReboot.ForeColor = System.Drawing.Color.Plum;
                MessageBox.Show("ALERT - FORCE SYSTEM REBOOTS!", "PATCH MGR v2.5");
            }
            else
            {
                RbtnForceReboot.ForeColor = System.Drawing.Color.White;
            }
        }

        // USER MODIFIED QUIET MODE SETTINGS:
        private void CBQuietMode_CheckedChanged(object sender, EventArgs e)
        {
            if (CBQuietMode.Checked == true)
            {
                CBQuietMode.ForeColor = System.Drawing.Color.LimeGreen;
            }
            else
            {
                CBQuietMode.ForeColor = System.Drawing.Color.White;
            }
        }

        // CALL PATCHING ASYNC:
        private async void BtnStartPatch_Click(object sender, EventArgs e)
        {
            if (LstPatches.Items.Count == 0 || LstLoadSystems.Items.Count == 0)
            {
                AddToNotification($"ERROR - FAILED TO LOAD SYSTEMS LIST:", Color.Red);
                MessageBox.Show("ERROR - FAILED TO LOAD SYSTEMS LIST:", "PATCH MGR v2.5");
            }
            else
            {
                await STARTPATCHINGAsync();
            }
        }

        // CALL "GET PATCHING" METHOD:
        private async void BtnQueryKB_Click(object sender, EventArgs e)
        {
            if (LstPatches.Items.Count == 0 && LstLoadSystems.Items.Count != 0)
            {
                await QUERYALLKBs();
            }
            if (LstPatches.Items.Count != 0 && LstLoadSystems.Items.Count != 0)
            {
                await QUERYKB();
            }
            if(LstPatches.Items.Count == 0 && LstLoadSystems.Items.Count == 0)
            {
                AddToNotification($"ERROR - PLEASE LOAD PATCH & SYSTEMS LISTS:", Color.Red);
                MessageBox.Show("ERROR - PLEASE LOAD PATCH & SYSTEMS LISTS:", "PATCH MGR v2.5");
            }
        }

        // LOAD SELECTED PATCHES:
        private void LOADPatches()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = LOCPATCHDir,
                Filter = "WIN PATCH FILES (*.msu;*.msp;*.msi;*.cab;*.exe)|*.msu;*.msp;*.msi;*.cab;*.exe",
                Title = "NAVIGATE TO THE DESIRED PATCH FILE(s):",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PATCHPaths.AddRange(openFileDialog.FileNames);
                PATCHList();
                AddToNotification($"LOADED {openFileDialog.FileNames.Length} PATCH FILES:", Color.White);
            }
        }

        // LOAD SELECTED REMOTE SYSTEMS:
        private void LOADREMOTESys()
        {
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = LOCSYSDir,
                Filter = "JEB FILES (*.jeb;*.txt)|*.jeb;*.txt",
                Title = "SELECT FILE CONTAINING LIST OF REMOTE SCADA SYSTEMS:"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    REMSYSNames = File.ReadAllLines(openFileDialog.FileName).ToList();
                    UPDATEREMOTESYSList();
                    AddToNotification($"LOADED {REMSYSNames.Count} REMOTE SYSTEM(S): ", Color.White);
                }
                catch (Exception ex)
                {
                    AddToNotification($"ERROR LOADING REMOTE SYSTEMS FILE (.jeb): {ex.Message}", Color.Red);
                }
            }
        }

        // LIST OF PATCHES:
        private void PATCHList()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)PATCHList);
                return;
            }
            LstPatches.Items.Clear();
            foreach (var patchPath in PATCHPaths)
            {
                string patchFileName = Path.GetFileName(patchPath);
                LstPatches.Items.Add(patchPath);
            }
        }

        // LIST OF SYSTEMS:
        private void UPDATEREMOTESYSList()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)UPDATEREMOTESYSList);
                return;
            }
            LstLoadSystems.Items.Clear();
            LstLoadSystems.Items.AddRange(REMSYSNames.ToArray());
        }

        // TEST ACCESS TO REMOTE SYSTEMS:
        private bool REMFILEExists(string remoteFilePath)
        {
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "POWERSHELL.exe";
                    process.StartInfo.Arguments = $"TEST-PATH \"{remoteFilePath}\"";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    return output.Trim() == "True";
                }
            }
            catch (Exception ex)
            {
                AddToNotification($"ERROR CHECKING FILE EXISTENCE: {ex.Message}", Color.Red);
                return false;
            }
        }

        // MIGRATE PATCHING PROCESS:
        private void INSTALLPATCHAsync()
        {
            try
            {
                DISABLEBtns();
                int totalOperations = REMSYSNames.Count * PATCHPaths.Count;
                int currentOperation = 0;
                //
                if (LstPatches.Items.Count == 0 || LstLoadSystems.Items.Count == 0)
                {
                    AddToNotification($"ERROR - FAILED TO LOAD SYSTEMS LIST:", Color.Red);
                    MessageBox.Show("ERROR - FAILED TO LOAD SYSTEMS LIST:", "PATCH MGR v2.5");
                }
                foreach (var REMSYSName in REMSYSNames)
                {
                    foreach (var PATCHPath in PATCHPaths)
                    {
                        var REMFILEPath = Path.Combine($"\\\\{REMSYSName}\\C$\\TEMP\\PATCHES", Path.GetFileName(PATCHPath));
                        if (REMFILEExists(REMFILEPath))
                        {
                            AddToNotification($"SKIPPING [ {PATCHPath} ] - ALREADY EXISTS ON [ {REMSYSName} ].", Color.White);
                            continue;
                        }
                        COPYPATCHTORemote(PATCHPath, REMSYSName);
                        currentOperation++;
                        UPDATEPROGRESSBar(currentOperation, totalOperations);
                    }
                }
                AddToNotification($"END - PROCESS FILE MIGRATION ON ALL REMOTE SYSTEMS:", Color.White);
            }
            catch (Exception ex)
            {
                AddToNotification($"ERROR (INSTALLPATCHAsync): {ex.Message}", Color.Red);
            }
            finally
            {
                ENABLEBtns();
            }
        }

        // COPY PATCHES TO REMOTE SYSTEMS:
        private void COPYPATCHTORemote(string LOCPATCHPath, string REMSYSName)
        {
            var REMFILEPath = Path.Combine($"\\\\{REMSYSName}\\C$\\TEMP\\PATCHES", Path.GetFileName(LOCPATCHPath));
            //
            if (LstPatches.Items.Count == 0 && LstLoadSystems.Items.Count == 0)
            {
                AddToNotification($"ERROR - FAILED TO LOAD SYSTEMS LIST:", Color.Red);
                MessageBox.Show("ERROR - FAILED TO LOAD SYSTEMS LIST:", "PATCH MGR v2.5");
            }
            try
            {
                File.Copy(LOCPATCHPath, REMFILEPath, true);
                AddToNotification($"SUCCESSFULLY COPIED [ {Path.GetFileName(LOCPATCHPath)} ] TO [ {REMSYSName} ].", Color.White);
            }
            catch (Exception ex)
            {
                AddToNotification($"ERROR COPYING [ {Path.GetFileName(LOCPATCHPath)} ] TO [ {REMSYSName} ]: {ex.Message}", Color.Red);
            }
        }

        // START PATCHING PROCESS:
        private async Task STARTPATCHINGAsync()
        {
            try
            {
                DISABLEBtns();
                int totalOperations = REMSYSNames.Count * PATCHPaths.Count;
                int currentOperation = 0;
                //
                if (LstPatches.Items.Count == 0 || LstLoadSystems.Items.Count == 0)
                {
                    AddToNotification($"ERROR - FAILED TO LOAD SYSTEMS LIST:", Color.Red);
                    MessageBox.Show("ERROR - FAILED TO LOAD SYSTEMS LIST:", "PATCH MGR v2.5");
                }
                // LOOP THRU ALL SYSTEMS: 
                foreach (var REMSYSName in REMSYSNames)
                {
                    foreach (var PATCHPath in PATCHPaths)
                    {
                        var REMFILEPath = Path.Combine($"C$\\TEMP\\PATCHES", Path.GetFileName(PATCHPath));
                        //
                        string FILExt = Path.GetExtension(PATCHPath).ToLower();
                        string FILEName = Path.GetFileName(REMFILEPath);
                        string PSCmd = "";
                        string PSArgs = "";
                        //
                        // UNBLOCK STEP:
                        var UNBLOCKCmd = $"GET-CHILDITEM -PATH \\\\{REMSYSName}\\C$\\TEMP\\PATCHES\\ -RECURSE | UNBLOCK-FILE";
                        var UNBLOCKArgs = $"\"{UNBLOCKCmd}\"";
                        var UNBLOCKProcInfo = new ProcessStartInfo
                        {
                            FileName = "POWERSHELL.exe",
                            Arguments = UNBLOCKArgs,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        };
                        AddToNotification($"UNBLOCK COMMAND: {UNBLOCKCmd}", Color.White);
                        AddToNotification($"UNBLOCKING FILE(S): {Path.GetFileName(REMFILEPath)}", Color.Lime);
                        // UNBLOCK PROCESS:
                        using (var process = Process.Start(UNBLOCKProcInfo))
                        {
                            if (process != null)
                            {
                                string output = await process.StandardOutput.ReadToEndAsync();
                                await process.WaitForExitAsync();
                                if (process.ExitCode != 0)
                                {
                                    AddToNotification($"ERROR UNBLOCKING FILE: {Path.GetFileName(REMFILEPath)}", Color.Red);
                                    AddToNotification($"POWERSHELL OUTPUT: {output}", Color.Red);
                                    continue;
                                }
                            }
                            else
                            {
                                AddToNotification($"ERROR STARTING POWERSHELL PROCESS", Color.Red);
                                continue;
                            }
                        }
                        // PROCESS THE LOADED FILE TYPES:
                        switch (FILExt)
                        {
                            // INSTALL CAB - MICROSOFT CABINET FILE:
                            case ".cab":
                                PSCmd = $@"&{PSEXECPath} -accepteula -s \\{REMSYSName} DISM /ONLINE /ADD-PACKAGE /PACKAGEPATH:\\{REMSYSName}\{REMFILEPath}";
                                if (!RbtnNoReboot.Checked == false) { PSCmd += " /NORESTART"; }
                                if (CBQuietMode.Checked == true)  { PSCmd += " /QUIET"; }
                                if (CBCleanRemDir.Checked == true) { DELREMFiles(); }
                                break;
                            //
                            // INSTALL MSI - MICROSOFT STANDALONE INSTALLER:
                            case ".msi":
                                PSCmd = $@"&{PSEXECPath} -accepteula -s \\{REMSYSName} MSIEXEC /i \\{REMSYSName}\{REMFILEPath}";
                                if (!RbtnNoReboot.Checked == false) { PSCmd += " /NORESTART"; }
                                if (CBQuietMode.Checked == true) { PSCmd += " /qn"; }
                                if (CBCleanRemDir.Checked == true) { DELREMFiles(); }
                                break;
                            //
                            // INSTALL MSP - MICROSOFT STANDALONE PATCH:
                            case ".msp":
                                PSCmd = $@"&{PSEXECPath} -accepteula -s \\{REMSYSName} MSIEXEC /p \\{REMSYSName}\{REMFILEPath}";
                                if (!RbtnNoReboot.Checked == false) { PSCmd += " /qb"; }
                                if (CBCleanRemDir.Checked == true) { DELREMFiles(); }
                                break;
                            //
                            // MSU - MICROSOFT UPDATE:
                            case ".msu":
                                PSCmd = $@"&{PSEXECPath} -accepteula -s \\{REMSYSName} WUSA -ARGUMENTLIST \\{REMSYSName}\{REMFILEPath}";
                                if (!RbtnNoReboot.Checked == false) { PSCmd += " /NORESTART"; }
                                if (CBQuietMode.Checked == true) { PSCmd += " /QUIET"; }
                                if (CBCleanRemDir.Checked == true) { DELREMFiles(); }
                                break;
                            //
                            // INSTALL EXE - MICROSOFT EXECUTABLE:
                            case ".exe":
                                PSCmd = $@"&{PSEXECPath} -c -e -v -h \\{REMSYSName} \\{REMSYSName}\{REMFILEPath} /S";
                                if (!RbtnNoReboot.Checked == false) { PSCmd += " /NORESTART"; }
                                if (CBQuietMode.Checked == true) { PSCmd += " /QUIET"; }
                                if (CBCleanRemDir.Checked == true) { DELREMFiles(); }
                                break;
                            default:
                                AddToNotification($"ERROR - UNSUPPORTED WINDOWS FILE TYPE: {FILExt}", Color.Red);
                                continue;
                        }
                        // PASSING COMMAND WITH ARGUMENTS:
                        PSArgs = $@"-NOPROFILE -EXECUTIONPOLICY REMOTESIGNED -COMMAND {PSCmd}";
                        var powershellProcessInfo = new ProcessStartInfo
                        {
                            FileName = "POWERSHELL.exe",
                            Arguments = PSArgs,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        };
                        AddToNotification($"EXECUTING COMMAND: {PSCmd}", Color.Lime);
                        using (Process process = Process.Start(powershellProcessInfo))
                        {
                            process.StartInfo = powershellProcessInfo;
                            process.OutputDataReceived += (sender, e) => AddToNotification(e.Data, Color.White);
                            process.Start();
                            process.BeginOutputReadLine();
                            await process.WaitForExitAsync();
                        }
                        currentOperation++;
                        UPDATEPROGRESSBar(currentOperation, totalOperations);
                        await Task.Delay(TimeSpan.FromSeconds(30));
                        // KILL REMOTE POWERSHELL PROCESSES:
                        foreach (var process in Process.GetProcessesByName("powershell.exe"))
                        {
                            if (process != null)
                            {
                                AddToNotification($"KILL REMOTE PS PROCESS:", Color.Lime);
                                process.Kill();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddToNotification($"ERROR (STARTPATCHINGAsync): {ex.Message}", Color.Red);
            }
            finally
            {
                ENABLEBtns();
            }
        }

        // RETRIEVE USER DEFINED SYSTEMS KB'S:
        private async Task QUERYKB()
        {
            try
            {
                DISABLEBtns();
                //
                int totalOperations = REMSYSNames.Count * PATCHPaths.Count;
                int currentOperation = 0;
                //
                // LOOP THROUGH PATCHES & SYSTEMS LISTS:
                foreach (var REMSYSName in REMSYSNames)
                {
                    foreach (var PATCHPath in PATCHPaths)
                    {
                        var REMFILEPath = Path.Combine($"C$\\TEMP\\PATCHES", Path.GetFileName(PATCHPath));
                        string FILExt = Path.GetExtension(PATCHPath).ToLower();
                        string FILEName = Path.GetFileName(REMFILEPath);
                        string GETHFCmd = "";
                        string GETHFArgs = "";
                        string KBNOName = FILEName.Remove(FILEName.Length - 4);
                        // PURGE KB FROM STRING:
                        char[] KBChars = { 'K', 'B' };
                        string KBName = KBNOName.TrimStart(KBChars);
                        //
                        AddToNotification($"NOTE - PLEASE WAIT, VERIFYING {KBNOName} INSTALLATION ON {REMSYSName}:", Color.Lime);
                        GETHFCmd = $@"&{PSEXECPath} -accepteula -s \\{REMSYSName} DISM /ONLINE /GET-PACKAGES /FORMAT:TABLE | FINDSTR /i '{KBNOName}'";
                        // PASSING COMMAND WITH ARGUMENTS:
                        GETHFArgs = $@"-NOPROFILE -EXECUTIONPOLICY REMOTESIGNED -COMMAND {GETHFCmd}";
                        //
                        // PASS PS ARGS TO A NEW PS PROCESS:
                        var powershellProcessInfo = new ProcessStartInfo
                        {
                            FileName = "POWERSHELL.exe",
                            Arguments = GETHFArgs,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        };
                        AddToNotification($"EXECUTING COMMAND: {GETHFCmd}", Color.White);
                        using (Process process = Process.Start(powershellProcessInfo))
                        {
                            process.StartInfo = powershellProcessInfo;
                            process.OutputDataReceived += (sender, e) => AddToNotification(e.Data, Color.White);
                            process.Start();
                            process.BeginOutputReadLine();
                            await process.WaitForExitAsync();
                        }
                        currentOperation++;
                        UPDATEPROGRESSBar(currentOperation, totalOperations);
                        await Task.Delay(TimeSpan.FromSeconds(30));
                        // KILL REMOTE POWERSHELL PROCESSES:
                        foreach (var process in Process.GetProcessesByName("powershell.exe"))
                        {
                            if (process != null)
                            {
                                AddToNotification($"KILL REMOTE PS PROCESS:", Color.Lime);
                                process.Kill();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddToNotification($"ERROR - (QUERYKB): {ex.Message}", Color.Red);
            }
            finally
            {
                ENABLEBtns();
            }
        }

        // RETRIEVE ALL SYSTEM KB'S:
        private async Task QUERYALLKBs()
        {
            try
            {
                DISABLEBtns();
                int totalOperations = REMSYSNames.Count * PATCHPaths.Count;
                int currentOperation = 0;
                //
                // LOOP THROUGH PATCHES & SYSTEMS LISTS:
                foreach (var REMSYSName in REMSYSNames)
                {
                    string PSCmd = "";
                    string PSArgs = "";
                    //
                    AddToNotification($"NOTE - RETRIEVING THE FULL LIST OF KB'S INSTALLED ON {REMSYSName}:", Color.Lime);
                    PSCmd = $@"&{PSEXECPath} -accepteula -s \\{REMSYSName} DISM /ONLINE /GET-PACKAGES /FORMAT:TABLE";
                    // PASSING COMMAND WITH ARGUMENTS:
                    PSArgs = $@"-NOPROFILE -EXECUTIONPOLICY REMOTESIGNED -COMMAND {PSCmd}";
                    //
                    // PASS PS ARGS TO A NEW PS PROCESS:
                    var powershellProcessInfo = new ProcessStartInfo
                    {
                        FileName = "POWERSHELL.exe",
                        Arguments = PSArgs,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    };
                    AddToNotification($"EXECUTING COMMAND: {PSCmd}", Color.White);
                    using (Process process = Process.Start(powershellProcessInfo))
                    {
                        process.StartInfo = powershellProcessInfo;
                        process.OutputDataReceived += (sender, e) => AddToNotification(e.Data, Color.White);
                        process.Start();
                        process.BeginOutputReadLine();
                        await process.WaitForExitAsync();
                    }
                    currentOperation++;
                    UPDATEPROGRESSBar(currentOperation, totalOperations);
                    await Task.Delay(TimeSpan.FromSeconds(30));
                    // KILL REMOTE POWERSHELL PROCESSES:
                    foreach (var process in Process.GetProcessesByName("powershell.exe"))
                    {
                        if (process != null)
                        {
                            AddToNotification($"KILL REMOTE PS PROCESS:", Color.Lime);
                            process.Kill();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddToNotification($"ERROR - (QUERYKBS): {ex.Message}", Color.Red);
            }
            finally
            {
                ENABLEBtns();
            }
        }

        // METHOD TO PURGE FILES IN REMFILEPath:
        private void DELREMFiles()
        {
            try
            {
                DISABLEBtns();
                //
                if (LstLoadSystems.Items.Count == 0 && LstPatches.Items.Count == 0)
                {
                    AddToNotification($"ERROR - FAILED TO LOAD SYSTEMS LIST:", Color.Red);
                    MessageBox.Show("ERROR - FAILED TO LOAD SYSTEMS LIST:", "PATCH MGR v2.5");
                }
                // LOOP THROUGH SYSTEMS:
                foreach (var REMSYSName in REMSYSNames)
                {
                    // CONSTRUCT REMOTE FILE PATH:
                    var REMFILEPath = Path.Combine($"\\\\{REMSYSName}\\C$\\TEMP\\PATCHES\\");
                    AddToNotification($"NOTE - PREPARING PURGE OF ALL PATCHES @ ({REMFILEPath}):", Color.Lime);
                    // VERIFY REMOTE SYSTEMS DIRECTORY EXISTS:
                    if (Directory.Exists(REMFILEPath))
                    {
                        string[] files = Directory.GetFiles(REMFILEPath);
                        AddToNotification($"NOTE - PURGING ALL FILES @ ({REMFILEPath}):", Color.Lime);
                        // DELETE EACH FILE IN REMOTE SYSTEMS DIRECTORY:
                        foreach (string file in files)
                        {
                            File.Delete(file);
                        }
                        AddToNotification($"NOTE - PURGED {files.Length} FILES @ {REMFILEPath}:", Color.Lime);
                    }
                    else
                    {
                        AddToNotification($"ERROR - ({REMFILEPath}) DOES NOT EXIST:", Color.Red);
                    }
                }
            }
            catch (Exception ex)
            {
                AddToNotification($"ERROR: {ex.Message}", Color.Red);
            }
            finally
            {
                ENABLEBtns();
            }
        }

        // METHOD TO REBOOT ALL LOADED SYSTEMS:
        private void REBOOTSys()
        {
            try
            {
                DISABLEBtns();
                //
                if (LstLoadSystems.Items.Count == 0)
                {
                    AddToNotification("ERROR - FAILED TO LOAD SYSTEMS LIST:", Color.Red);
                    MessageBox.Show("ERROR - FAILED TO LOAD SYSTEMS LIST:", "PATCH MGR v2.5");
                }
                // LOOP THROUGH SYSTEMS:
                foreach (var REMSYSName in REMSYSNames)
                {
                    string PSCmd = "";
                    string PSArgs = "";
                    //
                    AddToNotification($"NOTE - PREPAIRING TO REBOOT SYSTEM - {REMSYSName}:", Color.Lime);
                    // EXECUTE REBOOT COMMAND USING A 5 SEC WAIT TIME:
                    PSCmd = $@"&{PSEXECPath} -accepteula -s \\{REMSYSName} SHUTDOWN /m \\{REMSYSName} /r /f /t 5";
                    Thread.Sleep(5000);
                    // PASSING COMMAND WITH ARGUMENTS:
                    PSArgs = $@"-NOPROFILE -EXECUTIONPOLICY REMOTESIGNED -COMMAND {PSCmd}";
                    //
                    // PASS CMD & ARGS TO A NEW PS PROCESS:
                    var powershellProcessInfo = new ProcessStartInfo
                    {
                        FileName = "POWERSHELL.exe",
                        Arguments = PSArgs,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    };
                    AddToNotification($"EXECUTING COMMAND: {PSCmd}", Color.White);
                    using (Process process = Process.Start(powershellProcessInfo))
                    {
                        process.StartInfo = powershellProcessInfo;
                        process.OutputDataReceived += (sender, e) => AddToNotification(e.Data, Color.White);
                        process.Start();
                        process.BeginOutputReadLine();
                    }
                    AddToNotification($"NOTE - SYSTEM {REMSYSName} IS REBOOTING:", Color.Lime);
                    //
                    // KILL REMOTE POWERSHELL PROCESSES:
                    foreach (var process in Process.GetProcessesByName("powershell.exe"))
                    {
                        if (process != null)
                        {
                            AddToNotification($"KILL REMOTE PS PROCESS:", Color.Lime);
                            process.Kill();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddToNotification($"ERROR: {ex.Message}", Color.Red);
            }
            finally
            {
                ENABLEBtns();
            }
        }

        // UPDATE PROGRESS BAR & PROGRESS BAR PERCENTAGE LABEL:
        private void UPDATEPROGRESSBar(int currentOperation, int totalOperations)
        {
            int PROGPercentage = (int)((double)currentOperation / totalOperations * 100);
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() => { PbarOverallProgress.Value = PROGPercentage; }));
            }
            else
            {
                PbarOverallProgress.Value = PROGPercentage;
            }
        }

        // WRITE NOTIFICATIONS:
        private void AddToNotification(string message, Color textColor)
        {
            // CHECK FOR NULL, EMPTY, OR WHITE SPACES:
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() => AddToNotification(message, textColor)));
                return;
            }
            LstNotification.Items.Add(message);
            LstNotification.SelectedIndex = LstNotification.Items.Count - 1;
            LstNotification.ClearSelected();
            LstNotification.ForeColor = textColor;
            WriteLog(message);
        }

        private void BtnCopyNotification_Click(object sender, EventArgs e)
        {
            CopyNotificationToClipboard();
        }

        private void CopyNotificationToClipboard()
        {
            StringBuilder notificationText = new StringBuilder();
            foreach (var item in LstNotification.Items)
            {
                notificationText.AppendLine(item.ToString());
            }
            if (notificationText.Length > 0)
            {
                Clipboard.SetText(notificationText.ToString());
            }
        }

        // OPEN LOG FILE:
        private void OPENLOGFile()
        {
            try
            {
                if (File.Exists(LOGPath))
                {
                    Process.Start(LOGPath);
                }
                else
                {
                    AddToNotification($"ERROR - LOG FILE MISSING:", Color.Red);
                }
            }
            catch (Exception ex)
            {
                AddToNotification($"ERROR: {ex.Message}", Color.Red);
            }
        }

        // WRITE TO LOG FILE:
        private void WriteLog(string message)
        {
            try
            {
                File.AppendAllText(LOGPath, $"{DateTime.Now}: {message}\n");
            }
            catch (Exception ex)
            {
                AddToNotification($"ERROR: {ex.Message}", Color.Red);
            }
        }

        private void ConnectToServerWithCredentials(string username, string password)
        {
            // I NEED TO WRITE CONNECTION LOGIC:
        }

        // DISABLE BUTTONS:
        private void DISABLEBtns()
        {
            BtnOpenLog.Enabled = false;
            BtnQueryKB.Enabled = false;
            BtnLoadPatches.Enabled = false;
            BtnLoadSys.Enabled = false;
            BtnStartPatch.Enabled = false;
            BtnCopyPatches.Enabled = false;
            BtnQueryKB.Enabled = false;
            CBCleanRemDir.Enabled = false;
            CBQuietMode.Enabled = false;
            RbtnNoReboot.Enabled = false;
            RbtnForceReboot.Enabled = false;
        }

        // ENABLE BUTTONS:
        private void ENABLEBtns()
        {
            BtnOpenLog.Enabled = true;
            BtnQueryKB.Enabled = true;
            BtnLoadPatches.Enabled = true;
            BtnLoadSys.Enabled = true;
            BtnStartPatch.Enabled = true;
            BtnCopyPatches.Enabled = true;
            BtnQueryKB.Enabled = true;
            CBCleanRemDir.Enabled = true;
            CBQuietMode.Enabled = true;
            RbtnNoReboot.Enabled = true;
            RbtnForceReboot.Enabled = true;
        }

        private void HELPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.Show();
        }

        // CLEAR PATCH & SYSTEM LISTS:
        private void CLEARLists()
        {
            this.Hide();
            Form1 F1 = new Form1();
            F1.Show();
        }

        // RUN NEW INSTANCE:
        private void TsmNewInstance_Click(object sender, EventArgs e)
        {
            Form1 F1 = new Form1();
            F1.Show();
        }

        // CLOSE CURRENT INSTANCE:
        private void TsmCloseInstance_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // CLOSE ALL THREADS & EXIT APP:
        private void TsmCloseApplication_Click(object sender, EventArgs e)
        {
            while (MessageBox.Show("WARNING - CLOSE ALL PATCH MGR INSTANCES?", "PATCH MGR v2.5", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EXITApp();
            }
            this.Hide();
        }

        // CLOSE CURRENT INSTANCE:
        private void BtnCmdExit_Click(object sender, EventArgs e)
        {
            while (MessageBox.Show("WARNING - CLOSE ALL PATCH MGR INSTANCES?", "PATCH MGR v2.5", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EXITApp();
            }
            this.Hide();
        }

        private void EXITApp()
        {
            System.Windows.Forms.Application.ExitThread();
            System.Windows.Forms.Application.Exit();
            Environment.Exit(0);
            Application.Exit();
        }

        private void LstPatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void LstLoadSystems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void RbtnForceReboot_MouseHover(object sender, EventArgs e)
        {
            //
        }

        private void CBQuietMode_MouseHover(object sender, EventArgs e)
        {
            //
        }

        private void BtnQueryKB_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void PbarOverallProgress_Click(object sender, EventArgs e)
        {
            //
        }

        private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //
        }

        private void TSMItemFile_Click(object sender, EventArgs e)
        {
            //
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //
        }

        private void ToolTip1_Popup(object sender, PopupEventArgs e)
        {
            //
        }
    }
}
//
// ********************************************************:
// END OF C# FORM SOURCE                                   :
// ********************************************************:
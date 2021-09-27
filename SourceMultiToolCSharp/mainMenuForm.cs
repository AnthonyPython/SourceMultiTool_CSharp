using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Steamworks;
using Steamworks.Ugc;
//using Facepunch.Steamworks;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SourceMultiToolCSharp
{
    
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        // to load the steam_api.dll, we will use LoadLibrary from kernel32
        // (worry not, ye 64-bit app developers: kernel32 is a misnomer; this
        // DLL is used in both 32 and 64-bit environments.)
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        public static Steam steam = new Steam();
        static List<DirectoryInfo> SourceModfolders = new List<DirectoryInfo>(); // List that hold direcotries that cannot be accessed
        public static List<SourceGame> listOfSourceGames = new List<SourceGame>();
        public static string version = "3.0.0";

        public string cwd = Directory.GetCurrentDirectory().ToString();

        private void ButtonBrowseSteamDir_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialogSteam.ShowDialog();
            if (result == DialogResult.OK)
            {
                textSteamDirectory.Text = folderBrowserDialogSteam.SelectedPath;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (File.Exists(textSteamDirectory.Text + "/Steam.exe"))
            {
                Properties.Settings.Default.mainSteamDir = textSteamDirectory.Text;
                Properties.Settings.Default.Save();
                steam.MainSteamDir = Properties.Settings.Default.mainSteamDir;
                System.Windows.Forms.MessageBox.Show("Save Complete!", "Saved", MessageBoxButtons.OK);
                FindSteamDirectories();
                
            }
            else
            {
                MessageBox.Show("The Main Steam Directory you have chosen does not contain Steam.exe meaning it is not your main directory", "ERROR 001", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        

    private void MainMenuForm_Load(object sender, EventArgs e)
        {
            FindSteam();
            SteamInt();


            try
            {
                SteamClient.Init(440, true);
            }
            catch (System.Exception e_)
            {
                // something here
            }

            versionLabel.Text += version;
            // Add Source Games
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Alien Swarm",
                ProperName = "Alien Swarm",
                SourceName = "swarm",
                Installed = false,
                Directory = "",
                Executable = "swarm",
                AppID = 630

            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Alien Swarm Reactive Drop",
                ProperName = "Alien Swarm: Reactive Drop",
                SourceName = "reactivedrop",
                Installed = false,
                Directory = "",
                Executable = "reactivedrop",
                AppID = 563560
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Blade Symphony",
                ProperName = "Blade Symphony",
                SourceName = "berimbau",
                Installed = false,
                Directory = "",
                Executable = "berimbau",
                AppID = 225600
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Contagion",
                ProperName = "Contagion",
                SourceName = "contagion",
                Installed = false,
                Directory = "",
                Executable = "contagion",
                AppID = 238430
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Counter-Strike Global Offensive",
                ProperName = "Counter-Strike Global Offensive",
                SourceName = "csgo",
                Installed = false,
                Directory = "",
                Executable = "csgo",
                AppID = 730
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Counter-Strike Source",
                ProperName = "Counter-Strike Source",
                SourceName = "cstrike",
                Installed = false,
                Directory = "",
                Executable = "hl2",
                AppID = 240
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Day of Defeat Source",
                ProperName = "Day of Defeat Source",
                SourceName = "dod",
                Installed = false,
                Directory = "",
                Executable = "hl2",
                AppID = 300
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "dayofinfamy",
                ProperName = "Day of Infamy",
                SourceName = "doi",
                Installed = false,
                Directory = "",
                Executable = "dayofinfamy_BE",
                AppID = 447820
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Dino D-Day",
                ProperName = "Dino D-Day",
                SourceName = "dinodday",
                Installed = false,
                Directory = "",
                Executable = "dinodday",
                AppID = 70000
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Double Action",
                ProperName = "Double Action",
                SourceName = "dab",
                Installed = false,
                Directory = "",
                Executable = "hl2",
                AppID = 317360
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Deathmatch Classic Refragged",
                ProperName = "Deathmatch Classic: Refragged",
                SourceName = "dmc",
                Installed = false,
                Directory = "",
                Executable = "dmc",
                AppID = 1435320
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Empires",
                ProperName = "Empires",
                SourceName = "empires",
                Installed = false,
                Directory = "",
                Executable = "hl2",
                AppID = 17740
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "FIREFIGHT RELOADED",
                ProperName = "FIREFIGHT RELOADED",
                SourceName = "firefightreloaded",
                Installed = false,
                Directory = "",
                Executable = "fr",
                AppID = 397680
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "G String",
                ProperName = "G String",
                SourceName = "gstringv2",
                Installed = false,
                Directory = "",
                Executable = "gstring",
                AppID = 1224600
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "GarrysMod",
                ProperName = "Garry's Mod",
                SourceName = "garrysmod",
                Installed = false,
                Directory = "",
                Executable = "hl2",
                AppID = 4000
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Half-Life 1 Source Deathmatch",
                ProperName = "Half-Life Source Deathmatch",
                SourceName = "hl1mp",
                Installed = false,
                Directory = "",
                Executable = "hl2",
                AppID = 360
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Half-Life 2",
                ProperName = "Half-Life 2",
                SourceName = "hl2",
                Installed = false,
                Directory = "",
                Executable = "hl2",
                AppID = 220
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Half-Life 2",
                ProperName = "Half-Life 2 Episode 1",
                SourceName = "episodic",
                Installed = false,
                Directory = "",
                Executable = "hl2",
                AppID = 380
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Half-Life 2",
                ProperName = "Half-Life 2 Episode 2",
                SourceName = "ep2",
                Installed = false,
                Directory = "",
                Executable = "hl2",
                AppID = 420
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Half-Life 2 Deathmatch",
                ProperName = "Half-Life 2 Deathmatch",
                SourceName = "hl2mp",
                Installed = false,
                Directory = "",
                Executable = "hl2",
                AppID = 320
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Half-Life 2 Update",
                ProperName = "Half-Life 2 Update",
                SourceName = "hl2",
                Installed = false,
                Directory = "",
                Executable = "hl2",
                AppID = 290930
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "insurgency2",
                ProperName = "Insurgency",
                SourceName = "insurgency",
                Installed = false,
                Directory = "",
                Executable = "insurgency_BE",
                AppID = 222880
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "left 4 dead",
                ProperName = "left 4 dead",
                SourceName = "left4dead",
                Installed = false,
                Directory = "",
                Executable = "left4dead",
                AppID = 500
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Left 4 Dead 2",
                ProperName = "Left 4 Dead 2",
                SourceName = "left4dead2",
                Installed = false,
                Directory = "",
                Executable = "left4dead2",
                AppID = 550
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "nmrih",
                ProperName = "No More Room In Hell",
                SourceName = "nmrih",
                Installed = false,
                Directory = "",
                AppID = 224260
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Nuclear Dawn",
                ProperName = "Nuclear Dawn",
                SourceName = "nucleardawn",
                Installed = false,
                Directory = "",
                AppID = 17710
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "pirates, vikings and knights ii",
                ProperName = "Pirates, Vikings, and Knights II",
                SourceName = "pvkii",
                Installed = false,
                Directory = "",
                AppID = 17570
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Portal",
                ProperName = "Portal",
                SourceName = "portal",
                Installed = false,
                Directory = "",
                AppID = 400
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Portal 2",
                ProperName = "Portal 2",
                SourceName = "portal2",
                Installed = false,
                Directory = "",
                AppID = 620
            });
            
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Source SDK Base 2013 Multiplayer",
                ProperName = "Source SDK Base 2013 Multiplayer",
                SourceName = "hl2mp",
                Installed = false,
                Directory = "",
                AppID = 243750
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Source SDK Base 2013 Singleplayer",
                ProperName = "Source SDK Base 2013 Singleplayer",
                SourceName = "hl2",
                Installed = false,
                Directory = "",
                AppID = 243730
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "SourceFilmmaker",
                ProperName = "Source Filmmaker",
                SourceName = "game",
                Installed = false,
                Directory = "",
                AppID = 1840
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Team Fortress 2",
                ProperName = "Team Fortress 2",
                SourceName = "tf",
                Installed = false,
                Directory = "",
                Executable = "hl2",
                AppID = 440
            });
           
            // Load in saved properties if still valid
            if (File.Exists(Properties.Settings.Default.mainSteamDir + "/Steam.exe"))
            {
                steam.MainSteamDir = Properties.Settings.Default.mainSteamDir;
                textSteamDirectory.Text = Properties.Settings.Default.mainSteamDir;
                FindSteamDirectories();
            }
            else
            {
                FindSteam();
            }
        }


        private void FindSteam()
        {
            steam.MainSteamDir = (Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Valve\\Steam\\") ?? Registry.LocalMachine.OpenSubKey("SOFTWARE\\Valve\\Steam\\"))?.GetValue("InstallPath").ToString();
            textSteamDirectory.Text = steam.MainSteamDir;

        }
        private void FindSteamDirectories()
        {
            if (File.Exists(steam.MainSteamDir + "/steamapps/libraryfolders.vdf"))
            {
                string[] lines = File.ReadAllLines(steam.MainSteamDir + "/steamapps/libraryfolders.vdf");
                if (lines.Count() != 5)
                {
                    //This means we have multiple directories
                    steam.AdditionalSteamDirectories.Clear();
                    int numberOfDirectories = lines.Count() - 5;
                    for (int i = 4; i < lines.Count() - 1; i++)    //start at line 5 and go to closing bracket
                    {
                        string temp = lines[i];
                        int finalPosition = temp.LastIndexOf("\"");
                        if (finalPosition != -1)
                        {
                            int startPosition = temp.LastIndexOf("\"", finalPosition - 1) + 1;    //Dont grab the same position or starting quote
                            temp = temp.Substring(startPosition, (finalPosition - startPosition)).Replace("\\\\", "\\");
                            if (Directory.Exists(temp))
                                steam.AdditionalSteamDirectories.Add(temp);
                        }
                    }
                    richTextBoxAdditionalSteamDirectory.Lines = steam.AdditionalSteamDirectories.ToArray();
                }
            }
            FindSourceModDirectories();
            CheckSourceModsInstalled();
            checkGamesInstalled();
        }


        private void FindSourceModDirectories()
        {
            if (Directory.Exists(steam.MainSteamDir + "/steamapps/sourcemods"))
            {
                DirectoryInfo dir = new DirectoryInfo(steam.MainSteamDir + "/steamapps/sourcemods");
                SourceModfolders.Clear();


                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    if (File.Exists(d.FullName + "/gameinfo.txt"))
                        SourceModfolders.Add(d);


                }

            }


        }

        private void CheckSourceModsInstalled()
        {
            foreach (var item in SourceModfolders)
            {
                listOfSourceGames.Add(new SourceGame
                {
                    SteamName = item.Name,
                    ProperName = item.Name,
                    SourceName = item.Name,
                    Installed = false,
                    Directory = item.FullName,
                    Executable = "hl2",
                    Mod = true

                });
            }
        }
        private void checkGamesInstalled()
        {
            foreach (SourceGame game in listOfSourceGames)
            {
                if (game.Mod)
                {
                    if (Directory.Exists(steam.MainSteamDir + "\\steamapps\\sourcemods\\" + game.SteamName))
                    {

                        string[] lines = File.ReadAllLines(steam.MainSteamDir + "\\steamapps\\sourcemods\\" + game.SteamName + "\\gameinfo.txt");
                        if (lines.Count() != 1)
                        {

                            for (int i = 1; i < lines.Count() - 1; i++)    //start at line 2 and go to closing bracket
                            {
                                string temp = lines[i];

                                if (temp.Contains("game") && !temp.Contains("//"))
                                {
                                    var temp2 = temp.Replace("\"", "");
                                    temp2 = temp2.Replace("game", "");
                                    temp2 = temp2.Replace("\t", "");
                                    temp2.Trim();
                                    game.ProperName = "Mod: " +temp2;
                                   
                                }
                                else
                                {
                                    game.ProperName = "Mod: " + game.SteamName;
                                }

                                if (temp.Contains("SteamAppId") || temp.Contains("steamappid"))
                                {
                                    var temp2 = temp.Replace("\"", "");
                                    temp2 = temp2.Replace("SteamAppId", "");
                                    temp2 = temp2.Replace("steamappid", "");
                                    temp2 = temp2.Replace("\t", "");
                                    List<string> splits;
                                    if (temp2.Contains("//"))
                                    {
                                        temp2 = temp2.Replace("//", "");
                                        splits = temp2.Split().ToList<string>();
                                       
                                        splits.RemoveAll(x => string.IsNullOrEmpty(x));
                                        foreach (var item in splits)
                                        {
                                            uint uintOut;
                                            if(uint.TryParse(item, out uintOut))
                                            {
                                                if (uintOut.ToString() == item)
                                                {
                                                    temp2 = item;
                                                    break;
                                                }
                                                    
                                                
                                            }
                                        }
                                    }
                                    temp2.Trim();
                                    game.AppID = uint.Parse(temp2);
                                    break;
                                }
                                


                            }
                        }
                        //game.Directory = steam.MainSteamDir + "\\steamapps\\sourcemods\\" + game.SteamName;
                        game.Mod = true;
                        game.Installed = true;
                    }
                }
                else 
                {
                    if (Directory.Exists(steam.MainSteamDir + "\\steamapps\\common\\" + game.SteamName))
                    {
                        game.Directory = steam.MainSteamDir + "\\steamapps\\common\\" + game.SteamName;
                        game.Installed = true;
                    }
                }
                
            }
            // Cycle through all additional directories
            foreach (string dir in steam.AdditionalSteamDirectories)
            {
                foreach (SourceGame game in listOfSourceGames)
                {
                    if (Directory.Exists(dir + "\\steamapps\\common\\" + game.SteamName))
                    {
                        game.Directory = dir + "\\steamapps\\common\\" + game.SteamName;
                        game.Installed = true;
                    }
                }
            }
            updateGameDropDown();
            UpdateDebugInfo();
        }

        private void UpdateDebugInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (SourceGame game in listOfSourceGames)
            {
                sb.Append("SteamName: ");
                sb.AppendLine(game.SteamName);
                sb.Append("ProperName: ");
                sb.AppendLine(game.ProperName);
                sb.Append("SourceName: ");
                sb.AppendLine(game.SourceName);
                sb.Append("Installed: ");
               
                sb.AppendLine(game.Installed.ToString());
                if (game.Installed)
                {
                    sb.Append("Directory: ");
                    sb.AppendLine(game.Directory);
                }
                sb.Append("Mod: ");
                sb.AppendLine(game.Mod.ToString());
                sb.Append("Executable: ");
                sb.AppendLine(game.Executable);

                sb.Append("AppID: ");
                sb.AppendLine(game.AppID.ToString());
                sb.AppendLine("\n");
            }
            richTextBoxSourceGameDebug.Text = sb.ToString();
        }

        private void updateGameDropDown()
        {
            // Clear the combobox and disable buttons
            comboBoxGames.Items.Clear();
            hammer_btn.Enabled = false;
            modelViewer_btn.Enabled = false;
            button_gmodConfig.Enabled = false;
            button_hammerConfig.Enabled = false;
            foreach (SourceGame game in listOfSourceGames)
            {
                if (game.Installed)
                {
                    comboBoxGames.Items.Add(game.ProperName);
                    button_hammerConfig.Enabled = true;
                }
            }
            if (comboBoxGames.Items.Count > 0)
            {
                comboBoxGames.SelectedIndex = 0;
                // Reenable
                hammer_btn.Enabled = true;
                modelViewer_btn.Enabled = true;
            }
            if(comboBoxGames.Items.Contains("Garry's Mod"))
            {
                button_gmodConfig.Enabled = true;
            }

        }

        private void buttonHammer_Click(object sender, EventArgs e)
        {
            string gameName = comboBoxGames.GetItemText(comboBoxGames.SelectedItem);
            SourceGame getgame = listOfSourceGames.First(item => item.ProperName == gameName);
            string directory = getgame.Directory;//listOfSourceGames.First(item => item.ProperName == gameName).Directory;
            string Moddirectory = getgame.Directory;
            uint AppIDToUse = getgame.AppID;
            bool isMod = getgame.Mod;
            SourceGame ModBaseGame;

            if (isMod)
            {
                ModBaseGame = listOfSourceGames.First(item => item.AppID == AppIDToUse);
                directory = ModBaseGame.Directory;
                AppIDToUse = ModBaseGame.AppID;
            }
            if (!File.Exists(directory + "\\bin\\hammer.exe"))
            {
                switch (AppIDToUse)
                {
                    
                    case 630://"Alien Swarm":
                    case 563560://"Alien Swarm: Reactive Drop":
                    case 730://"Counter-Strike Global Offensive":
                    case 70000://"Dino D-Day":
                    case 550://"Left 4 Dead 2":
                    case 17710://"Nuclear Dawn":
                    case 620://"Portal 2":

                        MessageBox.Show(String.Format("No Hammer install could be found at {0}\\bin\\hammer.exe \n\n Make sure you have installed it's authoring tools in Steam!", directory), "ERROR 002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    case 224260: // "No More Room In Hell":
                        if (!File.Exists(directory + "\\sdk\\bin\\hammer.exe"))
                        {
                            MessageBox.Show(String.Format("No Hammer install could be found at {0}\\sdk\\bin\\hammer.exe", directory), "ERROR 002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    case 17570: // "Pirates, Vikings, and Knights II":
                        if (!File.Exists(directory + "\\sdkbase_pvkii\\bin\\hammer.exe"))
                        {
                            MessageBox.Show(String.Format("No Hammer install could be found at {0}\\sdkbase_pvkii\\bin\\hammer.exe", directory), "ERROR 002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    case 1840: // "Source Filmmaker":
                        if (!File.Exists(directory + "\\game\\bin\\hammer.exe"))
                        {
                            MessageBox.Show(String.Format("No Hammer install could be found at {0}\\game\\bin\\hammer.exe", directory), "ERROR 002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    case 1224600: // "G String":
                        if (!File.Exists(directory + "\\bin\\hammer.exe"))
                        {
                            MessageBox.Show(String.Format("No Hammer install could be found at {0}\\game\\bin\\hammer.exe \n\n G String doesn't have it!", directory), "ERROR 002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    case 290930: // "Half-Life 2 Update":
                        if (!File.Exists(directory + "\\bin\\hammer.exe"))
                        {
                            MessageBox.Show(String.Format("No Hammer install could be found at {0}\\game\\bin\\hammer.exe \n\n Half-Life 2 Update doesn't have it!", directory), "ERROR 002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    case 225600: // "Blade Symphony":
                        if (!File.Exists(directory + "\\bin\\win32\\hammer.exe"))
                        {
                            MessageBox.Show(String.Format("No Hammer install could be found at {0}\\bin\\win32\\hammer.exe \n\n Make sure you have installed it's authoring tools in Steam!", directory), "ERROR 002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    default:
                        MessageBox.Show(String.Format("No Hammer install could be found at {0}\\bin\\hammer.exe", directory), "ERROR 002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }
                /*switch (gameName)
                {
                    case "Alien Swarm":
                    case "Alien Swarm: Reactive Drop":
                    case "Counter-Strike Global Offensive":
                    case "Dino D-Day":
                    case "Left 4 Dead 2":
                    case "Nuclear Dawn":
                    case "Portal 2":
                        MessageBox.Show(String.Format("No Hammer install could be found at {0}\\bin\\hammer.exe \n\n Make sure you have installed it's authoring tools in Steam!", directory), "ERROR 002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    case "No More Room In Hell":
                        if (!File.Exists(directory + "\\sdk\\bin\\hammer.exe"))
                        {
                            MessageBox.Show(String.Format("No Hammer install could be found at {0}\\sdk\\bin\\hammer.exe", directory), "ERROR 002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    case "Pirates, Vikings, and Knights II":
                        if (!File.Exists(directory + "\\sdkbase_pvkii\\bin\\hammer.exe"))
                        {
                            MessageBox.Show(String.Format("No Hammer install could be found at {0}\\sdkbase_pvkii\\bin\\hammer.exe", directory), "ERROR 002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    case "Source Filmmaker":
                        if (!File.Exists(directory + "\\game\\bin\\hammer.exe"))
                        {
                            MessageBox.Show(String.Format("No Hammer install could be found at {0}\\game\\bin\\hammer.exe", directory), "ERROR 002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    case "G String":
                        if (!File.Exists(directory + "\\bin\\hammer.exe"))
                        {
                            MessageBox.Show(String.Format("No Hammer install could be found at {0}\\game\\bin\\hammer.exe \n\n G String doesn't have it!", directory), "ERROR 002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    case "Half-Life 2 Update":
                        if (!File.Exists(directory + "\\bin\\hammer.exe"))
                        {
                            MessageBox.Show(String.Format("No Hammer install could be found at {0}\\game\\bin\\hammer.exe \n\n Half-Life 2 Update doesn't have it!", directory), "ERROR 002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    case "Blade Symphony":
                        if (!File.Exists(directory + "\\bin\\win32\\hammer.exe"))
                        {
                            MessageBox.Show(String.Format("No Hammer install could be found at {0}\\bin\\win32\\hammer.exe \n\n Make sure you have installed it's authoring tools in Steam!", directory), "ERROR 002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    default:
                        MessageBox.Show(String.Format("No Hammer install could be found at {0}\\bin\\hammer.exe", directory), "ERROR 002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }*/

            }
            Process hammer = new Process();
            hammer.StartInfo.FileName = "CMD.exe";
            if (AppIDToUse == 224260/*"No More Room In Hell"*/)
                hammer.StartInfo.Arguments = "/c cd /d " + directory + "\\sdk\\bin && start \"\" hammer.exe -nop4";
            else if (AppIDToUse == 17570/*"Pirates, Vikings, and Knights II"*/)
                hammer.StartInfo.Arguments = "/c cd /d " + directory + "\\sdkbase_pvkii\\bin && start \"\" hammer.exe -nop4";
            else if (AppIDToUse == 1840/*"Source Filmmaker"*/)
                hammer.StartInfo.Arguments = "/c cd /d " + directory + "\\game\\bin && start \"\" hammer.exe -nop4";
            else if (AppIDToUse == 225600/*"Blade Symphony"*/)
                hammer.StartInfo.Arguments = "/c cd /d " + directory + "\\bin\\win32 && start \"\" hammer.exe -nop4";
            else
                hammer.StartInfo.Arguments = "/c cd /d " + directory + "\\bin && start \"\" hammer.exe -nop4";
            hammer.Start();
        }

        private void ButtonModelViewer_Click(object sender, EventArgs e)
        {
            string gameName = comboBoxGames.GetItemText(comboBoxGames.SelectedItem);
            //string directory = listOfSourceGames.First(item => item.ProperName == gameName).Directory;
            string sourcename = listOfSourceGames.First(item => item.ProperName == gameName).SourceName;

            SourceGame getgame = listOfSourceGames.First(item => item.ProperName == gameName);
            string directory = getgame.Directory;//listOfSourceGames.First(item => item.ProperName == gameName).Directory;
            string Moddirectory = getgame.Directory;
            uint AppIDToUse = getgame.AppID;
            bool isMod = getgame.Mod;
            SourceGame ModBaseGame;

            if (isMod)
            {
                ModBaseGame = listOfSourceGames.First(item => item.AppID == AppIDToUse);
                directory = ModBaseGame.Directory;
                AppIDToUse = ModBaseGame.AppID;
            }
            if (!File.Exists(directory + "\\bin\\hlmv.exe"))
            {
                switch (AppIDToUse)
                {
                    case 630://"Alien Swarm":
                    case 563560://"Alien Swarm: Reactive Drop":
                    case 730://"Counter-Strike Global Offensive":
                    case 70000://"Dino D-Day":
                    case 550://"Left 4 Dead 2":
                    case 17710://"Nuclear Dawn":
                    case 620://"Portal 2":
                        MessageBox.Show(String.Format("No Hammer install could be found at {0}\\bin\\hlmv.exe \n\n Make sure you have installed it's authoring tools in Steam!", directory), "ERROR 003", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    case 224260: // "No More Room In Hell":
                        if (!File.Exists(directory + "\\sdk\\bin\\hlmv.exe"))
                        {
                            MessageBox.Show(String.Format("No Model Viewer install could be found at {0}\\sdk\\bin\\hlmv.exe", directory), "ERROR 003", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    case 17570: // "Pirates, Vikings, and Knights II":
                        if (!File.Exists(directory + "\\sdkbase_pvkii\\bin\\hlmv.exe"))
                        {
                            MessageBox.Show(String.Format("No Model Viewer install could be found at {0}\\sdkbase_pvkii\\bin\\hlmv.exe", directory), "ERROR 003", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    case 1840: // "Source Filmmaker":
                        if (!File.Exists(directory + "\\game\\bin\\hlmv.exe"))
                        {
                            MessageBox.Show(String.Format("No Model Viewer install could be found at {0}\\game\\bin\\hlmv.exe", directory), "ERROR 003", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    case 1224600: // "G String":
                        if (!File.Exists(directory + "\\bin\\hlmv.exe"))
                        {
                            MessageBox.Show(String.Format("No Model Viewer install could be found at {0}\\game\\bin\\hlmv.exe \n\n Thats ok though we will use 2013 MP or 2013 SP. ", directory), "ERROR 003", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            
                        }
                        break;
                    case 290930: // "Half-Life 2 Update":
                        if (!File.Exists(directory + "\\bin\\hlmv.exe"))
                        {
                            MessageBox.Show(String.Format("No Model Viewer install could be found at {0}\\game\\bin\\hlmv.exe \n\n Thats ok though we will use 2013 MP or 2013 SP. ", directory), "ERROR 003", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        break;
                    case 225600: // "Blade Symphony":
                        if (!File.Exists(directory + "\\bin\\win32\\hlmv.exe"))
                        {
                            MessageBox.Show(String.Format("No Model Viewer install could be found at {0}\\win32\\bin\\hlmv.exe \n\n Make sure you have installed it's authoring tools in Steam!", directory), "ERROR 003", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        break;
                    default:
                        MessageBox.Show(String.Format("No Model Viewer install could be found at {0}\\bin\\hlmv.exe", directory), "ERROR 003", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }
            }

            Process modelviewer = new Process();
            modelviewer.StartInfo.FileName = "CMD.exe";
            if (AppIDToUse == 224260/*"No More Room In Hell"*/)
            {
                if (isMod)
                {
                    modelviewer.StartInfo.Arguments = "/c cd /d " + directory + "\\sdk\\bin && start \"\" hlmv.exe -game \"" + Moddirectory + "\"";
                }
                else
                {
                    modelviewer.StartInfo.Arguments = "/c cd /d " + directory + "\\sdk\\bin && start \"\" hlmv.exe -game \"" + directory + "\\" + sourcename + "\"";
                }
            }
            else if (AppIDToUse == 17570/*"Pirates, Vikings, and Knights II"*/)
            {
                if (isMod)
                {
                    modelviewer.StartInfo.Arguments = "/c cd /d " + directory + "\\sdkbase_pvkii\\bin && start \"\" hlmv.exe -game \"" + Moddirectory + "\"";
                }
                else
                {
                    modelviewer.StartInfo.Arguments = "/c cd /d " + directory + "\\sdkbase_pvkii\\bin && start \"\" hlmv.exe -game \"" + directory + "\\" + sourcename + "\"";
                }
            }
            else if (AppIDToUse == 1840/*"Source Filmmaker"*/)
            {
                if (isMod)
                {
                    modelviewer.StartInfo.Arguments = "/c cd /d " + directory + "\\game\\bin && start \"\" hlmv.exe -game \"" + Moddirectory + "\"";
                }
                else
                {
                    modelviewer.StartInfo.Arguments = "/c cd /d " + directory + "\\game\\bin && start \"\" hlmv.exe -game \"" + directory + "\\" + sourcename + "\\usermod" + "\"";
                }
                
            }

            else if (AppIDToUse == 1224600/* "G String"*/)
            {

                if (comboBoxGames.Items.Contains("Source SDK Base 2013 Singleplayer"))
                {
                    string mpdirectory = listOfSourceGames.First(item => item.ProperName == "Source SDK Base 2013 Singleplayer").Directory;
                    if (isMod)
                    {
                        modelviewer.StartInfo.Arguments = "/c cd /d " + "\"" + mpdirectory + "\\bin" + "\"" + " && start \"\" hlmv.exe -game \"" + Moddirectory + "\"";
                    }
                    else
                    {
                        modelviewer.StartInfo.Arguments = "/c cd /d " + "\"" + mpdirectory + "\\bin" + "\"" + " && start \"\" hlmv.exe -game \"" + directory + "\\" + sourcename + "\"";
                    }
                }
                else if (comboBoxGames.Items.Contains("Source SDK Base 2013 Multiplayer"))
                {
                    string mpdirectory = listOfSourceGames.First(item => item.ProperName == "Source SDK Base 2013 Multiplayer").Directory;
                    if (isMod)
                    {
                        modelviewer.StartInfo.Arguments = "/c cd /d " + "\"" + mpdirectory + "\\bin" + "\"" + " && start \"\" hlmv.exe -game \"" + Moddirectory + "\"";
                    }
                    else
                    {
                        modelviewer.StartInfo.Arguments = "/c cd /d " + "\"" + mpdirectory + "\\bin" + "\"" + " && start \"\" hlmv.exe -game \"" + directory + "\\" + sourcename + "\"";
                    }
                    
                }
                else
                {
                    MessageBox.Show(String.Format("2013 MP or 2013 SP wasn't found please install one of these. ", directory), "ERROR 005", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (AppIDToUse == 290930/*"Half-Life 2 Update"*/)
            {

                if (comboBoxGames.Items.Contains("Source SDK Base 2013 Singleplayer"))
                {
                    string mpdirectory = listOfSourceGames.First(item => item.ProperName == "Source SDK Base 2013 Singleplayer").Directory;
                    if (isMod)
                    {
                        modelviewer.StartInfo.Arguments = "/c cd /d " + "\"" + mpdirectory + "\\bin" + "\"" + " && start \"\" hlmv.exe -game \"" + Moddirectory + "\"";
                    }
                    else
                    {
                        modelviewer.StartInfo.Arguments = "/c cd /d " + "\"" + mpdirectory + "\\bin" + "\"" + " && start \"\" hlmv.exe -game \"" + directory + "\\" + sourcename + "\"";
                    }
                    
                }
                else if (comboBoxGames.Items.Contains("Source SDK Base 2013 Multiplayer"))
                {
                    string mpdirectory = listOfSourceGames.First(item => item.ProperName == "Source SDK Base 2013 Multiplayer").Directory;
                    if (isMod)
                    {
                        modelviewer.StartInfo.Arguments = "/c cd /d " + "\"" + mpdirectory + "\\bin" + "\"" + " && start \"\" hlmv.exe -game \"" + Moddirectory + "\"";
                    }
                    else 
                    {
                        modelviewer.StartInfo.Arguments = "/c cd /d " + "\"" + mpdirectory + "\\bin" + "\"" + " && start \"\" hlmv.exe -game \"" + directory + "\\" + sourcename + "\"";
                    }
                    
                }
                else
                {
                    MessageBox.Show(String.Format("2013 MP or 2013 SP wasn't found please install one of these. ", directory), "ERROR 005", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (AppIDToUse == 225600/*"Blade Symphony"*/)
            {
                if (isMod)
                {
                    modelviewer.StartInfo.Arguments = "/c cd /d " + directory + "\\bin\\win32 && start \"\" hlmv.exe -game \"" + Moddirectory + "\"";
                }
                else 
                {
                    modelviewer.StartInfo.Arguments = "/c cd /d " + directory + "\\bin\\win32 && start \"\" hlmv.exe -game \"" + directory + "\\" + sourcename + "\"";
                }
            } 
            else
            {
                if (isMod)
                {
                    modelviewer.StartInfo.Arguments = "/c cd /d " + directory + "\\bin && start \"\" hlmv.exe -game \"" + Moddirectory + "\"";
                }
                else 
                {
                    modelviewer.StartInfo.Arguments = "/c cd /d " + directory + "\\bin && start \"\" hlmv.exe -game \"" + directory + "\\" + sourcename + "\"";
                }
                
            }
                
            modelviewer.Start();
        }

        private void button_gmodConfig_Click(object sender, EventArgs e)
        {
            GarrysModConfigForm gmodConfigForm = new GarrysModConfigForm();
            gmodConfigForm.ShowDialog();
        }

        private void resetSettings_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to reset settings back to default?", "WARNING", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                hammer_btn.Enabled = false;
                modelViewer_btn.Enabled = false;
                textSteamDirectory.Clear();
                richTextBoxAdditionalSteamDirectory.Clear();
                richTextBoxSourceGameDebug.Clear();
                button_gmodConfig.Enabled = false;
                button_hammerConfig.Enabled = false;
                FindSteam();
                foreach (SourceGame game in listOfSourceGames)
                {
                    game.Directory = "";
                    game.Installed = false;
                }
                comboBoxGames.Items.Clear();
            }
        }

        private void button_ToolMode_Click(object sender, EventArgs e)
        {
            string gameName = comboBoxGames.GetItemText(comboBoxGames.SelectedItem);
            string directory = listOfSourceGames.First(item => item.ProperName == gameName).Directory;
            string sourcename = listOfSourceGames.First(item => item.ProperName == gameName).SourceName;
            string executable = listOfSourceGames.First(item => item.ProperName == gameName).Executable;
            if (!File.Exists(directory + "\\" + executable +".exe"))
            {
                switch (gameName)
                {
                    case "Alien Swarm":
                    case "Alien Swarm: Reactive Drop":
                    case "Counter-Strike Global Offensive":
                    case "Dino D-Day":
                    case "Left 4 Dead 2":
                    case "Nuclear Dawn":
                    case "Portal 2":
                        MessageBox.Show(String.Format("Executable could not be found at {0}\\{1} \n\n Make sure you have installed it in Steam!", directory, executable + ".exe"), "ERROR 006", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    /*case "No More Room In Hell":
                        if (!File.Exists(directory + "\\sdk\\bin\\hlmv.exe"))
                        {
                            MessageBox.Show(String.Format("No Model Viewer install could be found at {0}\\sdk\\bin\\hlmv.exe", directory), "ERROR 003", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    case "Pirates, Vikings, and Knights II":
                        if (!File.Exists(directory + "\\sdkbase_pvkii\\bin\\hlmv.exe"))
                        {
                            MessageBox.Show(String.Format("No Model Viewer install could be found at {0}\\sdkbase_pvkii\\bin\\hlmv.exe", directory), "ERROR 003", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    case "Source Filmmaker":
                        if (!File.Exists(directory + "\\game\\bin\\hlmv.exe"))
                        {
                            MessageBox.Show(String.Format("No Model Viewer install could be found at {0}\\game\\bin\\hlmv.exe", directory), "ERROR 003", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    case "G String":
                        if (!File.Exists(directory + "\\bin\\hlmv.exe"))
                        {
                            MessageBox.Show(String.Format("No Model Viewer install could be found at {0}\\game\\bin\\hlmv.exe \n\n Thats ok though we will use 2013 MP or 2013 SP. ", directory), "ERROR 003", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        break;
                    case "Half-Life 2 Update":
                        if (!File.Exists(directory + "\\bin\\hlmv.exe"))
                        {
                            MessageBox.Show(String.Format("No Model Viewer install could be found at {0}\\game\\bin\\hlmv.exe \n\n Thats ok though we will use 2013 MP or 2013 SP. ", directory), "ERROR 003", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        break;
                    case "Blade Symphony":
                        if (!File.Exists(directory + "\\bin\\win32\\hlmv.exe"))
                        {
                            MessageBox.Show(String.Format("No Model Viewer install could be found at {0}\\win32\\bin\\hlmv.exe \n\n Make sure you have installed it's authoring tools in Steam!", directory), "ERROR 003", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        break;*/
                    default:
                        MessageBox.Show(String.Format("Executable could not be found at {0}\\{1} \n\n Make sure you have installed it in Steam!", directory, executable + ".exe"), "ERROR 006", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }
            }

            Process modelviewer = new Process();
            modelviewer.StartInfo.FileName = "CMD.exe";
            if (gameName == "No More Room In Hell")
                modelviewer.StartInfo.Arguments = "/c cd /d " + directory + "\\sdk\\bin && start \"\" hlmv.exe -game \"" + directory + "\\" + sourcename + "\"";
            else if (gameName == "Pirates, Vikings, and Knights II")
                modelviewer.StartInfo.Arguments = "/c cd /d " + directory + "\\sdkbase_pvkii\\bin && start \"\" hlmv.exe -game \"" + directory + "\\" + sourcename + "\"";
            else if (gameName == "Source Filmmaker")
            {
                modelviewer.StartInfo.Arguments = "/c cd /d " + directory + "\\game\\bin && start \"\" hlmv.exe -game \"" + directory + "\\" + sourcename + "\\usermod" + "\"";
            }
            else if (gameName == "G String")
            {

                if (comboBoxGames.Items.Contains("Source SDK Base 2013 Singleplayer"))
                {
                    string mpdirectory = listOfSourceGames.First(item => item.ProperName == "Source SDK Base 2013 Singleplayer").Directory;
                    modelviewer.StartInfo.Arguments = "/c cd /d " + "\"" + mpdirectory + "\\bin" + "\"" + " && start \"\" hlmv.exe -game \"" + directory + "\\" + sourcename + "\"";
                }
                else if (comboBoxGames.Items.Contains("Source SDK Base 2013 Multiplayer"))
                {
                    string mpdirectory = listOfSourceGames.First(item => item.ProperName == "Source SDK Base 2013 Multiplayer").Directory;
                    modelviewer.StartInfo.Arguments = "/c cd /d " + "\"" + mpdirectory + "\\bin" + "\"" + " && start \"\" hlmv.exe -game \"" + directory + "\\" + sourcename + "\"";
                }
                else
                {
                    MessageBox.Show(String.Format("2013 MP or 2013 SP wasn't found please install one of these. ", directory), "ERROR 005", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (gameName == "Half-Life 2 Update")
            {

                if (comboBoxGames.Items.Contains("Source SDK Base 2013 Singleplayer"))
                {
                    string mpdirectory = listOfSourceGames.First(item => item.ProperName == "Source SDK Base 2013 Singleplayer").Directory;
                    modelviewer.StartInfo.Arguments = "/c cd /d " + "\"" + mpdirectory + "\\bin" + "\"" + " && start \"\" hlmv.exe -game \"" + directory + "\\" + sourcename + "\"";
                }
                else if (comboBoxGames.Items.Contains("Source SDK Base 2013 Multiplayer"))
                {
                    string mpdirectory = listOfSourceGames.First(item => item.ProperName == "Source SDK Base 2013 Multiplayer").Directory;
                    modelviewer.StartInfo.Arguments = "/c cd /d " + "\"" + mpdirectory + "\\bin" + "\"" + " && start \"\" hlmv.exe -game \"" + directory + "\\" + sourcename + "\"";
                }
                else
                {
                    MessageBox.Show(String.Format("2013 MP or 2013 SP wasn't found please install one of these. ", directory), "ERROR 005", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (gameName == "Blade Symphony")
                modelviewer.StartInfo.Arguments = "/c cd /d " + directory + "\\bin\\win32 && start \"\" hlmv.exe -game \"" + directory + "\\" + sourcename + "\"";
            else
                modelviewer.StartInfo.Arguments = @"/c cd /d " + "\"" + directory + "\"" + "&& start \"\" " + executable + ".exe " + "-tools -nop4 -novid -game "  + "\"" + directory + "\\" + sourcename + "\"";
            modelviewer.Start();
        }

        private void button_Content_Click(object sender, EventArgs e)
        {
            string gameName = comboBoxGames.GetItemText(comboBoxGames.SelectedItem);
            string directory = listOfSourceGames.First(item => item.ProperName == gameName).Directory;
            string sourcename = listOfSourceGames.First(item => item.ProperName == gameName).SourceName;
            bool isMod = listOfSourceGames.First(item => item.ProperName == gameName).Mod;

            if (isMod)
            {
                Process.Start("explorer.exe", "\"" + directory + "\"");
            }
            else
            {
                Process.Start("explorer.exe", "\"" + directory + "\\" + sourcename + "\"");
            }
           

        }

        private void button_Vpacker_Click(object sender, EventArgs e)
        {

        }

        private void button_hammerConfig_Click(object sender, EventArgs e)
        {
            HammerConfigForm hammerConfigForm = new HammerConfigForm();
            hammerConfigForm.ShowDialog();
        }

        private async void button_TestWorkShop_Click(object sender, EventArgs e)
        {
            SteamClient.Shutdown();

            string gameName = comboBoxGames.GetItemText(comboBoxGames.SelectedItem);
            uint appid = listOfSourceGames.First(item => item.ProperName == gameName).AppID;

            await IntGameID(appid, true);
           


            var steamValid = SteamClient.IsValid;
            if (steamValid)
            {
                var playername = SteamClient.Name;
                var playersteamid = SteamClient.SteamId;

                StringBuilder sb = new StringBuilder();
                //string text = "";
                sb.AppendFormat(string.Format($"Is Steam Valid:  {steamValid.ToString()}"));
                sb.AppendLine("\n");
                sb.AppendFormat(string.Format($"Your Name is:  {playername}"));
                sb.AppendLine("\n");
                sb.AppendFormat(string.Format($"Your SteamID is:  {playersteamid}"));


                sb.AppendLine("\n");
                richTextBoxSourceGameDebug.Text += sb.ToString();

               
                var q = Query.Items
                .WhereSearchText(textBox_WRKS_search.Text.Trim())
                .RankedByTextSearch();

                var page = await q.GetPageAsync(1);

                if (page.HasValue)
                {

                    //StringBuilder sb = new StringBuilder();
                    //string text = "";
                    sb.AppendFormat(string.Format($"This page has {page.Value.ResultCount}"));
                    sb.AppendLine("\n");



                    foreach (Item entry in page.Value.Entries)
                    {

                        sb.AppendFormat(string.Format($"Entry: {entry.Title}"));
                        sb.AppendLine("\n");
                    }
                    sb.AppendLine("\n");
                    richTextBox_WRK_Results.Text += sb.ToString();

                    SteamClient.Shutdown();
                }
                
            }
           
        }

        private void MainMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SteamClient.Shutdown();
        }

        public Task IntGameID(uint ID, bool async = true)
        {
            return Task.Run(() =>
            {
                
                try
                {
                    SteamClient.Init(ID, async);
                }
                catch (System.Exception e_)
                {
                    MessageBox.Show("Steam isn't running, couldn't find Steam, AppId is ureleased or Don't own AppId.", "ERROR 007", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }



            });
        }
        public static void SteamInt()
        {
            // this bit of logic determines if we're 64 or 32-bit, and loads
            // the appropriate copy of steam_api.dll
            string fileName = Environment.Is64BitProcess ? "redistributable_bin\\win64\\steam_api64.dll" : "redistributable_bin\\steam_api.dll";

            fileName = Path.GetFullPath(fileName);

            LoadLibrary(fileName);
        }
    }


   
}

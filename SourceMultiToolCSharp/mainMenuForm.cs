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


namespace SourceMultiToolCSharp
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        public static Steam steam = new Steam();
        public static List<SourceGame> listOfSourceGames = new List<SourceGame>();
        public static string version = "3.0.0";

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

            versionLabel.Text += version;
            // Add Source Games
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Alien Swarm",
                ProperName = "Alien Swarm",
                SourceName = "swarm",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Alien Swarm Reactive Drop",
                ProperName = "Alien Swarm: Reactive Drop",
                SourceName = "reactivedrop",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Contagion",
                ProperName = "Contagion",
                SourceName = "contagion",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Counter-Strike Global Offensive",
                ProperName = "Counter-Strike Global Offensive",
                SourceName = "csgo",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Counter-Strike Source",
                ProperName = "Counter-Strike Source",
                SourceName = "cstrike",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Day of Defeat Source",
                ProperName = "Day of Defeat Source",
                SourceName = "dod",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "dayofinfamy",
                ProperName = "Day of Infamy",
                SourceName = "doi",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Dino D-Day",
                ProperName = "Dino D-Day",
                SourceName = "dinodday",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Double Action",
                ProperName = "Double Action",
                SourceName = "dab",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "FIREFIGHT RELOADED",
                ProperName = "FIREFIGHT RELOADED",
                SourceName = "firefightreloaded",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Empires",
                ProperName = "Empires",
                SourceName = "empires",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "G String",
                ProperName = "G String",
                SourceName = "gstringv2",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "GarrysMod",
                ProperName = "Garry's Mod",
                SourceName = "garrysmod",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Half-Life 1 Source Deathmatch",
                ProperName = "Half-Life Source Deathmatch",
                SourceName = "hl1mp",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Half-Life 2",
                ProperName = "Half-Life 2",
                SourceName = "hl2",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Half-Life 2",
                ProperName = "Half-Life 2 Episode 1",
                SourceName = "episodic",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Half-Life 2",
                ProperName = "Half-Life 2 Episode 2",
                SourceName = "ep2",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Half-Life 2 Deathmatch",
                ProperName = "Half-Life 2 Deathmatch",
                SourceName = "hl2mp",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Half-Life 2 Update",
                ProperName = "Half-Life 2 Update",
                SourceName = "hl2",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "insurgency2",
                ProperName = "Insurgency",
                SourceName = "insurgency",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Left 4 Dead 2",
                ProperName = "Left 4 Dead 2",
                SourceName = "left4dead2",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "nmrih",
                ProperName = "No More Room In Hell",
                SourceName = "nmrih",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Nuclear Dawn",
                ProperName = "Nuclear Dawn",
                SourceName = "nucleardawn",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "pirates, vikings and knights ii",
                ProperName = "Pirates, Vikings, and Knights II",
                SourceName = "pvkii",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Portal",
                ProperName = "Portal",
                SourceName = "portal",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Portal 2",
                ProperName = "Portal 2",
                SourceName = "portal2",
                Installed = false,
                Directory = ""
            });
            
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Source SDK Base 2013 Multiplayer",
                ProperName = "Source SDK Base 2013 Multiplayer",
                SourceName = "hl2mp",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Source SDK Base 2013 Singleplayer",
                ProperName = "Source SDK Base 2013 Singleplayer",
                SourceName = "hl2",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "SourceFilmmaker",
                ProperName = "Source Filmmaker",
                SourceName = "game",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Team Fortress 2",
                ProperName = "Team Fortress 2",
                SourceName = "tf",
                Installed = false,
                Directory = ""
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
            checkGamesInstalled();
        }

        private void checkGamesInstalled()
        {
            foreach (SourceGame game in listOfSourceGames)
            {
                if (Directory.Exists(steam.MainSteamDir + "\\steamapps\\common\\" + game.SteamName))
                {
                    game.Directory = steam.MainSteamDir + "\\steamapps\\common\\" + game.SteamName;
                    game.Installed = true;
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
            foreach (SourceGame game in listOfSourceGames)
            {
                if (game.Installed)
                {
                    comboBoxGames.Items.Add(game.ProperName);
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
            string directory = listOfSourceGames.First(item => item.ProperName == gameName).Directory;
            if (!File.Exists(directory + "\\bin\\hammer.exe"))
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
                    default:
                        MessageBox.Show(String.Format("No Hammer install could be found at {0}\\bin\\hammer.exe", directory), "ERROR 002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

            }
            Process hammer = new Process();
            hammer.StartInfo.FileName = "CMD.exe";
            if (gameName == "No More Room In Hell")
                hammer.StartInfo.Arguments = "/c cd /d " + directory + "\\sdk\\bin && start \"\" hammer.exe -nop4";
            else if (gameName == "Pirates, Vikings, and Knights II")
                hammer.StartInfo.Arguments = "/c cd /d " + directory + "\\sdkbase_pvkii\\bin && start \"\" hammer.exe -nop4";
            else if (gameName == "Source Filmmaker")
                hammer.StartInfo.Arguments = "/c cd /d " + directory + "\\game\\bin && start \"\" hammer.exe -nop4";
            else
                hammer.StartInfo.Arguments = "/c cd /d " + directory + "\\bin && start \"\" hammer.exe -nop4";
            hammer.Start();
        }

        private void ButtonModelViewer_Click(object sender, EventArgs e)
        {
            string gameName = comboBoxGames.GetItemText(comboBoxGames.SelectedItem);
            string directory = listOfSourceGames.First(item => item.ProperName == gameName).Directory;
            string sourcename = listOfSourceGames.First(item => item.ProperName == gameName).SourceName;
            if (!File.Exists(directory + "\\bin\\hlmv.exe"))
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
                        MessageBox.Show(String.Format("No Hammer install could be found at {0}\\bin\\hlmv.exe \n\n Make sure you have installed it's authoring tools in Steam!", directory), "ERROR 003", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    case "No More Room In Hell":
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
                    default:
                        MessageBox.Show(String.Format("No Model Viewer install could be found at {0}\\bin\\hlmv.exe", directory), "ERROR 003", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                modelviewer.StartInfo.Arguments = "/c cd /d " + directory + "\\game\\bin && start \"\" hlmv.exe -game \"" + directory + "\\" + sourcename + "\\usermod" + "\"";
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
            else
                modelviewer.StartInfo.Arguments = "/c cd /d " + directory + "\\bin && start \"\" hlmv.exe -game \""+directory+"\\"+sourcename+"\"";
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
                foreach (SourceGame game in listOfSourceGames)
                {
                    game.Directory = "";
                    game.Installed = false;
                }
                comboBoxGames.Items.Clear();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SourceMultiToolCSharp
{
    public partial class HammerConfigForm : Form
    {
        public HammerConfigForm()
        {
            InitializeComponent();
        }
        Dictionary<string,string> gmodAddons = new Dictionary<string,string>();
        Dictionary<string, string> FGDS = new Dictionary<string, string>();
        string gmodDirectory = "";
        string modDirectory = "";
        string cwDirectory = Directory.GetCurrentDirectory().ToString();
        
        private void HammerConfigForm_Shown(object sender, EventArgs e)
        {
            // Populate our menu with the games they have
            foreach (SourceGame game in MainMenuForm.listOfSourceGames)
            {
                if (game.Installed)
                {
                    
                    if (game.Mod)
                    {

                        string modName = game.ProperName;

                        listbox_HContent.Items.Add(modName);
                        
                    }
                    else
                    {
                        listbox_HContent.Items.Add(game.ProperName);
                    }
                    string FGDDirectory = game.Directory + "\\bin\\";  
                    //string FGDDirectory = cwDirectory + "\\FGD\\";
                    if (Directory.Exists(FGDDirectory))
                    {
                        var Defaultfiles = Directory.GetFiles(FGDDirectory, "*.fgd");
                        foreach (string file in Defaultfiles)
                        {
                            
                            string fileName = file.Remove(0, FGDDirectory.Length);
                            
                            if (!FGDS.ContainsKey(fileName) && fileName != "base.fgd" && fileName != "swarmbase.fgd" && fileName != "swarm_fixed_ents.fgd")
                            {
                                FGDS.Add(fileName, file);
                                listbox_FGDs.Items.Add(fileName);
                            }


                        }
                    }
                    

                    if (game.Mod)
                    {
                        modDirectory = game.Directory + "\\";

                        var files = Directory.GetFiles(modDirectory, "*.fgd");
                        foreach (string file in files)
                        {

                            string fileName = file.Remove(0, modDirectory.Length);

                            if (!FGDS.ContainsKey(fileName) && fileName != "base.fgd" && fileName != "halflife2.fgd" && fileName != "swarmbase.fgd" && fileName != "swarm_fixed_ents.fgd")
                            {
                                FGDS.Add(fileName, file);
                                listbox_FGDs.Items.Add(fileName);
                            }


                        }
                    }

                        
                }
            }
        }

        private void button_CHTU_Click(object sender, EventArgs e)
        {
            Process.Start(gmodDirectory + "/garrysmod/addons");
        }

        private void button_gmodSave_Click(object sender, EventArgs e)
        {
            //Backup the file if it exists
            if(File.Exists(gmodDirectory+"/garrysmod/cfg/mount.cfg"))
            {
                File.Copy(gmodDirectory + "/garrysmod/cfg/mount.cfg", gmodDirectory + "/garrysmod/cfg/mount.cfg.backup",true);
            }
            using (StreamWriter writer = new StreamWriter(gmodDirectory + "/garrysmod/cfg/mount.cfg"))
            {
                writer.WriteLine("// Use this file to mount additional paths to the filesystem");
                writer.WriteLine("// DO NOT add a slash to the end of the filename \n\n");
                writer.WriteLine("\"mountcfg\"");
                writer.WriteLine("{");
                foreach (string content in listbox_HContent.CheckedItems)
                {
                    // TODO: This could be better optimized
                    foreach (SourceGame game in MainMenuForm.listOfSourceGames)
                    {
                        if(game.ProperName == content)
                        {
                            writer.WriteLine("\""+game.SourceName+"\"    "+"\""+game.Directory+"\\"+game.SourceName+"\"");
                        }
                    }
                    if (gmodAddons.ContainsKey(content))
                    {
                        writer.WriteLine("\"" + content.Remove(0, 7) + "\"    " + "\"" + gmodAddons[content] + "\"");
                    }
                }
                writer.WriteLine("}");
                System.Windows.Forms.MessageBox.Show("WARNING: This does not auto pack this content into your map you must still do this on your own!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                System.Windows.Forms.MessageBox.Show("Save Complete!", "Garry's Mod Configuration Saved", MessageBoxButtons.OK);
            }
        }


		/*if (!Directory.Exists(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/customConfig"))
			{
				Directory.CreateDirectory(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/customConfig");
			}
			FileStream fileStream = File.Create(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/customConfig/gameinfo.txt");
			fileStream.Close();
			this.writeToGameinfo();
			this.writeToGameConfig();
			Settings.Default.bspLocation_string = this.bspLocation_TB.Text;
			Settings.Default.vmfLocation_string = this.vmfLocation_TB.Text;
			Settings.Default.gameExeLocation_string = this.gameExeLocation_TB.Text;
			Settings.Default.Save();
			base.Close();

        private void writeToGameinfo()
		{
			List<string> list = new List<string>();
			list.Add("\"GameInfo\"");
			list.Add("{");
			list.Add("\t game \t \"customConfig\"");
			list.Add("\t title \t \"HAMMER4LIFE\"");
			list.Add("\t title2 \t \"HammerLegion\"");
			list.Add("\t type \t multiplayer_only");
			list.Add("\t nomodels \t 0");
			list.Add("\t nohimodel \t 1");
			list.Add("\t nocrosshair \t 1");
			list.Add("\t FileSystem");
			list.Add("{");
			list.Add("\t SteamAppId \t 243750");
			list.Add("\t SearchPaths");
			list.Add("{");
			list.Add("\t game+mod \t customConfig/custom/*");
			list.Add("\t gamebin \t |gameinfo_path|bin");
			if (this.contentMountListBox.CheckedItems.Contains("Counter-Strike Source"))
			{
				list.Add("\t game \t \"|all_source_engine_paths|../Counter-Strike Source/cstrike/cstrike_pak.vpk\"");
			}
			if (this.contentMountListBox.CheckedItems.Contains("Day of Defeat Source"))
			{
				list.Add("\t game \t \"|all_source_engine_paths|../Day of Defeat Source/dod/dod_pak.vpk\"");
			}
			if (this.contentMountListBox.CheckedItems.Contains("GarrysMod"))
			{
				list.Add("\t game \t \"|all_source_engine_paths|../GarrysMod/garrysmod/garrysmod.vpk\"");
			}
			if (this.contentMountListBox.CheckedItems.Contains("Half-Life 2"))
			{
				list.Add("\t game \t \"|all_source_engine_paths|hl2/hl2_english.vpk\"");
				list.Add("\t game \t \"|all_source_engine_paths|hl2/hl2_pak.vpk\"");
				list.Add("\t game \t \"|all_source_engine_paths|hl2/hl2_textures.vpk\"");
				list.Add("\t game \t \"|all_source_engine_paths|hl2/hl2_sound_vo_english.vpk\"");
				list.Add("\t game \t \"|all_source_engine_paths|hl2/hl2_sound_misc.vpk\"");
				list.Add("\t game \t \"|all_source_engine_paths|hl2/hl2_misc.vpk\"");
			}
			if (this.contentMountListBox.CheckedItems.Contains("Half-Life 2 Deathmatch"))
			{
				list.Add("\t game \t \"|all_source_engine_paths|../Half-Life 2 Deathmatch/hl2mp/hl2mp_pak.vpk\"");
			}
			if (this.contentMountListBox.CheckedItems.Contains("Half-Life 2 Episodic"))
			{
				list.Add("\t game \t \"|all_source_engine_paths|../Half-Life 2/episodic/ep1_pak.vpk\"");
				list.Add("\t game \t \"|all_source_engine_paths|episodic/ep1_english.vpk\"");
			}
			if (this.contentMountListBox.CheckedItems.Contains("Half-Life 2 Episode 2"))
			{
				list.Add("\t game \t \"|all_source_engine_paths|../Half-Life 2/ep2/ep2_pak.vpk\"");
				list.Add("\t game \t \"|all_source_engine_paths|ep2/ep2_english.vpk\"");
			}
			if (this.contentMountListBox.CheckedItems.Contains("Half-Life 2 Lost Coast"))
			{
				list.Add("\t game \t \"|all_source_engine_paths|../Half-Life 2/lostcoast/lostcoast_pak.vpk\"");
			}
			if (this.contentMountListBox.CheckedItems.Contains("No More Room In Hell"))
			{
				list.Add("\t game \t \"|all_source_engine_paths|../nmrih/nmrih\"");
			}
			if (this.contentMountListBox.CheckedItems.Contains("Portal"))
			{
				list.Add("\t game \t \"|all_source_engine_paths|../Portal/portal/portal_pak.vpk\"");
			}
			if (this.contentMountListBox.CheckedItems.Contains("Source Mods"))
			{
				list.Add("\t game \t \"|all_source_engine_paths|../../sourcemods/*\"");
			}
			if (this.contentMountListBox.CheckedItems.Contains("Team Fortress 2"))
			{
				list.Add("\t game \t \"|all_source_engine_paths|../Team Fortress 2/tf/tf2_misc.vpk\"");
				list.Add("\t game \t \"|all_source_engine_paths|../Team Fortress 2/tf/tf2_sound_misc.vpk\"");
				list.Add("\t game \t \"|all_source_engine_paths|../Team Fortress 2/tf/tf2_sound_vo_english.vpk\"");
				list.Add("\t game \t \"|all_source_engine_paths|../Team Fortress 2/tf/tf2_textures.vpk\"");
			}
			if (this.contentMountListBox.CheckedItems.Contains("Zombie Panic Source"))
			{
				list.Add("\t game \t \"|all_source_engine_paths|../Source SDK Base 2007/zps\"");
			}
			list.Add("\t platform \t |all_source_engine_paths|platform/platform_misc.vpk");
			list.Add("\t mod+mod_write+default_write_path \t \"|gameinfo_path|.\"");
			list.Add("\t game+game_write \t hl2mp");
			list.Add("\t platform \t |all_source_engine_paths|platform");
			list.Add("}");
			list.Add("}");
			list.Add("}");
			File.WriteAllLines(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/customConfig/gameinfo.txt", list);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003784 File Offset: 0x00001984
		private void writeToGameConfig()
		{
			string[] collection = File.ReadAllLines(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/bin/GameConfig.txt");
			int num = 0;
			int num2 = 0;
			bool flag = false;
			List<string> list = new List<string>();
			list.AddRange(collection);
			string[] fgdfilePath = this.getFGDfilePath();
			this.getFGDfileNames();
			int count = this.fgdListBox.CheckedItems.Count;
			if (list.Contains("\t\t\"customConfig\""))
			{
				int num3 = list.IndexOf("\t\t\"customConfig\"");
				num = num3--;
				num2 = list.IndexOf("\t\t}", num3 + 1);
				flag = true;
			}
			if (flag)
			{
				int num4 = 1;
				int count2 = num2 - num - 1;
				list.RemoveRange(num + 1, count2);
				list.Insert(num + num4, "\t \t {");
				num4++;
				list.Insert(num + num4, "\t\t\t\"GameDir\"\t\t\"" + this.grabSteamRegistry() + "\\steamapps\\common\\Source SDK Base 2013 Multiplayer\\customConfig\"");
				num4++;
				list.Insert(num + num4, "\t\t\t\"Hammer\"");
				num4++;
				list.Insert(num + num4, "\t\t\t{");
				num4++;
				int num5 = 0;
				for (int i = 0; i < count; i++)
				{
					int num6 = num5;
					while (!this.fgdListBox.GetItemChecked(num6) || num6 > this.fgdListBox.Items.Count + 1)
					{
						num5++;
						num6++;
					}
					list.Insert(num + num4, string.Concat(new object[]
					{
						"\t\t\t\t \"GameData",
						i,
						"\" \t \"",
						fgdfilePath[num5].ToString(),
						"\""
					}));
					num5++;
					num4++;
				}
				list.Insert(num + num4, "\t\t\t\t \"TextureFormat\" \t \"5\"");
				num4++;
				list.Insert(num + num4, "\t\t\t\t \"MapFormat\" \t \"4\"");
				num4++;
				list.Insert(num + num4, "\t\t\t\t \"DefaultTextureScale\" \t \"0.250000\"");
				num4++;
				list.Insert(num + num4, "\t\t\t\t \"DefaultLightMapScale\" \t \"16\"");
				num4++;
				list.Insert(num + num4, "\t\t\t\t \"GameExe\" \t \"" + this.gameExecutableLocation_TB.Text + "\"");
				num4++;
				list.Insert(num + num4, "\t\t\t\t \"DefaultSolidEntity\" \t \"func_detail\"");
				num4++;
				list.Insert(num + num4, "\t\t\t\t \"DefaultPointEntity\" \t \"info_player_start\"");
				num4++;
				list.Insert(num + num4, "\t\t\t\t\"BSP\" \t \"" + this.grabSteamRegistry() + "\\steamapps\\common\\Source SDK Base 2013 Multiplayer\\bin\\vbsp.exe\"");
				num4++;
				list.Insert(num + num4, "\t\t\t\t \"Vis\" \t \"" + this.grabSteamRegistry() + "\\steamapps\\common\\Source SDK Base 2013 Multiplayer\\bin\\vvis.exe\"");
				num4++;
				list.Insert(num + num4, "\t\t\t\t \"Light\" \t \"" + this.grabSteamRegistry() + "\\steamapps\\common\\Source SDK Base 2013 Multiplayer\\bin\\vrad.exe\"");
				num4++;
				list.Insert(num + num4, "\t\t\t\t \"GameExeDir\" \t \"" + this.gameExeLocation_TB.Text + "\"");
				num4++;
				list.Insert(num + num4, "\t\t\t\t \"MapDir\" \t \"" + this.vmfLocation_TB.Text + "\"");
				num4++;
				list.Insert(num + num4, "\t\t\t\t \"BSPDir\" \t \"" + this.bspLocation_TB.Text + "\"");
				num4++;
				list.Insert(num + num4, "\t\t\t\t \"CordonTexture\" \t \"BLACK\"");
				num4++;
				list.Insert(num + num4, "\t\t\t\t \"MaterialExcludeCount\" \t \"0\"");
				num4++;
				list.Insert(num + num4, "\t\t\t}");
				num4++;
				File.WriteAllLines(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/bin/GameConfig.txt", list);
				return;
			}
			int num7 = 1;
			num = list.IndexOf("\t\"SDKVersion\"\t\t\"5\"") - 2;
			list.Insert(num + num7, "\t\t\"customConfig\"");
			num7++;
			list.Insert(num + num7, "\t\t{");
			num7++;
			list.Insert(num + num7, "\t\t\t\"GameDir\"\t\t\"" + this.grabSteamRegistry() + "\\steamapps\\common\\Source SDK Base 2013 Multiplayer\\customConfig\"");
			num7++;
			list.Insert(num + num7, "\t\t\t\"Hammer\"");
			num7++;
			list.Insert(num + num7, "\t\t\t{");
			num7++;
			int num8 = 0;
			for (int j = 0; j < count; j++)
			{
				int num9 = num8;
				while (!this.fgdListBox.GetItemChecked(num9) || num9 > this.fgdListBox.Items.Count + 1)
				{
					num8++;
					num9++;
				}
				list.Insert(num + num7, string.Concat(new object[]
				{
					"\t\t\t\t \"GameData",
					j,
					"\" \t \"",
					fgdfilePath[num8].ToString(),
					"\""
				}));
				num8++;
				num7++;
			}
			list.Insert(num + num7, "\t\t\t\t \"TextureFormat\" \t \"5\"");
			num7++;
			list.Insert(num + num7, "\t\t\t\t \"MapFormat\" \t \"4\"");
			num7++;
			list.Insert(num + num7, "\t\t\t\t \"DefaultTextureScale\" \t \"0.250000\"");
			num7++;
			list.Insert(num + num7, "\t\t\t\t \"DefaultLightMapScale\" \t \"16\"");
			num7++;
			list.Insert(num + num7, "\t\t\t\t \"GameExe\" \t \"" + this.gameExecutableLocation_TB.Text + "\"");
			num7++;
			list.Insert(num + num7, "\t\t\t\t \"DefaultSolidEntity\" \t \"func_detail\"");
			num7++;
			list.Insert(num + num7, "\t\t\t\t \"DefaultPointEntity\" \t \"info_player_start\"");
			num7++;
			list.Insert(num + num7, "\t\t\t\t\"BSP\" \t \"" + this.grabSteamRegistry() + "\\steamapps\\common\\Source SDK Base 2013 Multiplayer\\bin\\vbsp.exe\"");
			num7++;
			list.Insert(num + num7, "\t\t\t\t \"Vis\" \t \"" + this.grabSteamRegistry() + "\\steamapps\\common\\Source SDK Base 2013 Multiplayer\\bin\\vvis.exe\"");
			num7++;
			list.Insert(num + num7, "\t\t\t\t \"Light\" \t \"" + this.grabSteamRegistry() + "\\steamapps\\common\\Source SDK Base 2013 Multiplayer\\bin\\vrad.exe\"");
			num7++;
			list.Insert(num + num7, "\t\t\t\t \"GameExeDir\" \t \"" + this.gameExeLocation_TB.Text + "\"");
			num7++;
			list.Insert(num + num7, "\t\t\t\t \"MapDir\" \t \"" + this.vmfLocation_TB.Text + "\"");
			num7++;
			list.Insert(num + num7, "\t\t\t\t \"BSPDir\" \t \"" + this.bspLocation_TB.Text + "\"");
			num7++;
			list.Insert(num + num7, "\t\t\t\t \"CordonTexture\" \t \"BLACK\"");
			num7++;
			list.Insert(num + num7, "\t\t\t\t \"MaterialExcludeCount\" \t \"0\"");
			num7++;
			list.Insert(num + num7, "\t\t\t}");
			num7++;
			list.Insert(num + num7, "\t\t}");
			num7++;
			File.WriteAllLines(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/bin/GameConfig.txt", list);
		}
        
         
         */

		private void button_HCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_VMF_Click(object sender, EventArgs e)
        {
			DialogResult result = folderBrowserDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				textBox_VMF.Text = folderBrowserDialog1.SelectedPath;
			}
		}

        private void button_BSP_Click(object sender, EventArgs e)
        {
			DialogResult result = folderBrowserDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				textBox_BSP.Text = folderBrowserDialog1.SelectedPath;
			}
		}

        private void button_Exe_Folder_Click(object sender, EventArgs e)
        {
			DialogResult result = folderBrowserDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				textBox_Exe_Folder.Text = folderBrowserDialog1.SelectedPath;
			}
		}

        private void button_Exe_Click(object sender, EventArgs e)
        {
			DialogResult dialogResult = openFileDialog1.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				textBox_Game_Exe.Text = openFileDialog1.FileName;
			}
		}
    }
}

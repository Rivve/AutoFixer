using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFixer
{
    partial class UIAdvanced
    {

        /// <summary>
        /// Double click on a row to copy to clipboard
        /// </summary>
        private void Specslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView view = (ListView)sender;
            foreach (ListViewItem s in view.SelectedItems)
                Clipboard.SetText(s.Text);
        }

        /// <summary>
        /// If update is available ask the user if they wanna install it.
        /// </summary>
        private void UpdateAvailable(object sender, EventArgs e)
        {
            DialogResult install_update = MessageBox.Show("An update is available, would you like to install it?", "Update AutoFixer?", MessageBoxButtons.YesNo);
            if (install_update == DialogResult.Yes)
            {
                UpdateChecker.InstallNow();
            }
        }

        /// <summary>
        /// Run the Automode since user pressed the button
        /// </summary>
        private void RunAutoMode(object sender, EventArgs e)
        {
            RunModes.RunAutoMode();
        }

        /// <summary>
        /// Reset Automode since user pressed the button
        /// </summary>
        private void ResetAutoMode(object sender, EventArgs e)
        {
            RunModes.ResetSettings();
        }

        /// <summary>
        /// Force reinstallation of all windows preinstalled apps through powershell
        /// </summary>
        private void ReinstallApps(object sender, EventArgs e)
        {
            DialogResult reinstall = MessageBox.Show("Are you sure you want to reinstall all apps? If so please wait after this window becuase it can take some time.", "Reinstall apps?", MessageBoxButtons.YesNo);
            if (reinstall == DialogResult.Yes)
            {
                Utils.RunScript(@"Get-AppxPackage -AllUsers| Foreach {Add-AppxPackage -DisableDevelopmentMode -Register “$($_.InstallLocation)\AppXManifest.xml”}");
                DialogResult dialog = MessageBox.Show("All Windows preinstalled apps is now installed", "Reinstall apps");
            }
        }

        /// <summary>
        /// Take a screenshot of the specslist and save it to desktop
        /// </summary>
        private void ScreenShoot(object sender, EventArgs e)
        {
            Size temp = specslist.Size;
            specslist.EnsureVisible(0);
            int h1 = specslist.Items.Count * (specslist.Items[0].Bounds.Height) + (specslist.Items.Count * 6);
            int h2 = specslist.Groups.Count * 19;
            specslist.Size = new Size(specslist.Bounds.Width, h1 + h2);
            String s = specslist.Items[1].Text;
            specslist.Items[1].Text = "HIDDEN FROM SCREENSHOOT!";
            var frm = specslist;
            using (var bmp = new Bitmap(specslist.Size.Width, specslist.Size.Height))
            {
                frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                bmp.Save(path + @"\Screenshot" + DateTime.UtcNow.Ticks + ".png");
            }
            specslist.Size = temp;
            DialogResult dialog = MessageBox.Show("Screenshot has been saved to Desktop!");
            specslist.Items[1].Text = s;
        }

        /// <summary>
        /// Activate the certain function or revert it depending on check/uncheck
        /// </summary>
        /// <param name="sender">The function which the user which to activate</param>
        private void Toggle_Checkbox(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (e.RowIndex >= 0)
                    toggles[e.RowIndex].Toggle();
            }
        }

        /// <summary>
        /// Check if user pressed the uninstall button and if not uninstalled > uninstall the program
        /// </summary>
        /// <param name="sender">The uninstall button in the column</param>
        private void Uninstall_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewDisableButtonCell button = uninstall_app_list.Rows[e.RowIndex].Cells[0] as DataGridViewDisableButtonCell;
                    if (button.Enabled)
                    {
                        if (uninstall_apps[e.RowIndex].UninstallProgram())
                        {
                            button.Enabled = false;
                            MessageBox.Show("The windows app is now uninstalled!");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Execute all the options the user made when pressing Execute button
        /// </summary>
        private void Execute_Button(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DataGridViewRow row in action_list.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (actions[chk.RowIndex].Execute)
                {
                    Task task = Task.Factory.StartNew(() => actions[chk.RowIndex].ExecuteAction());
                    Task.WaitAll(task);
                    i++;
                }
            }

            if (i == 0) return;

            if (AutoFixer.reqRestart)
            {
                DialogResult dialog = MessageBox.Show("Changes has been made which require a computer restart \nWould you like you restart it now?", "Require restart...", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes) Utils.Restart();
                else MessageBox.Show("Execution complete, enjoy!");
            }
            else MessageBox.Show("Execution complete, enjoy!");
        }

        /// <summary>
        /// Toggle the grid options when being pressed 
        /// And change Execute value in Option
        /// </summary>
        private void Toggle_Action_Checkbox(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (e.RowIndex >= 0)
                    actions[e.RowIndex].Execute = !actions[e.RowIndex].Execute;
            }
        }

    }
}

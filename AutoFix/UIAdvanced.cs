using AutoFixer.Actions;
using AutoFixer.Toggles;
using AutoFixer.UninstallsApp;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AutoFixer
{
    public partial class UIAdvanced : Form
    {

        private AutoFixer au;
        private bool ActivateForm = false;
        private BindingList<ExecuteAbstract> actions;
        private BindingList<ToggleAbstract> toggles;
        private BindingList<UninstallAppAbstract> uninstall_apps;
        private DataGridViewDisableButtonColumn uninstall_app_button;
        private bool uninstall_button_init_status = false;
        private BackgroundWorker bgworker = new BackgroundWorker();

        public UIAdvanced(AutoFixer au)
        {
            this.au = au;
            InitializeComponent();
        }

        /// <summary>
        /// On Form load actions
        /// </summary>
        private void UIAdvanced_Load(object sender, EventArgs e)
        {
            UpdateChecker.ForceCheckForUpdate();
        }

        /// <summary>
        /// Backgroundworker fill data to spec tab (since this can delay the startup still)
        /// TODO : Maybe remove certain things of WMI and use hardwaremonitor lib instead for faster access time
        /// </summary>
        private void FillSpecsTab(object sender, DoWorkEventArgs e)
        {
            AutoFixer.chw.Open();
            FillSpecsTab();
        }

        /// <summary>
        /// Fill the toggletab with the toggles there is in the system
        /// </summary>
        private void FillToggleTab()
        {
            toggles = new BindingList<ToggleAbstract>()
            {
                new VolumeMixer(),
                new VisualFX(),
                new AutoUpdate(),
                new ClockSeconds(),
                new GameBar(),
                new GameMode(),
                new Cortana(),
                new LockScreen(),
                new DisableUac(),

            };
            togglelist.DataSource = toggles;

            for(int i = togglelist.Rows.Count - 1; i >= 0; --i)
            {
                ToggleAbstract obj = (ToggleAbstract)togglelist.Rows[i].DataBoundItem;
                if (obj.Unavailable)
                    togglelist.Rows.Remove(togglelist.Rows[i]);
            }

            FixGridView(ref togglelist);
        }

        /// <summary>
        /// Fill the general tab with the actions there is in the system
        /// </summary>
        private void FillGeneralTab()
        {
            actions = new BindingList<ExecuteAbstract>()
            {
                new MemoryLeak(),
                new XboxDVR(),
                new UpdateShare(),
                new HighPerformance(),
                new DisableSuperFetch(),
                new DisableWindowsSearch(),
                new DisableWindowsCollection(),
                new RemoveOneDrive(),
            };
            action_list.DataSource = actions;

            for (int i = action_list.Rows.Count - 1; i >= 0; --i)
            {
                ExecuteAbstract obj = (ExecuteAbstract)action_list.Rows[i].DataBoundItem;
                if (obj.Unavailable)
                    action_list.Rows.Remove(action_list.Rows[i]);
            }

            FixGridView(ref action_list);
        }

        /// <summary>
        /// Fill the uninstall with uninstall options of preinstalled programs in windows
        /// </summary>
        private void FillUninstallAppTab()
        {
            uninstall_app_button = new DataGridViewDisableButtonColumn();
            uninstall_app_button.HeaderText = "Uninstall App";
            uninstall_app_button.Name = "uninstall_button";
            uninstall_app_button.Text = "Click to uninstall";
            uninstall_app_button.UseColumnTextForButtonValue = true;
            uninstall_app_list.Columns.AddRange(new DataGridViewColumn[] { uninstall_app_button });

            uninstall_apps = new BindingList<UninstallAppAbstract>()
            {
                new ThreeDBuilder(),
                new AlarmsAndClock(),
                new BingSport(),
                new CalendarAndMail(),
                new Camera(),
                new GetOffice(),
                new GetSkype(),
                new GetStarted(),
                new GrooveMusic(),
                new Maps(),
                new Money(),
                new MoviesAndTV(),
                new News(),
                new OneNote(),
                new People(),
                new PhoneCompanion(),
                new Photos(),
                new SolitaireCollection(),
                new Store(),
                new VoiceRecorder(),
                new Weather(),
                new XboxApp()
            };
            uninstall_app_list.DataSource = uninstall_apps;

            FixGridView(ref uninstall_app_list);
        }

        /// <summary>
        /// Resize columns to fit content
        /// </summary>
        /// <param name="dgv">The DataGridView which shall be resized</param>
        private void FixGridView(ref DataGridView dgv)
        {
            dgv.AutoResizeColumns();

            dgv.DataBindingComplete += (o, _) =>
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };
        }

        /// <summary>
        /// Set the buttons status when they get visible for the first time otherwise they have wrong "enabled" status
        /// </summary>
        private void SetUninstallButtonsStatus(object sender, EventArgs e)
        {
            if (!uninstall_button_init_status)
            {
                for (int i = uninstall_app_list.Rows.Count - 1; i >= 0; --i)
                {
                    UninstallAppAbstract obj = (UninstallAppAbstract)uninstall_app_list.Rows[i].DataBoundItem;
                    if (!obj.Installed)
                    {
                        DataGridViewRow row = uninstall_app_list.Rows[i];
                        DataGridViewDisableButtonCell button = row.Cells[0] as DataGridViewDisableButtonCell;
                        if (button != null)
                            button.Enabled = false;
                    }
                }
                uninstall_button_init_status = true;
            }
        }

        /// <summary>
        /// When the form goes activate start to fill the windows form 
        /// </summary>
        private void UIAdvanced_Activated(object sender, EventArgs e)
        {
            if (!ActivateForm)
            {
                ActivateForm = true;
                FillGeneralTab();
                FillToggleTab();
                FillUninstallAppTab();
                bgworker.DoWork += new DoWorkEventHandler(FillSpecsTab);
                bgworker.RunWorkerAsync();
            }
        }
    }
}

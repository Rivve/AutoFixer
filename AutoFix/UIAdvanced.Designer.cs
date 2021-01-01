namespace AutoFixer
{
    partial class UIAdvanced
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIAdvanced));
            this.uninstall_apps_tab = new System.Windows.Forms.TabPage();
            this.uninstall_app_list = new System.Windows.Forms.DataGridView();
            this.toggle_tab = new System.Windows.Forms.TabPage();
            this.toggle_message = new System.Windows.Forms.Label();
            this.togglelist = new System.Windows.Forms.DataGridView();
            this.specs = new System.Windows.Forms.TabPage();
            this.specs_click_info = new System.Windows.Forms.Label();
            this.button_screenshot = new System.Windows.Forms.Button();
            this.specslist = new System.Windows.Forms.ListView();
            this.action_tab = new System.Windows.Forms.TabPage();
            this.execute_selected_options = new System.Windows.Forms.Button();
            this.action_list = new System.Windows.Forms.DataGridView();
            this.uninstall = new System.Windows.Forms.TabControl();
            this.general_tab = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.auto_mode_button = new System.Windows.Forms.Button();
            this.reset_auto_button = new System.Windows.Forms.Button();
            this.UpdateChecker = new wyDay.Controls.AutomaticUpdater();
            this.uninstall_apps_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uninstall_app_list)).BeginInit();
            this.toggle_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.togglelist)).BeginInit();
            this.specs.SuspendLayout();
            this.action_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.action_list)).BeginInit();
            this.uninstall.SuspendLayout();
            this.general_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateChecker)).BeginInit();
            this.SuspendLayout();
            // 
            // uninstall_apps_tab
            // 
            this.uninstall_apps_tab.Controls.Add(this.uninstall_app_list);
            this.uninstall_apps_tab.Location = new System.Drawing.Point(4, 22);
            this.uninstall_apps_tab.Name = "uninstall_apps_tab";
            this.uninstall_apps_tab.Padding = new System.Windows.Forms.Padding(3);
            this.uninstall_apps_tab.Size = new System.Drawing.Size(769, 428);
            this.uninstall_apps_tab.TabIndex = 3;
            this.uninstall_apps_tab.Text = "Uninstall Apps";
            this.uninstall_apps_tab.UseVisualStyleBackColor = true;
            // 
            // uninstall_app_list
            // 
            this.uninstall_app_list.AllowUserToAddRows = false;
            this.uninstall_app_list.AllowUserToDeleteRows = false;
            this.uninstall_app_list.AllowUserToResizeColumns = false;
            this.uninstall_app_list.AllowUserToResizeRows = false;
            this.uninstall_app_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uninstall_app_list.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.uninstall_app_list.Location = new System.Drawing.Point(3, 3);
            this.uninstall_app_list.Name = "uninstall_app_list";
            this.uninstall_app_list.RowHeadersVisible = false;
            this.uninstall_app_list.Size = new System.Drawing.Size(760, 422);
            this.uninstall_app_list.TabIndex = 1;
            this.uninstall_app_list.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Uninstall_CellContentClick);
            this.uninstall_app_list.VisibleChanged += new System.EventHandler(this.SetUninstallButtonsStatus);
            // 
            // toggle_tab
            // 
            this.toggle_tab.Controls.Add(this.toggle_message);
            this.toggle_tab.Controls.Add(this.togglelist);
            this.toggle_tab.Location = new System.Drawing.Point(4, 22);
            this.toggle_tab.Name = "toggle_tab";
            this.toggle_tab.Padding = new System.Windows.Forms.Padding(3);
            this.toggle_tab.Size = new System.Drawing.Size(769, 428);
            this.toggle_tab.TabIndex = 2;
            this.toggle_tab.Text = "Toggles";
            this.toggle_tab.UseVisualStyleBackColor = true;
            // 
            // toggle_message
            // 
            this.toggle_message.AutoSize = true;
            this.toggle_message.Location = new System.Drawing.Point(7, 7);
            this.toggle_message.Name = "toggle_message";
            this.toggle_message.Size = new System.Drawing.Size(253, 13);
            this.toggle_message.TabIndex = 2;
            this.toggle_message.Text = "Toggle functions in windows, just check to proceed.";
            // 
            // togglelist
            // 
            this.togglelist.AllowUserToAddRows = false;
            this.togglelist.AllowUserToDeleteRows = false;
            this.togglelist.AllowUserToResizeColumns = false;
            this.togglelist.AllowUserToResizeRows = false;
            this.togglelist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.togglelist.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.togglelist.Location = new System.Drawing.Point(4, 28);
            this.togglelist.Name = "togglelist";
            this.togglelist.RowHeadersVisible = false;
            this.togglelist.Size = new System.Drawing.Size(760, 395);
            this.togglelist.TabIndex = 1;
            this.togglelist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Toggle_Checkbox);
            // 
            // specs
            // 
            this.specs.Controls.Add(this.specs_click_info);
            this.specs.Controls.Add(this.button_screenshot);
            this.specs.Controls.Add(this.specslist);
            this.specs.Location = new System.Drawing.Point(4, 22);
            this.specs.Name = "specs";
            this.specs.Padding = new System.Windows.Forms.Padding(3);
            this.specs.Size = new System.Drawing.Size(769, 428);
            this.specs.TabIndex = 1;
            this.specs.Text = "Specs";
            this.specs.UseVisualStyleBackColor = true;
            // 
            // specs_click_info
            // 
            this.specs_click_info.AutoSize = true;
            this.specs_click_info.Location = new System.Drawing.Point(6, 401);
            this.specs_click_info.Name = "specs_click_info";
            this.specs_click_info.Size = new System.Drawing.Size(236, 13);
            this.specs_click_info.TabIndex = 3;
            this.specs_click_info.Text = "Doubleclick a line to copy the content of the row";
            // 
            // button_screenshot
            // 
            this.button_screenshot.Location = new System.Drawing.Point(617, 388);
            this.button_screenshot.Name = "button_screenshot";
            this.button_screenshot.Size = new System.Drawing.Size(147, 38);
            this.button_screenshot.TabIndex = 2;
            this.button_screenshot.Text = "Screenshot";
            this.button_screenshot.UseVisualStyleBackColor = true;
            this.button_screenshot.Click += new System.EventHandler(this.ScreenShoot);
            // 
            // specslist
            // 
            this.specslist.Location = new System.Drawing.Point(4, 6);
            this.specslist.Name = "specslist";
            this.specslist.Size = new System.Drawing.Size(760, 377);
            this.specslist.TabIndex = 0;
            this.specslist.UseCompatibleStateImageBehavior = false;
            this.specslist.DoubleClick += new System.EventHandler(this.Specslist_SelectedIndexChanged);
            // 
            // action_tab
            // 
            this.action_tab.Controls.Add(this.execute_selected_options);
            this.action_tab.Controls.Add(this.action_list);
            this.action_tab.Location = new System.Drawing.Point(4, 22);
            this.action_tab.Name = "action_tab";
            this.action_tab.Padding = new System.Windows.Forms.Padding(3);
            this.action_tab.Size = new System.Drawing.Size(769, 428);
            this.action_tab.TabIndex = 0;
            this.action_tab.Text = "Actions";
            this.action_tab.UseVisualStyleBackColor = true;
            // 
            // execute_selected_options
            // 
            this.execute_selected_options.Location = new System.Drawing.Point(617, 388);
            this.execute_selected_options.Name = "execute_selected_options";
            this.execute_selected_options.Size = new System.Drawing.Size(147, 38);
            this.execute_selected_options.TabIndex = 1;
            this.execute_selected_options.Text = "Execute selected options";
            this.execute_selected_options.UseVisualStyleBackColor = true;
            this.execute_selected_options.Click += new System.EventHandler(this.Execute_Button);
            // 
            // action_list
            // 
            this.action_list.AllowUserToAddRows = false;
            this.action_list.AllowUserToDeleteRows = false;
            this.action_list.AllowUserToResizeColumns = false;
            this.action_list.AllowUserToResizeRows = false;
            this.action_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.action_list.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.action_list.Location = new System.Drawing.Point(4, 6);
            this.action_list.Name = "action_list";
            this.action_list.RowHeadersVisible = false;
            this.action_list.Size = new System.Drawing.Size(760, 376);
            this.action_list.TabIndex = 0;
            this.action_list.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Toggle_Action_Checkbox);
            // 
            // uninstall
            // 
            this.uninstall.Controls.Add(this.general_tab);
            this.uninstall.Controls.Add(this.action_tab);
            this.uninstall.Controls.Add(this.specs);
            this.uninstall.Controls.Add(this.toggle_tab);
            this.uninstall.Controls.Add(this.uninstall_apps_tab);
            this.uninstall.Location = new System.Drawing.Point(4, 4);
            this.uninstall.Name = "uninstall";
            this.uninstall.SelectedIndex = 0;
            this.uninstall.Size = new System.Drawing.Size(777, 454);
            this.uninstall.TabIndex = 0;
            // 
            // general_tab
            // 
            this.general_tab.Controls.Add(this.button1);
            this.general_tab.Controls.Add(this.auto_mode_button);
            this.general_tab.Controls.Add(this.reset_auto_button);
            this.general_tab.Location = new System.Drawing.Point(4, 22);
            this.general_tab.Name = "general_tab";
            this.general_tab.Padding = new System.Windows.Forms.Padding(3);
            this.general_tab.Size = new System.Drawing.Size(769, 428);
            this.general_tab.TabIndex = 4;
            this.general_tab.Text = "General";
            this.general_tab.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(515, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(249, 51);
            this.button1.TabIndex = 6;
            this.button1.Tag = "";
            this.button1.Text = "Reinstall all apps\r\n(Windows preinstalled apps)\r\n";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ReinstallApps);
            // 
            // auto_mode_button
            // 
            this.auto_mode_button.Location = new System.Drawing.Point(4, 6);
            this.auto_mode_button.Name = "auto_mode_button";
            this.auto_mode_button.Size = new System.Drawing.Size(249, 51);
            this.auto_mode_button.TabIndex = 5;
            this.auto_mode_button.Tag = "";
            this.auto_mode_button.Text = "Run Auto mode\r\nMy recommended windows settings";
            this.auto_mode_button.UseVisualStyleBackColor = true;
            this.auto_mode_button.Click += new System.EventHandler(this.RunAutoMode);
            // 
            // reset_auto_button
            // 
            this.reset_auto_button.Location = new System.Drawing.Point(259, 6);
            this.reset_auto_button.Name = "reset_auto_button";
            this.reset_auto_button.Size = new System.Drawing.Size(249, 51);
            this.reset_auto_button.TabIndex = 4;
            this.reset_auto_button.Tag = "";
            this.reset_auto_button.Text = "Reset Auto mode\r\n(Except powerplan and memoryleak fix)";
            this.reset_auto_button.UseVisualStyleBackColor = true;
            this.reset_auto_button.Click += new System.EventHandler(this.ResetAutoMode);
            // 
            // UpdateChecker
            // 
            this.UpdateChecker.Animate = false;
            this.UpdateChecker.ContainerForm = this;
            this.UpdateChecker.GUID = "91ee893c-7486-4722-8524-5bc2abd4d65d";
            this.UpdateChecker.Location = new System.Drawing.Point(12, 12);
            this.UpdateChecker.Name = "UpdateChecker";
            this.UpdateChecker.Size = new System.Drawing.Size(16, 16);
            this.UpdateChecker.TabIndex = 1;
            this.UpdateChecker.UpdateType = wyDay.Controls.UpdateType.OnlyCheck;
            this.UpdateChecker.WaitBeforeCheckSecs = 1;
            this.UpdateChecker.wyUpdateCommandline = null;
            this.UpdateChecker.ReadyToBeInstalled += new System.EventHandler(this.UpdateAvailable);
            this.UpdateChecker.UpdateAvailable += new System.EventHandler(this.UpdateAvailable);
            // 
            // UIAdvanced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.uninstall);
            this.Controls.Add(this.UpdateChecker);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(800, 500);
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "UIAdvanced";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoFixer";
            this.Activated += new System.EventHandler(this.UIAdvanced_Activated);
            this.Load += new System.EventHandler(this.UIAdvanced_Load);
            this.uninstall_apps_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uninstall_app_list)).EndInit();
            this.toggle_tab.ResumeLayout(false);
            this.toggle_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.togglelist)).EndInit();
            this.specs.ResumeLayout(false);
            this.specs.PerformLayout();
            this.action_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.action_list)).EndInit();
            this.uninstall.ResumeLayout(false);
            this.general_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UpdateChecker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage uninstall_apps_tab;
        private System.Windows.Forms.TabPage toggle_tab;
        private System.Windows.Forms.Label toggle_message;
        private System.Windows.Forms.DataGridView togglelist;
        private System.Windows.Forms.TabPage specs;
        private System.Windows.Forms.Label specs_click_info;
        private System.Windows.Forms.Button button_screenshot;
        private System.Windows.Forms.ListView specslist;
        private System.Windows.Forms.TabPage action_tab;
        private System.Windows.Forms.Button execute_selected_options;
        private System.Windows.Forms.DataGridView action_list;
        private System.Windows.Forms.TabControl uninstall;
        private System.Windows.Forms.DataGridView uninstall_app_list;
        private System.Windows.Forms.TabPage general_tab;
        private System.Windows.Forms.Button auto_mode_button;
        private System.Windows.Forms.Button reset_auto_button;
        private wyDay.Controls.AutomaticUpdater UpdateChecker;
        private System.Windows.Forms.Button button1;
    }
}
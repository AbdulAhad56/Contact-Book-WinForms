
namespace Contact_Book_Management_System
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pTop = new System.Windows.Forms.Panel();
            this.lbSelectedGroup = new System.Windows.Forms.Label();
            this.llbEditProfile = new System.Windows.Forms.LinkLabel();
            this.lbProfile = new System.Windows.Forms.Label();
            this.lbProfileName = new System.Windows.Forms.Label();
            this.pbProfilePicture = new System.Windows.Forms.PictureBox();
            this.dgvGroups = new System.Windows.Forms.DataGridView();
            this.group_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveGroup = new System.Windows.Forms.Button();
            this.btnEditGroup = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.dgvContacts = new System.Windows.Forms.DataGridView();
            this.contact_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.btnEditContact = new System.Windows.Forms.Button();
            this.btnRemoveContact = new System.Windows.Forms.Button();
            this.pRight = new System.Windows.Forms.Panel();
            this.pContactButtons = new System.Windows.Forms.Panel();
            this.btnShowAllContacts = new System.Windows.Forms.Button();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pGroupButtons = new System.Windows.Forms.Panel();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.pTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            this.pRight.SuspendLayout();
            this.pContactButtons.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pGroupButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pTop
            // 
            this.pTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(121)))), ((int)(((byte)(140)))));
            this.pTop.Controls.Add(this.lblSearch);
            this.pTop.Controls.Add(this.cbSearch);
            this.pTop.Controls.Add(this.lbSelectedGroup);
            this.pTop.Controls.Add(this.llbEditProfile);
            this.pTop.Controls.Add(this.lbProfile);
            this.pTop.Controls.Add(this.lbProfileName);
            this.pTop.Controls.Add(this.pbProfilePicture);
            this.pTop.Location = new System.Drawing.Point(0, 0);
            this.pTop.Margin = new System.Windows.Forms.Padding(4);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(1459, 82);
            this.pTop.TabIndex = 0;
            // 
            // lbSelectedGroup
            // 
            this.lbSelectedGroup.AutoSize = true;
            this.lbSelectedGroup.Font = new System.Drawing.Font("Trebuchet MS", 16F, System.Drawing.FontStyle.Bold);
            this.lbSelectedGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(224)))), ((int)(((byte)(195)))));
            this.lbSelectedGroup.Location = new System.Drawing.Point(619, 36);
            this.lbSelectedGroup.Name = "lbSelectedGroup";
            this.lbSelectedGroup.Size = new System.Drawing.Size(0, 35);
            this.lbSelectedGroup.TabIndex = 4;
            this.lbSelectedGroup.Click += new System.EventHandler(this.lbSelectedGroup_Click);
            // 
            // llbEditProfile
            // 
            this.llbEditProfile.AutoSize = true;
            this.llbEditProfile.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.llbEditProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(224)))), ((int)(((byte)(195)))));
            this.llbEditProfile.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.llbEditProfile.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(193)))), ((int)(((byte)(163)))));
            this.llbEditProfile.Location = new System.Drawing.Point(85, 48);
            this.llbEditProfile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llbEditProfile.Name = "llbEditProfile";
            this.llbEditProfile.Size = new System.Drawing.Size(118, 26);
            this.llbEditProfile.TabIndex = 3;
            this.llbEditProfile.TabStop = true;
            this.llbEditProfile.Text = "Edit profile";
            this.llbEditProfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbEditProfile_LinkClicked);
            // 
            // lbProfile
            // 
            this.lbProfile.AutoSize = true;
            this.lbProfile.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.lbProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(224)))), ((int)(((byte)(195)))));
            this.lbProfile.Location = new System.Drawing.Point(85, 12);
            this.lbProfile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbProfile.Name = "lbProfile";
            this.lbProfile.Size = new System.Drawing.Size(111, 26);
            this.lbProfile.TabIndex = 2;
            this.lbProfile.Text = "Logged as:";
            // 
            // lbProfileName
            // 
            this.lbProfileName.AutoSize = true;
            this.lbProfileName.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.lbProfileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(224)))), ((int)(((byte)(195)))));
            this.lbProfileName.Location = new System.Drawing.Point(216, 12);
            this.lbProfileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbProfileName.Name = "lbProfileName";
            this.lbProfileName.Size = new System.Drawing.Size(115, 26);
            this.lbProfileName.TabIndex = 1;
            this.lbProfileName.Text = "User Name";
            // 
            // pbProfilePicture
            // 
            this.pbProfilePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbProfilePicture.Image = global::Contact_Book_Management_System.Properties.Resources._1729416623801;
            this.pbProfilePicture.Location = new System.Drawing.Point(13, 12);
            this.pbProfilePicture.Margin = new System.Windows.Forms.Padding(4);
            this.pbProfilePicture.Name = "pbProfilePicture";
            this.pbProfilePicture.Size = new System.Drawing.Size(65, 59);
            this.pbProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProfilePicture.TabIndex = 0;
            this.pbProfilePicture.TabStop = false;
            // 
            // dgvGroups
            // 
            this.dgvGroups.AllowUserToAddRows = false;
            this.dgvGroups.AllowUserToDeleteRows = false;
            this.dgvGroups.AllowUserToOrderColumns = true;
            this.dgvGroups.AllowUserToResizeRows = false;
            this.dgvGroups.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(169)))), ((int)(((byte)(161)))));
            this.dgvGroups.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.group_id,
            this.group_name});
            this.dgvGroups.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroups.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvGroups.Location = new System.Drawing.Point(0, 0);
            this.dgvGroups.Margin = new System.Windows.Forms.Padding(4);
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.ReadOnly = true;
            this.dgvGroups.RowHeadersVisible = false;
            this.dgvGroups.RowHeadersWidth = 51;
            this.dgvGroups.RowTemplate.Height = 25;
            this.dgvGroups.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroups.Size = new System.Drawing.Size(364, 562);
            this.dgvGroups.TabIndex = 5;
            this.dgvGroups.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroups_CellContentClick);
            // 
            // group_id
            // 
            this.group_id.HeaderText = "Group ID";
            this.group_id.MinimumWidth = 6;
            this.group_id.Name = "group_id";
            this.group_id.ReadOnly = true;
            this.group_id.Width = 125;
            // 
            // group_name
            // 
            this.group_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.group_name.HeaderText = "Group Name";
            this.group_name.MinimumWidth = 6;
            this.group_name.Name = "group_name";
            this.group_name.ReadOnly = true;
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRemoveGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(193)))), ((int)(((byte)(163)))));
            this.btnRemoveGroup.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.btnRemoveGroup.Location = new System.Drawing.Point(244, 5);
            this.btnRemoveGroup.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size(114, 40);
            this.btnRemoveGroup.TabIndex = 6;
            this.btnRemoveGroup.Text = "Remove Group";
            this.btnRemoveGroup.UseVisualStyleBackColor = false;
            this.btnRemoveGroup.Click += new System.EventHandler(this.btnRemoveGroup_Click);
            // 
            // btnEditGroup
            // 
            this.btnEditGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(193)))), ((int)(((byte)(163)))));
            this.btnEditGroup.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.btnEditGroup.Location = new System.Drawing.Point(125, 5);
            this.btnEditGroup.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnEditGroup.Name = "btnEditGroup";
            this.btnEditGroup.Size = new System.Drawing.Size(114, 40);
            this.btnEditGroup.TabIndex = 5;
            this.btnEditGroup.Text = "Edit Group";
            this.btnEditGroup.UseVisualStyleBackColor = false;
            this.btnEditGroup.Click += new System.EventHandler(this.btnEditGroup_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(193)))), ((int)(((byte)(163)))));
            this.btnAddGroup.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.btnAddGroup.Location = new System.Drawing.Point(0, 5);
            this.btnAddGroup.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(114, 40);
            this.btnAddGroup.TabIndex = 4;
            this.btnAddGroup.Text = "Add Group";
            this.btnAddGroup.UseVisualStyleBackColor = false;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // dgvContacts
            // 
            this.dgvContacts.AllowUserToAddRows = false;
            this.dgvContacts.AllowUserToDeleteRows = false;
            this.dgvContacts.AllowUserToOrderColumns = true;
            this.dgvContacts.AllowUserToResizeRows = false;
            this.dgvContacts.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(169)))), ((int)(((byte)(161)))));
            this.dgvContacts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContacts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.contact_id,
            this.firstname,
            this.lastname,
            this.phone,
            this.email,
            this.address});
            this.dgvContacts.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContacts.Location = new System.Drawing.Point(0, 0);
            this.dgvContacts.Margin = new System.Windows.Forms.Padding(4);
            this.dgvContacts.Name = "dgvContacts";
            this.dgvContacts.ReadOnly = true;
            this.dgvContacts.RowHeadersVisible = false;
            this.dgvContacts.RowHeadersWidth = 51;
            this.dgvContacts.RowTemplate.Height = 25;
            this.dgvContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContacts.Size = new System.Drawing.Size(1060, 562);
            this.dgvContacts.TabIndex = 4;
            this.dgvContacts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContacts_CellContentClick);
            // 
            // contact_id
            // 
            this.contact_id.HeaderText = "Contact ID";
            this.contact_id.MinimumWidth = 6;
            this.contact_id.Name = "contact_id";
            this.contact_id.ReadOnly = true;
            this.contact_id.Width = 125;
            // 
            // firstname
            // 
            this.firstname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.firstname.HeaderText = "First Name";
            this.firstname.MinimumWidth = 6;
            this.firstname.Name = "firstname";
            this.firstname.ReadOnly = true;
            // 
            // lastname
            // 
            this.lastname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lastname.HeaderText = "Last Name";
            this.lastname.MinimumWidth = 6;
            this.lastname.Name = "lastname";
            this.lastname.ReadOnly = true;
            // 
            // phone
            // 
            this.phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.phone.HeaderText = "Phone Number";
            this.phone.MinimumWidth = 6;
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            // 
            // email
            // 
            this.email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.email.HeaderText = "Email";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // address
            // 
            this.address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.address.HeaderText = "Address";
            this.address.MinimumWidth = 6;
            this.address.Name = "address";
            this.address.ReadOnly = true;
            // 
            // btnAddContact
            // 
            this.btnAddContact.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(193)))), ((int)(((byte)(163)))));
            this.btnAddContact.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.btnAddContact.Location = new System.Drawing.Point(652, 5);
            this.btnAddContact.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(130, 40);
            this.btnAddContact.TabIndex = 9;
            this.btnAddContact.Text = "Add Contact";
            this.btnAddContact.UseVisualStyleBackColor = false;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // btnEditContact
            // 
            this.btnEditContact.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEditContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(193)))), ((int)(((byte)(163)))));
            this.btnEditContact.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.btnEditContact.Location = new System.Drawing.Point(791, 5);
            this.btnEditContact.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditContact.Name = "btnEditContact";
            this.btnEditContact.Size = new System.Drawing.Size(130, 40);
            this.btnEditContact.TabIndex = 8;
            this.btnEditContact.Text = "Edit Contact";
            this.btnEditContact.UseVisualStyleBackColor = false;
            this.btnEditContact.Click += new System.EventHandler(this.btnEditContact_Click);
            // 
            // btnRemoveContact
            // 
            this.btnRemoveContact.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRemoveContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(193)))), ((int)(((byte)(163)))));
            this.btnRemoveContact.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.btnRemoveContact.Location = new System.Drawing.Point(930, 5);
            this.btnRemoveContact.Margin = new System.Windows.Forms.Padding(0);
            this.btnRemoveContact.Name = "btnRemoveContact";
            this.btnRemoveContact.Size = new System.Drawing.Size(130, 40);
            this.btnRemoveContact.TabIndex = 7;
            this.btnRemoveContact.Text = "Remove Contact";
            this.btnRemoveContact.UseVisualStyleBackColor = false;
            this.btnRemoveContact.Click += new System.EventHandler(this.btnRemoveContact_Click);
            // 
            // pRight
            // 
            this.pRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pRight.Controls.Add(this.dgvContacts);
            this.pRight.Controls.Add(this.pContactButtons);
            this.pRight.Location = new System.Drawing.Point(384, 89);
            this.pRight.Margin = new System.Windows.Forms.Padding(4);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(1060, 614);
            this.pRight.TabIndex = 5;
            // 
            // pContactButtons
            // 
            this.pContactButtons.Controls.Add(this.btnShowAllContacts);
            this.pContactButtons.Controls.Add(this.btnAddContact);
            this.pContactButtons.Controls.Add(this.btnRemoveContact);
            this.pContactButtons.Controls.Add(this.btnEditContact);
            this.pContactButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pContactButtons.Location = new System.Drawing.Point(0, 562);
            this.pContactButtons.Margin = new System.Windows.Forms.Padding(4);
            this.pContactButtons.Name = "pContactButtons";
            this.pContactButtons.Size = new System.Drawing.Size(1060, 52);
            this.pContactButtons.TabIndex = 0;
            // 
            // btnShowAllContacts
            // 
            this.btnShowAllContacts.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnShowAllContacts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(193)))), ((int)(((byte)(163)))));
            this.btnShowAllContacts.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.btnShowAllContacts.Location = new System.Drawing.Point(0, 5);
            this.btnShowAllContacts.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.btnShowAllContacts.Name = "btnShowAllContacts";
            this.btnShowAllContacts.Size = new System.Drawing.Size(170, 40);
            this.btnShowAllContacts.TabIndex = 10;
            this.btnShowAllContacts.Text = "Show All Contacts";
            this.btnShowAllContacts.UseVisualStyleBackColor = false;
            this.btnShowAllContacts.Click += new System.EventHandler(this.btnShowAllContacts_Click);
            // 
            // pLeft
            // 
            this.pLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pLeft.Controls.Add(this.dgvGroups);
            this.pLeft.Controls.Add(this.pGroupButtons);
            this.pLeft.Location = new System.Drawing.Point(13, 89);
            this.pLeft.Margin = new System.Windows.Forms.Padding(4);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(364, 614);
            this.pLeft.TabIndex = 6;
            // 
            // pGroupButtons
            // 
            this.pGroupButtons.Controls.Add(this.btnAddGroup);
            this.pGroupButtons.Controls.Add(this.btnRemoveGroup);
            this.pGroupButtons.Controls.Add(this.btnEditGroup);
            this.pGroupButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pGroupButtons.Location = new System.Drawing.Point(0, 562);
            this.pGroupButtons.Margin = new System.Windows.Forms.Padding(4);
            this.pGroupButtons.Name = "pGroupButtons";
            this.pGroupButtons.Size = new System.Drawing.Size(364, 52);
            this.pGroupButtons.TabIndex = 6;
            // 
            // cbSearch
            // 
            this.cbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(169)))), ((int)(((byte)(161)))));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(1239, 36);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(186, 24);
            this.cbSearch.TabIndex = 5;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(224)))), ((int)(((byte)(195)))));
            this.lblSearch.Location = new System.Drawing.Point(1048, 36);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(171, 26);
            this.lblSearch.TabIndex = 6;
            this.lblSearch.Text = "Search by Name:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(1457, 715);
            this.Controls.Add(this.pLeft);
            this.Controls.Add(this.pRight);
            this.Controls.Add(this.pTop);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contact Book";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pTop.ResumeLayout(false);
            this.pTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
            this.pRight.ResumeLayout(false);
            this.pContactButtons.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pGroupButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pTop;
        private System.Windows.Forms.PictureBox pbProfilePicture;
        private System.Windows.Forms.Label lbProfileName;
        private System.Windows.Forms.Label lbProfile;
        private System.Windows.Forms.LinkLabel llbEditProfile;
        private System.Windows.Forms.DataGridView dgvContacts;
        private System.Windows.Forms.Button btnRemoveGroup;
        private System.Windows.Forms.Button btnEditGroup;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.Button btnEditContact;
        private System.Windows.Forms.Button btnRemoveContact;
        private System.Windows.Forms.DataGridView dgvGroups;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pContactButtons;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pGroupButtons;
        private System.Windows.Forms.Button btnShowAllContacts;
        private System.Windows.Forms.DataGridViewTextBoxColumn group_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn group_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn contact_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.Label lbSelectedGroup;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cbSearch;
    }
}
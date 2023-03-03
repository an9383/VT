namespace VTEventSchedule
{
    partial class frmAppointmentCustomEdit
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnRecurrence = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.edtEndTime = new DevExpress.XtraScheduler.UI.SchedulerTimeEdit();
            this.edtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.edtStartTime = new DevExpress.XtraScheduler.UI.SchedulerTimeEdit();
            this.edtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.holdReasonComobBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.releaseReasonComobBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holdReasonComobBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.releaseReasonComobBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnRecurrence);
            this.layoutControl1.Controls.Add(this.btnDelete);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnOk);
            this.layoutControl1.Controls.Add(this.edtEndTime);
            this.layoutControl1.Controls.Add(this.edtEndDate);
            this.layoutControl1.Controls.Add(this.edtStartTime);
            this.layoutControl1.Controls.Add(this.edtStartDate);
            this.layoutControl1.Controls.Add(this.holdReasonComobBoxEdit);
            this.layoutControl1.Controls.Add(this.releaseReasonComobBoxEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(443, 221);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnRecurrence
            // 
            this.btnRecurrence.AccessibleName = "Recurrence";
            this.btnRecurrence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRecurrence.Location = new System.Drawing.Point(332, 175);
            this.btnRecurrence.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecurrence.Name = "btnRecurrence";
            this.btnRecurrence.Padding = new System.Windows.Forms.Padding(4);
            this.btnRecurrence.Size = new System.Drawing.Size(96, 30);
            this.btnRecurrence.StyleController = this.layoutControl1;
            this.btnRecurrence.TabIndex = 29;
            this.btnRecurrence.Text = "반복일정";
            this.btnRecurrence.Click += new System.EventHandler(this.OnBtnRecurrenceClick);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleName = "Delete";
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.CausesValidation = false;
            this.btnDelete.Location = new System.Drawing.Point(227, 175);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(4);
            this.btnDelete.Size = new System.Drawing.Size(95, 30);
            this.btnDelete.StyleController = this.layoutControl1;
            this.btnDelete.TabIndex = 28;
            this.btnDelete.Text = "삭 제";
            this.btnDelete.Click += new System.EventHandler(this.OnBtnDeleteClick);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Cancel";
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(121, 175);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(4);
            this.btnCancel.Size = new System.Drawing.Size(96, 30);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "취 소";
            // 
            // btnOk
            // 
            this.btnOk.AccessibleName = "Ok";
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(15, 175);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Padding = new System.Windows.Forms.Padding(4);
            this.btnOk.Size = new System.Drawing.Size(96, 30);
            this.btnOk.StyleController = this.layoutControl1;
            this.btnOk.TabIndex = 26;
            this.btnOk.Text = "저 장";
            this.btnOk.Click += new System.EventHandler(this.OnBtnOkClick);
            // 
            // edtEndTime
            // 
            this.edtEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtEndTime.EditValue = new System.DateTime(2005, 3, 31, 0, 0, 0, 0);
            this.edtEndTime.Location = new System.Drawing.Point(226, 135);
            this.edtEndTime.Margin = new System.Windows.Forms.Padding(4);
            this.edtEndTime.Name = "edtEndTime";
            this.edtEndTime.Properties.AccessibleName = "End time";
            this.edtEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtEndTime.Properties.Padding = new System.Windows.Forms.Padding(4);
            this.edtEndTime.Size = new System.Drawing.Size(202, 30);
            this.edtEndTime.StyleController = this.layoutControl1;
            this.edtEndTime.TabIndex = 10;
            // 
            // edtEndDate
            // 
            this.edtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtEndDate.EditValue = new System.DateTime(2005, 3, 31, 0, 0, 0, 0);
            this.edtEndDate.Location = new System.Drawing.Point(98, 135);
            this.edtEndDate.Margin = new System.Windows.Forms.Padding(4);
            this.edtEndDate.Name = "edtEndDate";
            this.edtEndDate.Properties.AccessibleName = "End date";
            this.edtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtEndDate.Properties.MaxValue = new System.DateTime(4000, 1, 1, 0, 0, 0, 0);
            this.edtEndDate.Properties.Padding = new System.Windows.Forms.Padding(4);
            this.edtEndDate.Size = new System.Drawing.Size(118, 30);
            this.edtEndDate.StyleController = this.layoutControl1;
            this.edtEndDate.TabIndex = 9;
            // 
            // edtStartTime
            // 
            this.edtStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStartTime.EditValue = new System.DateTime(2005, 3, 31, 0, 0, 0, 0);
            this.edtStartTime.Location = new System.Drawing.Point(226, 95);
            this.edtStartTime.Margin = new System.Windows.Forms.Padding(4);
            this.edtStartTime.Name = "edtStartTime";
            this.edtStartTime.Properties.AccessibleName = "Start time";
            this.edtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtStartTime.Properties.Padding = new System.Windows.Forms.Padding(4);
            this.edtStartTime.Size = new System.Drawing.Size(202, 30);
            this.edtStartTime.StyleController = this.layoutControl1;
            this.edtStartTime.TabIndex = 7;
            // 
            // edtStartDate
            // 
            this.edtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStartDate.EditValue = new System.DateTime(2005, 3, 31, 0, 0, 0, 0);
            this.edtStartDate.Location = new System.Drawing.Point(98, 95);
            this.edtStartDate.Margin = new System.Windows.Forms.Padding(4);
            this.edtStartDate.Name = "edtStartDate";
            this.edtStartDate.Properties.AccessibleName = "Start date";
            this.edtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtStartDate.Properties.MaxValue = new System.DateTime(4000, 1, 1, 0, 0, 0, 0);
            this.edtStartDate.Properties.Padding = new System.Windows.Forms.Padding(4);
            this.edtStartDate.Size = new System.Drawing.Size(118, 30);
            this.edtStartDate.StyleController = this.layoutControl1;
            this.edtStartDate.TabIndex = 6;
            // 
            // holdReasonComobBoxEdit
            // 
            this.holdReasonComobBoxEdit.Location = new System.Drawing.Point(98, 15);
            this.holdReasonComobBoxEdit.Name = "holdReasonComobBoxEdit";
            this.holdReasonComobBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.holdReasonComobBoxEdit.Properties.Padding = new System.Windows.Forms.Padding(4);
            this.holdReasonComobBoxEdit.Size = new System.Drawing.Size(330, 30);
            this.holdReasonComobBoxEdit.StyleController = this.layoutControl1;
            this.holdReasonComobBoxEdit.TabIndex = 4;
            // 
            // releaseReasonComobBoxEdit
            // 
            this.releaseReasonComobBoxEdit.Location = new System.Drawing.Point(98, 55);
            this.releaseReasonComobBoxEdit.Name = "releaseReasonComobBoxEdit";
            this.releaseReasonComobBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.releaseReasonComobBoxEdit.Properties.Padding = new System.Windows.Forms.Padding(4);
            this.releaseReasonComobBoxEdit.Size = new System.Drawing.Size(330, 30);
            this.releaseReasonComobBoxEdit.StyleController = this.layoutControl1;
            this.releaseReasonComobBoxEdit.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem10,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(443, 221);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.holdReasonComobBoxEdit;
            this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem1.CustomizationFormText = "Hold 사유";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(423, 40);
            this.layoutControlItem1.Text = "Hold 사유";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(71, 16);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.releaseReasonComobBoxEdit;
            this.layoutControlItem10.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem10.CustomizationFormText = "Hold 사유";
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem10.Size = new System.Drawing.Size(423, 40);
            this.layoutControlItem10.Text = "Release 사유";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(71, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.edtStartDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 80);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem2.Size = new System.Drawing.Size(211, 40);
            this.layoutControlItem2.Text = "시작시간";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(71, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.edtEndDate;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem4.Size = new System.Drawing.Size(211, 40);
            this.layoutControlItem4.Text = "종료시간";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(71, 16);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnOk;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 160);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem6.Size = new System.Drawing.Size(106, 41);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnCancel;
            this.layoutControlItem7.Location = new System.Drawing.Point(106, 160);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem7.Size = new System.Drawing.Size(106, 41);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnDelete;
            this.layoutControlItem8.Location = new System.Drawing.Point(212, 160);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem8.Size = new System.Drawing.Size(105, 41);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnRecurrence;
            this.layoutControlItem9.Location = new System.Drawing.Point(317, 160);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem9.Size = new System.Drawing.Size(106, 41);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.edtStartTime;
            this.layoutControlItem3.Location = new System.Drawing.Point(211, 80);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem3.Size = new System.Drawing.Size(212, 40);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.edtEndTime;
            this.layoutControlItem5.Location = new System.Drawing.Point(211, 120);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem5.Size = new System.Drawing.Size(212, 40);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // frmAppointmentCustomEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 221);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmAppointmentCustomEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "일정 편집";
            this.Activated += new System.EventHandler(this.OnAppointmentFormActivated);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holdReasonComobBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.releaseReasonComobBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        protected DevExpress.XtraEditors.ComboBoxEdit holdReasonComobBoxEdit;
        protected DevExpress.XtraEditors.ComboBoxEdit releaseReasonComobBoxEdit;
        protected DevExpress.XtraEditors.DateEdit edtStartDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        protected DevExpress.XtraScheduler.UI.SchedulerTimeEdit edtStartTime;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        protected DevExpress.XtraEditors.DateEdit edtEndDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        protected DevExpress.XtraScheduler.UI.SchedulerTimeEdit edtEndTime;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        protected DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        protected DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        protected DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        protected DevExpress.XtraEditors.SimpleButton btnRecurrence;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}
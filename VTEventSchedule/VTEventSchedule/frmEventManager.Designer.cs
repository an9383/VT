﻿
namespace VTEventSchedule
{
    partial class frmEventManager
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerDataStorage1 = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
            this.vM_AppointmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.schedulerDataSet = new VTEventSchedule.SchedulerDataSet();
            this.vM_ResourcesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.vM_AppointmentsTableAdapter = new VTEventSchedule.SchedulerDataSetTableAdapters.VM_AppointmentsTableAdapter();
            this.vM_ResourcesTableAdapter = new VTEventSchedule.SchedulerDataSetTableAdapters.VM_ResourcesTableAdapter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.logList = new DevExpress.XtraEditors.ListBoxControl();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vM_AppointmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vM_ResourcesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.logList);
            this.layoutControl1.Controls.Add(this.schedulerControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1134, 666);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            this.schedulerControl1.DataStorage = this.schedulerDataStorage1;
            this.schedulerControl1.Location = new System.Drawing.Point(12, 12);
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.Size = new System.Drawing.Size(1110, 543);
            this.schedulerControl1.Start = new System.DateTime(2022, 5, 1, 0, 0, 0, 0);
            this.schedulerControl1.TabIndex = 4;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.AgendaView.Enabled = false;
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.Views.GanttView.Enabled = false;
            this.schedulerControl1.Views.TimelineView.Enabled = false;
            this.schedulerControl1.Views.WeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            this.schedulerControl1.Views.YearView.Enabled = false;
            this.schedulerControl1.Views.YearView.UseOptimizedScrolling = false;
            this.schedulerControl1.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.schedulerControl1_EditAppointmentFormShowing);
            // 
            // schedulerDataStorage1
            // 
            // 
            // 
            // 
            this.schedulerDataStorage1.AppointmentDependencies.AutoReload = false;
            // 
            // 
            // 
            this.schedulerDataStorage1.Appointments.DataSource = this.vM_AppointmentsBindingSource;
            this.schedulerDataStorage1.Appointments.Labels.CreateNewLabel(0, "None", "&None", System.Drawing.SystemColors.Window);
            this.schedulerDataStorage1.Appointments.Labels.CreateNewLabel(1, "Important", "&Important", System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(190))))));
            this.schedulerDataStorage1.Appointments.Labels.CreateNewLabel(2, "Business", "&Business", System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(213)))), ((int)(((byte)(255))))));
            this.schedulerDataStorage1.Appointments.Labels.CreateNewLabel(3, "Personal", "&Personal", System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(244)))), ((int)(((byte)(156))))));
            this.schedulerDataStorage1.Appointments.Labels.CreateNewLabel(4, "Vacation", "&Vacation", System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(228)))), ((int)(((byte)(199))))));
            this.schedulerDataStorage1.Appointments.Labels.CreateNewLabel(5, "Must Attend", "Must &Attend", System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(206)))), ((int)(((byte)(147))))));
            this.schedulerDataStorage1.Appointments.Labels.CreateNewLabel(6, "Travel Required", "&Travel Required", System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(244)))), ((int)(((byte)(255))))));
            this.schedulerDataStorage1.Appointments.Labels.CreateNewLabel(7, "Needs Preparation", "&Needs Preparation", System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(152))))));
            this.schedulerDataStorage1.Appointments.Labels.CreateNewLabel(8, "Birthday", "&Birthday", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(207)))), ((int)(((byte)(233))))));
            this.schedulerDataStorage1.Appointments.Labels.CreateNewLabel(9, "Anniversary", "&Anniversary", System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(233)))), ((int)(((byte)(223))))));
            this.schedulerDataStorage1.Appointments.Labels.CreateNewLabel(10, "Phone Call", "Phone &Call", System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(165))))));
            this.schedulerDataStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerDataStorage1.Appointments.Mappings.End = "EndDate";
            this.schedulerDataStorage1.Appointments.Mappings.Label = "Label";
            this.schedulerDataStorage1.Appointments.Mappings.Location = "Location";
            this.schedulerDataStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            this.schedulerDataStorage1.Appointments.Mappings.ResourceId = "ResourceID";
            this.schedulerDataStorage1.Appointments.Mappings.Start = "StartDate";
            this.schedulerDataStorage1.Appointments.Mappings.Status = "Status";
            this.schedulerDataStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerDataStorage1.Appointments.Mappings.TimeZoneId = "TimeZoneId";
            this.schedulerDataStorage1.Appointments.Mappings.Type = "Type";
            // 
            // 
            // 
            this.schedulerDataStorage1.Resources.DataSource = this.vM_ResourcesBindingSource;
            this.schedulerDataStorage1.Resources.Mappings.Caption = "ResourceName";
            this.schedulerDataStorage1.Resources.Mappings.Color = "Color";
            this.schedulerDataStorage1.Resources.Mappings.Id = "ResourceID";
            // 
            // vM_AppointmentsBindingSource
            // 
            this.vM_AppointmentsBindingSource.DataMember = "VM_Appointments";
            this.vM_AppointmentsBindingSource.DataSource = this.schedulerDataSet;
            // 
            // schedulerDataSet
            // 
            this.schedulerDataSet.DataSetName = "SchedulerDataSet";
            this.schedulerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vM_ResourcesBindingSource
            // 
            this.vM_ResourcesBindingSource.DataMember = "VM_Resources";
            this.vM_ResourcesBindingSource.DataSource = this.schedulerDataSet;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1134, 666);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.schedulerControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1114, 547);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // vM_AppointmentsTableAdapter
            // 
            this.vM_AppointmentsTableAdapter.ClearBeforeFill = true;
            // 
            // vM_ResourcesTableAdapter
            // 
            this.vM_ResourcesTableAdapter.ClearBeforeFill = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // logList
            // 
            this.logList.Location = new System.Drawing.Point(12, 559);
            this.logList.Name = "logList";
            this.logList.Size = new System.Drawing.Size(1110, 95);
            this.logList.StyleController = this.layoutControl1;
            this.logList.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.logList;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 547);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1114, 99);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmEventManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 666);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmEventManager";
            this.Text = "사업부별 무가동 계획";
            this.Load += new System.EventHandler(this.frmEventManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vM_AppointmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vM_ResourcesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.SchedulerDataStorage schedulerDataStorage1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private SchedulerDataSet schedulerDataSet;
        private System.Windows.Forms.BindingSource vM_AppointmentsBindingSource;
        private SchedulerDataSetTableAdapters.VM_AppointmentsTableAdapter vM_AppointmentsTableAdapter;
        private SchedulerDataSetTableAdapters.VM_ResourcesTableAdapter vM_ResourcesTableAdapter;
        private System.Windows.Forms.BindingSource vM_ResourcesBindingSource;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.ListBoxControl logList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}


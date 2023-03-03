using DevExpress.Utils.Internal;
using DevExpress.Utils.Menu;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Native;
using DevExpress.XtraScheduler.Localization;
using DevExpress.XtraScheduler.Native;
using DevExpress.XtraScheduler.UI;
using DevExpress.XtraScheduler;
using DevExpress.XtraWaitForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Authentication.ExtendedProtection;
using VTEventSchedule.Models;

namespace VTEventSchedule
{
    public partial class frmAppointmentCustomEdit : DevExpress.XtraEditors.XtraForm, IDXManagerPopupMenu
    {
        #region Fields
        bool openRecurrenceForm;
        readonly ISchedulerStorage storage;
        readonly SchedulerControl control;
        Icon recurringIcon;
        Icon normalIcon;
        readonly AppointmentFormController controller;
        IDXMenuManager menuManager;
        string errMsg = "";
        #endregion

        clsCode code = new clsCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public frmAppointmentCustomEdit()
        {
            InitializeComponent();
        }
        public frmAppointmentCustomEdit(SchedulerControl control, Appointment apt)
            : this(control, apt, false)
        {
        }
        public frmAppointmentCustomEdit(SchedulerControl control, Appointment apt, bool openRecurrenceForm)
        {
            Guard.ArgumentNotNull(control, "control");
            Guard.ArgumentNotNull(control.DataStorage, "control.DataStorage");
            Guard.ArgumentNotNull(apt, "apt");

            this.openRecurrenceForm = openRecurrenceForm;
            this.controller = CreateController(control, apt);
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            DataView reasonView = code.GetHoldReason();

            foreach (DataRowView item in reasonView)
            {
                holdReasonComobBoxEdit.Properties.Items.Add(item[0].ToString());
            }

            reasonView = code.GetReleaseReason();

            foreach (DataRowView item in reasonView)
            {
                releaseReasonComobBoxEdit.Properties.Items.Add(item[0].ToString());
            }

            LoadIcons();

            this.control = control;
            this.storage = control.Storage;

            SubscribeControllerEvents(Controller);
            BindControllerToControls();

            

        }
        #region Properties
        protected override FormShowMode ShowMode { get { return DevExpress.XtraEditors.FormShowMode.AfterInitialization; } }
        public IDXMenuManager MenuManager { get { return menuManager; } private set { menuManager = value; } }
        protected internal AppointmentFormController Controller { get { return controller; } }
        protected internal SchedulerControl Control { get { return control; } }
        protected internal ISchedulerStorage Storage { get { return storage; } }
        protected internal bool IsNewAppointment { get { return controller != null ? controller.IsNewAppointment : true; } }
        protected internal Icon RecurringIcon { get { return recurringIcon; } }
        protected internal Icon NormalIcon { get { return normalIcon; } }
        protected internal bool OpenRecurrenceForm { get { return openRecurrenceForm; } }
        public bool ReadOnly
        {
            get { return Controller != null && Controller.ReadOnly; }
            set
            {
                if (Controller.ReadOnly == value)
                    return;
                Controller.ReadOnly = value;
            }
        }
        #endregion

        #region #CustomFieldData
        string _contacts;

        public virtual bool IsAppointmentChanged(Appointment appointment)
        {
            if (_contacts == appointment.CustomFields["Contacts"].ToString())
                return false;
            else
                return true;
        }
        #endregion #CustomFieldData

        public virtual void SetMenuManager(DevExpress.Utils.Menu.IDXMenuManager menuManager)
        {
            MenuManagerUtils.SetMenuManager(Controls, menuManager);
            this.menuManager = menuManager;
        }

        protected virtual void BindControllerToControls()
        {
            BindControllerToIcon();
            BindProperties(this.holdReasonComobBoxEdit, "Text", "Subject");
            BindProperties(this.releaseReasonComobBoxEdit, "Text", "Location");
            BindProperties(this.edtStartDate, "EditValue", "DisplayStartDate");
            BindProperties(this.edtStartDate, "Enabled", "IsDateTimeEditable");
            BindProperties(this.edtStartTime, "EditValue", "DisplayStartTime");
            BindProperties(this.edtStartTime, "Visible", "IsTimeVisible");
            BindProperties(this.edtStartTime, "Enabled", "IsTimeVisible");
            BindProperties(this.edtEndDate, "EditValue", "DisplayEndDate", DataSourceUpdateMode.Never);
            BindProperties(this.edtEndDate, "Enabled", "IsDateTimeEditable", DataSourceUpdateMode.Never);
            BindProperties(this.edtEndTime, "EditValue", "DisplayEndTime", DataSourceUpdateMode.Never);
            BindProperties(this.edtEndTime, "Visible", "IsTimeVisible", DataSourceUpdateMode.Never);
            BindProperties(this.edtEndTime, "Enabled", "IsTimeVisible", DataSourceUpdateMode.Never);
            //BindProperties(this.chkAllDay, "Checked", "AllDay");
            //BindProperties(this.chkAllDay, "Enabled", "IsDateTimeEditable");

            Controller.AllDay = false;

            BindToBoolPropertyAndInvert(this.btnOk, "Enabled", "ReadOnly");
            BindToBoolPropertyAndInvert(this.btnRecurrence, "Enabled", "ReadOnly");
            BindProperties(this.btnDelete, "Enabled", "CanDeleteAppointment");
            BindProperties(this.btnRecurrence, "Visible", "ShouldShowRecurrenceButton");
        }
        protected virtual void BindControllerToIcon()
        {
            Binding binding = new Binding("Icon", Controller, "AppointmentType");
            binding.Format += AppointmentTypeToIconConverter;
            DataBindings.Add(binding);
        }
        protected virtual void ObjectToStringConverter(object o, ConvertEventArgs e)
        {
            e.Value = e.Value.ToString();
        }
        protected virtual void AppointmentTypeToIconConverter(object o, ConvertEventArgs e)
        {
            AppointmentType type = (AppointmentType)e.Value;
            if (type == AppointmentType.Pattern)
                e.Value = RecurringIcon;
            else
                e.Value = NormalIcon;
        }
        protected virtual void BindProperties(Control target, string targetProperty, string sourceProperty)
        {
            BindProperties(target, targetProperty, sourceProperty, DataSourceUpdateMode.OnPropertyChanged);
        }
        protected virtual void BindProperties(Control target, string targetProperty, string sourceProperty, DataSourceUpdateMode updateMode)
        {
            target.DataBindings.Add(targetProperty, Controller, sourceProperty, true, updateMode);
        }
        protected virtual void BindProperties(Control target, string targetProperty, string sourceProperty, ConvertEventHandler objectToStringConverter)
        {
            Binding binding = new Binding(targetProperty, Controller, sourceProperty, true);
            binding.Format += objectToStringConverter;
            target.DataBindings.Add(binding);
        }
        protected virtual void BindToBoolPropertyAndInvert(Control target, string targetProperty, string sourceProperty)
        {
            target.DataBindings.Add(new BoolInvertBinding(targetProperty, Controller, sourceProperty));
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Controller == null)
                return;
            this.DataBindings.Add("Text", Controller, "Caption");
            SubscribeControlsEvents();
        }
        protected virtual AppointmentFormController CreateController(SchedulerControl control, Appointment apt)
        {
            return new AppointmentFormController(control, apt);
        }
        void SubscribeControllerEvents(AppointmentFormController controller)
        {
            if (controller == null)
                return;
            controller.PropertyChanged += OnControllerPropertyChanged;
        }
        void OnControllerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ReadOnly")
                UpdateReadonly();
        }
        protected virtual void UpdateReadonly()
        {
            if (Controller == null)
                return;
            IList<Control> controls = GetAllControls(this);
            foreach (Control control in controls)
            {
                BaseEdit editor = control as BaseEdit;
                if (editor == null)
                    continue;
                editor.ReadOnly = Controller.ReadOnly;
            }
            this.btnOk.Enabled = !Controller.ReadOnly;
            this.btnRecurrence.Enabled = !Controller.ReadOnly;
        }

        List<Control> GetAllControls(Control rootControl)
        {
            List<Control> result = new List<Control>();
            foreach (Control control in rootControl.Controls)
            {
                result.Add(control);
                IList<Control> childControls = GetAllControls(control);
                result.AddRange(childControls);
            }
            return result;
        }
        protected internal virtual void LoadIcons()
        {
            Assembly asm = typeof(SchedulerControl).Assembly;
            recurringIcon = ResourceImageHelper.CreateIconFromResources(SchedulerIconNames.RecurringAppointment, asm);
            normalIcon = ResourceImageHelper.CreateIconFromResources(SchedulerIconNames.Appointment, asm);
        }
        protected internal virtual void SubscribeControlsEvents()
        {
            this.edtEndDate.Validating += new CancelEventHandler(OnEdtEndDateValidating);
            this.edtEndDate.InvalidValue += new InvalidValueExceptionEventHandler(OnEdtEndDateInvalidValue);
            this.edtEndTime.Validating += new CancelEventHandler(OnEdtEndTimeValidating);
            this.edtEndTime.InvalidValue += new InvalidValueExceptionEventHandler(OnEdtEndTimeInvalidValue);
        }
        protected internal virtual void UnsubscribeControlsEvents()
        {
            this.edtEndDate.Validating -= new CancelEventHandler(OnEdtEndDateValidating);
            this.edtEndDate.InvalidValue -= new InvalidValueExceptionEventHandler(OnEdtEndDateInvalidValue);
            this.edtEndTime.Validating -= new CancelEventHandler(OnEdtEndTimeValidating);
            this.edtEndTime.InvalidValue -= new InvalidValueExceptionEventHandler(OnEdtEndTimeInvalidValue);
        }
        void OnBtnOkClick(object sender, System.EventArgs e)
        {
            OnOkButton();
        }
        protected internal virtual void OnEdtEndDateValidating(object sender, CancelEventArgs e)
        {
            e.Cancel = !IsValidInterval();
            if (!e.Cancel)
                this.edtEndDate.DataBindings["EditValue"].WriteValue();
        }
        protected internal virtual void OnEdtEndDateInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_InvalidEndDate);
        }
        protected internal virtual void OnEdtEndTimeValidating(object sender, CancelEventArgs e)
        {
            e.Cancel = !IsValidInterval();
            if (!e.Cancel)
                this.edtEndTime.DataBindings["EditValue"].WriteValue();
        }
        protected internal virtual void OnEdtEndTimeInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_InvalidEndDate);
        }
        protected internal virtual bool IsValidInterval()
        {
            errMsg = "";

            DateTime startDate = new DateTime(edtStartDate.DateTime.Date.Year, edtStartDate.DateTime.Date.Month, edtStartDate.DateTime.Date.Day,
                          edtStartTime.Time.Hour, edtStartTime.Time.Minute, edtStartTime.Time.Second);

            DateTime endDate = new DateTime(edtEndDate.DateTime.Date.Year, edtEndDate.DateTime.Date.Month, edtEndDate.DateTime.Date.Day,
                          edtEndTime.Time.Hour, edtEndTime.Time.Minute, edtEndTime.Time.Second);

            TimeSpan tSpan = endDate - startDate;
            if (tSpan.TotalMinutes < 5)
            {
                errMsg = "일정 간격은 최소 5분 이상으로 설정하세요.";
                return false;
            }
            else
            {
                return AppointmentFormControllerBase.ValidateInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay);
            }
        }
        protected internal virtual void OnOkButton()
        {
            if (!Controller.IsConflictResolved())
            {
                ShowMessageBox(SchedulerLocalizer.GetString(SchedulerStringId.Msg_Conflict), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Controller.IsAppointmentChanged() || Controller.IsNewAppointment || IsAppointmentChanged(Controller.EditedAppointmentCopy))
                Controller.ApplyChanges();

            this.DialogResult = DialogResult.OK;
        }
        protected internal virtual DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return XtraMessageBox.Show(this, text, caption, buttons, icon);
        }
        void OnBtnDeleteClick(object sender, System.EventArgs e)
        {
            OnDeleteButton();
        }
        protected internal virtual void OnDeleteButton()
        {
            if (IsNewAppointment)
                return;

            Controller.DeleteAppointment();

            DialogResult = DialogResult.Abort;
            Close();
        }
        void OnBtnRecurrenceClick(object sender, System.EventArgs e)
        {
            OnRecurrenceButton();
        }
        protected internal virtual void OnRecurrenceButton()
        {
            if (!Controller.ShouldShowRecurrenceButton)
                return;

            Appointment patternCopy = Controller.PrepareToRecurrenceEdit();

            DialogResult result;
            using (Form form = CreateAppointmentRecurrenceForm(patternCopy, Control.OptionsView.FirstDayOfWeek))
            {
                result = ShowRecurrenceForm(form);
            }

            if (result == DialogResult.Abort)
            {
                Controller.RemoveRecurrence();
            }
            else if (result == DialogResult.OK)
            {
                Controller.ApplyRecurrence(patternCopy);
            }
        }
        protected virtual DialogResult ShowRecurrenceForm(Form form)
        {
            return FormTouchUIAdapter.ShowDialog(form, this);
        }
        protected internal virtual Form CreateAppointmentRecurrenceForm(Appointment patternCopy, FirstDayOfWeek firstDayOfWeek)
        {
            AppointmentRecurrenceForm form = new AppointmentRecurrenceForm(patternCopy, firstDayOfWeek, Controller);
            form.SetMenuManager(MenuManager);
            form.LookAndFeel.ParentLookAndFeel = LookAndFeel;
            form.ShowExceptionsRemoveMsgBox = controller.AreExceptionsPresent();
            return form;
        }
        internal void OnAppointmentFormActivated(object sender, EventArgs e)
        {
   
            if (openRecurrenceForm)
            {
                openRecurrenceForm = false;
                OnRecurrenceButton();
            }

            
        }

        protected internal virtual void OnCbReminderInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_InvalidReminderTimeBeforeStart);
        }

    }
}
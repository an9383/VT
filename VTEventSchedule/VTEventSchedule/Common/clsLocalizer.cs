using DevExpress.XtraScheduler.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTEventSchedule.Common
{
    public class clsSchedulerLocalizer : SchedulerLocalizer
    {
        public override string GetLocalizedString(SchedulerStringId id)
        {
            string localString = "";

            switch (id)
            {
                case SchedulerStringId.MenuCmd_NewAppointment:
                    localString =  "새 일정";
                    break;
                case SchedulerStringId.MenuCmd_NewAllDayEvent:
                    localString = "새 AllDay일정";
                    break;
                case SchedulerStringId.MenuCmd_NewRecurringAppointment:
                    localString = "새 반복일정";
                    break;
                case SchedulerStringId.MenuCmd_NewRecurringEvent:
                    localString = "새 반복작업";
                    break;
                case SchedulerStringId.MenuCmd_GotoDate:
                    localString = "일별로";
                    break;
                case SchedulerStringId.MenuCmd_GotoThisDay:
                    localString = "선택된 일자로";
                    break;
                case SchedulerStringId.MenuCmd_GotoToday:
                    localString = "오늘로";
                    break;
                case SchedulerStringId.MenuCmd_SwitchViewMenu:
                    localString = "뷰 변경";
                    break;
                case SchedulerStringId.MenuCmd_SwitchToDayView:
                    localString = "일간 뷰";
                    break;
                case SchedulerStringId.MenuCmd_SwitchToMonthView:
                    localString = "월간 뷰";
                    break;
                case SchedulerStringId.MenuCmd_OpenAppointment:
                    localString = "일정 열기";
                    break;
                case SchedulerStringId.MenuCmd_EditSeries:
                    localString = "반복일정 수정";
                    break;
                case SchedulerStringId.MenuCmd_RestoreOccurrence:
                    localString = "일정 구분 초기화";
                    break;
                case SchedulerStringId.MenuCmd_ShowTimeAs:
                    localString = "일정 구분";
                    break;
                case SchedulerStringId.MenuCmd_Free:
                    localString = "자유";
                    break;
                case SchedulerStringId.MenuCmd_Tentative:
                    localString = "잠정";
                    break;
                case SchedulerStringId.MenuCmd_Busy:
                    localString = "긴급";
                    break;
                case SchedulerStringId.MenuCmd_OutOfOffice:
                    localString = "외근";
                    break;
                case SchedulerStringId.MenuCmd_WorkingElsewhere:
                    localString = "출장";
                    break;
                case SchedulerStringId.MenuCmd_DeleteAppointment:
                    localString = "삭제";
                    break;
                case SchedulerStringId.MenuCmd_LabelAs:
                    localString = "라벨";
                    break;
                case SchedulerStringId.Caption_Appointment:
                    localString = "일정";
                    break;
                case SchedulerStringId.Caption_Event:
                    localString = "작업";
                    break;
                case SchedulerStringId.Abbr_Minute:
                case SchedulerStringId.Abbr_Minutes:
                    localString = "분";
                    break;
                case SchedulerStringId.Abbr_Hour:
                case SchedulerStringId.Abbr_Hours:
                    localString = "시간";
                    break;
                case SchedulerStringId.Abbr_Day:
                case SchedulerStringId.Abbr_Days:
                    localString = "일";
                    break;
                case SchedulerStringId.Abbr_Week:
                case SchedulerStringId.Abbr_Weeks:
                    localString = "주";
                    break;
                case SchedulerStringId.FlyoutCaption_Reminder:
                case SchedulerStringId.Caption_NoneReminder:
       
                    localString = "";
                    break;
                default:
                    localString = base.GetLocalizedString(id);
                    break;
            }

            return localString;
        }
    }
}

import CalendarTest from "../../../components/Utilities/myCalendar"
import FullCalendar from "@fullcalendar/react";
// The import order DOES MATTER here. If you change it, you'll get an error!
import interactionPlugin from "@fullcalendar/interaction";
import timeGridPlugin from "@fullcalendar/timegrid";

export default function myCalendar(){
    return(
        <div>
            <CalendarTest></CalendarTest>
    
        </div>
    )
}
import { PatientModel } from "./patient.model";

export class AppointmentsModel{
    id: string = "";
    startDate: string = "";
    endDate: string = "";
    title: string = "";
    patient: PatientModel = new PatientModel();


}
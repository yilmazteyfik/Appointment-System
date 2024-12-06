import { Pipe, PipeTransform } from '@angular/core';
import { DoctorModel } from '../models/doctor.models';

@Pipe({
  name: 'doctor'
})
export class DoctorPipe implements PipeTransform {

  transform(value: DoctorModel[], search: string): DoctorModel[] {
    if (!search) {return value;}

    return value.filter(x=> 
      x.fullName.toLocaleLowerCase().includes(search.toLocaleLowerCase()) ||
      x.department.name.toLocaleLowerCase().includes(search.toLocaleLowerCase())
    )
  }

}

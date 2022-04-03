import { Pipe, PipeTransform } from '@angular/core';
import { Airplane } from '../models/airplane';

@Pipe({
  name: 'filterPipe'
})
export class FilterPipePipe implements PipeTransform {

  transform(value: Airplane[], filterText:string): Airplane[] {
    filterText = filterText?filterText.toLocaleLowerCase():""
    
    return filterText?value.filter((a:Airplane)=>a.airplaneName.toLocaleLowerCase().indexOf(filterText)!==-1):value;
  }

}

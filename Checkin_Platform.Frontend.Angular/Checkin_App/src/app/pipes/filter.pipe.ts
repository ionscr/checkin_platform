import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter',
})
export class FilterPipe implements PipeTransform {
  transform(
    items: any[],
    callback: (item: any, schedule: any) => boolean,
    schedule: any
  ): any {
    if (!items || !callback) {
      return items;
    }
    return items.filter((item) => callback(item, schedule));
  }
}

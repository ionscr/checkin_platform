import { Injectable } from "@angular/core";

import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Action } from "@ngrx/store";

import { Observable, of } from "rxjs";
import { map, mergeMap, catchError } from "rxjs/operators";

import { ClassService } from "../class.service";
import * as classActions from "./class.actions";
import { Class } from "../class.model";

@Injectable()
export class ClassEffect {
  constructor(private actions$: Actions, private classService: ClassService) {}

  loadClasses$ = createEffect( () => this.actions$.pipe(
    ofType<classActions.LoadClasses>(
      classActions.ClassActionTypes.LOAD_CLASSES
    ),
    mergeMap((action: classActions.LoadClasses) =>
      this.classService.GetClasses().pipe(
        map(
          (classes: Class[]) =>
            new classActions.LoadClassesSuccess(classes)
        ),
        catchError(err => of(new classActions.LoadClassesFail(err)))
      ))
    )
  );

// createClass$ = createEffect( () => this.actions$.pipe(
//         ofType<classActions.CreateClass>(
//           classActions.ClassActionTypes.CREATE_CLASS
//         ),
//         map((action: classActions.CreateClass) => action.payload),
//         mergeMap((class: Class) =>
//           this.classService.CreateClass(class).pipe(
//             map(
//               (newClass: Class) =>
//                 new classActions.CreateClassSuccess(newClass)
//             ),
//             catchError(err => of(new classActions.CreateClassFail(err)))
//           ))
//         )
//       );


//   updateClass$ = createEffect( () => this.actions$.pipe(
//     ofType<classActions.UpdateClass>(
//       classActions.ClassActionTypes.UPDATE_CLASS
//     ),
//     map((action: classActions.UpdateClass) => action.payload),
//     mergeMap((class: Class) =>
//       this.classService.UpdateClass(class).pipe(
//         map(
//           (updateClass: Class) =>
//             new classActions.UpdateClassSuccess({
//               id: updateClass.id,
//               changes: updateClass
//             })
//         ),
//         catchError(err => of(new classActions.UpdateClassFail(err)))
//       ))
//     )
//   );


  deleteClass$ = createEffect( () => this.actions$.pipe(
    ofType<classActions.DeleteClass>(
      classActions.ClassActionTypes.DELETE_CLASS
    ),
    map((action: classActions.DeleteClass) => action.payload),
    mergeMap((id: number) =>
      this.classService.DeleteClass(id).pipe(
        map(() => new classActions.DeleteClassSuccess(id)),
        catchError(err => of(new classActions.DeleteClassFail(err)))
      ))
    )
  );
}
import * as store from "@ngrx/store";

import { Update } from "@ngrx/entity";

import { Class } from "../class.model";

export enum ClassActionTypes {
    LOAD_CLASSES = "[Class] Load Classes",
    LOAD_CLASSES_SUCCESS = "[Class] Load Classes Success",
    LOAD_CLASSES_FAIL = "[Class] Load Classes Fail",
    CREATE_CLASS = "[Class] Create Class",
    CREATE_CLASS_SUCCESS = "[Class] Create Class Success",
    CREATE_CLASS_FAIL = "[Class] Create Class Fail",
    UPDATE_CLASS = "[Class] Update Class",
    UPDATE_CLASS_SUCCESS = "[Class] Update Class Success",
    UPDATE_CLASS_FAIL = "[Class] Update Class Fail",
    DELETE_CLASS = "[Class] Delete Class",
    DELETE_CLASS_SUCCESS = "[Class] Delete Class Success",
    DELETE_CLASS_FAIL = "[Class] Delete Class Fail"
  }
  
  export class LoadClasses implements store.Action {
    readonly type = ClassActionTypes.LOAD_CLASSES;
  }
  
  export class LoadClassesSuccess implements store.Action {
    readonly type = ClassActionTypes.LOAD_CLASSES_SUCCESS;
  
    constructor(public payload: Class[]) {}
  }
  
  export class LoadClassesFail implements store.Action {
    readonly type = ClassActionTypes.LOAD_CLASSES_FAIL;
  
    constructor(public payload: string) {}
  }
  
  export class CreateClass implements store.Action {
    readonly type = ClassActionTypes.CREATE_CLASS;
  
    constructor(public payload: Class) {}
  }
  
  export class CreateClassSuccess implements store.Action {
    readonly type = ClassActionTypes.CREATE_CLASS_SUCCESS;
  
    constructor(public payload: Class) {}
  }
  
  export class CreateClassFail implements store.Action {
    readonly type = ClassActionTypes.CREATE_CLASS_FAIL;
  
    constructor(public payload: string) {}
  }
  
  export class UpdateClass implements store.Action {
    readonly type = ClassActionTypes.UPDATE_CLASS;
  
    constructor(public payload: Class) {}
  }
  
  export class UpdateClassSuccess implements store.Action {
    readonly type = ClassActionTypes.UPDATE_CLASS_SUCCESS;
  
    constructor(public payload: Update<Class>) {}
  }
  
  export class UpdateClassFail implements store.Action {
    readonly type = ClassActionTypes.UPDATE_CLASS_FAIL;
  
    constructor(public payload: string) {}
  }
  
  export class DeleteClass implements store.Action {
    readonly type = ClassActionTypes.DELETE_CLASS;
  
    constructor(public payload: number) {}
  }
  
  export class DeleteClassSuccess implements store.Action {
    readonly type = ClassActionTypes.DELETE_CLASS_SUCCESS;
  
    constructor(public payload: number) {}
  }
  
  export class DeleteClassFail implements store.Action {
    readonly type = ClassActionTypes.DELETE_CLASS_FAIL;
  
    constructor(public payload: string) {}
  }
  
  export type Action =
    | LoadClasses
    | LoadClassesSuccess
    | LoadClassesFail
    | CreateClass
    | CreateClassSuccess
    | CreateClassFail
    | UpdateClass
    | UpdateClassSuccess
    | UpdateClassFail
    | DeleteClass
    | DeleteClassSuccess
    | DeleteClassFail;
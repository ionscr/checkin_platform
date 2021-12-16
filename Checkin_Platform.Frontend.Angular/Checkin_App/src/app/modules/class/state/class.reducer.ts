import * as classActions from "./class.actions";
import * as fromRoot from '../../../state/app.state'
import { EntityState, EntityAdapter, createEntityAdapter } from "@ngrx/entity";

import { Class } from "../class.model";

export interface ClassState extends EntityState<Class> {
  selectedClassId: number | null;
  loading: boolean;
  loaded: boolean;
  error: string;
}

export interface AppState extends fromRoot.AppState {
  classes: ClassState;
}

export const classAdapter: EntityAdapter<Class> = createEntityAdapter<Class>();

export const defaultClass: ClassState = {
  ids: [],
  entities: {},
  selectedClassId: null,
  loading: false,
  loaded: false,
  error: ""
};

export const initialState = classAdapter.getInitialState(defaultClass);

export function classReducer(
  state = initialState,
  action: classActions.Action
): ClassState {
  switch (action.type) {
    case classActions.ClassActionTypes.LOAD_CLASSES_SUCCESS: {
      return classAdapter.setAll(action.payload, {
        ...state,
        loading: false,
        loaded: true
      });
    }
    case classActions.ClassActionTypes.LOAD_CLASSES_FAIL: {
      return {
        ...state,
        entities: {},
        loading: false,
        loaded: false,
        error: action.payload
      };
    }

    case classActions.ClassActionTypes.CREATE_CLASS_SUCCESS: {
      return classAdapter.addOne(action.payload, state);
    }
    case classActions.ClassActionTypes.CREATE_CLASS_FAIL: {
      return {
        ...state,
        error: action.payload
      };
    }

    case classActions.ClassActionTypes.UPDATE_CLASS_SUCCESS: {
      return classAdapter.updateOne(action.payload, state);
    }
    case classActions.ClassActionTypes.UPDATE_CLASS_FAIL: {
      return {
        ...state,
        error: action.payload
      };
    }

    case classActions.ClassActionTypes.DELETE_CLASS_SUCCESS: {
      return classAdapter.removeOne(action.payload, state);
    }
    case classActions.ClassActionTypes.DELETE_CLASS_FAIL: {
      return {
        ...state,
        error: action.payload
      };
    }

    default: {
      return state;
    }
  }
}
